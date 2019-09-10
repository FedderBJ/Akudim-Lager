using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using WarehouseService;
    public partial class fmSetup : Form
    {
        MyToolbox mt = new MyToolbox();
        public fmSetup()
        {
            InitializeComponent();
            
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmSetup));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void fmSetup_Load(object sender, EventArgs e)
        {

            if (Globals.theLanguageCode != "")
            {
                ChangeLanguage(Globals.theLanguageCode);
            }

            BalanceWarehouse Warehouse = new BalanceWarehouse();
            Warehouse.UseDefaultCredentials = true;

            string Sqlserver = "";
            string SqlInstance = "";
            string SqlDatabaseUser = "";
            string Company = "";
            string WebUrl = "";
            string Language = "";
            string Printer = "";

            try
            {
                Warehouse.WsReturnServerInfo(ref Sqlserver, ref SqlInstance, ref SqlDatabaseUser, ref Company, ref Language, ref WebUrl);
                tbSqlServer.Text = Sqlserver;
                tbInstance.Text = SqlInstance;
                tbDatabaseUser.Text = SqlDatabaseUser;
                tbCompany.Text = Company;
                tbLanguage.Text = Language;
                tbWebUrl.Text = WebUrl;
            }
            catch ( Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }

            try
            {
                Warehouse.WSReturnPrinterInfo(Globals.theWinlogon, Globals.theLocation, ref Printer);
                lbPrinterName.Text = Printer;
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }

            Warehouse.Dispose();
            tbInputData.Focus();
            tbInputData.SelectAll();

            Assembly asm = Assembly.GetExecutingAssembly();
            FileInfo fi = new FileInfo(asm.Location);
            lbBuildDateTime.Text = fi.LastWriteTime.ToString();
            lbLocation.Text = Globals.theLocation;
        }

        private void btlLogout_Click(object sender, EventArgs e)
        {
            BalanceWarehouse Warehouse = new BalanceWarehouse();
            Warehouse.UseDefaultCredentials = true;

            try
            {
                if (Warehouse.WSEndProgramCode(tbInputData.Text))
                    Application.ExitThread();
                else
                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Error1"));
                tbInputData.Text = "";
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                this.Close();
            }
        }

        private void btChangePrinter_Click(object sender, EventArgs e)
        {
            string printer = "";
            fmTerminalPrinters tp = new fmTerminalPrinters();
            tp.ShowDialog(ref printer);
            if ((!lbPrinterName.Text.Equals(printer)) && (!printer.Equals("")))
            {
                lbPrinterName.Text = printer;
                BalanceWarehouse Warehouse = new BalanceWarehouse();
                Warehouse.UseDefaultCredentials = true;

                try
                {
                    Warehouse.WSSetPrinter(Globals.theWinlogon, Globals.theLocation, printer);
                }
                catch (Exception ex)
                {
                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                }

                Warehouse.Dispose();
            }
            
            tbInputData.Focus();
        }
    }
}
