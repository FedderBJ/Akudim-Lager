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
    using WSWarehouseFright;
    using WSSalesOrderHeader;
    using WSSalesCommentLines;
    using WarehouseService;

    public partial class fmWarehouseFright : Form
    {
        private string WhseShipNo = "";
        private WarehouseShipmentFright[] Result = null;
        private SalesOrderHeader SalesOrderResult = null;

        public fmWarehouseFright()
        {
            InitializeComponent();
        }

        public fmWarehouseFright(string WarehouseShipmentNo)
        {
            InitializeComponent();
            WhseShipNo = WarehouseShipmentNo;
        }

        public void GetCommentLines()
        {
            if (SalesOrderResult.CommentSpecified)
            {
                fmComment cs = new fmComment(WSSalesCommentLines.Document_Type.Order, SalesOrderResult.No);
                SalesCommentLines[] Comments = cs.GetCommentArray();
                tbComments.Text = "";
                foreach (var item in Comments)
                {
                    tbComments.Text = tbComments.Text + item.Comment + Environment.NewLine;
                }
            }
        }

        public void GetSalesOrder()
        {
            SalesOrderHeader_Service SOH = new SalesOrderHeader_Service();
            SOH.UseDefaultCredentials = true;

            SalesOrderResult = SOH.Read(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            tbInfo.Text =
                string.Format("{0} {1}{2}{3} {4}{5}{6}{7}{8}{9}{10}{11}{12} {13}{14}{15} {16}{17}{18} {19}",
                              "Leveringskode:", SalesOrderResult.Shipment_Method_Code, Environment.NewLine,
                              "Betalingsbet. kode:", SalesOrderResult.Payment_Method_Code, Environment.NewLine,
                              SalesOrderResult.Ship_to_Name, Environment.NewLine,
                              SalesOrderResult.Ship_to_Address, Environment.NewLine,
                              SalesOrderResult.Ship_to_Address_2, Environment.NewLine,
                              SalesOrderResult.Ship_to_Post_Code, SalesOrderResult.Ship_to_City, Environment.NewLine,
                              "Ordrebeløb: ", Result[dataGridView1.CurrentRow.Index].Total_Kundeordrebeløb.ToString("N2"), Environment.NewLine,
                              "Ordrevægt: ", Result[dataGridView1.CurrentRow.Index].VægtKundeordre.ToString("N2"));
            GetCommentLines();
        }

        public void GetCustomers()
        {
            BalanceWarehouse Warehouse = new BalanceWarehouse();
            Warehouse.UseDefaultCredentials = true;

            try
            {
                Warehouse.WSFindCustomers(WhseShipNo);
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }

            WarehouseShipmentFright_Service whsefrightservice = new WarehouseShipmentFright_Service();
            whsefrightservice.UseDefaultCredentials = true;

            List<WarehouseShipmentFright_Filter> WarehouseShipmentFrightFilterArray = new List<WarehouseShipmentFright_Filter>();

            WarehouseShipmentFright_Filter WarehouseShipmentNoFilter = new WarehouseShipmentFright_Filter();
            WarehouseShipmentNoFilter.Field = WarehouseShipmentFright_Fields.Warehouse_Shipment_Header_No;
            WarehouseShipmentNoFilter.Criteria = WhseShipNo;
            WarehouseShipmentFrightFilterArray.Add(WarehouseShipmentNoFilter);

            Result = whsefrightservice.ReadMultiple(WarehouseShipmentFrightFilterArray.ToArray(), "", 50);

            if (Result.Count() > 0)
            {
                dataGridView1.DataSource = Result;
                dataGridView1.Update();
            }
        }

        public void UpdateWarehouseFright()
        {
            var FrightService = new WarehouseShipmentFright_Service();
            FrightService.UseDefaultCredentials = true;

            for (int i = 0; i < (Result.Count() -1); i++)
            {
                Result[i].Freight_Amount = decimal.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            try
            {
                FrightService.UpdateMultiple(ref Result);
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);  
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
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void fmWarehouseFright_Load(object sender, EventArgs e)
        {
            lbWarehouseshipmentNo.Text = WhseShipNo;
            GetCustomers();
        }

        private void btPost_Click(object sender, EventArgs e)
        {
            UpdateWarehouseFright();
            BalanceWarehouse Warehouse = new BalanceWarehouse();
            Warehouse.UseDefaultCredentials = true;

            try
            {
                if(Warehouse.WSPostWarehouseShipment(WhseShipNo))
                   MessageBoxExample.MyMessageBox.ShowBox("Fragt er registreret og leverancen bogført");
                else
                    MessageBoxExample.MyMessageBox.ShowBox("Fejl ved bogføring. Tjek ved en PC!");
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GetSalesOrder();
        }

        private void btComment_Click(object sender, EventArgs e)
        {
            fmComment cs = new fmComment(WSSalesCommentLines.Document_Type.Order, SalesOrderResult.No);
            cs.ShowDialog();
            GetCommentLines();
        }
    }
}
