using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.WarehouseService;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Net;


// INFO Form og kode er rettet til med Multilanguage.
// INFO Updated the code with Eventlog entry.

namespace WindowsFormsApplication1
{
    using WSPurchaseOrderCard;
    using WSWarehouseReceiptLines;
    using WSSalesReturnOrder;

    public partial class fmWhseReceiptSingle : Form
    {
        private string OrderNo = "";
        private int OrderType = 0;
        private List<PurchaseLine> PurchaseLineList = new List<PurchaseLine>();
        private int POLindex = 0;
        private PurchaseLine POL = new PurchaseLine();
        private static string GenereretPID = "";
        private decimal remaning = 0;
        private int ItemWithNoTracking = 0;
        private string Vendorlot = "";

        MyToolbox mt = new MyToolbox();

        public fmWhseReceiptSingle()
        {
            InitializeComponent();
        }

        public fmWhseReceiptSingle(string Orderno, int Ordertype)
        {
            InitializeComponent();
            OrderNo = Orderno;
            OrderType = Ordertype;
        }

        public void ExtractData()
        {
            if (POLindex > -1)
            {
                POL = PurchaseLineList.ElementAt(POLindex);
                tbInputData.Text = "";
                lbMHD.Text = "";
                lbLotNo.Text = "";
                lbDescription.Text = POL.TheDescription;
                lbNo.Text = POL.TheItemNo;
                lbQuantity.Text = POL.TheQuantity.ToString();
                if (POL.TheQuantity <= 0)
                    tbInputData.Enabled = false;
                else
                    tbInputData.Enabled = true;
                lbUnitOfMesure.Text = POL.TheUnitOfMesure;
                lbNoOfLines.Text = string.Format("{0} {1} {2}", (POLindex + 1), "af", PurchaseLineList.Count());
            }
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmWhseReceiptSingle));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void btnPrevius_Click(object sender, EventArgs e)
        {
            if (POLindex > 0)
            {
                POLindex--;
                ExtractData();
            }
            else
            {
                POLindex = (PurchaseLineList.Count - 1);
                ExtractData();
            }
            this.tbInputData.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (POLindex < (PurchaseLineList.Count - 1))
            {
                POLindex++;
                ExtractData();
            }
            else
            {
                POLindex = 0;
                ExtractData();
            }
            this.tbInputData.Focus();
        }

        private void GetPurchaseOrder(string OrderNo)
        {
            PurchaseOrderCard_Service purchaseorderservice = new PurchaseOrderCard_Service();
            purchaseorderservice.UseDefaultCredentials = true;

            List<PurchaseOrderCard_Filter> PurchaseOrderFilterArray = new List<PurchaseOrderCard_Filter>();

            PurchaseOrderCard_Filter PurchaseOrderNoFilter = new PurchaseOrderCard_Filter();
            PurchaseOrderNoFilter.Field = PurchaseOrderCard_Fields.No;
            PurchaseOrderNoFilter.Criteria = OrderNo;
            PurchaseOrderFilterArray.Add(PurchaseOrderNoFilter);

            PurchaseOrderCard [] PurchaseOrder = purchaseorderservice.ReadMultiple(PurchaseOrderFilterArray.ToArray(), "", 1000);

            if (PurchaseOrder.Count() > 0)
            {
                foreach (var PO in PurchaseOrder)
                {
                    if (PO.Status == 0)
                    {
                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message4"));
                        break;
                    }
                    lbName.Text = PO.Buy_from_Vendor_Name.ToString();
                    if (!string.IsNullOrEmpty(PO.Buy_from_Vendor_Name_2))
                       lbName2.Text = PO.Buy_from_Vendor_Name_2.ToString();
                    if (!string.IsNullOrEmpty(PO.Buy_from_Address))
                       lbAddress.Text = PO.Buy_from_Address.ToString();

                    BalanceWarehouse WareHouse = new BalanceWarehouse();
                    WareHouse.UseDefaultCredentials = true;
                    try
                    {
                        if (WareHouse.WSCreateWarehouseInboundDoc(OrderNo))
                        {
                            // Hent købsmodtagelseslinjer
                            GetReceiptliens(OrderNo, OrderType);
                        }
                    }
                    catch (Exception ex)
                    {
                        Globals.step = 0;
                        lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText1");
                        MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                    }
                    finally
                    {
                        WareHouse.Dispose();
                        tbInputData.Text = "";
                        btnDecoder.Visible = true;
                    }
                }
            }
            else
            {
                tbInputData.Text = "";
                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
            }
        }

