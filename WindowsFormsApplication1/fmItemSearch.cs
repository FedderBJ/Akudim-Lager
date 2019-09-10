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
    public partial class fmItemSearch : Form
    {
        public fmItemSearch()
        {
            InitializeComponent();
        }

        public void ShowDialog(ref string tbSearch)
        {
            tbSearch = "";
            this.ShowDialog();
            tbSearch = tbInputData.Text;
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
