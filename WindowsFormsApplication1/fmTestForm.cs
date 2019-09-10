using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    using WarehouseService;
    public partial class fmTestForm : Form
    {
        public fmTestForm()
        {
            InitializeComponent();
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmPIDInfo));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
        string OK = "";
        string Error = "";
        bool Errormessage = false;

        MyToolbox mt = new MyToolbox();

        public void onePingError()
        {
            SoundPlayer simpleSound = new SoundPlayer(Error);
            simpleSound.Play();
        }
        public void onePingOK()
        {
            SoundPlayer simpleSound = new SoundPlayer(OK);
            simpleSound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string test = textBox1.Text == "1" ? "fmPickActivityListSourseType1" : "fmPickActivityListSourseType11";

            MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(test));
        }

        private void fmTestForm_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);

            BalanceWarehouse wh = new BalanceWarehouse();
            wh.UseDefaultCredentials = true;
            wh.WSReturnGeneralSetup(ref Error, ref OK, ref Errormessage); ;
            wh.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onePingError();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            onePingOK();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBoxExample.MyMessageBox.ShowBox(e.KeyCode.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BalanceWarehouse wh = new BalanceWarehouse();
            wh.UseDefaultCredentials = true;

            try
            {
                //MessageBoxExample.MyMessageBox.ShowBox( wh.WSEncodeCode128(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            finally
            {
                wh.Dispose();
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            BalanceWarehouse Warehouse = new BalanceWarehouse();
            if (checkBox1.Checked)
            {
                Warehouse.UseDefaultCredentials = true;
            }
            else
            {
                Warehouse.Credentials = new System.Net.NetworkCredential("JEWO", "Vinter2015", "FROESLEV");
            }
            
            try
            {

            }
            catch (Exception ecx)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ecx.Message);
            }
            

            Warehouse.Dispose();
        }



        private void button9_Click(object sender, EventArgs e)
        {
            BalanceWarehouse wh = new BalanceWarehouse();
            wh.UseDefaultCredentials = true;

            try
            {
                //MessageBoxExample.MyMessageBox.ShowBox( wh.WSEncodeCode128(textBox1.Text));
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            finally
            {
                wh.Dispose();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fmWarehouseReceiptList wrl = new fmWarehouseReceiptList();
            wrl.ShowDialog();
        }
    }
}