        private void GetReturnOrder(string OrderNo)
        {
            SalesReturnOrder_Service returnorderservice = new SalesReturnOrder_Service();
            returnorderservice.UseDefaultCredentials = true;

            List<SalesReturnOrder_Filter> ReturnOrderFilterArray = new List<SalesReturnOrder_Filter>();

            SalesReturnOrder_Filter ReturnOrderNoFilter = new SalesReturnOrder_Filter();
            ReturnOrderNoFilter.Field = SalesReturnOrder_Fields.No;
            ReturnOrderNoFilter.Criteria = OrderNo;
            ReturnOrderFilterArray.Add(ReturnOrderNoFilter);

            SalesReturnOrder[] ReturnOrder = returnorderservice.ReadMultiple(ReturnOrderFilterArray.ToArray(), "", 1000);

            if (ReturnOrder.Count() > 0)
            {
                foreach (var PO in ReturnOrder)
                {
                    if (PO.Status == 0)
                    {
                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message4"));
                        break;
                    }
                    lbName.Text = PO.Sell_to_Customer_Name;

                    tbInputData.Text = "";
                    btnDecoder.Visible = true;
                    GetReceiptliens(OrderNo, OrderType);
                }
            }
            else
            {
                tbInputData.Text = "";
                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message2"));
            }
        }

        private void GetReceiptliens(string OrderNo, int SourceType)
        {
            WarehouseReceiptLine_Service warehouserecieptlineservice = new WarehouseReceiptLine_Service();
            warehouserecieptlineservice.UseDefaultCredentials = true;

            List<WarehouseReceiptLine_Filter> WarehouseRecieptFilterArray = new List<WarehouseReceiptLine_Filter>();

            WarehouseReceiptLine_Filter SourceNoFilter = new WarehouseReceiptLine_Filter();
            SourceNoFilter.Field = WarehouseReceiptLine_Fields.Source_No;
            SourceNoFilter.Criteria = OrderNo;
            WarehouseRecieptFilterArray.Add(SourceNoFilter);

            WarehouseReceiptLine_Filter SourceTypeFilter = new WarehouseReceiptLine_Filter();
            SourceTypeFilter.Field = WarehouseReceiptLine_Fields.Source_Type;
            SourceTypeFilter.Criteria = SourceType.ToString();
            WarehouseRecieptFilterArray.Add(SourceTypeFilter);

            WarehouseReceiptLine [] RecieptLine = warehouserecieptlineservice.ReadMultiple(WarehouseRecieptFilterArray.ToArray(), "", 1000);

            if (RecieptLine.Count() > 0)
            {
                PurchaseLineList.Clear();
                POL = null;

                BalanceWarehouse Warehouse = new BalanceWarehouse();
                Warehouse.UseDefaultCredentials = true;



                foreach (var POLl in RecieptLine)
                {
                    PurchaseLineList.Add(new PurchaseLine(POLl.No.ToString(), POLl.Description.ToString(), POLl.Qty_Outstanding, POLl.Unit_of_Measure_Code, 1, Warehouse.WSItemUsesMhdTracking(POLl.Item_No.ToString()), OrderNo, POLl.Item_No, POLl.Line_No));
                }
          
                lbNoOfLines.Text = (RecieptLine.Count() - ItemWithNoTracking).ToString();
                lbNoOfLines.Text = string.Format("{0} {1} {2}", (POLindex + 1), "af", PurchaseLineList.Count());
                Globals.step++;
                POL = PurchaseLineList.First();
                lbDescription.Text = POL.TheDescription;
                lbNo.Text = POL.TheItemNo;
                lbQuantity.Text = POL.TheQuantity.ToString();
                lbUnitOfMesure.Text = POL.TheUnitOfMesure;

                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText7");
            }
            else
            {
                tbInputData.Text = "";
                MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message1"));
            }

        }

