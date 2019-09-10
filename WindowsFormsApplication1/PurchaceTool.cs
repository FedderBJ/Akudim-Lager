using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PurchaseLine
    {
        private string SourceNo = "";
        private string No = "";
        private string ItemNo = "";
        private int LineNo = 0;
        private string Description = "";
        private decimal Quantity = 0;
        private string UnitOfMesureCode = "";
        private string LotNr = "";
        private DateTime MHD;
        private bool UseMhd = false;
        private int Status = 1;
        public PurchaseLine()
        {
        }
        public PurchaseLine(string No, string Description, decimal Quantity, string uom, int Status, bool UseMhd, string SourceNo, string ItemNo, int Linje)
        {
            this.ItemNo = ItemNo;
            this.SourceNo = SourceNo;
            this.No = No;
            this.LineNo = Linje;
            this.Description = Description;
            this.Quantity = Quantity;
            this.UseMhd = UseMhd;
            this.UnitOfMesureCode = uom;
        }
        
        public string TheNo
        {
            get { return No; }
            set { No = value; }
        }
        public string TheItemNo
        {
            get { return ItemNo; }
            set { ItemNo = value; }
        }
        public bool TheUseMHD
        {
            get { return UseMhd; }
            set { UseMhd = value; }
        }
        public string TheDescription
        {
            get { return Description; }
            set { Description = value; }
        }
        public decimal TheQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public string TheUnitOfMesure
        {
            get { return UnitOfMesureCode; }
            set { UnitOfMesureCode = value; }
        }
        public DateTime TheMHD
        {
            get { return MHD; }
            set { MHD = value; }
        }
        public string TheLotNr
        {
            get { return LotNr; }
            set { LotNr = value; }
        }
        public int TheStatus
        {
            get { return Status; }
            set { Status = value; }
        }
        public int TheLinje
        {
            get { return LineNo; }
            set { LineNo = value; }
        }
        public string TheSourceNo
        {
            get { return SourceNo; }
            set { SourceNo = value; }
        }

    }
}
