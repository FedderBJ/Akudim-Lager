using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    using System.Globalization;
    using WarehouseService;
    public partial class fmPidInventory : Form
    {
        private string thepid = "";
        private string g_PID = "";
        private bool recountpid = false;
        private bool b_NewPID = false;
        private bool b_confirmPid = false;

        public fmPidInventory()
        {
            InitializeComponent();
        }

        public fmPidInventory(string pid)
        {
            InitializeComponent();
            thepid = pid;
        }

        MyToolbox mt = new MyToolbox();

        public void GetPidData()
        {
#region Local variables
            string lokation = Globals.theLocation;
            string placering = "";
            string varenr = "";
            string beskrivelse = "";
            decimal antal = 0;
            DateTime mhd = DateTime.Now;
            string uom = "";
            string vl = "";

            MyToolbox mt = new MyToolbox();
#endregion

            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            ItemTool it = new ItemTool();

            if (thepid.Equals("#"))
            {
                g_PID = WareHouse.WSReturnNewPID();
                b_NewPID = true;
                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv Placering.
                tbInputData.Text = "";
                lbLocation.Text = Globals.theLocation;
                if (Globals.theShowMessage)
                    MessageBoxExample.MyMessageBox.ShowBox(g_PID.ToString());
                b_confirmPid = true;
                Globals.step++;
            }

            try
            {
                if (it.TypeOfItem(ref thepid, Globals.theLocation, ref placering, ref varenr, ref beskrivelse, ref antal, ref mhd, ref uom, ref vl, ref recountpid) == 1)
                {
                    lbLocation.Text = lokation;
                    if (lokation.Equals(""))
                        lokation = Globals.theLocation;
                    lbBin.Text = placering;
                    lbItemNo.Text = varenr;
                    lbDescription.Text = beskrivelse;
                    lbQuantity.Text = antal.ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);
                    lbUnitOfMesure.Text = uom;
                    lbExpiredate.Text = mhd.ToShortDateString();
                    lbPID.Text = thepid;
                    lbVendorLot.Text = vl;

                    bool FirstInventory = false;

                    if (recountpid)
                    {
                        if (Globals.thePhysCountMode)
                        {
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv placering
                            Globals.step++;
                        }
                        else
                        {
                            b_NewPID = true;
                            b_confirmPid = false;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv Placering.
                            tbInputData.Text = "";
                            Globals.step++;
                        }
                    }
                    else
                    {
                        if (Globals.thePhysCountMode)
                        {
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv placering
                            Globals.step++;

                        }
                        else
                        {
                            if (!FirstInventory)
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText6"); // Angiv Antal.
                                Globals.step = 5;
                            }
                            else
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv placering
                                Globals.step++;
                            }
                        }
                    }
                }
                else
                {
                    if (!WareHouse.WSPIDExists(tbInputData.Text))
                    {
                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                        tbInputData.SelectAll();
                        //break;
                    }
                    if (WareHouse.WSLotInfoUsed(tbInputData.Text))
                    {
                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                       // break;
                    }
                    else
                    {
                        b_NewPID = true;
                        b_confirmPid = false;
                        lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText3"); // Angiv Placering.
                        tbInputData.Text = "";
                        lbLocation.Text = Globals.theLocation;
                        Globals.step++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
            }
            finally
            {
                WareHouse.Dispose();
            }
        }


        private void fmPidInventory_Load(object sender, EventArgs e)
        {
            GetPidData();
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
                        }
                        break;
                    case 1:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;


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

//  Cykliskoptælling i kld begynd
                            if (Globals.thePhysCountMode)
                            {
                                if (tbInputData.Text.ToUpper() != lbBin.Text)
                                {
                                    if (MessageBox.Show(string.Format("Placeringen {0} er forskellig fra {1}{2}Der er registreret på P-ID {3}. Er placeringen {4} rigtig?{5}Hvis ja, så flyttes P-ID {6} til den scannede placering",
                                                                       tbInputData.Text, lbBin.Text, Environment.NewLine, lbPID.Text, tbInputData.Text, Environment.NewLine, lbPID.Text), "Placering", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            var service = new BalanceWarehouse();
                                            service.UseDefaultCredentials = true;

                                            service.WSPostTransfer(Globals.theTransferTemplateName, Globals.theTransferBatchName, lbItemNo.Text, lbUnitOfMesure.Text, Globals.theWinlogon, Globals.theLocation, lbBin.Text, lbPID.Text, Globals.theLocation, tbInputData.Text, lbPID.Text, decimal.Parse(lbQuantity.Text), false, DateTime.Parse(lbExpiredate.Text.ToString()), DateTime.Now, 0);
                                            lbBin.Text = tbInputData.Text.ToUpper();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                        }
                                        tbInputData.Text = "";
                                        lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText6"); // Angiv antal
                                        Globals.step = 5;
                                        break;
                                    }
                                    else
                                    {
                                        tbInputData.Text = "";
                                        tbInputData.Focus();
                                        break;
                                    }
                                }
                                tbInputData.Text = "";
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText6"); // Angiv antal
                                Globals.step = 5;
                                break;
                            }
