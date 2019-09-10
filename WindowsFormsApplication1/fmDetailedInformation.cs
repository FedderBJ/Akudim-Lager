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
    using WSDetailedUserInformation;

    public partial class fmDetailedInformation : Form
    {
        public fmDetailedInformation()
        {
            InitializeComponent();
        }

        public fmDetailedInformation(string ItemFilter, string BinFilter)
        {
            InitializeComponent();

            DetailedUserInformation_Service detaileduserinformationservice = new DetailedUserInformation_Service();
            detaileduserinformationservice.UseDefaultCredentials = true;

            List<DetailedUserInformation_Filter> DetailtUserInfoFilterArray = new List<DetailedUserInformation_Filter>();

            DetailedUserInformation_Filter LocationFilter = new DetailedUserInformation_Filter();
            LocationFilter.Field = DetailedUserInformation_Fields.Location;
            LocationFilter.Criteria = Globals.theLocation;
            DetailtUserInfoFilterArray.Add(LocationFilter);

            DetailedUserInformation_Filter ItemNoFilter = new DetailedUserInformation_Filter();
            ItemNoFilter.Field = DetailedUserInformation_Fields.ItemNo;
            ItemNoFilter.Criteria = ItemFilter;
            DetailtUserInfoFilterArray.Add(ItemNoFilter);

            DetailedUserInformation_Filter BinCodeFilter = new DetailedUserInformation_Filter();
            BinCodeFilter.Field = DetailedUserInformation_Fields.Bin;
            BinCodeFilter.Criteria = BinFilter;
            DetailtUserInfoFilterArray.Add(BinCodeFilter);

            DetailedUserInformation[] Details = detaileduserinformationservice.ReadMultiple(DetailtUserInfoFilterArray.ToArray(), "", 1000);

            if (Details.Count() > 0)
            {
                this.dataGridView1.DataSource = Details;
                this.dataGridView1.Update();
            }
        }


        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(fmDetailedInformation));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmDetailedInformation_Load(object sender, EventArgs e)
        {
            if (Globals.theLanguageCode != "")
                ChangeLanguage(Globals.theLanguageCode);
        }
    }
}
