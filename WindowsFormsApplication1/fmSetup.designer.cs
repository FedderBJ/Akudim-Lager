namespace WindowsFormsApplication1
{
    partial class fmSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSetup));
            this.btlLogout = new System.Windows.Forms.Button();
            this.tbInputData = new System.Windows.Forms.TextBox();
            this.lblInputText = new System.Windows.Forms.Label();
            this.tbSqlServer = new System.Windows.Forms.Label();
            this.lblSqlServer = new System.Windows.Forms.Label();
            this.tbInstance = new System.Windows.Forms.Label();
            this.lblSqlInstance = new System.Windows.Forms.Label();
            this.tbLanguage = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.tbDatabaseUser = new System.Windows.Forms.Label();
            this.lblDatabaseUser = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.tbWebUrl = new System.Windows.Forms.Label();
            this.lblWebUrl = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lbBuildDateTime = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btChangePrinter = new System.Windows.Forms.Button();
            this.lbPrinterName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btlLogout
            // 
            resources.ApplyResources(this.btlLogout, "btlLogout");
            this.btlLogout.Name = "btlLogout";
            this.btlLogout.TabStop = false;
            this.btlLogout.UseVisualStyleBackColor = true;
            this.btlLogout.Click += new System.EventHandler(this.btlLogout_Click);
            // 
            // tbInputData
            // 
            resources.ApplyResources(this.tbInputData, "tbInputData");
            this.tbInputData.Name = "tbInputData";
            this.tbInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInputData_KeyPress);
            // 
            // lblInputText
            // 
            resources.ApplyResources(this.lblInputText, "lblInputText");
            this.lblInputText.Name = "lblInputText";
            // 
            // tbSqlServer
            // 
            resources.ApplyResources(this.tbSqlServer, "tbSqlServer");
            this.tbSqlServer.Name = "tbSqlServer";
            // 
            // lblSqlServer
            // 
            resources.ApplyResources(this.lblSqlServer, "lblSqlServer");
            this.lblSqlServer.Name = "lblSqlServer";
            // 
            // tbInstance
            // 
            resources.ApplyResources(this.tbInstance, "tbInstance");
            this.tbInstance.Name = "tbInstance";
            // 
            // lblSqlInstance
            // 
            resources.ApplyResources(this.lblSqlInstance, "lblSqlInstance");
            this.lblSqlInstance.Name = "lblSqlInstance";
            // 
            // tbLanguage
            // 
            resources.ApplyResources(this.tbLanguage, "tbLanguage");
            this.tbLanguage.Name = "tbLanguage";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // tbDatabaseUser
            // 
            resources.ApplyResources(this.tbDatabaseUser, "tbDatabaseUser");
            this.tbDatabaseUser.Name = "tbDatabaseUser";
            // 
            // lblDatabaseUser
            // 
            resources.ApplyResources(this.lblDatabaseUser, "lblDatabaseUser");
            this.lblDatabaseUser.Name = "lblDatabaseUser";
            // 
            // tbCompany
            // 
            resources.ApplyResources(this.tbCompany, "tbCompany");
            this.tbCompany.Name = "tbCompany";
            // 
            // lblCompany
            // 
            resources.ApplyResources(this.lblCompany, "lblCompany");
            this.lblCompany.Name = "lblCompany";
            // 
            // tbWebUrl
            // 
            resources.ApplyResources(this.tbWebUrl, "tbWebUrl");
            this.tbWebUrl.Name = "tbWebUrl";
            // 
            // lblWebUrl
            // 
            resources.ApplyResources(this.lblWebUrl, "lblWebUrl");
            this.lblWebUrl.Name = "lblWebUrl";
            // 
            // lblBuild
            // 
            resources.ApplyResources(this.lblBuild, "lblBuild");
            this.lblBuild.Name = "lblBuild";
            // 
            // lbBuildDateTime
            // 
            resources.ApplyResources(this.lbBuildDateTime, "lbBuildDateTime");
            this.lbBuildDateTime.Name = "lbBuildDateTime";
            // 
            // lbLocation
            // 
            resources.ApplyResources(this.lbLocation, "lbLocation");
            this.lbLocation.Name = "lbLocation";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // btChangePrinter
            // 
            resources.ApplyResources(this.btChangePrinter, "btChangePrinter");
            this.btChangePrinter.Name = "btChangePrinter";
            this.btChangePrinter.TabStop = false;
            this.btChangePrinter.UseVisualStyleBackColor = true;
            this.btChangePrinter.Click += new System.EventHandler(this.btChangePrinter_Click);
            // 
            // lbPrinterName
            // 
            resources.ApplyResources(this.lbPrinterName, "lbPrinterName");
            this.lbPrinterName.Name = "lbPrinterName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // fmSetup
            // 
            this.AcceptButton = this.btlLogout;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.lbPrinterName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btChangePrinter);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lbBuildDateTime);
            this.Controls.Add(this.lblBuild);
            this.Controls.Add(this.tbWebUrl);
            this.Controls.Add(this.lblWebUrl);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.tbDatabaseUser);
            this.Controls.Add(this.lblDatabaseUser);
            this.Controls.Add(this.tbLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.tbInstance);
            this.Controls.Add(this.lblSqlInstance);
            this.Controls.Add(this.tbSqlServer);
            this.Controls.Add(this.lblSqlServer);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.tbInputData);
            this.Controls.Add(this.btlLogout);
            this.Name = "fmSetup";
            this.Load += new System.EventHandler(this.fmSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btlLogout;
        private System.Windows.Forms.TextBox tbInputData;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.Label tbSqlServer;
        private System.Windows.Forms.Label lblSqlServer;
        private System.Windows.Forms.Label tbInstance;
        private System.Windows.Forms.Label lblSqlInstance;
        private System.Windows.Forms.Label tbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label tbDatabaseUser;
        private System.Windows.Forms.Label lblDatabaseUser;
        private System.Windows.Forms.Label tbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label tbWebUrl;
        private System.Windows.Forms.Label lblWebUrl;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.Label lbBuildDateTime;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btChangePrinter;
        private System.Windows.Forms.Label lbPrinterName;
        private System.Windows.Forms.Label label2;
    }
}