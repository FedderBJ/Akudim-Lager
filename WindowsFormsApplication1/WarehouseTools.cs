using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsFormsApplication1
{
    static class WarehouseTools
    {
    }
    
    public static class MyActivityType
    {
        private static int Kildetype = 0;
        private static int KildeUndertype = 0;
        private static int ActionType = 0;
        private static string PickOrderNo = "";

        public static int theKildetype
        {
            get { return Kildetype; }
            set { Kildetype = value; }
        }
        public static int theKildeUndertype
        {
            get { return KildeUndertype; }
            set { KildeUndertype = value; }
        }
        public static int theActionType
        {
            get { return ActionType; }
            set { ActionType = value; }
        }
        public static string thePickOrderNo
        {
            get { return PickOrderNo; }
            set { PickOrderNo = value; }
        }
    }

    public class WarehouseActivityHeader
    {
        private int Type = 0;
        private string No = "";
        private string Location = "";
        private string TildeltBruger = "";
        private int AntaLinier = 0;
        public WarehouseActivityHeader()
        {
        }
        public WarehouseActivityHeader(int Type, string No, string Loc, string ToUser, int Lines)
        {
            this.Type = Type;
            this.No = No;
            this.Location = Loc;
            this.TildeltBruger = ToUser;
            this.AntaLinier = Lines;
        }
        public int theType
        {
            get { return Type; }
            set { Type = value; }
        }
        public string theNo
        {
            get { return No; }
            set { No = value; }
        }
        public string theLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public string theUser
        {
            get { return TildeltBruger; }
            set { TildeltBruger = value; }
        }
        public int l_Antallinier
        {
            get { return AntaLinier; }
            set { AntaLinier = value; }
        }
    }

    public class WarehouseActivityLine
    {
        private

        int Type = 0;
        string No = "";
        int LineNo = 0;
        int SourceType = 0;
        int SourceSubType = 0;
        int SourceLineNo = 0;
        string SourceNo = "";
        string ItemNo = "";
        string Description = "";
        string UnitOfMesure = "";
        decimal Quantity = 0;
        decimal QtyToHandle = 0;
        decimal QtyHandled = 0;
        decimal QtyOutstanding = 0;
        string LotNr = "";
        string ExpDate = "";
        string WarehouseDoc = "";
        string Bin = "";
        int PickOrder = 0;

        public WarehouseActivityLine()
        {
        }

        public WarehouseActivityLine(int Type, string No, int LineNo, int SourceLineNo, int SourceType, int SourceSubType, string SourceNo, string ItemNo, string Description, string UnitOfMesure, decimal Quantity, decimal QtyToHandle, decimal QtyHandled, decimal QtyOutstanding, string LotNr, string ExpDate, string WarehouseDoc, string Bin, int Order)
        {
            this.Type = Type;
            this.No = No;
            this.LineNo = LineNo;
            this.SourceType = SourceType;
            this.SourceSubType = SourceSubType;
            this.SourceLineNo = SourceLineNo;
            this.SourceNo = SourceNo;
            this.ItemNo = ItemNo;
            this.Description = Description;
            this.UnitOfMesure = UnitOfMesure;
            this.Quantity = Quantity;
            this.QtyToHandle = QtyToHandle;
            this.QtyHandled = QtyHandled;
            this.QtyOutstanding = QtyOutstanding;
            this.LotNr = LotNr;
            this.ExpDate = ExpDate;
            this.WarehouseDoc = WarehouseDoc;
            this.Bin = Bin;
            this.PickOrder = Order; 
        }

        public int theType
        {
            get { return Type; }
            set { Type = value; }
        }
        public string theNo
        {
            get { return No; }
            set { No = value; }
        }
        public int theLineNo
        {
            get { return LineNo; }
            set { LineNo = value; }
        }
        public int theSourceType
        {
            get { return SourceType; }
            set { SourceType = value; }
        }
        public int theSourceSubType
        {
            get { return SourceSubType; }
            set { SourceSubType = value; }
        }
        public string theSourceNo
        {
            get { return SourceNo;  }
            set { SourceNo = value; }
        }

        public int theSourceLineNo
        {
            get { return SourceLineNo; }
            set { SourceLineNo = value; }
        }

        public string theItemNo
        {
            get { return ItemNo; }
            set { ItemNo = value; }
        }
        public string theDescription
        {
            get { return Description; }
            set { Description = value; }
        }
        public string theUnitOfMesure
        {
            get { return UnitOfMesure; }
            set { UnitOfMesure = value; }
        }
        public decimal theQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public decimal theQtyToHandle
        {
            get { return QtyToHandle; }
            set { QtyToHandle = value; }
        }
        public decimal theQtyHandled
        {
            get { return QtyHandled; }
            set { QtyHandled = value; }
        }
        public decimal theQtyOutstanding
        {
            get { return QtyOutstanding; }
            set { QtyOutstanding = value; }
        }
        public string theLotNo
        {
            get { return LotNr; }
            set { LotNr = value; }
        }
        public string theExpDate
        {
            get { return ExpDate; }
            set { ExpDate = value; }
        }
        public string theWhsDocNo
        {
            get { return WarehouseDoc; }
            set { WarehouseDoc = value; }
        }
        public string theBin
        {
            get { return Bin; }
            set { Bin = value; }
        }
        public int thePickOrder
        {
            get { return PickOrder; }
            set { PickOrder = value; }
        }
    }
}
