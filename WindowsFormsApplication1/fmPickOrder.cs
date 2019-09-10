using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Diagnostics;
using WindowsFormsApplication1.WarehouseService;
using System.Globalization;


namespace WindowsFormsApplication1
{
    using WSPickList;
    using WSPickLines;
    public partial class fmPickOrder : Form
    {
        private string pickorder = "";
        private int WhaLineIndex = 0;
        private int NoOfLines = 0;
        bool UseTracking = false;
        private string Warehouseshipmentno = "";

        private List<WarehouseActivityHeader> WarehouseActivityHeaderList = new List<WarehouseActivityHeader>();
        private WarehouseActivityHeader WhaHeader = new WarehouseActivityHeader();
        private List<WarehouseActivityLine> WarehouseActivityLineList = new List<WarehouseActivityLine>();
        private WarehouseActivityLine WhaLine = new WarehouseActivityLine();

        MyToolbox mt = new MyToolbox();

        #region ICompare
        public class MyOrderingClass : IComparer<WarehouseActivityLine>
        {
            public int Compare(WarehouseActivityLine x, WarehouseActivityLine y)
            {
                int compareDate = x.thePickOrder.CompareTo(y.thePickOrder);
                if (compareDate == 0)
                {
                    return x.thePickOrder.CompareTo(y.thePickOrder);
                }
                return compareDate;
            }
        }
        #endregion

        public fmPickOrder()
        {
            InitializeComponent();
        }

        public fmPickOrder(string PickOrder)
        {
            InitializeComponent();
            pickorder = PickOrder;
        }

        public int GetWhseActivityHeader()
        {
            fmPickList pl = new fmPickList();
            PickList [] PickOrderHeader = pl.ReturnOrder(pickorder);

            if (PickOrderHeader.Count() > 0)
            {
                WarehouseActivityHeaderList.Add(new WarehouseActivityHeader(2, PickOrderHeader.FirstOrDefault().No, PickOrderHeader.FirstOrDefault().Location_Code, PickOrderHeader.FirstOrDefault().Assigned_User_ID, PickOrderHeader.FirstOrDefault().No_of_Lines));
            }

            return PickOrderHeader.Count();
        }

        public int GetWhseActivityLines()
        {
            PickLines_Service picklineservice = new PickLines_Service();
            picklineservice.UseDefaultCredentials = true;

            List<PickLines_Filter> PickLinesFilterArray = new List<PickLines_Filter>();

            PickLines_Filter NoFilter = new PickLines_Filter();
            NoFilter.Field = PickLines_Fields.No;
            NoFilter.Criteria = pickorder;
            PickLinesFilterArray.Add(NoFilter);

            PickLines_Filter ActionTypeFilter = new PickLines_Filter();
            ActionTypeFilter.Field = PickLines_Fields.Action_Type;
            ActionTypeFilter.Criteria = Action_Type.Take.ToString();
            PickLinesFilterArray.Add(ActionTypeFilter);

            PickLines[] Details = picklineservice.ReadMultiple(PickLinesFilterArray.ToArray(), "", 1000);

            BalanceWarehouse Warehouse = new BalanceWarehouse();
            Warehouse.UseDefaultCredentials = true;

            if (Details.Count() > 0)
            {
                foreach (var item in Details)
                {
                    WarehouseActivityLineList.Add(new WarehouseActivityLine(2, item.No, item.Line_No, item.Source_Line_No ,item.Source_Type, 1, item.Source_No,
                                                        item.Item_No, item.Description, item.Unit_of_Measure_Code, item.Quantity, item.Qty_to_Handle,
                                                        item.Qty_Handled, item.Qty_Outstanding, item.Lot_No, item.Expiration_Date.ToString(), item.Whse_Document_No, item.Bin_Code, item.Pick_Route));

                }
                Warehouseshipmentno = Details.FirstOrDefault().Whse_Document_No;
            }

            IComparer<WarehouseActivityLine> comparer = new MyOrderingClass();
            WarehouseActivityLineList.Sort(comparer);

            return WarehouseActivityLineList.Count() -1;
        }

        public int GetIndexOfItem(string ItemNo)
        {
            return WarehouseActivityLineList.FindIndex(item => item.theItemNo.Equals(ItemNo));
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmPickOrder));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void ExtractHeaderData()
        {
            WhaHeader = WarehouseActivityHeaderList.ElementAt(0);
            lbOrderNo.Text = WhaHeader.theNo.ToString();
            NoOfLines = (WhaHeader.l_Antallinier / 2);
            lbLines.Text = string.Format("{0} af {1}", 1, NoOfLines.ToString());
        }
        
