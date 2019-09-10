using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Globalization;


namespace WindowsFormsApplication1
{
    using WarehouseService;
    public partial class fmLotSplit : Form
    {
        private string lot = "";
        private string g_NyPid = "";

        public fmLotSplit()
        {
            InitializeComponent();
        }

        MyToolbox mt = new MyToolbox();

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmLotSplit));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                switch (Globals.GlobalStep)
                {
                    case 0:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            string lokation = "";
                            string placering = "";
                            string varenr = "";
                            string beskrivelse = "";
                            decimal antal = 0;
                            DateTime mhd = DateTime.UtcNow;
                            string uof = "";
                            string vl = "";
                            lot = tbInputData.Text;
                            try
                            {
                                if (!WareHouse.WSReturnLotInfo(tbInputData.Text.ToString(), Globals.theLocation, ref placering, ref varenr, ref beskrivelse, ref antal, ref mhd, ref uof, ref vl))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                                    break;
                                }
                                else
                                {
                                    lokation = Globals.theLocation;
                                    lbLocation.Text = lokation;
                                    lbBin.Text = placering;
                                    lbItemNo.Text = varenr;
                                    lbDescription.Text = beskrivelse;
                                    lbQuantity.Text = antal.ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat); 
                                    lbExpiredate.Text = mhd.ToShortDateString();
                                    lbUnitOfMesure.Text = uof;
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText2") ;
                                    tbInputData.Text = "";
                                    lbFromPID.Text = lot;
                                    lbVendorLot.Text = vl;
                                    Globals.step++;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                WareHouse.Dispose();
                                tbInputData.Text = "";
                            }
                        }
                        break;
                    case 1:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

                            if (decimal.Parse(tbInputData.Text) >= decimal.Parse(lbQuantity.Text))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Message4"), (decimal.Parse(lbQuantity.Text)).ToString()));
                                break;
                            }
                            
                            lbNewQty.Text = tbInputData.Text;
                            tbInputData.Text = "";
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3");
                            
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            
                            g_NyPid = WareHouse.WSReturnNewPID();
                            WareHouse.WSPrintPidPrev(g_NyPid, Globals.theWinlogon, lbItemNo.Text, lbNewQty.Text, lbExpiredate.Text, lbVendorLot.Text, lbUnitOfMesure.Text); 
                            // Print af ny label.
                            if (Globals.theShowMessage)
                                MessageBoxExample.MyMessageBox.ShowBox(g_NyPid.ToString());   
                            WareHouse.Dispose();
                            Globals.step++;
                        }
                        break;
                    case 2:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;
                            if (!g_NyPid.Equals(tbInputData.Text))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
                                break;
                            }

                            lbNewLot.Text = tbInputData.Text;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
                            tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                            Globals.step++;
                        }
                        break;
                    case 3:
                        {
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                            this.pbIndicator.Visible = true;

                            try
                            {
                                WareHouse.WSPostLotSplit(Globals.theTransferTemplateName, Globals.theTransferBatchName, lbItemNo.Text.ToString(), lbUnitOfMesure.Text, Globals.theWinlogon, lbLocation.Text.ToString(), lbBin.Text.ToString(), lot.ToString(), lbLocation.Text.ToString(), lbBin.Text.ToString(), lbNewLot.Text.ToString(), decimal.Parse(lbNewQty.Text.ToString()), false, DateTime.Parse(lbExpiredate.Text.ToString()), DateTime.Now, lbVendorLot.Text);
                                WareHouse.WSPrintPid(lbFromPID.Text, Globals.theWinlogon);
                            }
                            catch (Exception ex)
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText1");
                                tbInputData.Text = "";
                                lbLocation.Text = "";
                                lbBin.Text = "";
                                lbItemNo.Text = "";
                                lbDescription.Text = "";
                                lbQuantity.Text = "";
                                lbExpiredate.Text = "";
                                lbNewQty.Text = "";
                                lbNewLot.Text = "";
                                lbUnitOfMesure.Text = "";
                                lbVendorLot.Text = "";
                                lbFromPID.Text = "";
                                WareHouse.Dispose();
                                Globals.step = 0;
                            }
                        }
                        break;
                }
            }

            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                switch (Globals.step)
                {
                    case 4:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
                            tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1"); 
                        }
                        break;
                    case 3:
                        {
                            Globals.step--;
                            tbInputData.Text = "";
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); 
                        }
                        break;
                    case 2:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText2");
                            tbInputData.Text = "";
                        }
                        break;
                    case 1:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText1"); 
                            tbInputData.Text = "";
                            lbLocation.Text = "";
                            lbBin.Text = "";
                            lbItemNo.Text = "";
                            lbDescription.Text = "";
                            lbQuantity.Text = "";
                            lbExpiredate.Text = "";
                            lbNewQty.Text = "";
                            lbNewLot.Text = "";
                            lbUnitOfMesure.Text = "";
                            lbFromPID.Text = "";
                        }
                        break;
                    case 0: this.Close();
                        break;
                }

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            tbInputData.AppendText(",");
        }

        private void fmLotSplit_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
        }
    }
}
