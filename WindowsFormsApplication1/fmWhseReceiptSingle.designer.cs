namespace WindowsFormsApplication1
{
    partial class fmWhseReceiptSingle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmWhseReceiptSingle));
            this.lblInputText = new System.Windows.Forms.Label();
            this.tbInputData = new System.Windows.Forms.MaskedTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbName2 = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbNoOfLines = new System.Windows.Forms.Label();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.gbLines = new System.Windows.Forms.GroupBox();
            this.pbIndicator = new System.Windows.Forms.PictureBox();
            this.lbNo = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbUnitOfMesure = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbMHD = new System.Windows.Forms.Label();
            this.lbLotNo = new System.Windows.Forms.Label();
            this.lblNummer = new System.Windows.Forms.Label();
            this.lblMHD = new System.Windows.Forms.Label();
            this.lblMenge = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLot = new System.Windows.Forms.Label();
            this.btnPrevius = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.btnDecoder = new System.Windows.Forms.Button();
            this.gbHeader.SuspendLayout();
            this.gbLines.SuspendLayout();
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
            this.tbInputData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInputData_KeyDown);
            this.tbInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblAddress
            // 
            resources.ApplyResources(this.lblAddress, "lblAddress");
            this.lblAddress.Name = "lblAddress";
            // 
            // lblName2
            // 
            resources.ApplyResources(this.lblName2, "lblName2");
            this.lblName2.Name = "lblName2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbName
            // 
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbName2
            // 
            this.lbName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbName2, "lbName2");
            this.lbName2.Name = "lbName2";
            // 
            // lbAddress
            // 
            this.lbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbAddress, "lbAddress");
            this.lbAddress.Name = "lbAddress";
            // 
            // lbNoOfLines
            // 
            this.lbNoOfLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbNoOfLines, "lbNoOfLines");
            this.lbNoOfLines.Name = "lbNoOfLines";
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lbNoOfLines);
            this.gbHeader.Controls.Add(this.lbAddress);
            this.gbHeader.Controls.Add(this.lbName2);
            this.gbHeader.Controls.Add(this.lbName);
            resources.ApplyResources(this.gbHeader, "gbHeader");
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.TabStop = false;
            // 
            // gbLines
            // 
            this.gbLines.Controls.Add(this.pbIndicator);
            this.gbLines.Controls.Add(this.lbNo);
            this.gbLines.Controls.Add(this.lbDescription);
            this.gbLines.Controls.Add(this.lbUnitOfMesure);
            this.gbLines.Controls.Add(this.lbQuantity);
            this.gbLines.Controls.Add(this.lbMHD);
            this.gbLines.Controls.Add(this.lbLotNo);
            resources.ApplyResources(this.gbLines, "gbLines");
            this.gbLines.Name = "gbLines";
            this.gbLines.TabStop = false;
            // 
            // pbIndicator
            // 
            resources.ApplyResources(this.pbIndicator, "pbIndicator");
            this.pbIndicator.Name = "pbIndicator";
            this.pbIndicator.TabStop = false;
            // 
            // lbNo
            // 
            this.lbNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbNo, "lbNo");
            this.lbNo.Name = "lbNo";
            // 
            // lbDescription
            // 
            this.lbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
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
            // lbMHD
            // 
            this.lbMHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbMHD, "lbMHD");
            this.lbMHD.Name = "lbMHD";
            // 
            // lbLotNo
            // 
            this.lbLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lbLotNo, "lbLotNo");
            this.lbLotNo.Name = "lbLotNo";
            // 
            // lblNummer
            // 
            resources.ApplyResources(this.lblNummer, "lblNummer");
            this.lblNummer.Name = "lblNummer";
            // 
            // lblMHD
            // 
            resources.ApplyResources(this.lblMHD, "lblMHD");
            this.lblMHD.Name = "lblMHD";
            // 
            // lblMenge
            // 
            resources.ApplyResources(this.lblMenge, "lblMenge");
            this.lblMenge.Name = "lblMenge";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblLot
            // 
            resources.ApplyResources(this.lblLot, "lblLot");
            this.lblLot.Name = "lblLot";
            // 
            // btnPrevius
            // 
            resources.ApplyResources(this.btnPrevius, "btnPrevius");
            this.btnPrevius.Name = "btnPrevius";
            this.btnPrevius.TabStop = false;
            this.btnPrevius.UseVisualStyleBackColor = true;
            this.btnPrevius.Click += new System.EventHandler(this.btnPrevius_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btSearch
            // 
            resources.ApplyResources(this.btSearch, "btSearch");
            this.btSearch.Name = "btSearch";
            this.btSearch.TabStop = false;
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btnDecoder
            // 
            resources.ApplyResources(this.btnDecoder, "btnDecoder");
            this.btnDecoder.Name = "btnDecoder";
            this.btnDecoder.TabStop = false;
            this.btnDecoder.UseVisualStyleBackColor = true;
            this.btnDecoder.Click += new System.EventHandler(this.btnDecoder_Click);
            // 
            // fmWhseReceiptSingle
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.lblNummer);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblMHD);
            this.Controls.Add(this.lblLot);
            this.Controls.Add(this.lblMenge);
            this.Controls.Add(this.btnDecoder);
            this.Controls.Add(this.tbInputData);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.gbHeader);
            this.Controls.Add(this.btnPrevius);
            this.Controls.Add(this.gbLines);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmWhseReceiptSingle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.fmWhseReceiptSingle_Load);
            this.Leave += new System.EventHandler(this.fmWhseReceiptSingle_Leave);
            this.gbHeader.ResumeLayout(false);
            this.gbLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.MaskedTextBox tbInputData;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbName2;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbNoOfLines;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.Label lblNummer;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Label lblMHD;
        private System.Windows.Forms.Label lblMenge;
        private System.Windows.Forms.Button btnPrevius;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbLotNo;
        private System.Windows.Forms.Label lbMHD;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbUnitOfMesure;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbNo;
        private System.Windows.Forms.GroupBox gbLines;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.PictureBox pbIndicator;
        private System.Windows.Forms.Button btnDecoder;
    }
}