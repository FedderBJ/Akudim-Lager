using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    using WSItemBinContent;
    class BinContentTool
    {
        public bool GetItemBincontent(string location, string bincode, string itemno, ref decimal quantity, ref string uom)
        {
            ItemBinContent_Service bincontentservice = new ItemBinContent_Service();
            bincontentservice.UseDefaultCredentials = true;

            List<ItemBinContent_Filter> BincontentFilterArray = new List<ItemBinContent_Filter>();

            ItemBinContent_Filter LocationFilter = new ItemBinContent_Filter();
            LocationFilter.Field = ItemBinContent_Fields.Location_Code;
            LocationFilter.Criteria = location;
            BincontentFilterArray.Add(LocationFilter);

            if (bincode != "")
            {
                ItemBinContent_Filter BinFilter = new ItemBinContent_Filter();
                BinFilter.Field = ItemBinContent_Fields.Bin_Code;
                BinFilter.Criteria = bincode;
                BincontentFilterArray.Add(BinFilter);
            }

            if (itemno != "")
            {
                ItemBinContent_Filter ItemFilter = new ItemBinContent_Filter();
                ItemFilter.Field = ItemBinContent_Fields.Item_No;
                ItemFilter.Criteria = itemno;
                BincontentFilterArray.Add(ItemFilter);
            }

            ItemBinContent [] Details = bincontentservice.ReadMultiple(BincontentFilterArray.ToArray(), "", 1000);

            if (Details.Count() > 0)
            {
                quantity = Details.First().CalcQtyUOM;
                uom = Details.First().Unit_of_Measure_Code;
                return true;
            }
            return false;
        }

        public ItemBinContent[] GetBincontent(string location, string bincode, string itemno, ref decimal quantity, ref string uom)
        {
            
            ItemBinContent_Service bincontentservice = new ItemBinContent_Service();
            bincontentservice.UseDefaultCredentials = true;

            List<ItemBinContent_Filter> BincontentFilterArray = new List<ItemBinContent_Filter>();

            ItemBinContent_Filter LocationFilter = new ItemBinContent_Filter();
            LocationFilter.Field = ItemBinContent_Fields.Location_Code;
            LocationFilter.Criteria = location;
            BincontentFilterArray.Add(LocationFilter);

            if (bincode != "")
            {
                ItemBinContent_Filter BinFilter = new ItemBinContent_Filter();
                BinFilter.Field = ItemBinContent_Fields.Bin_Code;
                BinFilter.Criteria = bincode;
                BincontentFilterArray.Add(BinFilter);
            }

            if (itemno != "")
            {
                ItemBinContent_Filter ItemFilter = new ItemBinContent_Filter();
                ItemFilter.Field = ItemBinContent_Fields.Item_No;
                ItemFilter.Criteria = itemno;
                BincontentFilterArray.Add(ItemFilter);
            }
            ItemBinContent[] Details = bincontentservice.ReadMultiple(BincontentFilterArray.ToArray(), "", 1000);

            if (Details.Count() > 0)
            {
                return Details;
            }
            return null;
        }

        public bool BinIsDefault(string location, string bincode, string itemno, string pid)
        {
            ItemBinContent_Service bincontentservice = new ItemBinContent_Service();
            bincontentservice.UseDefaultCredentials = true;

            List<ItemBinContent_Filter> BincontentFilterArray = new List<ItemBinContent_Filter>();

            ItemBinContent_Filter LocationFilter = new ItemBinContent_Filter();
            LocationFilter.Field = ItemBinContent_Fields.Location_Code;
            LocationFilter.Criteria = location;
            BincontentFilterArray.Add(LocationFilter);

            ItemBinContent_Filter BinFilter = new ItemBinContent_Filter();
            BinFilter.Field = ItemBinContent_Fields.Bin_Code;
            BinFilter.Criteria = bincode;
            BincontentFilterArray.Add(BinFilter);

            ItemBinContent_Filter ItemFilter = new ItemBinContent_Filter();
            ItemFilter.Field = ItemBinContent_Fields.Item_No;
            ItemFilter.Criteria = itemno;
            BincontentFilterArray.Add(ItemFilter);

            ItemBinContent[] Details = bincontentservice.ReadMultiple(BincontentFilterArray.ToArray(), "", 100);

            if (Details.Count() > 0)
            {
                return Details.Last().Default;
            }
            return false;
        }

        public string GetDefaultBin(string location, string itemno)
        {
            ItemBinContent_Service bincontentservice = new ItemBinContent_Service();
            bincontentservice.UseDefaultCredentials = true;

            List<ItemBinContent_Filter> BincontentFilterArray = new List<ItemBinContent_Filter>();

            ItemBinContent_Filter LocationFilter = new ItemBinContent_Filter();
            LocationFilter.Field = ItemBinContent_Fields.Location_Code;
            LocationFilter.Criteria = location;
            BincontentFilterArray.Add(LocationFilter);

            ItemBinContent_Filter ItemFilter = new ItemBinContent_Filter();
            ItemFilter.Field = ItemBinContent_Fields.Item_No;
            ItemFilter.Criteria = itemno;
            BincontentFilterArray.Add(ItemFilter);

            ItemBinContent_Filter DefaultFilter = new ItemBinContent_Filter();
            DefaultFilter.Field = ItemBinContent_Fields.Default;
            DefaultFilter.Criteria = true.ToString();
            BincontentFilterArray.Add(DefaultFilter);

            ItemBinContent[] Details = bincontentservice.ReadMultiple(BincontentFilterArray.ToArray(), "", 10);

            if (Details.Count() > 0)
            {
                return Details.First().Bin_Code;
            }
            return "";
        }

    }
}
