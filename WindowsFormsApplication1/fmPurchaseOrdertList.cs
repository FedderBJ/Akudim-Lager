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
    using WSPurchaseOrderList;
    public partial class fmPurchaseOrdertList : Form
    {
        public fmPurchaseOrdertList()
        {
            InitializeComponent();
        }

        MyToolbox mt = new MyToolbox();
        DataTable dtBin = null; 

        string filterField = "";

        public void ReturnReceipts(string LocationCode)
        {
            if (dtBin == null)
            {
                dtBin = new DataTable();
                dtBin.Columns.Add(mt.ReadResFile(this.Name.ToString() + "No"), typeof(string));
                dtBin.Columns.Add(mt.ReadResFile(this.Name.ToString() + "Name"), typeof(string));
                dtBin.Columns.Add(mt.ReadResFile(this.Name.ToString() + "Order"), typeof(string));
            }
            else
                dtBin.Rows.Clear();

            PurchaseOrderList_Service purchaseorderservice = new PurchaseOrderList_Service();
            purchaseorderservice.UseDefaultCredentials = true;

            List<PurchaseOrderList_Filter> PurchaseOrderFilterArray = new List<PurchaseOrderList_Filter>();
    
            PurchaseOrderList_Filter LocationFilter= new PurchaseOrderList_Filter();
            LocationFilter.Field = PurchaseOrderList_Fields.Location_Code;
            LocationFilter.Criteria = LocationCode;
            PurchaseOrderFilterArray.Add(LocationFilter);

            PurchaseOrderList_Filter StatusFilter = new PurchaseOrderList_Filter();
            StatusFilter.Field = PurchaseOrderList_Fields.Status;
            StatusFilter.Criteria = Status.Released.ToString();
            PurchaseOrderFilterArray.Add(StatusFilter);

            PurchaseOrderList_Filter AssignedFilter = new PurchaseOrderList_Filter();
            AssignedFilter.Field = PurchaseOrderList_Fields.Assigned_User_ID;
            AssignedFilter.Criteria = Globals.theWinlogon;
            PurchaseOrderFilterArray.Add(AssignedFilter);


            PurchaseOrderList [] PurchaseOrderResult = purchaseorderservice.ReadMultiple(PurchaseOrderFilterArray.ToArray(), "", 1000);

            if (PurchaseOrderResult.Count() > 0)
            {

                foreach (var item in PurchaseOrderResult)
                {
                    if (item.No != "")
                        dtBin.Rows.Add(new object[] { item.No, item.Buy_from_Vendor_Name, (item.Vendor_Order_No == null ? "" : item.Vendor_Order_No) });
                }

                dataGridView1.DataSource = dtBin;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Update();
                tbFilter.Focus();
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
                        fmWhseReceiptSingle wrs = new fmWhseReceiptSingle(dataGridView1.CurrentRow.Cells[0].Value.ToString(), 39);
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

        private void fmPurchaseOrdertList_Load(object sender, EventArgs e)
        {
            ReturnReceipts(Globals.theLocation);
            filterField = mt.ReadResFile(this.Name.ToString() + "No");
            tbFilter.Focus();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            dtBin.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, tbFilter.Text);
        }
    }
}
