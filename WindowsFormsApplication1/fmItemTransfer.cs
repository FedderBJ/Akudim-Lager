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

    public partial class fmItemTransfer : Form
    {
        private string itemno = "";
        private bool changedefaultbin = false;

        public fmItemTransfer()
        {
            InitializeComponent();
        }

        public fmItemTransfer(string ItemNo)
        {
            InitializeComponent();
            itemno = ItemNo;
        }

        
        MyToolbox mt = new MyToolbox();

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmItemTransfer));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void GetData()
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            try
            {
                lbLocation.Text = Globals.theLocation;
                lbItemNo.Text = itemno;
                lbQuantity.Text = "0";
                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText1");
                lbNewLocation.Text = Globals.theLocation;
                tbInputData.Text = "";
                Globals.step = 0;

                lbDescription.Text = WareHouse.WSReturnItemDescription(itemno);
                if (lbDescription.Text.Equals(""))
                {
                    MessageBoxExample.MyMessageBox.ShowBox(string.Format("Varen {0} findes ikke", itemno));
                    tbInputData.Focus();
                    tbInputData.SelectAll();
                }
                lbUnitOfMesure.Text = WareHouse.WSReturnItemUnitOfMesure(itemno, 2);
                BinContentTool btool = new BinContentTool();
                lbStdBin.Text = btool.GetDefaultBin(Globals.theLocation, itemno);

            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);

            }
            finally
            {
                WareHouse.Dispose();
                lbNewLocation.Text = Globals.theLocation;
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
                        {
                            // Placeringsfunktionalitet.
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            try
                            {
                                if (!WareHouse.WSBinExists(Globals.theLocation, tbInputData.Text))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                    break;
                                }

                                lbBin.Text = tbInputData.Text.ToUpper();

                                #region GetBincontent
                                decimal antal = 0;
                                string uom = "";
                                BinContentTool bct = new BinContentTool();
                                if (bct.GetItemBincontent(lbLocation.Text, lbBin.Text, lbItemNo.Text, ref antal, ref uom))
                                {
                                    lbQuantity.Text = antal.ToString("N2");
                                    lbUnitOfMesure.Text = uom;
                                }
                                #endregion
                                if (antal == 0)
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Error5"), lbItemNo.Text, lbBin.Text));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                    break;
                                }
                                Globals.GlobalStep++;
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                tbInputData.SelectAll();
                                break;
                            }
                            tbInputData.Text = "";
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText2");
                        }
                        break;
                    case 1:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            if (!WareHouse.WSBinExists(lbNewLocation.Text, tbInputData.Text))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
                                tbInputData.SelectAll();
                                break;
                            }

                            lbNewBinCode.Text = tbInputData.Text.ToUpper();
                            lblInputText.Text = lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3");
                            tbInputData.Text = lbQuantity.Text;

                            BinContentTool btool = new BinContentTool();

                            if (!btool.BinIsDefault(Globals.theLocation, lbNewBinCode.Text, lbItemNo.Text, "") && (lbStdBin.Text != lbNewBinCode.Text))
                            {
                                if (MessageBox.Show(string.Format("Skal standard placering skiftes fra {0} til {1}?", lbStdBin.Text, lbNewBinCode.Text), "Skift standard placering", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    if (MessageBox.Show(string.Format("Er du sikker på at du vil skiftes fra {0} til {1}?", lbStdBin.Text, lbNewBinCode.Text), "Advarsel! Skifter standard placering", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        changedefaultbin = true;
                                    }
                                }
                            }

                            tbInputData.SelectAll();
                            Globals.step++;
                        }
                        break;
                    case 2:
                        {
                            decimal d = 0;
                            // Angivelse af antal.
                            if (!decimal.TryParse(tbInputData.Text, out d))
                            {
                                break;
                            }
                            if (d < 0)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message6"));
                                tbInputData.SelectAll();
                                break;
                            }

                            if (d > decimal.Parse(lbQuantity.Text))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Error4"), lbQuantity.Text, lbUnitOfMesure.Text));
                                tbInputData.SelectAll();
                                break;
                            }

                            lbMoveQty.Text = tbInputData.Text;
                            lbNewUom.Text = lbUnitOfMesure.Text;
                            lblInputText.Text = lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
                            tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText5");
                            Globals.step++;
                        }
                        break;
                    case 3:
                        {
                            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                            this.pbIndicator.Visible = true;

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            try
                            {
                                if (changedefaultbin)
                                {
                                    WareHouse.WSSetDefaultBin(Globals.theLocation, lbStdBin.Text, lbItemNo.Text, lbUnitOfMesure.Text, false);
                                }
                                
                                WareHouse.WSPostTransfer(Globals.theTransferTemplateName, Globals.theTransferBatchName, lbItemNo.Text.ToString(), lbUnitOfMesure.Text, Globals.theWinlogon, lbLocation.Text.ToString(), lbBin.Text.ToString(), "", lbNewLocation.Text.ToString(), lbNewBinCode.Text.ToString(), itemno.ToString(), decimal.Parse(lbMoveQty.Text.ToString()), false, DateTime.Parse(DateTime.Now.ToString()), DateTime.Now, 0);
                                
                                if (changedefaultbin)
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
                            this.Close();
                            Globals.GlobalStep = 0;
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
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText1"); ;
                        }
                        break;
                    case 1:
                        {
                            this.Close();
                        }
                        break;
                    case 0: this.Close();
                        break;
                }

            }
        }

        private void fmItemTransfer_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
            GetData();
        }

        private void lbStdBin_DoubleClick(object sender, EventArgs e)
        {
            if (Globals.GlobalStep == 1)
            {
                tbInputData.Text = lbStdBin.Text;
            }
        }

        private void lbBin_DoubleClick(object sender, EventArgs e)
        {
            string placering = lbItemNo.Text;
            fmBinContentList bcl = new fmBinContentList();
            bcl.ShowDialog(ref placering);

            if (placering != "")
            {
                tbInputData.Text = placering;
            }
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
