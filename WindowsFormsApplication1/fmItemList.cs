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
    using WSTestItemList;

    public partial class fmItemList : Form
    {
        public fmItemList()
        {
            InitializeComponent();
        }

        public void GetItemList()
        {
            var service = new TestItem_Service();
            service.UseDefaultCredentials = true;

            List<TestItem_Filter> FilterArray = new List<TestItem_Filter>();

            TestItem_Filter ItemNoFilter = new TestItem_Filter();
            ItemNoFilter.Field = TestItem_Fields.No;
            ItemNoFilter.Criteria = "60209";
            FilterArray.Add(ItemNoFilter);

            //TestItem_Filter VariantFilter = new TestItem_Filter();
            //VariantFilter.Field = TestItem_Fields.Variant_Filter;
            //VariantFilter.Criteria = "L";
            //FilterArray.Add(VariantFilter);

            TestItem[] Result = service.ReadMultiple(FilterArray.ToArray(), "", 100);

            dataGridView1.DataSource = Result;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void fmItemList_Load(object sender, EventArgs e)
        {
            GetItemList();
        }
    }
}
