using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Information
    {
        private string User = "";
        private string Location = "";
        private string Zone = "";
        private string Bin = "";
        private string ItemNo = "";
        private string Description = "";
        private string UnitOfMesure = "";
        private decimal Qty = 0;
        private decimal RemaningQty = 0;
        private string PID = "";
        private DateTime D;
        private string VendorLot = "";

        public Information()
        {

        }

        public Information(string p_user, string p_location, string p_zone, string p_bin, string p_item, string p_description, string p_uom, decimal p_qty, decimal p_remaning_qty, string p_pid, DateTime p_d, string p_vendorlot)
        {
            this.User = p_user;
            this.Location = p_location;
            this.Zone = p_zone;
            this.Bin = p_bin;
            this.ItemNo = p_item;
            this.Description = p_description;
            this.UnitOfMesure = p_uom;
            this.Qty = p_qty;
            this.RemaningQty = p_remaning_qty;
            this.PID = p_pid;
            this.D = p_d;
            this.VendorLot = p_vendorlot;
        }
        public string TheUser
        {
            get { return User; }
            set { User = value; }
        }
        public string TheLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public string TheZone
        {
            get { return Zone; }
            set { Zone = value; }
        }
        public string TheBin
        {
            get { return Bin; }
            set { Bin = value; }
        }
        public string TheItem
        {
            get { return ItemNo; }
            set { ItemNo = value; }
        }
        public string TheDescription
        {
            get { return Description; }
            set { Description = value; }
        }
        public string TheUnitOfMesure
        {
            get { return UnitOfMesure; }
            set { UnitOfMesure = value; }
        }
        public decimal TheQty
        {
            get { return Qty; }
            set { Qty = value; }
        }
        public decimal TheRemaningQty
        {
            get { return RemaningQty; }
            set { RemaningQty = value; }
        }
        public string ThePid
        {
            get { return PID; }
            set { PID = value; }
        }
        public DateTime theDate
        {
            get { return D; }
            set { D = value; }
        }
        public string TheVendorLot
        {
            get { return VendorLot; }
            set { VendorLot = value; }
        }
    }
}
