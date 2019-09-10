using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.WarehouseService;
using System.Diagnostics;
using System.Net;
using System.Globalization;


namespace WindowsFormsApplication1
{

    public partial class fmInventory : Form
    {
        private string itemno = "";
        private string lot = "";
        private string g_PID = "";
        private bool b_NewPID = false;
        private bool b_confirmPid = false;
        private bool UseMhd = false;

        public fmInventory()
        {
            InitializeComponent();
        }

        public fmInventory(string ItemNo)
        {
            InitializeComponent();
            itemno = ItemNo.ToUpper();
        }
        
        MyToolbox mt = new MyToolbox();

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmInventory));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void GetItemData(string input)
        {
            bool UseMhd = false;

            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            if (input.Equals("#"))
            {
                lbLocation.Text = Globals.theLocation;
                CaptionItem();
                Globals.GlobalStep = 0;
            }
            else
            {
                try
                {
                    if (WareHouse.WSItemUsesTracking(input))
                    {
                        g_PID = WareHouse.WSReturnNewPID();
                        b_NewPID = true;
                        b_confirmPid = true;
                    }

                    UseMhd = WareHouse.WSItemUsesMhdTracking(input);
                    lbDescription.Text = WareHouse.WSReturnItemDescription(input);
                    if (lbDescription.Text.Equals(""))
                    {
                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message8"));
                        tbInputData.Focus();
                        tbInputData.SelectAll();
                    }
                    lbUnitOfMesure.Text = WareHouse.WSReturnItemUnitOfMesure(itemno, 2);
                    lbItemNo.Text = input;
                }
                catch (Exception ex)
                {
                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);

                }
                CaptionBin();
                Globals.GlobalStep = 1;
            }
        }

        private void CaptionBin()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv Placering.
            tbInputData.Text = "";
            tbInputData.Focus();
        }

        private void CaptionExpiredate()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText5");
            tbInputData.Mask = mt.ReadResFile(this.Name.ToString() + "DataMask");
            tbInputData.Text = "";
        }

        private void CaptionVendorlot()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText7"); ;
            tbInputData.Text = "";
        }

        private void Vendorlot()
        {
            lbVendorLot.Text = tbInputData.Text;
            Globals.step++;
        }

        private void CaptionQuantity()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText6");
            tbInputData.Text = "";
            tbInputData.Focus();
        }

        private void CaptionLot()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText8");
            tbInputData.Text = "";
            tbInputData.Focus();
        }

        private void CaptionItem()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
            tbInputData.Text = "";

        }

        private void CaptionPosting()
        {
            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText9");
            tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
            tbInputData.Focus();
        }

        private int Posting()
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
            this.pbIndicator.Visible = true;

            try
            {
                DateTime d;
                if (lbExpiredate.Text != "")
                    DateTime.TryParse(lbExpiredate.Text, out d);
                else
                    d = DateTime.Now;

                WareHouse.WSPostPhysicalInventory(Globals.thePhysInvTemplateName, Globals.thePhysInvBatchName, lbItemNo.Text.ToString(), Globals.theWinlogon, lbLocation.Text, lbBin.Text, lot, decimal.Parse(lbPhysQty.Text), lbUnitOfMesure.Text, false, true, d, lbVendorLot.Text, DateTime.Now);
                
                if ((!b_NewPID) && (decimal.Parse(lbQuantity.Text) != decimal.Parse(lbPhysQty.Text)))
                {
                    //WareHouse.WSPrintPid(lot, Globals.theWinlogon);
                }

                if ((Globals.thePrintInvPid) && (!b_NewPID))
                {
                    WareHouse.WSPrintPid(lot, Globals.theWinlogon);
                }
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            finally
            {
                this.pbIndicator.Image = null;
                this.pbIndicator.Visible = false;

                //lblInputText3
                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText1");
                tbInputData.Text = "";
                lbLocation.Text = "";
                lbBin.Text = "";
                lbItemNo.Text = "";
                lbDescription.Text = "";
                lbQuantity.Text = "";
                lbExpiredate.Text = "";
                lbUnitOfMesure.Text = "";
                lbPhysQty.Text = "";
                lbVendorLot.Text = "";
                lbPID.Text = "";
                WareHouse.Dispose();
                lot = "";
                g_PID = "";
                b_NewPID = false;
                b_confirmPid = false;
                Globals.GlobalStep = 0;
                this.Close();
            }
            return 0;
        }

        private void fmInventory_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
            
            GetItemData(itemno);
            //CaptionBin();

        }

        private void lblInputText_Click(object sender, EventArgs e)
        {
            tbInputData.AppendText("#");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            tbInputData.AppendText(",");
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                switch (Globals.GlobalStep)
                {
                    case 0:
                        {
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            try
                            {
                                tbInputData.Text = WareHouse.WSGetItemCrossRef(WareHouse.WSGetItemCrossRef(tbInputData.Text));

                                if (WareHouse.WSItemUsesTracking(tbInputData.Text))
                                {
                                    g_PID = WareHouse.WSReturnNewPID();
                                    b_NewPID = true;
                                    b_confirmPid = true;

                                    UseMhd = WareHouse.WSItemUsesMhdTracking(tbInputData.Text);
                                }
                                lbDescription.Text = WareHouse.WSReturnItemDescription(tbInputData.Text);
                                if (lbDescription.Text.Equals(""))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message8"));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                }
                                lbUnitOfMesure.Text = WareHouse.WSReturnItemUnitOfMesure(tbInputData.Text, 2);
                                lbItemNo.Text = tbInputData.Text;
                                CaptionBin();
                                Globals.GlobalStep++;
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                tbInputData.Text = "";
                                tbInputData.Focus();
                            }
                        }
                        break;

                    case 1:
                        {
                            // Placeringsfunktionalitet.
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            lbLocation.Text = Globals.theLocation;

                            if (!WareHouse.WSBinExists(Globals.theLocation, tbInputData.Text.ToUpper()))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message4"));
                                tbInputData.Focus();
                                tbInputData.SelectAll();
                                break;
                            }
                            if (!WareHouse.WSInventoryAllowed(Globals.theLocation, tbInputData.Text.ToUpper()))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message10"));
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
                            else
                                lbQuantity.Text = "0";
                            #endregion
                            bool UseMhd = false;
                            UseMhd = WareHouse.WSItemUsesMhdTracking(lbItemNo.Text);

                            if (UseMhd)
                            {
                                CaptionExpiredate();
                                Globals.GlobalStep = 3;
                            }
                            else
                            {
                                CaptionQuantity();
                                Globals.GlobalStep = 5;
                            }
                        }

                        break;
                    case 2:
                        {

                        }
                        break;
                    case 3:
                        {
                            // Mhd
                            bool OK = false;
                            DateTime TestDate = new DateTime(1, 1, 1);
                            try
                            {
                                TestDate = Convert.ToDateTime(tbInputData.Text);
                                if (TestDate.CompareTo(DateTime.Now) >= 1)
                                    OK = true;
                                else
                                {
                                    OK = false;
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Message5"), TestDate.ToShortDateString(), Environment.NewLine, Environment.NewLine, DateTime.Today.ToShortDateString()));
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }

                            if (OK)
                            {
                                lbExpiredate.Text = tbInputData.Text;
                                tbInputData.Mask = "";
                                tbInputData.Text = "";
                                CaptionVendorlot();
                                Globals.GlobalStep++;
                            }
                            else
                                tbInputData.Text = "";
                        }
                        break;

                    case 4:
                        {
                            // Leverandørlot
                            Vendorlot();
                            CaptionQuantity();
                        }
                        break;
                    case 5:
                        {
                            // Antal
                            // Kontrol på, at der ikke tælles på en ikke tilladt placeringstype kode
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            if (!WareHouse.WSInventoryAllowed(Globals.theLocation, lbBin.Text))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message10"));
                                tbInputData.Focus();
                                tbInputData.SelectAll();
                                break;
                            }

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

                            if (d > 1000000)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message9"));
                                tbInputData.SelectAll();
                                break;
                            }

                            lbPhysQty.Text = tbInputData.Text;
                            if (b_NewPID && b_confirmPid)
                            {
                                CaptionLot();
                                //Indsæt funktion til udskrivning af p-is label-
                                Globals.GlobalStep = 6;
                            }
                            else
                            {
                                CaptionPosting();
                                Globals.GlobalStep = 7;
                            }

                            if ((b_NewPID) && (decimal.Parse(lbPhysQty.Text) > 0))
                                WareHouse.WSPrintPidPrev(g_PID, Globals.theWinlogon, lbItemNo.Text, lbPhysQty.Text, lbExpiredate.Text, lbVendorLot.Text, lbUnitOfMesure.Text);
                            WareHouse.Dispose();

                        }
                        break;
                    case 6:
                        {
                            // Bekræft et evt P-ID
                            if (b_confirmPid)
                            {
                                if (g_PID != tbInputData.Text)
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                    break;
                                }
                            }
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            try
                            {
                                if (WareHouse.WSLotInfoUsed(tbInputData.Text))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }

                            try
                            {
                                if (!WareHouse.WSLotInfoExists(lbItemNo.Text, tbInputData.Text, lbVendorLot.Text))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                    break;
                                }
                                lot = tbInputData.Text;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText9");
                                tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                                Globals.step++;
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                WareHouse.Dispose();
                            }
                        }
                        break;
                    case 7:
                        {
                            // Bogføring
                            Posting();
                        }
                        break;

                }
            }
            #region ESC_KEY
            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                switch (Globals.step)
                {
                    case 6:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText8");
                            tbInputData.Text = "";
                        }
                        break;
                    case 5:
                        {
                            if (!b_NewPID)
                            {
                                Globals.step = 0;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText1");
                                tbInputData.Text = "";
                                b_NewPID = false;
                                b_confirmPid = false;
                                tbInputData.Text = "";
                                lbLocation.Text = "";
                                lbBin.Text = "";
                                lbItemNo.Text = "";
                                lbDescription.Text = "";
                                lbQuantity.Text = "";
                                lbExpiredate.Text = "";
                                lbPID.Text = "";
                                lbVendorLot.Text = "";
                            }
                            else
                            {
                                Globals.step--;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText7");
                                tbInputData.Text = "";
                            }
                        }
                        break;
                    case 4:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText5");
                            tbInputData.Mask = mt.ReadResFile(this.Name.ToString() + "DataMask");
                        }
                        break;
                    case 3:
                        {
                            Globals.step--;
                            tbInputData.Mask = "";
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
                        }
                        break;
                    case 2:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3");
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
            #endregion
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
    }
}
