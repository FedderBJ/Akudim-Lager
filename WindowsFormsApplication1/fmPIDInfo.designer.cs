namespace WindowsFormsApplication1
{
    partial class fmPIDInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPIDInfo));
            this.lblInputText = new System.Windows.Forms.Label();
            this.tbInputData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.lbVendorLot = new System.Windows.Forms.Label();
            this.lbExpiredate = new System.Windows.Forms.Label();
            this.lbUnitOfMesure = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbItemNo = new System.Windows.Forms.Label();
            this.lbBin = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.btnBlock = new System.Windows.Forms.Button();
            this.pbIndicator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInputText
            // 
            resources.ApplyResources(this.lblInputText, "lblInputText");
            this.lblInputText.Name = "lblInputText";
            // 
            // tbInputData
            // 
            resources.ApplyResources(this.tbInputData, "tbInputData");
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInputData_KeyPress);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btPrint
            // 
            resources.ApplyResources(this.btPrint, "btPrint");
            this.btPrint.Name = "btPrint";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // lbVendorLot
            // 
            this.lbVendorLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbVendorLot, "lbVendorLot");
            this.lbVendorLot.Name = "lbVendorLot";
            // 
            // lbExpiredate
            // 
            this.lbExpiredate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbExpiredate, "lbExpiredate");
            this.lbExpiredate.Name = "lbExpiredate";
            // 
            // lbUnitOfMesure
            // 
            this.lbUnitOfMesure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbUnitOfMesure, "lbUnitOfMesure");
            this.lbUnitOfMesure.Name = "lbUnitOfMesure";
            // 
            // lbQuantity
            // 
            this.lbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbQuantity, "lbQuantity");
            this.lbQuantity.Name = "lbQuantity";
            // 
            // lbDescription
            // 
            this.lbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            // 
            // lbItemNo
            // 
            this.lbItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbItemNo, "lbItemNo");
            this.lbItemNo.Name = "lbItemNo";
            // 
            // lbBin
            // 
            this.lbBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbBin, "lbBin");
            this.lbBin.Name = "lbBin";
            // 
            // lbLocation
            // 
            this.lbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbLocation, "lbLocation");
            this.lbLocation.Name = "lbLocation";
            // 
            // btnBlock
            // 
            resources.ApplyResources(this.btnBlock, "btnBlock");
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // pbIndicator
            // 
            resources.ApplyResources(this.pbIndicator, "pbIndicator");
            this.pbIndicator.Name = "pbIndicator";
            this.pbIndicator.TabStop = false;
            // 
            // fmPIDInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pbIndicator);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.lbVendorLot);
            this.Controls.Add(this.lbExpiredate);
            this.Controls.Add(this.lbUnitOfMesure);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbItemNo);
            this.Controls.Add(this.lbBin);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.tbInputData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.MinimizeBox = false;
            this.Name = "fmPIDInfo";
            this.Load += new System.EventHandler(this.fmPIDInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.TextBox tbInputData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbVendorLot;
        private System.Windows.Forms.Label lbExpiredate;
        private System.Windows.Forms.Label lbUnitOfMesure;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbItemNo;
        private System.Windows.Forms.Label lbBin;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.PictureBox pbIndicator;
    }
}