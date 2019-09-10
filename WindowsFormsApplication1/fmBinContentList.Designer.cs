namespace WindowsFormsApplication1
{
    partial class fmBinContentList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemBinContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.binCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcQtyUOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitofMeasureCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBinContentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 60;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.binCodeDataGridViewTextBoxColumn,
            this.quantityBaseDataGridViewTextBoxColumn,
            this.calcQtyUOMDataGridViewTextBoxColumn,
            this.unitofMeasureCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.itemBinContentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(462, 619);
            this.dataGridView1.TabIndex = 1;
            // 
            // itemBinContentBindingSource
            // 
            this.itemBinContentBindingSource.DataSource = typeof(WindowsFormsApplication1.WSItemBinContent.ItemBinContent);
            // 
            // binCodeDataGridViewTextBoxColumn
            // 
            this.binCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.binCodeDataGridViewTextBoxColumn.DataPropertyName = "Bin_Code";
            this.binCodeDataGridViewTextBoxColumn.HeaderText = "Placering";
            this.binCodeDataGridViewTextBoxColumn.Name = "binCodeDataGridViewTextBoxColumn";
            this.binCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityBaseDataGridViewTextBoxColumn
            // 
            this.quantityBaseDataGridViewTextBoxColumn.DataPropertyName = "Quantity_Base";
            this.quantityBaseDataGridViewTextBoxColumn.HeaderText = "Antal";
            this.quantityBaseDataGridViewTextBoxColumn.Name = "quantityBaseDataGridViewTextBoxColumn";
            this.quantityBaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calcQtyUOMDataGridViewTextBoxColumn
            // 
            this.calcQtyUOMDataGridViewTextBoxColumn.DataPropertyName = "CalcQtyUOM";
            this.calcQtyUOMDataGridViewTextBoxColumn.HeaderText = "Antal pr enhed";
            this.calcQtyUOMDataGridViewTextBoxColumn.Name = "calcQtyUOMDataGridViewTextBoxColumn";
            this.calcQtyUOMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitofMeasureCodeDataGridViewTextBoxColumn
            // 
            this.unitofMeasureCodeDataGridViewTextBoxColumn.DataPropertyName = "Unit_of_Measure_Code";
            this.unitofMeasureCodeDataGridViewTextBoxColumn.HeaderText = "Enhed";
            this.unitofMeasureCodeDataGridViewTextBoxColumn.Name = "unitofMeasureCodeDataGridViewTextBoxColumn";
            this.unitofMeasureCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fmBinContentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 624);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(480, 640);
            this.MinimumSize = new System.Drawing.Size(480, 640);
            this.Name = "fmBinContentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fmBinContentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBinContentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn binCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityBaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcQtyUOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitofMeasureCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource itemBinContentBindingSource;
    }
}