        private void ExtractLineData()
        {
            WhaLine = WarehouseActivityLineList.ElementAt(WhaLineIndex);
            lbLines.Text = string.Format("{0} af {1}", (WhaLineIndex + 1), NoOfLines.ToString());
            lbSourceNo.Text = WhaLine.theSourceNo;
            lbItemNo.Text = WhaLine.theItemNo;
            lbDescription.Text = WhaLine.theDescription;
            lbLotNo.Text = WhaLine.theLotNo;
            lbQty.Text = WhaLine.theQtyToHandle.ToString();
            lbBincode.Text = WhaLine.theBin;
            lbUnits.Text = WhaLine.theUnitOfMesure;
            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;
            lbQuantity.Text = WareHouse.WSReturnRemaningQtyPickorder(WhaLine.theNo, WhaLine.theLineNo).ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);
            
            UseTracking = WareHouse.WSItemUsesTracking(WhaLine.theItemNo);
            WareHouse.Dispose();

            if (UseTracking)
            {
                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText2");
                tbInputData.Text = "";
                Globals.GlobalStep = 1;
            }
            else
            {
                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText5");
                tbInputData.Text = "";
                Globals.GlobalStep = 3;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (WhaLineIndex < (WarehouseActivityLineList.Count - 1))
            {
                WhaLineIndex++;

                ExtractLineData();

                if (WhaLine.theQtyOutstanding <= 0)
                    tbInputData.Enabled = false;
                else
                    tbInputData.Enabled = true;

            }
            else
            {
                WhaLineIndex = 0;
                ExtractLineData();
            }

            tbInputData.SelectAll();
            tbInputData.Focus();
        }

        private void btnPrevius_Click(object sender, EventArgs e)
        {
            if (WhaLineIndex > 0)
            {
                WhaLineIndex--;

                ExtractLineData();

                if (WhaLine.theQtyOutstanding <= 0)
                    tbInputData.Enabled = false;
                else
                    tbInputData.Enabled = true;
            }
            else
            {
                WhaLineIndex = (WarehouseActivityLineList.Count - 1);
                ExtractLineData();
            }

            tbInputData.SelectAll();
            tbInputData.Focus();
        }

        private void tbInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                switch (Globals.GlobalStep)
                {
                    case 0:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

                            pickorder = tbInputData.Text;

                            if (GetWhseActivityHeader() > 0)
                            {
                                ExtractHeaderData();

                                if (GetWhseActivityLines() > 0)
                                {
                                    WhaLineIndex = 0;

                                    ExtractLineData();
                                    Globals.step++;
                                    tbInputData.Text = "";
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText2");
                                }
                                else
                                {
                                    tbInputData.Text = "";
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
                                }
                            }
                            else
                            {
                                tbInputData.Text = "";
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
                            }
                        }
                        break;
                    case 1:
                        {
                            ItemTool it = new ItemTool();

                            if (it.ReturnItemNo(tbInputData.Text) == lbItemNo.Text)
                            {
                                string local_bin = "";
                                //string local_itemno = "";
                                //string local_uom = "";
                                //string local_vendor = "";
                                //string local_desc = "";
                                DateTime local_mhd = DateTime.Now;
                                DateTime localRegDate = DateTime.Now;
                                decimal local_qty = 0;
                                int local_appentry = 0;

                                BalanceWarehouse WareHouse = new BalanceWarehouse();
                                WareHouse.UseDefaultCredentials = true;
                                    
                                try
                                {
                                    //if (WareHouse.WSReturnLotInfo(tbInputData.Text, WhaHeader.theLocation, ref local_bin, ref local_itemno, ref local_desc, ref local_qty, ref local_mhd, ref local_uom, ref local_vendor))
                                    //{
                                        
                                    //}
                                    if (WareHouse.WSReturnMhdAndBinFromLot(tbInputData.Text, WhaLine.theItemNo, WhaHeader.theLocation, ref local_bin, ref local_mhd, ref local_qty, ref local_appentry, ref localRegDate))
                                    {
                                        WhaLine.theBin = local_bin;
                                        WhaLine.theLotNo = tbInputData.Text;
                                        lbQty.Text = local_qty.ToString();
                                        lbLotNo.Text = tbInputData.Text;
                                        lbBincode.Text = local_bin;
                                        lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText3");
                                        
                                        if (local_qty <= decimal.Parse(lbQuantity.Text))
                                        {
                                            tbInputData.Text = local_qty.ToString();
                                        }
                                        else
                                        {
                                            tbInputData.Text = lbQuantity.Text;
                                        }
                                        tbInputData.SelectAll();
                                        Globals.step++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message3"));
                                tbInputData.Text = "";
                            }
                        }
                        break;
                    case 2:
                        {
                            // Antals funktion ved P-ID

                            if (tbInputData.Text.Equals(""))
                                break;
                            btnNext.Enabled = false;
                            btnPrevius.Enabled = false;
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            WhaLine = WarehouseActivityLineList.ElementAt(WhaLineIndex);
                            try
                            {
                                decimal d = 0;
                                if (!decimal.TryParse(tbInputData.Text, out d))
                                {
                                    break;
                                }
                                lbQuantity.Text = WareHouse.WSReturnRemaningQtyPickorder(WhaLine.theNo, WhaLine.theLineNo).ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);
                                if (d >= decimal.Parse(tbInputData.Text))
                                {
                                    WhaLine.theQtyToHandle = decimal.Parse(tbInputData.Text);
                                    lbQty.Text = tbInputData.Text;
                                    WarehouseActivityLineList.Insert(WhaLineIndex, WhaLine);
                                    WarehouseActivityLineList.RemoveAt(WhaLineIndex + 1);
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText4");
                                    tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                                    Globals.step = 10;
                                }
                                else
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Message4"), lbQuantity.Text),
                                                      mt.ReadResFile(this.Name.ToString() + "Message4Caption"));
                                    tbInputData.SelectAll();
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                WareHouse.Dispose();
                            }
                        }
                        break;

