using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.WarehouseService;
using System.Globalization;


namespace WindowsFormsApplication1
{

    public partial class fmPidItemTransfer : Form
    {
        private string lot = "";
        private bool ChangeStdBin = false;

        public fmPidItemTransfer()
        {
            InitializeComponent();
        }

        public fmPidItemTransfer(string pid)
        {
            InitializeComponent();
            lot = pid;
        }
        
        MyToolbox mt = new MyToolbox();

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmPidItemTransfer));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void GetData()
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;
            string lokation = "";
            string placering = "";
            string varenr = "";
            string beskrivelse = "";
            decimal antal = 0;
            DateTime mhd = DateTime.UtcNow;
            lot = tbInputData.Text;
            string uom = "";
            string vl = "";
            try
            {
                if (!WareHouse.WSReturnLotInfo(lot, Globals.theLocation, ref placering, ref varenr, ref beskrivelse, ref antal, ref mhd, ref uom, ref vl))
                {
                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                }
                else
                {
                    lokation = Globals.theLocation;
                    lbPID.Text = lot;
                    lbLocation.Text = lokation;
                    lbBin.Text = placering;
                    lbItemNo.Text = varenr;
                    lbDescription.Text = beskrivelse;
                    lbQuantity.Text = antal.ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);
                    lbUnitOfMesure.Text = uom;
                    lbExpiredate.Text = mhd.ToShortDateString();
                    lbVendorLot.Text = vl;
                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText2") ;
                    lbNewLocation.Text = lokation;
                    BinContentTool btool = new BinContentTool();
                    lbStdBin.Text = btool.GetDefaultBin(Globals.theLocation, varenr);
                    tbInputData.Text = "";
                    Globals.step = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            finally
            {
                WareHouse.Dispose();
                lbNewLocation.Text = lokation;
                tbInputData.Text = "";
            }
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                switch (Globals.GlobalStep)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            if (!WareHouse.WSBinExists(lbNewLocation.Text, tbInputData.Text))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Error2"));
                                tbInputData.SelectAll();
                                break;
                            }

                            BinContentTool btool = new BinContentTool();
                            ChangeStdBin = false;
                            if (!btool.BinIsDefault(Globals.theLocation, tbInputData.Text, "", "") && (lbStdBin.Text != tbInputData.Text))
                            {
                                if (MessageBox.Show(string.Format("Skal standard placering skiftes fra {0} til {1}?", lbStdBin.Text, lbNewBinCode.Text), "Skift standard placering", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    if (MessageBox.Show(string.Format("Er du sikker på at du vil skiftes fra {0} til {1}?", lbStdBin.Text, lbNewBinCode.Text), "Advarsel! Skifter standard placering", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        ChangeStdBin = true;
                                    }
                                }
                            }

                            lbNewBinCode.Text = tbInputData.Text;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
                            tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText5");
                            Globals.step++;
                        }
                        break;
                    case 2:
                        {
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                            this.pbIndicator.Visible = true;

                            try
                            {
                                if (ChangeStdBin)
                                {
                                    WareHouse.WSSetDefaultBin(Globals.theLocation, lbStdBin.Text, lbItemNo.Text, lbUnitOfMesure.Text, false);
                                }

                                WareHouse.WSPostTransfer(Globals.theTransferTemplateName, Globals.theTransferBatchName ,lbItemNo.Text.ToString(), lbUnitOfMesure.Text, Globals.theWinlogon, lbLocation.Text.ToString(), lbBin.Text.ToString(), lot.ToString(), lbNewLocation.Text.ToString(), lbNewBinCode.Text.ToString(), lot.ToString(), decimal.Parse(lbQuantity.Text.ToString()), false, DateTime.Parse(lbExpiredate.Text.ToString()), DateTime.Now, 0);

                                if (ChangeStdBin)
                                {
                                    WareHouse.WSSetDefaultBin(Globals.theLocation, lbNewBinCode.Text, lbItemNo.Text, lbUnitOfMesure.Text, true);
                                }
                            }
                            catch (Exception ex)
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                this.Close();
                            }
                        }
                        break;
                }
            }

            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                switch (Globals.step)
                {
                    case 2:
                        {
                            Globals.step--;
                            tbInputData.Text = "";
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText2"); ;
                        }
                        break;
                    case 1:
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                    case 0:
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                }
            }
        }

        private void fmUmlagerung_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
            tbInputData.Text = lot;
            GetData();
        }

        private void lbNewBinCode_DoubleClick(object sender, EventArgs e)
        {
            string placering = lbItemNo.Text;
            fmBinContentList bcl = new fmBinContentList();
            bcl.ShowDialog(ref placering);

            if ((placering != "") && (placering != lbBin.Text))
            {
                tbInputData.Text = placering;
            }
        }
    }
}
