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
    using WSWhseShipHeaderList;
    using WarehouseService;

    public partial class fmWarehouseShipmentHeaderList : Form
    {
        public fmWarehouseShipmentHeaderList()
        {
            InitializeComponent();
        }

        public void GetWhseShipmentHeaders()
        {
            WarehouseShipmentList_Service warehouseshipmentheaderlist = new WarehouseShipmentList_Service();
            warehouseshipmentheaderlist.UseDefaultCredentials = true;

            List<WarehouseShipmentList_Filter> WhseShipHeaderFilterArray = new List<WarehouseShipmentList_Filter>();

            WarehouseShipmentList_Filter LocationFilter = new WarehouseShipmentList_Filter();
            LocationFilter.Field = WarehouseShipmentList_Fields.Location_Code;
            LocationFilter.Criteria = Globals.theLocation;
            WhseShipHeaderFilterArray.Add(LocationFilter);

            WarehouseShipmentList_Filter StatusFilter = new WarehouseShipmentList_Filter();
            StatusFilter.Field = WarehouseShipmentList_Fields.Status;
            StatusFilter.Criteria = Status.Released.ToString();
            WhseShipHeaderFilterArray.Add(StatusFilter);

            WarehouseShipmentList[] Result = warehouseshipmentheaderlist.ReadMultiple(WhseShipHeaderFilterArray.ToArray(), "", 50);

            if (Result.Count() > 0)
            {
                dataGridView1.DataSource = Result;
                dataGridView1.Update();
            }
        }

        public int CountWhseShipmentHeaders()
        {
            WarehouseShipmentList_Service warehouseshipmentheaderlist = new WarehouseShipmentList_Service();
            warehouseshipmentheaderlist.UseDefaultCredentials = true;

            List<WarehouseShipmentList_Filter> WhseShipHeaderFilterArray = new List<WarehouseShipmentList_Filter>();

            WarehouseShipmentList_Filter LocationFilter = new WarehouseShipmentList_Filter();
            LocationFilter.Field = WarehouseShipmentList_Fields.Location_Code;
            LocationFilter.Criteria = Globals.theLocation;
            WhseShipHeaderFilterArray.Add(LocationFilter);

            WarehouseShipmentList_Filter StatusFilter = new WarehouseShipmentList_Filter();
            StatusFilter.Field = WarehouseShipmentList_Fields.Status;
            StatusFilter.Criteria = Status.Released.ToString();
            WhseShipHeaderFilterArray.Add(StatusFilter);

            WarehouseShipmentList[] Result = warehouseshipmentheaderlist.ReadMultiple(WhseShipHeaderFilterArray.ToArray(), "", 50);

            return Result.Count();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }

                int CurIndex = dataGridView1.CurrentRow.Index;

                fmWarehouseFright wf = new fmWarehouseFright(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                wf.ShowDialog();

                dataGridView1.CurrentCell = dataGridView1.Rows[CurIndex].Cells[0];

                return true;
            }

            if (keyData == Keys.D0)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }

                BalanceWarehouse Warehouse = new BalanceWarehouse();
                Warehouse.UseDefaultCredentials = true;
                try
                {
                    Warehouse.WSPrintWarehouseShipment(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                }
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            return true;
        }

        private void fmWarehouseShipmentHeaderList_Load(object sender, EventArgs e)
        {
            GetWhseShipmentHeaders();
        }
    }
}
