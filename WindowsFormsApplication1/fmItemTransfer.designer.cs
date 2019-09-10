namespace WindowsFormsApplication1
{
    partial class fmItemTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmItemTransfer));
            this.lblInputText = new System.Windows.Forms.Label();
            this.tbInputData = new System.Windows.Forms.TextBox();
            this.gbToLocation = new System.Windows.Forms.GroupBox();
            this.lbNewUom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMoveQty = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbNewBinCode = new System.Windows.Forms.Label();
            this.lbNewLocation = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbUnitOfMesure = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbBin = new System.Windows.Forms.Label();
            this.lbItemNo = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStdBin = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pbIndicator = new System.Windows.Forms.PictureBox();
            this.gbToLocation.SuspendLayout();
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
            // gbToLocation
            // 
            this.gbToLocation.Controls.Add(this.lbNewUom);
            this.gbToLocation.Controls.Add(this.label1);
            this.gbToLocation.Controls.Add(this.lbMoveQty);
            this.gbToLocation.Controls.Add(this.label8);
            this.gbToLocation.Controls.Add(this.label7);
            this.gbToLocation.Controls.Add(this.lbNewBinCode);
            this.gbToLocation.Controls.Add(this.lbNewLocation);
            resources.ApplyResources(this.gbToLocation, "gbToLocation");
            this.gbToLocation.Name = "gbToLocation";
            this.gbToLocation.TabStop = false;
            // 
            // lbNewUom
            // 
            this.lbNewUom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbNewUom, "lbNewUom");
            this.lbNewUom.Name = "lbNewUom";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbMoveQty
            // 
            this.lbMoveQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbMoveQty, "lbMoveQty");
            this.lbMoveQty.Name = "lbMoveQty";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lbNewBinCode
            // 
            this.lbNewBinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbNewBinCode, "lbNewBinCode");
            this.lbNewBinCode.Name = "lbNewBinCode";
            this.lbNewBinCode.DoubleClick += new System.EventHandler(this.lbNewBinCode_DoubleClick);
            // 
            // lbNewLocation
            // 
            this.lbNewLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbNewLocation, "lbNewLocation");
            this.lbNewLocation.Name = "lbNewLocation";
            // 
            // lbQuantity
            // 
            this.lbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbQuantity, "lbQuantity");
            this.lbQuantity.Name = "lbQuantity";
            // 
            // lbUnitOfMesure
            // 
            this.lbUnitOfMesure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbUnitOfMesure, "lbUnitOfMesure");
            this.lbUnitOfMesure.Name = "lbUnitOfMesure";
            // 
            // lbLocation
            // 
            this.lbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbLocation, "lbLocation");
            this.lbLocation.Name = "lbLocation";
            // 
            // lbBin
            // 
            this.lbBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbBin, "lbBin");
            this.lbBin.Name = "lbBin";
            this.lbBin.DoubleClick += new System.EventHandler(this.lbBin_DoubleClick);
            // 
            // lbItemNo
            // 
            this.lbItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbItemNo, "lbItemNo");
            this.lbItemNo.Name = "lbItemNo";
            // 
            // lbDescription
            // 
            this.lbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
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
            // lbStdBin
            // 
            this.lbStdBin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbStdBin, "lbStdBin");
            this.lbStdBin.ForeColor = System.Drawing.Color.Red;
            this.lbStdBin.Name = "lbStdBin";
            this.lbStdBin.DoubleClick += new System.EventHandler(this.lbStdBin_DoubleClick);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // pbIndicator
            // 
            resources.ApplyResources(this.pbIndicator, "pbIndicator");
            this.pbIndicator.Name = "pbIndicator";
            this.pbIndicator.TabStop = false;
            // 
            // fmItemTransfer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pbIndicator);
            this.Controls.Add(this.lbStdBin);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbUnitOfMesure);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbBin);
            this.Controls.Add(this.lbItemNo);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbToLocation);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.tbInputData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmItemTransfer";
            this.Load += new System.EventHandler(this.fmItemTransfer_Load);
            this.gbToLocation.ResumeLayout(false);
            this.gbToLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.TextBox tbInputData;
        private System.Windows.Forms.GroupBox gbToLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbNewBinCode;
        private System.Windows.Forms.Label lbNewLocation;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbUnitOfMesure;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbBin;
        private System.Windows.Forms.Label lbItemNo;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMoveQty;
        private System.Windows.Forms.Label lbNewUom;
        private System.Windows.Forms.Label lbStdBin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbIndicator;
    }
}