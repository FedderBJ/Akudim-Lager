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
    using WarehouseService;

    public partial class fmSelector : Form
    {
        private int Selector = 0;

        public fmSelector()
        {
            InitializeComponent();
        }
        public fmSelector(int Selection)
        {
            InitializeComponent();
            Selector = Selection;
        }


        public void GetPidData(string Data)
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
            bool b_recount = false;

            MyToolbox mt = new MyToolbox();
            #endregion

            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            ItemTool it = new ItemTool();

            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
            this.pbIndicator.Visible = true;

            if (tbInputData.Text.Equals("#"))
            {
                if (Selector == 0)
                {
                    // Kald formen til optælling uden P-ID, hvis det er en holdbarhedsvare tilføjes data og et P-ID.
                    fmInventory inv = new fmInventory(tbInputData.Text);
                    inv.ShowDialog();
                    tbInputData.Text = "";
                }
                if (Selector == 1)
                {
                    // Bruges pt ikke
                    tbInputData.Text = "";
                }
            }
            else
            {
                try
                {
                    switch (it.TypeOfItem(ref Data, Globals.theLocation, ref placering, ref varenr, ref beskrivelse, ref antal, ref mhd, ref uom, ref vl, ref b_recount))
                    {
                        case 0:
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Error1"), Data));
                                tbInputData.Text = "";
                            }
                            break;
                        case 1:
                            {
                                if (Selector == 0)
                                {
                                    fmPidInventory pi = new fmPidInventory(Data);
                                    pi.ShowDialog();
                                    tbInputData.Text = "";

                                }
                                if (Selector == 1)
                                {
                                    // Kalde form til at afvikle flytning af varer med P-ID
                                    fmPidItemTransfer pit = new fmPidItemTransfer(Data);
                                    pit.ShowDialog();
                                    tbInputData.Text = "";
                                }
                            }
                            break;
                        case 2:
                            {
#region GetBincontent
                                BinContentTool bct = new BinContentTool();
                                if (bct.GetItemBincontent(Globals.theLocation, "", Data.ToUpper(), ref antal, ref uom))
                                {
                                    if (Selector == 0)
                                    {
                                        // Kalde form til at afvikle optælling af varer uden P-ID
                                        fmInventory inv = new fmInventory(Data);
                                        inv.ShowDialog();
                                        tbInputData.Text = "";
                                    }

                                    if (Selector == 1)
                                    {
                                        // Kalde form til at afvikle flytning af varer uden P-ID
                                        fmItemTransfer itf = new fmItemTransfer(Data);
                                        itf.ShowDialog();
                                        tbInputData.Text = "";
                                    }
                                }
#endregion
/*
                                if (WareHouse.WSGetItemBinInformation(Globals.theWinlogon, Globals.theLocation, Data.ToUpper()) > 0)
                                {
                                    if (Selector == 0)
                                    {
                                        // Kalde form til at afvikle optælling af varer uden P-ID
                                        fmInventory inv = new fmInventory(Data);
                                        inv.ShowDialog();
                                        tbInputData.Text = "";
                                    }

                                    if (Selector == 1)
                                    {
                                        // Kalde form til at afvikle flytning af varer uden P-ID
                                        fmItemTransfer itf = new fmItemTransfer(Data);
                                        itf.ShowDialog();
                                        tbInputData.Text = "";
                                    }
                                }
 */ 
                            }
                            break;
                        case 3:
                            {
                                if (WareHouse.WSGetBinContentInformation(Globals.theWinlogon, Globals.theLocation, Data.ToUpper()) > 0)
                                {
                                    fmBinContent fm = new fmBinContent(1, Data.ToUpper());
                                    fm.ShowDialog();
                                    tbInputData.Text = "";
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
                    tbInputData.Text = "";
                }
                finally
                {
                    this.pbIndicator.Image = null;
                    this.pbIndicator.Visible = false;

                    WareHouse.Dispose();
                }
            }
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetPidData(tbInputData.Text.ToUpper());
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void fmSelector_Load(object sender, EventArgs e)
        {
            MyToolbox mt = new MyToolbox();

            if (Selector == 0)
            {
                lbCaption.Text = mt.ReadResFile(this.Name + "InventoryCaption");
                lbHelpTxt.Text = mt.ReadResFile(this.Name + "InventoryHelp");
            }

            if (Selector == 1)
            {
                lbCaption.Text = mt.ReadResFile(this.Name + "TransferCaption");
                lbHelpTxt.Text = mt.ReadResFile(this.Name + "TransferHelp");
            }
        }
    }
}
