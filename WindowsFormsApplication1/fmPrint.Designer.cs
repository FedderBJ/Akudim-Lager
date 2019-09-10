namespace WindowsFormsApplication1
{
    partial class fmPrint
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
            this.tbInputData = new System.Windows.Forms.MaskedTextBox();
            this.lblInputText = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.lbDescription = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInputData
            // 
            this.tbInputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.tbInputData.Location = new System.Drawing.Point(0, 51);
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.Size = new System.Drawing.Size(290, 53);
            this.tbInputData.TabIndex = 1;
            this.tbInputData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInputData_KeyDown);
            this.tbInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInputData_KeyPress);
            // 
            // lblInputText
            // 
            this.lblInputText.AutoSize = true;
            this.lblInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblInputText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInputText.Location = new System.Drawing.Point(1, 9);
            this.lblInputText.Name = "lblInputText";
            this.lblInputText.Size = new System.Drawing.Size(294, 24);
            this.lblInputText.TabIndex = 31;
            this.lblInputText.Text = "Scan P-ID, Vare nr. eller placering";
            // 
            // btPrint
            // 
            this.btPrint.Enabled = false;
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(49, 221);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(200, 58);
            this.btPrint.TabIndex = 3;
            this.btPrint.Text = "Udskriv";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDescription.Location = new System.Drawing.Point(-2, 112);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(0, 24);
            this.lbDescription.TabIndex = 33;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(189, 156);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(98, 49);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 42);
            this.label1.TabIndex = 34;
            this.label1.Text = "Antal Stk.";
            // 
            // fmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 287);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.tbInputData);
            this.Name = "fmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbInputData;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}