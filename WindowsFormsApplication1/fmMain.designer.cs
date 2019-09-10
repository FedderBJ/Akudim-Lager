namespace WindowsFormsApplication1
{
    partial class fmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnPackageInformation = new System.Windows.Forms.Button();
            this.btnMovePackage = new System.Windows.Forms.Button();
            this.btnPackageInventory = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.btnWarehoseReceipt = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.lbCompanyName = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLotSplit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::WindowsFormsApplication1.Properties.Resources.NAV4Timber;
            resources.ApplyResources(this.pbLogo, "pbLogo");
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // btnPackageInformation
            // 
            resources.ApplyResources(this.btnPackageInformation, "btnPackageInformation");
            this.btnPackageInformation.Name = "btnPackageInformation";
            this.btnPackageInformation.UseVisualStyleBackColor = true;
            this.btnPackageInformation.Click += new System.EventHandler(this.btnPackageInformation_Click);
            // 
            // btnMovePackage
            // 
            resources.ApplyResources(this.btnMovePackage, "btnMovePackage");
            this.btnMovePackage.Name = "btnMovePackage";
            this.btnMovePackage.UseVisualStyleBackColor = true;
            this.btnMovePackage.Click += new System.EventHandler(this.btnMovePackage_Click);
            // 
            // btnPackageInventory
            // 
            resources.ApplyResources(this.btnPackageInventory, "btnPackageInventory");
            this.btnPackageInventory.Name = "btnPackageInventory";
            this.btnPackageInventory.UseVisualStyleBackColor = true;
            this.btnPackageInventory.Click += new System.EventHandler(this.btnPackageInventory_Click);
            // 
            // btnPick
            // 
            resources.ApplyResources(this.btnPick, "btnPick");
            this.btnPick.Name = "btnPick";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnWarehoseReceipt
            // 
            resources.ApplyResources(this.btnWarehoseReceipt, "btnWarehoseReceipt");
            this.btnWarehoseReceipt.Name = "btnWarehoseReceipt";
            this.btnWarehoseReceipt.UseVisualStyleBackColor = true;
            this.btnWarehoseReceipt.Click += new System.EventHandler(this.btnMoveProdToBox_Click);
            // 
            // btnSetup
            // 
            resources.ApplyResources(this.btnSetup, "btnSetup");
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // lbCompanyName
            // 
            this.lbCompanyName.BackColor = System.Drawing.SystemColors.Window;
            this.lbCompanyName.ForeColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(this.lbCompanyName, "lbCompanyName");
            this.lbCompanyName.Name = "lbCompanyName";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLotSplit
            // 
            resources.ApplyResources(this.btnLotSplit, "btnLotSplit");
            this.btnLotSplit.Name = "btnLotSplit";
            this.btnLotSplit.UseVisualStyleBackColor = true;
            this.btnLotSplit.Click += new System.EventHandler(this.btnLotSplit_Click);
            // 
            // fmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.btnLotSplit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lbCompanyName);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnWarehoseReceipt);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.btnPackageInventory);
            this.Controls.Add(this.btnMovePackage);
            this.Controls.Add(this.btnPackageInformation);
            this.Controls.Add(this.pbLogo);
            this.Name = "fmMain";
            this.Load += new System.EventHandler(this.fmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnPackageInformation;
        private System.Windows.Forms.Button btnMovePackage;
        private System.Windows.Forms.Button btnPackageInventory;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Button btnWarehoseReceipt;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Label lbCompanyName;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnLotSplit;
    }
}

