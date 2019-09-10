namespace WindowsFormsApplication1
{
    partial class fmSelector
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
            this.lbHelpTxt = new System.Windows.Forms.Label();
            this.lbCaption = new System.Windows.Forms.Label();
            this.pbIndicator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInputData
            // 
            this.tbInputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.tbInputData.Location = new System.Drawing.Point(1, 114);
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.Size = new System.Drawing.Size(463, 53);
            this.tbInputData.TabIndex = 29;
            this.tbInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInputData_KeyPress);
            // 
            // lblInputText
            // 
            this.lblInputText.AutoSize = true;
            this.lblInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblInputText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInputText.Location = new System.Drawing.Point(-5, 70);
            this.lblInputText.Name = "lblInputText";
            this.lblInputText.Size = new System.Drawing.Size(376, 39);
            this.lblInputText.TabIndex = 28;
            this.lblInputText.Text = "Scan P-ID eller Vare nr.";
            // 
            // lbHelpTxt
            // 
            this.lbHelpTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbHelpTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbHelpTxt.Location = new System.Drawing.Point(1, 192);
            this.lbHelpTxt.Name = "lbHelpTxt";
            this.lbHelpTxt.Size = new System.Drawing.Size(463, 429);
            this.lbHelpTxt.TabIndex = 31;
            this.lbHelpTxt.Text = "Hjælp";
            // 
            // lbCaption
            // 
            this.lbCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lbCaption.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCaption.Location = new System.Drawing.Point(1, 9);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(463, 39);
            this.lbCaption.TabIndex = 32;
            this.lbCaption.Text = "1";
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbIndicator
            // 
            this.pbIndicator.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbIndicator.Location = new System.Drawing.Point(200, 280);
            this.pbIndicator.Name = "pbIndicator";
            this.pbIndicator.Size = new System.Drawing.Size(65, 65);
            this.pbIndicator.TabIndex = 76;
            this.pbIndicator.TabStop = false;
            this.pbIndicator.Visible = false;
            // 
            // fmSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(464, 624);
            this.ControlBox = false;
            this.Controls.Add(this.pbIndicator);
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.lbHelpTxt);
            this.Controls.Add(this.tbInputData);
            this.Controls.Add(this.lblInputText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "fmSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.fmSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbInputData;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.Label lbHelpTxt;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.PictureBox pbIndicator;
    }
}