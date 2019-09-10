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
    using WSSalesCommentLines;
    using WarehouseService;
    public partial class fmComment : Form
    {
        private string orderno = "";
        private Document_Type doctype = 0;
        private SalesCommentLines[] CommentLines = null;
        private SalesCommentLines Line = null;

        public fmComment()
        {
            InitializeComponent();
        }

        public fmComment(Document_Type DocType, String OrderNo)
        {
            InitializeComponent();
            orderno = OrderNo;
            doctype = DocType;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter) && (dataGridView1.Focused))
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return true;
                }

                int CurIndex = dataGridView1.CurrentRow.Index;

                
                // kald edit formen med linjen som ref param.

                // Create Service Reference 
                var service = new SalesCommentLines_Service();
                service.UseDefaultCredentials = true;

                Line = CommentLines[CurIndex];

                tbComment.Text = Line.Comment;
                tbComment.Focus();
            }

            if ((keyData == Keys.Escape) && (dataGridView1.Focused)) 
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void GetComment()
        {
            var service = new SalesCommentLines_Service();
            service.UseDefaultCredentials = true;

            List<SalesCommentLines_Filter> SalesCommentLineFilterArray = new List<SalesCommentLines_Filter>();

            SalesCommentLines_Filter DocTypeFiler = new SalesCommentLines_Filter();
            DocTypeFiler.Field = SalesCommentLines_Fields.Document_Type;
            DocTypeFiler.Criteria = doctype.ToString();
            SalesCommentLineFilterArray.Add(DocTypeFiler);

            SalesCommentLines_Filter DocNo = new SalesCommentLines_Filter();
            DocNo.Field = SalesCommentLines_Fields.No;
            DocNo.Criteria = orderno;
            SalesCommentLineFilterArray.Add(DocNo);

            CommentLines = service.ReadMultiple(SalesCommentLineFilterArray.ToArray(), "", 50);

            dataGridView1.DataSource = CommentLines;
            dataGridView1.Update();
        }

        public SalesCommentLines [] GetCommentArray()
        {
            var service = new SalesCommentLines_Service();
            service.UseDefaultCredentials = true;

            List<SalesCommentLines_Filter> SalesCommentLineFilterArray = new List<SalesCommentLines_Filter>();

            SalesCommentLines_Filter DocTypeFiler = new SalesCommentLines_Filter();
            DocTypeFiler.Field = SalesCommentLines_Fields.Document_Type;
            DocTypeFiler.Criteria = doctype.ToString();
            SalesCommentLineFilterArray.Add(DocTypeFiler);

            SalesCommentLines_Filter DocNo = new SalesCommentLines_Filter();
            DocNo.Field = SalesCommentLines_Fields.No;
            DocNo.Criteria = orderno;
            SalesCommentLineFilterArray.Add(DocNo);

            CommentLines = service.ReadMultiple(SalesCommentLineFilterArray.ToArray(), "", 50);

            return CommentLines;
        }

        private void fmComment_Load(object sender, EventArgs e)
        {
            GetComment();
        }

        private void tbComment_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter) && (tbComment.Focus()))
            {
                if (Line != null)
                {
                    var service = new SalesCommentLines_Service();
                    service.UseDefaultCredentials = true;

                    if (!tbComment.Text.Equals(""))
                    {
                        Line.Comment = tbComment.Text;
                        service.Update(ref Line);
                    }
                    else
                    {
                        if (MessageBox.Show("Vil du slette linjen?", "Slet bemærkningslinje", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            service.Delete(Line.Key);
                        }
                    }
                    tbComment.Text = "";
                    Line = null;
                }
                else
                {
                    var service = new BalanceWarehouse();
                    service.UseDefaultCredentials = true;

                    try
                    {
                        service.WSCreateSalesCommentLine((int)Document_Type.Order, orderno, tbComment.Text);
                        tbComment.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                    }
                }
                GetComment();
            }

            if ((e.KeyData == Keys.Escape) && (tbComment.Focus()))
            {
                this.Close();
            }
        }
    }
}
