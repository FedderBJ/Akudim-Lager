using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    using WarehouseService;
    using WSItemList;

    class ItemTool
    {
        public int TypeOfItem(ref string ItemData, string location, ref string placering, ref string varenr, ref string beskrivelse, ref decimal antal, ref DateTime mhd, ref string uom, ref string vl, ref bool b_recount)
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            try
            {
                if (!WareHouse.WSReturnLotInfo(ItemData, Globals.theLocation, ref placering, ref varenr, ref beskrivelse, ref antal, ref mhd, ref uom, ref vl))
                {

                    if (WareHouse.WSBinExists(Globals.theLocation, ItemData.ToUpper()))
                    {
                        placering = ItemData;
                        return 3;
                    }

                    if (WareHouse.WSItemExists(WareHouse.WSGetItemCrossRef(WareHouse.WSGetItemCrossRef(ItemData))))
                    {
                        ItemData = WareHouse.WSGetItemCrossRef(ItemData);
                        varenr = ItemData;
                        beskrivelse = ReturnItemDescription(ItemData);
                        
                        return 2;
                    }
                    if (WareHouse.WSLotInfoUsed(ItemData))
                    {
                        return 0;
                    }
                    else
                    {
                        if (WareHouse.WSPIDExists(ItemData))
                        {
                            b_recount = true;
                            return 1;
                        }
                    }
                }
                else
                    return 1;
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
            }
            return 0;
        }

        public string ReturnItemNo(string pid)
        {
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;

            try
            {
                return WareHouse.WSReturnItemNo(pid);
            }
            catch (Exception ex)
            {
                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
            }
            return "";
        }

        public string ReturnItemDescription(string ItemNo)
        {
            var service = new ItemListPage_Service();
            service.UseDefaultCredentials = true;

            ItemListPage Result = service.Read(ItemNo);
            return Result.Description;
        }
    }
}
