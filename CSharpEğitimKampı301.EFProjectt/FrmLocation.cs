﻿using System;
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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
           var values = db.Location.ToList();
            dataGridView1.DataSource= values;
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            Location location= new Location();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCoutry.Text;
            location.Price =decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayN.Text;
            location.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId


            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtLocation.Text);
            var deletedValue = db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi Başarılı");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtLocation.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.DayNight=txtDayN.Text;
            updatedValue.Price=decimal.Parse(txtPrice.Text);
            updatedValue.Capacity=byte.Parse(nudCapacity.Value.ToString());
            updatedValue.City=txtCity.Text;
            updatedValue.Country=txtCoutry.Text;
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}