        public void GetIndexOfItem(string ItemNo)
        {
            POLindex = PurchaseLineList.FindIndex(item => item.TheItemNo.Equals(ItemNo));
            ExtractData();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                switch (Globals.GlobalStep)
                {
                    case 0:
                        {
                            if (tbInputData.Text.Equals(""))
                                break;

                            // Hent Købsordredata
                            GetPurchaseOrder(tbInputData.Text);
                            btnDecoder.Visible = true;
                        }
                        break;
                    case 1:
                        {
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText2");
                            if (Vendorlot != "")
                            {
                                tbInputData.Text = Vendorlot;
                                tbInputData.SelectAll();
                            }
                            else
                              if (Decoding.theCode10.Equals(""))
                                tbInputData.Text = "";
                              else
                                tbInputData.Text = Decoding.theCode10.ToString();
                            Globals.step++;
                            btnDecoder.Visible = false;
                            btSearch.Visible = true;
                        }
                        break;
                    case 2:
                        {
                            btnNext.Enabled = false;
                            btnPrevius.Enabled = false;
                            btnDecoder.Visible = false;
                            btSearch.Visible = false;
                            Vendorlot = tbInputData.Text;
                            Globals.step++;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText3");
                            tbInputData.Text = "";

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            POL = PurchaseLineList.ElementAt(POLindex);
                            try
                            {
                                if (Decoding.theCode37.Equals(""))
                                    remaning = WareHouse.WSReturnRemaningQuantity(OrderType, POL.TheSourceNo.ToString(), POL.TheItemNo.ToString());
                                else
                                  remaning = decimal.Parse(Decoding.theCode37.ToString());


                                tbInputData.Text = remaning.ToString();
                                lbQuantity.Text = remaning.ToString();
                                tbInputData.SelectAll();
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
                            decimal d = 0;
                            if (!decimal.TryParse(tbInputData.Text, out d))
                            {
                                break;
                            }
#region Add Qty to purchaseorder
                            if (d > remaning)
                            {
                                if (MessageBox.Show(string.Format(mt.ReadResFile(this.Name.ToString() + "Message9"), remaning.ToString(), Environment.NewLine, tbInputData.Text), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    BalanceWarehouse WareHouse = new BalanceWarehouse();
                                    WareHouse.UseDefaultCredentials = true;
                                    try
                                    {
                                        if (!WareHouse.WSAddQuantityToPurchaseOrder(POL.TheSourceNo, POL.TheItemNo, (d - remaning), POL.TheUnitOfMesure))
                                        {
                                            MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message10"));
                                        }

                                        if (WareHouse.WSCreateWarehouseInboundDoc(OrderNo))
                                        {
                                            // Hent modtagelseslinjer på ny med de nye antal i.
                                            GetReceiptliens(OrderNo, OrderType);
                                            // GetReceiptlines tæller Globals.Step op med en så den skal sættes 1 ned.
                                            Globals.GlobalStep--;
                                            ExtractData();
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
                                else
                                {
                                    tbInputData.Focus();
                                    tbInputData.SelectAll();
                                    break;
                                }
                            }
#endregion
                            lbQuantity.Text = tbInputData.Text;
                            POL.TheQuantity = d;
                            PurchaseLineList.Insert(POLindex, POL);
                            PurchaseLineList.RemoveAt(POLindex + 1);
                            tbInputData.Text = "";
                            tbInputData.Focus();
                            tbInputData.SelectAll();
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText4");
#region QaSample
                            decimal SQ = 0;
                            string UOM = "";

                            try
                            {
                                BalanceWarehouse WareHouse = new BalanceWarehouse();
                                WareHouse.UseDefaultCredentials = true;

                                if (WareHouse.WSItemQaSample(POL.TheItemNo, ref SQ, ref UOM))
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Message6"), POL.TheItemNo.ToString(), SQ.ToString("F2"), UOM.ToString()),
                                                      mt.ReadResFile(this.Name.ToString() + "Message6Caption"));
                                }
                                WareHouse.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
#endregion

                            if (POL.TheUseMHD)
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText5");
                                tbInputData.Mask = mt.ReadResFile(this.Name.ToString() + "DateMask");
                                Globals.step++;
                            }
                            else
                            {
                                // Hent Lotnummer fra nummerserie og opret Lot Info  Start.

                                BalanceWarehouse WareHouse = new BalanceWarehouse();
                                WareHouse.UseDefaultCredentials = true;

                                if (WareHouse.WSItemUsesTracking(POL.TheItemNo))
                                {
#region Generate PID
                                    try
                                    {
                                        GenereretPID = WareHouse.WSReturnNewPID();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                    }
#endregion

#region Print PID Preview
                                    try
                                    {
                                        WareHouse.WSPrintPidPrev(GenereretPID, Globals.theWinlogon, POL.TheItemNo, POL.TheQuantity.ToString(), POL.TheMHD.ToString(), Vendorlot, POL.TheUnitOfMesure.ToString());
                                        if (Globals.theShowMessage)
                                            MessageBoxExample.MyMessageBox.ShowBox(GenereretPID.ToString());
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
                                    }
#endregion

                                    // Hent Lotnummer fra nummerserie og opret Lot Info  Slut.
                                    Globals.step += 2;
                                    tbInputData.Text = "";
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText4");
                                }
                                else
                                {
                                    Globals.step += 3;
                                    tbInputData.Text = "";
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText6");
                                    tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            bool OK = false;
                            DateTime TestDate = new DateTime(1, 1, 1);

                            try
                            {
                                if (Decoding.theCode15.Equals(""))
                                  TestDate = Convert.ToDateTime(tbInputData.Text);
                                else
                                  TestDate = Convert.ToDateTime(Decoding.theCode15.ToString());

                                if (TestDate.CompareTo(DateTime.Now) >= 1)
                                    OK = true;
                                else
                                {
                                    OK = false;
                                    MessageBoxExample.MyMessageBox.ShowBox(string.Format(mt.ReadResFile(this.Name.ToString() + "Message8"), TestDate.ToShortDateString(), Environment.NewLine, Environment.NewLine, DateTime.Today.ToShortDateString()));
                                }
                            }
                            catch (Exception ex)
                            {
                                OK = false;
                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message.ToString());
                            }

                            if (OK)
                            {
                                lbMHD.Text = tbInputData.Text;
                                POL.TheMHD = DateTime.Parse(lbMHD.Text);
                                PurchaseLineList.Insert(POLindex, POL);
                                PurchaseLineList.RemoveAt(POLindex + 1);
                                tbInputData.Mask = "";
                                tbInputData.Text = "";
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText4");
                                Globals.step++;
                                // Hent Lotnummer fra nummerserie og opret Lot Info  Start.
                                BalanceWarehouse WareHouse = new BalanceWarehouse();
                                WareHouse.UseDefaultCredentials = true;
                                GenereretPID = WareHouse.WSReturnNewPID();
                                WareHouse.WSPrintPidPrev(GenereretPID, Globals.theWinlogon, POL.TheItemNo, POL.TheQuantity.ToString(), POL.TheMHD.ToString(), Vendorlot, POL.TheUnitOfMesure.ToString());
                                if (Globals.theShowMessage)
                                    MessageBoxExample.MyMessageBox.ShowBox(GenereretPID.ToString());
                                WareHouse.Dispose();
                                // Hent Lotnummer fra nummerserie og opret Lot Info  Slut.
                            }
                            else
                                tbInputData.Text = "";
                        }
                        break;

                    case 5:
                        {

                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            POL = PurchaseLineList.ElementAt(POLindex);

                            if (WareHouse.WSItemUsesTracking(POL.TheItemNo))
                            {
                                if (!GenereretPID.Equals(tbInputData.Text))
                                {
                                    tbInputData.Text = "";
                                    MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message7"));
                                    break;
                                }

                                try
                                {
                                    if (WareHouse.WSLotInfoUsed(tbInputData.Text))
                                    {
                                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message5"));
                                        break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                                }


                                try
                                {
                                    if (!WareHouse.WSLotInfoExists(POL.TheItemNo, tbInputData.Text, Vendorlot))
                                    {
                                        MessageBoxExample.MyMessageBox.ShowBox(mt.ReadResFile(this.Name.ToString() + "Message3"));
                                        break;
                                    }
                                    lbLotNo.Text = tbInputData.Text;
                                    tbInputData.Text = "";
                                    POL = PurchaseLineList.ElementAt(POLindex);
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText6");
                                    tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                                    Globals.step++;

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
                        }
                        break;
                    case 6: 
                        {
                            Decoding.theCode00 = "";
                            Decoding.theCode01 = "";
                            Decoding.theCode02 = "";
                            Decoding.theCode10 = "";
                            Decoding.theCode15 = "";
                            Decoding.theCode37 = "";
                            BalanceWarehouse WareHouse = new BalanceWarehouse();
                            WareHouse.UseDefaultCredentials = true;
                            POL = PurchaseLineList.ElementAt(POLindex);
                            try
                            {
                                DateTime d;
                                if (POL.TheMHD.ToString() != "")
                                    DateTime.TryParse(POL.TheMHD.ToString(), out d);
                                else
                                    d = DateTime.Now;
                                this.pbIndicator.Image = WindowsFormsApplication1.Properties.Resources.animatedCircle;
                                this.pbIndicator.Visible = true;

                                WareHouse.WSWhsPostReceiptLine(OrderType, POL.TheSourceNo, POL.TheItemNo, POL.TheQuantity, d, lbLotNo.Text, Vendorlot, POL.TheLinje, Globals.theLocation);
                            }
                            catch (Exception ex)
                            {
                                this.pbIndicator.Image = null;
                                this.pbIndicator.Visible = false;

                                MessageBoxExample.MyMessageBox.ShowBox(ex.Message);
                            }
                            lbQuantity.Text = WareHouse.WSReturnRemaningQuantity(OrderType, POL.TheSourceNo.ToString(), POL.TheItemNo.ToString()).ToString(CultureInfo.GetCultureInfo(Globals.theLanguageCode).NumberFormat);

                            this.pbIndicator.Image = null;
                            this.pbIndicator.Visible = false;

                            if (lbQuantity.Text == "0")
                            {
                                PurchaseLineList.RemoveAt(POLindex);
                                if (POLindex > 0)
                                  POLindex--;
                                tbInputData.Text = "";
                                btnNext.Enabled = true;
                                btnPrevius.Enabled = true;
                                if (PurchaseLineList.Count > 1)
                                {
                                    //lbNoOfLines.Text = PurchaseLineList.Count.ToString();
                                    lbNoOfLines.Text = string.Format("{0} {1} {2}", (POLindex + 1), "af", PurchaseLineList.Count());
                                    Globals.step = 1;
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText7");

                                    // Hent aktuel varelinje Start
                                    POL = PurchaseLineList.ElementAt(POLindex);
                                    lbDescription.Text = POL.TheDescription;
                                    lbNo.Text = POL.TheItemNo;
                                    lbQuantity.Text = POL.TheQuantity.ToString();
                                    if (POL.TheQuantity <= 0)
                                        tbInputData.Enabled = false;
                                    else
                                        tbInputData.Enabled = true;
                                    lbUnitOfMesure.Text = POL.TheUnitOfMesure;
                                    // Hent aktuel varelinje Slut
                                    lbLotNo.Text = "";
                                    lbMHD.Text = "";
                                    lbQuantity.Text = "";
                                }

                                if (PurchaseLineList.Count == 1)
                                {
                                    lbNoOfLines.Text = PurchaseLineList.Count.ToString();
                                    lbNoOfLines.Text = string.Format("{0} {1} {2}", (POLindex + 1), "af", PurchaseLineList.Count());
                                    // Hent aktuel varelinje Start
                                    POL = PurchaseLineList.ElementAt(POLindex);
                                    lbDescription.Text = POL.TheDescription;
                                    lbNo.Text = POL.TheItemNo;
                                    lbQuantity.Text = POL.TheQuantity.ToString();
                                    if (POL.TheQuantity <= 0)
                                        tbInputData.Enabled = false;
                                    else
                                        tbInputData.Enabled = true;
                                    lbUnitOfMesure.Text = POL.TheUnitOfMesure;
                                    lbLotNo.Text = "";
                                    lbMHD.Text = "";

                                    // Hent aktuel varelinje Slut
                                    
                                    Globals.step = 1;
                                    lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText7");
                                    btnDecoder.Visible = true;
                                    btSearch.Visible = true;
                                }
                                if (PurchaseLineList.Count == 0)
                                    Globals.step = 0;
                            }
                            else
                            {
                                Globals.step = 1;
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText7");
                                btnDecoder.Visible = true;
                                btSearch.Visible = true;
                                tbInputData.Text = ""; // Globals.VendorLot;
                                tbInputData.SelectAll();
                                lbLotNo.Text = "";
                                lbMHD.Text = "";
                                btnNext.Enabled = true;
                                btnPrevius.Enabled = true;
                            }
                            if (Globals.step == 0)
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText1");
                                lbLotNo.Text = "";
                                lbMHD.Text = "";
                                lbName.Text = "";
                                lbName2.Text = "";
                                lbNo.Text = "";
                                lbQuantity.Text = "";
                                lbUnitOfMesure.Text = "";
                                lbAddress.Text = "";
                                lbDescription.Text = "";
                                tbInputData.Text = "";
                                lbNoOfLines.Text = "";
                                btnNext.Enabled = true;
                                btnPrevius.Enabled = true;
                                Vendorlot = "";
                            }
                            WareHouse.Dispose();
                        }
                        break;
                }
            }
#region ESC
            if ((e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Tab))
            {
                switch (Globals.step)
                {
                    case 7:
                        {
                            tbInputData.Text = mt.ReadResFile(this.Name.ToString() + "TextBox1");
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText6");
                            Globals.step--;
                        }
                        break;
                    case 6:
                        {
                            Globals.step--;
                        }
                        break;
                    case 5:
                        {
                            POL = PurchaseLineList.ElementAt(POLindex);


                            if (POL.TheUseMHD)
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText5");
                                tbInputData.Text = POL.TheMHD.ToString();
                                Globals.step-=2;
                            }
                            else
                            {
                                lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText4");
                                tbInputData.Text = POL.TheLotNr.ToString();
                                Globals.step -=2;
                            }
                        }
                        break;
                    case 4:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText3");
                            POL = PurchaseLineList.ElementAt(POLindex);
                            tbInputData.Mask = "";
                            tbInputData.Text = POL.TheQuantity.ToString();

                        }
                        break;
                    case 3:
                        {
                            Globals.step--;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText2");
                            tbInputData.Text = Vendorlot;
                            btnPrevius.Enabled = true;
                            btnNext.Enabled = true;
                        }
                        break;
                    case 2:
                        {
                            Globals.step = 0;
                            lblInputText.Text = mt.ReadResFile(this.Name.ToString() + "LabelInputText1");
                            tbInputData.Text = "";
                        }
                        break;
                    case 1:
                        {
                            Globals.step--;
                        }
                        break;
                    case 0: this.Close();
                        break;
                }
            }
#endregion
        }

        private void fmWhseReceiptSingle_Leave(object sender, EventArgs e)
        {
            Vendorlot = "";
            Globals.step = 0;
        }

        private void btnDecoder_Click(object sender, EventArgs e)
        {
            fmDecode bdc = new fmDecode();
            bdc.ShowDialog();
            if (Vendorlot != "")
            {
                tbInputData.Text = Vendorlot;
                tbInputData.SelectAll();
            }
            else
                if (Decoding.theCode10.Equals(""))
                    tbInputData.Text = "";
                else
                    tbInputData.Text = Decoding.theCode10.ToString();
            this.Update();
            this.tbInputData.Focus();
        }

        private void fmWhseReceiptSingle_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
            if (OrderNo != "")
            {
                if(OrderType == 39)
                    GetPurchaseOrder(OrderNo);
                if (OrderType == 37)
                    GetReturnOrder(OrderNo);
                Globals.GlobalStep = 1;
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            string Searchfor = "";

            BalanceWarehouse WareHouse = new BalanceWarehouse();
            WareHouse.UseDefaultCredentials = true;
            
            fmItemSearch isf = new fmItemSearch();
            isf.ShowDialog(ref Searchfor);

            GetIndexOfItem(WareHouse.WSGetItemCrossRef(WareHouse.WSGetItemCrossRef(Searchfor)));

            tbInputData.Focus();

        }
    }
}
