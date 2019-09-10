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
    using WSWarehouseReceipts;
    public partial class fmWarehouseReceiptList : Form
    {
        MyToolbox mt = new MyToolbox();
        private DataTable dtWhseResiepts = null; 

        public fmWarehouseReceiptList()
        {
            InitializeComponent();
        }

        public void ReturnReceipts(string LocationCode)
        {
            if (dtWhseResiepts == null)
            {
                dtWhseResiepts = new DataTable();
                dtWhseResiepts.Columns.Add("Navn", typeof(string));
                dtWhseResiepts.Columns.Add("Ordre Type", typeof(string));
                dtWhseResiepts.Columns.Add("Ordre Nr.", typeof(string));
            }
            else
                dtWhseResiepts.Rows.Clear();

            WhseReceiptList_Service warehousrecieptlistservice = new WhseReceiptList_Service();
            warehousrecieptlistservice.UseDefaultCredentials = true;

            List<WhseReceiptList_Filter> WhseRecieptFilterArray = new List<WhseReceiptList_Filter>();

            WhseReceiptList_Filter LocationFilter = new WhseReceiptList_Filter();
            LocationFilter.Field = WhseReceiptList_Fields.Location_Code;
            LocationFilter.Criteria = LocationCode;
            WhseRecieptFilterArray.Add(LocationFilter);
         
            WhseReceiptList [] Result = warehousrecieptlistservice.ReadMultiple(WhseRecieptFilterArray.ToArray(), "", 50);

            if (Result.Count() > 0)
            {

                foreach (var item in Result)
                {
                    if (item.No != "")
                        dtWhseResiepts.Rows.Add(new object[] { item.Buy_from_Vendor_Name, (item.Order_Type.ToString() == "Purchase_Order" ? "Købsordre" : "Returordre"), item.Order_No });
                }

                dataGridView1.DataSource = dtWhseResiepts;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Update();
            }
            else
            {
                fmWhseReceiptSingle wrs = new fmWhseReceiptSingle();
                wrs.ShowDialog();
                this.Close();
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

                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != "")
                {
                    #region BAL6.45
                    fmWhseReceiptSingle wrs = new fmWhseReceiptSingle(dataGridView1.CurrentRow.Cells[2].Value.ToString(), (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Købsordre" ? 39 : 37));
                    wrs.ShowDialog();
                    #endregion
                    ReturnReceipts(Globals.theLocation);
                }

                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void fmWarehouseReceiptList_Load(object sender, EventArgs e)
        {
            ReturnReceipts(Globals.theLocation);
        }
    }
}
