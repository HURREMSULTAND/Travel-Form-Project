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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {

           
            var values =db.Guide.ToList();
            dataGridView1.DataSource = values;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            Guide guid = new Guide();
            guid.GuideName=txtName.Text;    
            guid.GuideSurname=txtSurname.Text; 
            db.Guide.Add(guid); 
            db.SaveChanges();
            MessageBox.Show("Rehber Başarı İle Eklendi");
           
      

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            int id=int.Parse(txtId.Text);   
            var removeValue=db.Guide.Find(id);
            db.Guide.Remove(removeValue);
            db.SaveChanges() ;
            MessageBox.Show("Rehber Başarıyla Silindi");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName=txtName.Text;
            updateValue.GuideSurname=txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarı İle Gücellendi","uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id =int.Parse(txtId.Text);
            var values=db.Guide.Where(x=> x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
