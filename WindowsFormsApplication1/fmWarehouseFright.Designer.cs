namespace WindowsFormsApplication1
{
    partial class fmWarehouseFright
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.salesOrderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.freightAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentMethodCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseShipmentFrightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btPost = new System.Windows.Forms.Button();
            this.lblWarehouseshipmentNo = new System.Windows.Forms.Label();
            this.lbWarehouseshipmentNo = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.btComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseShipmentFrightBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.ColumnHeadersHeight = 55;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.salesOrderNoDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.freightAmountDataGridViewTextBoxColumn,
            this.shipmentMethodCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.warehouseShipmentFrightBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(462, 163);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // salesOrderNoDataGridViewTextBoxColumn
            // 
            this.salesOrderNoDataGridViewTextBoxColumn.DataPropertyName = "Sales_Order_No";
            this.salesOrderNoDataGridViewTextBoxColumn.HeaderText = "Salgs- Ordre nr.";
            this.salesOrderNoDataGridViewTextBoxColumn.Name = "salesOrderNoDataGridViewTextBoxColumn";
            this.salesOrderNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "Customer_Name";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Navn";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // freightAmountDataGridViewTextBoxColumn
            // 
            this.freightAmountDataGridViewTextBoxColumn.DataPropertyName = "Freight_Amount";
            this.freightAmountDataGridViewTextBoxColumn.HeaderText = "Fragt beløb";
            this.freightAmountDataGridViewTextBoxColumn.Name = "freightAmountDataGridViewTextBoxColumn";
            this.freightAmountDataGridViewTextBoxColumn.Width = 80;
            // 
            // shipmentMethodCodeDataGridViewTextBoxColumn
            // 
            this.shipmentMethodCodeDataGridViewTextBoxColumn.DataPropertyName = "Shipment_Method_Code";
            this.shipmentMethodCodeDataGridViewTextBoxColumn.HeaderText = "Leverings- kode";
            this.shipmentMethodCodeDataGridViewTextBoxColumn.Name = "shipmentMethodCodeDataGridViewTextBoxColumn";
            this.shipmentMethodCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipmentMethodCodeDataGridViewTextBoxColumn.Width = 110;
            // 
            // warehouseShipmentFrightBindingSource
            // 
            this.warehouseShipmentFrightBindingSource.DataSource = typeof(WindowsFormsApplication1.WSWarehouseFright.WarehouseShipmentFright);
            // 
            // btPost
            // 
            this.btPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPost.Location = new System.Drawing.Point(301, 570);
            this.btPost.Name = "btPost";
            this.btPost.Size = new System.Drawing.Size(162, 48);
            this.btPost.TabIndex = 3;
            this.btPost.Text = "Bogfør leverance";
            this.btPost.UseVisualStyleBackColor = true;
            this.btPost.Click += new System.EventHandler(this.btPost_Click);
            // 
            // lblWarehouseshipmentNo
            // 
            this.lblWarehouseshipmentNo.AutoSize = true;
            this.lblWarehouseshipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouseshipmentNo.Location = new System.Drawing.Point(-3, 7);
            this.lblWarehouseshipmentNo.Name = "lblWarehouseshipmentNo";
            this.lblWarehouseshipmentNo.Size = new System.Drawing.Size(168, 24);
            this.lblWarehouseshipmentNo.TabIndex = 5;
            this.lblWarehouseshipmentNo.Text = "Lagerleverance nr.";
            // 
            // lbWarehouseshipmentNo
            // 
            this.lbWarehouseshipmentNo.AutoSize = true;
            this.lbWarehouseshipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWarehouseshipmentNo.Location = new System.Drawing.Point(181, 7);
            this.lbWarehouseshipmentNo.Name = "lbWarehouseshipmentNo";
            this.lbWarehouseshipmentNo.Size = new System.Drawing.Size(0, 24);
            this.lbWarehouseshipmentNo.TabIndex = 6;
            // 
            // tbInfo
            // 
            this.tbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfo.Location = new System.Drawing.Point(1, 355);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(462, 209);
            this.tbInfo.TabIndex = 7;
            // 
            // tbComments
            // 
            this.tbComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComments.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbComments.Location = new System.Drawing.Point(1, 221);
            this.tbComments.Multiline = true;
            this.tbComments.Name = "tbComments";
            this.tbComments.ReadOnly = true;
            this.tbComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComments.Size = new System.Drawing.Size(462, 128);
            this.tbComments.TabIndex = 0;
            this.tbComments.TabStop = false;
            // 
            // btComment
            // 
            this.btComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btComment.Location = new System.Drawing.Point(3, 570);
            this.btComment.Name = "btComment";
            this.btComment.Size = new System.Drawing.Size(162, 48);
            this.btComment.TabIndex = 8;
            this.btComment.Text = "Vis / Tilføj Bemærkning";
            this.btComment.UseVisualStyleBackColor = true;
            this.btComment.Click += new System.EventHandler(this.btComment_Click);
            // 
            // fmWarehouseFright
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 624);
            this.ControlBox = false;
            this.Controls.Add(this.btComment);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.lbWarehouseshipmentNo);
            this.Controls.Add(this.lblWarehouseshipmentNo);
            this.Controls.Add(this.btPost);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbComments);
            this.Name = "fmWarehouseFright";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fmWarehouseFright_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseShipmentFrightBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btPost;
        private System.Windows.Forms.BindingSource warehouseShipmentFrightBindingSource;
        private System.Windows.Forms.Label lblWarehouseshipmentNo;
        private System.Windows.Forms.Label lbWarehouseshipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesOrderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn freightAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentMethodCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Button btComment;
    }
}