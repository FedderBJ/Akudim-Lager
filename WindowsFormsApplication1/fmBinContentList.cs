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
    using WSItemBinContent;

    public partial class fmBinContentList : Form
    {
        private string itemno = "";

        public fmBinContentList()
        {
            InitializeComponent();
        }

        public fmBinContentList(string ItemNo)
        {
            InitializeComponent();
            itemno = ItemNo;
        }

        public void ShowDialog(ref string ItemNo)
        {
            itemno = ItemNo;

            this.ShowDialog();

            ItemNo = itemno;
        }

        public void GetBinContent()
        {
            ItemBinContent_Service itembincontentservice = new ItemBinContent_Service();
            itembincontentservice.UseDefaultCredentials = true;

            List<ItemBinContent_Filter> ItemBincontentFilterArray = new List<ItemBinContent_Filter>();

            ItemBinContent_Filter LocationFilter = new ItemBinContent_Filter();
            LocationFilter.Field = ItemBinContent_Fields.Location_Code;
            LocationFilter.Criteria = Globals.theLocation;
            ItemBincontentFilterArray.Add(LocationFilter);

            ItemBinContent_Filter ItemNoFilter = new ItemBinContent_Filter();
            ItemNoFilter.Field = ItemBinContent_Fields.Item_No;
            ItemNoFilter.Criteria = itemno;
            ItemBincontentFilterArray.Add(ItemNoFilter);

            ItemBinContent_Filter QtyFilter = new ItemBinContent_Filter();
            QtyFilter.Field = ItemBinContent_Fields.Quantity_Base;
            QtyFilter.Criteria = "<>0";
            ItemBincontentFilterArray.Add(QtyFilter);

            ItemBinContent[] Result = itembincontentservice.ReadMultiple(ItemBincontentFilterArray.ToArray(), "", 100);

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

                itemno  = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                this.Close();
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void fmBinContentList_Load(object sender, EventArgs e)
        {
            GetBinContent();
        }

    }
}
