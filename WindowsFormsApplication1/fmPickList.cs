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
    using WSPickList;
    using WarehouseService;
    public partial class fmPickList : Form
    {
        private string userid = "";

        public fmPickList()
        {
            InitializeComponent();
        }

        public fmPickList(string UserId)
        {
            InitializeComponent();
            userid = UserId;
            GetPickOrders(UserId);
        }

        public void GetPickOrders(string UserId)
        {
            PickList_Service picklistservice = new PickList_Service();
            picklistservice.UseDefaultCredentials = true;

            List<PickList_Filter> PickListFilterArray = new List<PickList_Filter>();

            PickList_Filter UserIdFilter = new PickList_Filter();
            UserIdFilter.Field = PickList_Fields.Assigned_User_ID;
            UserIdFilter.Criteria = UserId;
            PickListFilterArray.Add(UserIdFilter);

            PickList[] Details = picklistservice.ReadMultiple(PickListFilterArray.ToArray(), "", 1000);

            if (Details.Count() > 0)
            {
                foreach (var item in Details)
                {
                    if (item.No_of_LinesSpecified)
                    {
                        item.No_of_Lines = (item.No_of_Lines / 2);
                    }
                }
                dataGridView1.DataSource = Details;
                dataGridView1.Update();
            }
        }

        public int ReturnNoOfOrders(string UserId)
        {
            PickList_Service picklistservice = new PickList_Service();
            picklistservice.UseDefaultCredentials = true;

            List<PickList_Filter> PickListFilterArray = new List<PickList_Filter>();

            PickList_Filter UserIdFilter = new PickList_Filter();
            UserIdFilter.Field = PickList_Fields.Assigned_User_ID;
            UserIdFilter.Criteria = UserId;
            PickListFilterArray.Add(UserIdFilter);

            PickList[] Details = picklistservice.ReadMultiple(PickListFilterArray.ToArray(), "", 1000);

            return Details.Count();
        }

        public PickList [] ReturnOrder(string OrderNo)
        {
            PickList_Service picklistservice = new PickList_Service();
            picklistservice.UseDefaultCredentials = true;

            List<PickList_Filter> PickListFilterArray = new List<PickList_Filter>();

            PickList_Filter OrderIdFilter = new PickList_Filter();
            OrderIdFilter.Field = PickList_Fields.No;
            OrderIdFilter.Criteria = OrderNo;
            PickListFilterArray.Add(OrderIdFilter);

            PickList[] Details = picklistservice.ReadMultiple(PickListFilterArray.ToArray(), "", 1000);

            return Details;
        }

        public void ShowDialog(string UserId)
        {
            userid = UserId;
            GetPickOrders(UserId);
            this.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }

                //int CurIndex = dataGridView1.CurrentRow.Index;

                fmPickOrder po = new fmPickOrder(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                po.ShowDialog();

                GetPickOrders(userid);

                //dataGridView1.CurrentCell = dataGridView1.Rows[CurIndex].Cells[0];

                return true;
            }

            if (keyData == Keys.D0)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }
                 
                int CurIndex = dataGridView1.CurrentRow.Index;

                fmWarehouseFright wf = new fmWarehouseFright(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                wf.ShowDialog();

                dataGridView1.CurrentCell = dataGridView1.Rows[CurIndex].Cells[0];

                return true;
            }

            if (keyData == Keys.D8)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }
                int CurIndex = dataGridView1.CurrentRow.Index;

                fmWarehouseShipmentHeaderList wsl = new fmWarehouseShipmentHeaderList();
                wsl.ShowDialog();

                dataGridView1.CurrentCell = dataGridView1.Rows[CurIndex].Cells[0];

                return true;
            }


            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