                    case 3:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;
                            btnNext.Enabled = false;
                            btnPrevius.Enabled = false;
                         
                            WhaLine = WarehouseActivityLineList.ElementAt(WhaLineIndex);
                            
                            BalanceWarehouse Warehouse = new BalanceWarehouse();
                            Warehouse.UseDefaultCredentials = true;

                            if (Warehouse.WSGetItemCrossRef(tbInputData.Text.ToUpper()) != lbItemNo.Text)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox("Forkert Varenummer!");
                                tbInputData.SelectAll();
                                break;
                            }
                            Globals.GlobalStep++;

                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText6");
                            tbInputData.Text = "";
                        }
                        break;
                    case 4:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

                            BalanceWarehouse Warehouse = new BalanceWarehouse();
                            Warehouse.UseDefaultCredentials = true;

                            if (!Warehouse.WSBinExists(Globals.theLocation, tbInputData.Text.ToUpper()))
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(string.Format("Placeringen {0} findes ikke", tbInputData.Text));
                                tbInputData.Text = "";
                                break;
                            }

                            BinContentTool bt = new BinContentTool();
                            decimal l_qty = 0;
                            string l_uom = "";

                            if(bt.GetItemBincontent(Globals.theLocation, tbInputData.Text, lbItemNo.Text, ref l_qty, ref l_uom))
                            {
                                lbQty.Text = l_qty.ToString("N2");
                                lbUnit.Text = l_uom;
                                lbBincode.Text = tbInputData.Text.ToUpper();
                            }

                            if (l_qty == 0)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(string.Format("Placeringen {0} indeholder ikke varen: {1}", tbInputData.Text.ToUpper(), lbItemNo.Text));
                                tbInputData.Text = "";
                                break;
                            }

                            if (l_qty <= decimal.Parse(lbQuantity.Text))
                            {
                                tbInputData.Text = l_qty.ToString();
                            }
                            else
                            {
                                tbInputData.Text = lbQuantity.Text;
                            }

                            Globals.GlobalStep++;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText3");
                            //tbInputData.Text = "";
                        }
                        break;
                    case 5:
                        {
                            // Antalsfunktion uden P-ID
                            
                            if (tbInputData.Text.Equals(""))
                                break;

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            try
                            {
                                decimal d = 0;
                                if (!decimal.TryParse(tbInputData.Text, out d))
                                {
                                    break;
                                }
                                lbQuantity.Text = WareHouse.WSReturnRemaningQtyPickorder(WhaLine.theNo, WhaLine.theLineNo).ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);
                                if (d <= decimal.Parse(lbQuantity.Text))
                                {
                                    WhaLine.theQtyToHandle = decimal.Parse(tbInputData.Text);
                                    lbQty.Text = tbInputData.Text;
                                    WhaLine.theLotNo = "";
                                    WarehouseActivityLineList.Insert(WhaLineIndex, WhaLine);
                                    WarehouseActivityLineList.RemoveAt(WhaLineIndex + 1);
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText4");
                                    tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                                    Globals.step = 10;
                                }
                                else
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Message4"), lbQuantity.Text),
                                                      mt.ReadResFile(this.Name.ToString() + "Message4Caption"));
                                    tbInputData.SelectAll();
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                WareHouse.Dispose();
                            }
                        }
                        break;

                    case 10:
                        {
                            // CallFunction in Navision To post the Pick" and "Place" line
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            //WhaLine = WarehouseActivityLineList.ElementAt(WhaLineIndex);

                            this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                            this.pbIndicator.Visible = true;

                            try
                            {
                                if (lbBincode.Text != WhaLine.theBin)
                                {
                                    WhaLine.theBin = lbBincode.Text;
                                }
                                WareHouse.WSPostPickOrder(WhaLine.theNo, WhaLine.theLineNo, WhaLine.theSourceLineNo, WhaLine.theItemNo, WhaLine.theQtyToHandle, WhaLine.theLotNo, WhaLine.theBin);
                            }
                            catch (Exception ex)
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }

                            this.pbIndicator.Image = null;
                            this.pbIndicator.Visible = false;

                            try
                            {
                                lbQuantity.Text = WareHouse.WSReturnRemaningQtyPickorder(WhaLine.theNo, WhaLine.theLineNo).ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat); 
                            }
                            catch (Exception ex)
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }

                            try
                            {
                                //WareHouse.WSDeleteQtyToHandle(WhaLine.theNo.ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            finally
                            {
                                WareHouse.Dispose();
                            }

                            if (decimal.Parse(lbQuantity.Text) > 0)
                            {
                                if (UseTracking)
                                {
                                    Globals.GlobalStep = 1;
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText2");
                                    tbInputData.Text = "";
                                }
                                else
                                {
                                    Globals.GlobalStep = 3;
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText5");
                                    tbInputData.Text = "";
                                }
                                btnNext.Enabled = true;
                                btnPrevius.Enabled = true;
                            }
                            else
                            {
                                // Funktionalitet til at finde næste pluklinje der skal plukkes eller afslutte hvis der ikke er flere.
                                WarehouseActivityLineList.RemoveAt(WhaLineIndex);
                                if (WhaLineIndex > 0)
                                  WhaLineIndex--;
                                //if (WhaLineIndex < (WarehouseActivityLineList.Count() -1))
                                //{
                                //    WhaLineIndex++;
                                //}
                                NoOfLines--;
                                lbLines.Text = string.Format("{0} af {1}", 1, NoOfLines.ToString());
                                
                                if (WarehouseActivityLineList.Count() > 1)
                                {
                                    ExtractLineData();
                                    lbQty.Text = "";
                                    
                                    if (WhaLine.theQtyOutstanding <= 0)
                                        tbInputData.Enabled = false;
                                    else
                                        tbInputData.Enabled = true;
                                    
                                    btnNext.Enabled = true;
                                    btnPrevius.Enabled = true;
                                }
                                if (WarehouseActivityLineList.Count() == 1)
                                {
                                    ExtractLineData();
                                    lbQty.Text = "";
                                    
                                    if (WhaLine.theQtyOutstanding <= 0)
                                        tbInputData.Enabled = false;
                                    else
                                        tbInputData.Enabled = true;
                                }
                                if ((WhaLineIndex == 0) && (WhaLineIndex == WarehouseActivityLineList.Count()))
                                {
                                    fmWarehouseFright wf = new fmWarehouseFright(Warehouseshipmentno);
                                    wf.ShowDialog();

                                    Globals.step = 0;
                                    this.Close();
                                }
                            }
                        }
                        break;
                }
            }

            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                switch (Globals.step)
                {
                    case 10:
                        {
                            if (UseTracking)
                            {
                                Globals.GlobalStep = 2;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText3");
                                tbInputData.Text = "";
                            }
                            else
                            {
                                Globals.GlobalStep = 5;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText3");
                                tbInputData.Text = "";
                            }
                        }
                        break;
                    case 5:
                        {
                            Globals.step--;
                            //lblInputText3
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText6");
                            tbInputData.Text = "";
                        }
                        break;

                    case 4:
                        {
                            Globals.step--;
                            //lblInputText3
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText5");
                            tbInputData.Text = "";
                        }
                        break;
                    case 3:
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                    case 2:
                        {
                            Globals.step--;
                            //lblInputText2
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText2");
                            tbInputData.Text = "";
                            btnNext.Enabled = true;
                            btnPrevius.Enabled = true;
                        }
                        break;
                    case 1: 
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                    case 0: 
                        {
                            Globals.step = 0;
                            this.Close();
                        }
                        break;
                }
            }
        }

        private void fmPickOrder_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);

            if (!pickorder.Equals(""))
            {
                if (GetWhseActivityHeader() > 0)
                {
                    ExtractHeaderData();
                    if(GetWhseActivityLines() > -1)
                    {
                        ExtractLineData();
                    }
                }
            }
        }

        private void tbInputData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnPrevius.PerformClick();
            }

            if (e.KeyCode == Keys.Down)
            {
                btnNext.PerformClick();
            }
        }

        private void lbBincode_Click(object sender, EventArgs e)
        {
            tbInputData.Text = lbBincode.Text;
        }
    }
}
