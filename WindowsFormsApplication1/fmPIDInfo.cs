using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.WarehouseService;
using System.Net;
using System.Globalization;


namespace WindowsFormsApplication1
{

    public partial class fmPIDInfo : Form
    {
        public fmPIDInfo()
        {
            InitializeComponent();
        }
        string lot = "";
        MyToolbox mt = new MyToolbox();

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmPIDInfo));
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
                            lbLocation.Text = "";
                            lbBin.Text = "";
                            lbItemNo.Text = "";
                            lbDescription.Text = "";
                            lbQuantity.Text = "";
                            lbUnitOfMesure.Text = "";
                            lbExpiredate.Text = "";
                            lbVendorLot.Text = "";

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            string lokation = "";
                            string placering = "";
                            string varenr = "";
                            string beskrivelse = "";
                            decimal antal = 0;
                            DateTime mhd = DateTime.UtcNow; 
                            lot = tbInputData.Text;
                            string vl = "";
                            string uom = "";
                            bool b_recount = false;

                            string refNo = tbInputData.Text.ToUpper();

                            ItemTool it = new ItemTool();

                            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                            this.pbIndicator.Visible = true;

                            try
                            {
                                refNo = WareHouse.WSGetItemCrossRef(refNo);
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            
                            try
                            {
                                switch (it.TypeOfItem(ref refNo, Globals.theLocation, ref placering, ref varenr, ref beskrivelse, ref antal, ref mhd, ref uom, ref vl, ref b_recount))
                                {
                                    case 0:
                                        {
                                            MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                                        }
                                        break;
                                    case 1:
                                        {
                                            if (lokation.Equals(""))
                                                lokation = Globals.theLocation;
                                            if (b_recount)
                                                break;  
                                            lbLocation.Text = lokation;
                                            lbBin.Text = placering;
                                            lbItemNo.Text = varenr;
                                            lbDescription.Text = beskrivelse;
                                            lbQuantity.Text = antal.ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);
                                            lbUnitOfMesure.Text = uom;
                                            lbExpiredate.Text = mhd.ToShortDateString();
                                            lbVendorLot.Text = vl;
                                        }
                                        break;
                                    case 2:
                                        {
                                            if (WareHouse.WSGetItemBinInformation(Globals.theWinlogon, Globals.theLocation, refNo) > 0)
                                            {
                                                fmBinContent fm = new fmBinContent(2, refNo);
                                                fm.ShowDialog();
                                                this.Close();
                                            }
                                        }
                                        break;
                                    case 3:
                                        {
                                            if (WareHouse.WSGetBinContentInformation(Globals.theWinlogon, Globals.theLocation, refNo) > 0)
                                            {
                                                fmBinContent fm = new fmBinContent(1, tbInputData.Text.ToUpper());
                                                fm.ShowDialog();
                                                this.Close();
                                            }
                                        }
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
                            }
                            finally
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                WareHouse.Dispose();
                                tbInputData.Focus();
                                tbInputData.SelectAll();
                            }
                        }
                        break;
                }
            }

            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                switch (Globals.step)
                {
                    case 3:
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                    case 2:
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                    case 1:
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                    case 0: this.Close();
                        break;
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
            this.pbIndicator.Visible = true;

            try
            {
                WareHouse.WSPrintPid(tbInputData.Text, Globals.theWinlogon);
            }
            catch (Exception ex)
            {
                this.pbIndicator.Image = null;
                this.pbIndicator.Visible = false;

                MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
            } 
            WareHouse.Dispose();
            tbInputData.Focus();
            tbInputData.SelectAll();
            this.pbIndicator.Image = null;
            this.pbIndicator.Visible = false;

        }

        private void fmPIDInfo_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            try
            {
                WareHouse.WSBlockLotNo(tbInputData.Text, Globals.theWinlogon, DateTime.Now, "Varen er ikke OK", true);
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            WareHouse.Dispose();
            tbInputData.Focus();
            tbInputData.SelectAll();
        }
    }
}
