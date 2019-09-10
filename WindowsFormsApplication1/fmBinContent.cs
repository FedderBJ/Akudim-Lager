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


namespace WindowsFormsApplication1
{
    using WSUserInformation;

    public partial class fmBinContent : Form
    {
        private int typetosearch = 0;
        private string stringtosearch = "";

        public fmBinContent()
        {
            InitializeComponent();
        }

        public fmBinContent(int SearchType, string SearchFor)
        {
            InitializeComponent();
            typetosearch = SearchType;
            stringtosearch = SearchFor;

            DoYourStuff();
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmBinContent));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        List<Information> InformationList = new List<Information>();
        Information Informations = new Information();
        int InformationIndex = 0;

        private void DoYourStuff()
        {
            UserInformation_Service userinformationservice = new UserInformation_Service();
            userinformationservice.UseDefaultCredentials = true;

            List<UserInformation_Filter> UserInfoFilterArray = new List<UserInformation_Filter>();

            UserInformation_Filter UserIdFilter = new UserInformation_Filter();
            UserIdFilter.Field = UserInformation_Fields.User;
            UserIdFilter.Criteria = Globals.theWinlogon;
            UserInfoFilterArray.Add(UserIdFilter);

            UserInformation_Filter LocationCodeFilter = new UserInformation_Filter();
            LocationCodeFilter.Field = UserInformation_Fields.Location;
            LocationCodeFilter.Criteria = Globals.theLocation;
            UserInfoFilterArray.Add(LocationCodeFilter);

            InformationIndex = 0;
            
            if (typetosearch == 1)
	        {

                UserInformation_Filter BinCodeFilter = new UserInformation_Filter();
                BinCodeFilter.Field = UserInformation_Fields.Bin;
                BinCodeFilter.Criteria = stringtosearch;
                UserInfoFilterArray.Add(BinCodeFilter);

                UserInformation[] Infos = userinformationservice.ReadMultiple(UserInfoFilterArray.ToArray(), "", 1000);

                if (Infos.Count() > 0)
                {
                    InformationList.Clear();
                    foreach (var item in Infos)
                    {
                        InformationList.Add(new Information(item.User, item.User, item.Zone, item.Bin, item.ItemNo, item.Description, item.UnitOfMesure, item.Quantity, item.Remaning_Qty, item.PID, item.MHD, item.VendorLot));
                    }
                    tbLines.Text = InformationList.Count().ToString();
                    Informations = InformationList.ElementAt(InformationIndex);
                    ExtractData(Informations);
                    this.Update();
                }
            }
            if (typetosearch == 2)
            {
                UserInformation_Filter ItemCodeFilter = new UserInformation_Filter();
                ItemCodeFilter.Field = UserInformation_Fields.ItemNo;
                ItemCodeFilter.Criteria = stringtosearch;
                UserInfoFilterArray.Add(ItemCodeFilter);

                UserInformation[] Infos = userinformationservice.ReadMultiple(UserInfoFilterArray.ToArray(), "", 1000);

                if (Infos.Count() > 0)
                {
                    InformationList.Clear();
                    foreach (var item in Infos)
                    {
                        InformationList.Add(new Information(item.User, item.User, item.Zone, item.Bin, item.ItemNo, item.Description, item.UnitOfMesure, item.Quantity, item.Remaning_Qty, item.PID, item.MHD, item.VendorLot));
                    }
                    tbLines.Text = InformationList.Count().ToString();
                    Informations = InformationList.ElementAt(InformationIndex);
                    ExtractData(Informations);
                    this.Update();
                }
            }
        }

        private void ExtractData(Information inf)
        {
            tbItemNo.Text = Informations.TheItem;
            tbDescription.Text = Informations.TheDescription;
            tbQuantity.Text = Informations.TheQty.ToString("F2");
            tbUnits.Text = Informations.TheUnitOfMesure;
            tbLotNo.Text = Informations.ThePid;
            if (Informations.theDate != null)
              tbMHD.Text = Informations.theDate.ToShortDateString();
            tbBincode.Text = Informations.TheBin;
            tbVendorLot.Text = Informations.TheVendorLot;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (InformationIndex < (InformationList.Count - 1))
            {
                InformationIndex++;
                Informations = InformationList.ElementAt(InformationIndex);
                ExtractData(Informations);
            }
        }

        private void btnPrevius_Click(object sender, EventArgs e)
        {
            if (InformationIndex > 0)
            {
                InformationIndex--;
                Informations = InformationList.ElementAt(InformationIndex);
                ExtractData(Informations);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            fmDetailedInformation di = new fmDetailedInformation(tbItemNo.Text, tbBincode.Text);
            di.ShowDialog();
        }

        private void fmBinContent_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
        }



    }
}
