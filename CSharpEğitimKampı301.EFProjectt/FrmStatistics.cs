using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEğitimKampı301.EFProjectt
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db =new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLokasyonSayısı.Text = db.Location.Count().ToString();
            lblSum.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuidCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();
          

            lblAvgLocationPrice.Text = (db.Location.Average(x => x.Price)?? 0).ToString("N1",new System.Globalization.CultureInfo("tr-TR"))+ " ₺"; 

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryId.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCapadokia.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = Math.Floor(
    db.Location
        .Where(x => x.Country == "Türkiye")
        .Average(y => (double?)y.Capacity) ?? 0).ToString();


            var romeGuideId =db.Location.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRoma.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity=db.Location.Max(x=>x.Capacity);
            lblMaxCapactyy.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

          var maxPrice =db.Location.Max(x=>x.Price);
          lblMaxPrice.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();


            var guidIdByNameAyşePekcan = db.Guide.Where(x => x.GuideName == "Ayşe" && x.GuideSurname == "Pekcan").Select(y => y.GuideId).FirstOrDefault();
             lblAyşe.Text=db.Location.Where(x=>x.GuideId==guidIdByNameAyşePekcan).Count().ToString();


        }

        
    }
}
