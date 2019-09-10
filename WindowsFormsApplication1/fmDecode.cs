using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class fmDecode : Form
    {
        public fmDecode()
        {
            InitializeComponent();
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmDecode));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }


        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string ID = "";
                lblDataIn.Text = tbInputData.Text;
                while (tbInputData.Text.Length > 0)
                {
                    if (!ID.Equals("XX"))
                        ID = tbInputData.Text.Substring(0, 2);
                    switch (ID)
                    {
                        case "00":
                            {
                                try
                                {
                                    lbl00.Text = tbInputData.Text.Substring(2, 18);
                                    tbInputData.Text = tbInputData.Text.Remove(0, 20);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    ID = "XX";
                                }
                            }
                            break;
                        case "01":
                            {
                                try
                                {
                                    lbl01.Text = tbInputData.Text.Substring(2, 14);
                                    tbInputData.Text = tbInputData.Text.Remove(0, 16);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    ID = "XX";
                                }
                            }
                            break;
                        case "02":
                            {
                                try
                                {
                                    lbl02.Text = tbInputData.Text.Substring(2, 14);
                                    tbInputData.Text = tbInputData.Text.Remove(0, 16);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    ID = "XX";
                                }
                            }
                            break;
                        case "10":
                            {
                                try
                                {
                                    lbl10.Text = tbInputData.Text.Substring(2);
                                    tbInputData.Text = tbInputData.Text.Remove(0);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    ID = "XX";
                                }
                            }
                            break;
                        case "15":
                            {
                                try
                                {
                                    lbl15.Text = tbInputData.Text.Substring(6, 2) + tbInputData.Text.Substring(4, 2) + tbInputData.Text.Substring(2, 2);
                                    tbInputData.Text = tbInputData.Text.Remove(0, 8);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    ID = "XX";
                                }
                            }
                            break;
                        case "37":
                            {
                                try
                                {
                                    lbl37.Text = tbInputData.Text.Substring(2);
                                    tbInputData.Text = tbInputData.Text.Remove(0);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    ID = "XX";
                                }
                            }
                            break;
                        case "XX":
                            {
                                tbInputData.Text = "";
                            }
                            break;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Decoding.theCode00 = "";
            Decoding.theCode01 = "";
            Decoding.theCode02 = "";
            Decoding.theCode10 = "";
            Decoding.theCode15 = "";
            Decoding.theCode37 = "";
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Decoding.theCode00 = lbl00.Text;
            Decoding.theCode01 = lbl01.Text;
            Decoding.theCode02 = lbl02.Text;
            Decoding.theCode10 = lbl10.Text;
            Decoding.theCode15 = lbl15.Text;
            Decoding.theCode37 = lbl37.Text;
            this.Close();
        }

        private void fmDecode_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);

        }
    }
}
