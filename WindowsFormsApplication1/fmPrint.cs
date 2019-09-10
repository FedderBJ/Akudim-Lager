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
    public partial class fmPrint : Form
    {
        private int ReturnIndex = -1;
        private string data = "";
        private string varenr = "";
        private string lokation = Globals.theLocation;
        private string placering = "";

        public fmPrint()
        {
            InitializeComponent();
        }

        public void GetPidData(string Data)
        {
            #region Local variables
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

            try
            {
                data = Data = WareHouse.WSGetItemCrossRef(Data);
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }

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
                            lbDescription.Text = string.Format("{0} {1}", varenr, beskrivelse);
                            ReturnIndex = 1;
                            //P-ID    
                        }
                        break;
                    case 2:
                        {
                            lbDescription.Text = string.Format("{0} {1}", varenr, beskrivelse);
                            ReturnIndex = 2;
                            //Vareinfo
                        }
                        break;
                    case 3:
                        {
                            lbDescription.Text = string.Format("{0} {1}", Data, "");
                            ReturnIndex = 3;
                            //Placering
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
                tbInputData.Text = "";
            }
            finally
            {
                WareHouse.Dispose();
            }
            if (ReturnIndex > 0)
            {
                btPrint.Enabled = true;
            }
            else
            {
                btPrint.Enabled = false;
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            var service = new BalanceWarehouse();
            service.UseDefaultCredentials = true;

            switch (ReturnIndex)
            {
                case 1:
                    {
                        try
                        {
                            service.WSPrintPid(data, Globals.theWinlogon);
                        }
                        catch (Exception ex)
                        {
                            MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                        }
                    }
                    break;
                case 2:
                    {
                        try
                        {
                            service.WSPrintItemLabel(data, (int)numericUpDown1.Value, Globals.theWinlogon);
                        }
                        catch (Exception ex)
                        {
                            MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                        }
                    }
                    break;
                case 3:
                    {
                        try
                        {
                            service.WSPrintBinLabel(data, (int)numericUpDown1.Value, Globals.theWinlogon);
                        }
                        catch (Exception ex)
                        {
                            MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                        }
                    }
                    break;
            }
            numericUpDown1.Value = 1;
            tbInputData.Text = "";
            lbDescription.Text = "";
            tbInputData.Focus();
            btPrint.Enabled = false;
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

        private void tbInputData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                numericUpDown1.UpButton();
            }

            if (e.KeyCode == Keys.Down)
            {
                numericUpDown1.DownButton();
            }
        }
    }
}