//  Cykliskoptælling i kld slut

                            lbBin.Text = tbInputData.Text;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText4");
                            tbInputData.Text = "";

                            bool FirstInventory = false;
                            if (!FirstInventory)
                                Globals.step++;
                            else
                            {
                                if (!WareHouse.WSItemUsesTracking(lbItemNo.Text))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format("Varen {0} kan ikke tælles op på et lotnummer,{1}da der ikke er en varesporringskode på varen", lbItemNo.Text, Environment.NewLine));
                                    tbInputData.Text = "";
                                    tbInputData.Focus();
                                    break;
                                }
                                bool UseMhd = false;
                                UseMhd = WareHouse.WSItemUsesMhdTracking(lbItemNo.Text);

                                if (UseMhd)
                                {
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText5");
                                    tbInputData.Mask = mt.ReadResFile(this.Name.ToString() + "DataMask");
                                    tbInputData.Text = "";
                                    Globals.step++;
                                }
                                else
                                {
                                    tbInputData.Text = "";
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText6"); // Angiv antal
                                    Globals.step = 5;
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            bool UseMhd = false;

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            try
                            {
                                if (!WareHouse.WSItemUsesTracking(tbInputData.Text))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format("Varen {0} kan ikke tælles op på et lotnummer,{1}da der ikke er en varesporringskode på varen", lbItemNo.Text, Environment.NewLine));
                                    break;
                                }

                                if (WareHouse.WSItemUsesTracking(tbInputData.Text) && (!recountpid))
                                {
                                    g_PID = WareHouse.WSReturnNewPID();
                                    b_NewPID = true;
                                }

                                UseMhd = WareHouse.WSItemUsesMhdTracking(tbInputData.Text);
                                lbDescription.Text = WareHouse.WSReturnItemDescription(tbInputData.Text);
                                if (lbDescription.Text.Equals(""))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message8"));
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                }
                                lbUnitOfMesure.Text = WareHouse.WSReturnItemUnitOfMesure(tbInputData.Text, 2);
                                lbItemNo.Text = tbInputData.Text;
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                tbInputData.Text = "";
                                tbInputData.Focus();
                                break;
                            }
                            if (UseMhd)
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText5");
                                tbInputData.Mask = mt.ReadResFile(this.Name.ToString() + "DataMask");
                                tbInputData.Text = "";
                                Globals.step++;
                            }
                            else
                            {
                                tbInputData.Text = "";
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText7");
                                Globals.step = 4;
                            }
                        }
                        break;
                    case 3:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

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
                                OK = false;
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }

                            if (OK)
                            {
                                lbExpiredate.Text = tbInputData.Text;
                                tbInputData.Mask = "";
                                tbInputData.Text = "";
                                Globals.step++;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText7"); ;
                                tbInputData.Text = "";
                            }
                            else
                                tbInputData.Text = "";
                        }
                        break;
                    case 4:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

                            lbVendorLot.Text = tbInputData.Text;
                            tbInputData.Text = "";
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText6");
                            Globals.step++;
                        }
                        break;
                    case 5:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;


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
                                Globals.step++;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText8");
                                tbInputData.Text = "";

                            }
                            else
                            {
                                Globals.step = 7;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "lblInputText9");
                                tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                            }

                            if ((b_NewPID) && (decimal.Parse(lbPhysQty.Text) > 0))
                                WareHouse.WSPrintPidPrev(g_PID, Globals.theWinlogon, lbItemNo.Text, lbPhysQty.Text, lbExpiredate.Text, lbVendorLot.Text, lbUnitOfMesure.Text);
                            WareHouse.Dispose();
                        }
                        break;
                    case 6:
                        {
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
                                thepid = tbInputData.Text;
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
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;

                            try
                            {
                                DateTime d;
                                if (lbExpiredate.Text != "")
                                    DateTime.TryParse(lbExpiredate.Text, out d);
                                else
                                    d = DateTime.Now;

                                this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                                this.pbIndicator.Visible = true;

                                WareHouse.WSPostPhysicalInventory(Globals.thePhysInvTemplateName, Globals.thePhysInvBatchName, lbItemNo.Text.ToString(), Globals.theWinlogon, lbLocation.Text, lbBin.Text, thepid, decimal.Parse(lbPhysQty.Text), lbUnitOfMesure.Text, false, true, d, lbVendorLot.Text, DateTime.Now);
                                if ((!b_NewPID) && (decimal.Parse(lbQuantity.Text) != decimal.Parse(lbPhysQty.Text)))
                                {
                                    //WareHouse.WSPrintPID(lot);
                                }

                                if ((Globals.thePrintInvPid) && (!b_NewPID))
                                {
                                    WareHouse.WSPrintPid(thepid, Globals.theWinlogon);
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
                                thepid = "";
                                g_PID = "";
                                b_NewPID = false;
                                b_confirmPid = false;
                                Globals.step = 0;
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
                                this.Close();
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
    }
}
