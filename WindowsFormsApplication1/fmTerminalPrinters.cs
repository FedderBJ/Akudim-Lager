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
    using WSTerminalPrinterList;

    public partial class fmTerminalPrinters : Form
    {
        private string printer = "";

        public fmTerminalPrinters()
        {
            InitializeComponent();
        }

        public void ShowDialog(ref string TermPrinter)
        {
            printer = TermPrinter;
            ShowDialog();
            TermPrinter = printer;
        }

        public void GetPrinters()
        {
            TerminalPrinterList_Service terminalprinterlistservice = new TerminalPrinterList_Service();
            terminalprinterlistservice.UseDefaultCredentials = true;

            List<TerminalPrinterList_Filter> TerminalPrinterFilterArray = new List<TerminalPrinterList_Filter>();

            TerminalPrinterList[] Result = terminalprinterlistservice.ReadMultiple(TerminalPrinterFilterArray.ToArray(), "", 1000);

            if (Result.Count() > 0)
            {
                dataGridView1.DataSource = Result;
                dataGridView1.Update();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }

                printer = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                this.Close();
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void fmTerminalPrinters_Load(object sender, EventArgs e)
        {
            GetPrinters();
        }

    }
}
