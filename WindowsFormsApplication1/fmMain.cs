using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Principal;
using System.Net;

namespace WindowsFormsApplication1
{
    using WarehouseService;
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }
        MyToolbox mt = new MyToolbox();

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmMain));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
 
        private void fmMain_Load(object sender, EventArgs e)
        {
            Globals.theWinlogon = WindowsIdentity.GetCurrent().Name.ToUpper();
            Globals.theUserID = Globals.theWinlogon.Substring(Globals.theWinlogon.IndexOf('\\') + 1).ToUpper();
            EmployeeTool et = new EmployeeTool();
            et.GetEmployeeSettings(Globals.theWinlogon);
            if (Globals.theLanguageCode != "")
              ChangeLanguage(Globals.theLanguageCode);

            string Sqlserver = "";
            string SqlInstance = "";
            string SqlDatabaseUser = "";
            string Company = "";
            string WebUrl = "";
            string Language = "";
            
            BalanceWarehouse Warehouse = new BalanceWarehouse();
            Warehouse.UseDefaultCredentials = true;
            
            try
            {
                Warehouse.WsReturnServerInfo(ref Sqlserver, ref SqlInstance, ref SqlDatabaseUser, ref Company, ref Language, ref WebUrl);
                lbCompanyName.Text = Company;
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }

            try
            {
                string ErrorSound = "";
                string OkSound = "";
                bool Errormessage = false;
                Warehouse.WSReturnGeneralSetup(ref ErrorSound, ref OkSound, ref Errormessage);
                Globals.theOkSoundPath = OkSound;
                Globals.theErrorSound = ErrorSound;
                Globals.theShowMessage = Errormessage;
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            Warehouse.Dispose();
        }

        private void btnPackageInformation_Click(object sender, EventArgs e)
        {
            fmPIDInfo pi = new fmPIDInfo();  // Pakkeinformation
            pi.ShowDialog();
        }

        private void btnMovePackage_Click(object sender, EventArgs e)
        {
            fmSelector ms = new fmSelector(1);
            ms.ShowDialog();
        }

        private void btnPackageInventory_Click(object sender, EventArgs e)
        {
            fmSelector invs = new fmSelector(0);
            invs.ShowDialog();
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            fmPickList pl = new fmPickList();
            
            if (pl.ReturnNoOfOrders(Globals.theWinlogon) > 0)
            {
                pl.ShowDialog(Globals.theWinlogon);
            }
            else
            {
                if (pl.ReturnNoOfOrders("") > 0)
                {
                    pl.ShowDialog("");
                }
                else
                {
                    fmWarehouseShipmentHeaderList sl = new fmWarehouseShipmentHeaderList();
                    sl.ShowDialog();
                }
            }
        }

        private void btnMoveProdToBox_Click(object sender, EventArgs e)
        {
            //fmPurchaseOrdertList wr = new fmPurchaseOrdertList();
            //wr.ShowDialog();
            fmWarehouseReceiptList wrl = new fmWarehouseReceiptList();
            wrl.ShowDialog();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            fmSetup su = new fmSetup();
            su.ShowDialog();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            //fmTestForm test = new fmTestForm();
            //test.ShowDialog();
            //fmItemList il = new fmItemList();
            //il.ShowDialog();
        }

        private void btnLotSplit_Click(object sender, EventArgs e)
        {
            fmLotSplit ls = new fmLotSplit();
            ls.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var pl = new fmPrint();
            pl.ShowDialog();
        }
    }
}
