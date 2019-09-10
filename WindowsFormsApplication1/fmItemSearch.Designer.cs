namespace WindowsFormsApplication1
{
    partial class fmItemSearch
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
            this.SuspendLayout();
            // 
            // tbInputData
            // 
            this.tbInputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.tbInputData.Location = new System.Drawing.Point(1, 46);
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.Size = new System.Drawing.Size(381, 53);
            this.tbInputData.TabIndex = 5;
            this.tbInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInputData_KeyPress);
            // 
            // lblInputText
            // 
            this.lblInputText.AutoSize = true;
            this.lblInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.lblInputText.ImageKey = "(none)";
            this.lblInputText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblInputText.Location = new System.Drawing.Point(-5, 9);
            this.lblInputText.Name = "lblInputText";
            this.lblInputText.Size = new System.Drawing.Size(162, 33);
            this.lblInputText.TabIndex = 6;
            this.lblInputText.Text = "Scan varen";
            // 
            // fmItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.ControlBox = false;
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.tbInputData);
            this.Name = "fmItemSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tbInputData;
        private System.Windows.Forms.Label lblInputText;
    }
}