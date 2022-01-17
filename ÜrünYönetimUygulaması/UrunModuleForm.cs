using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ÜrünYönetimUygulaması
{
    public partial class UrunModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UrunModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboMik.Items.Clear();
            cm = new SqlCommand("SELECT KategoriAdi FROM tbKategori", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboMik.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Yeni Ürün Kaydı Oluşturmak İstiyor musunuz ?", "Kaydediliyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbUrun(UrunAdi,UrunMiktar,UrunFiyat,UrunAciklama,UrunKategori)VALUES(@UrunAdi,@UrunMiktar,@UrunFiyat,@UrunAciklama,@UrunKategori)", con);
                    cm.Parameters.AddWithValue("@UrunAdi", textUrunAdi.Text);
                    cm.Parameters.AddWithValue("@UrunMiktar", Convert.ToInt16(textMiktar.Text));
                    cm.Parameters.AddWithValue("@UrunFiyat", Convert.ToInt16(textFiyat.Text));
                    cm.Parameters.AddWithValue("@UrunAciklama", textAciklama.Text);
                    cm.Parameters.AddWithValue("@UrunKategori", comboMik.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Başarı İle Kaydedildi.");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            textUrunAdi.Clear();
            textMiktar.Clear();
            textFiyat.Clear();
            textAciklama.Clear();
            comboMik.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ürün Bilgilerini Güncellemek İstiyor musunuz ?", "Güncelleniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbUrun SET UrunAdi = @UrunAdi,UrunMiktar = @UrunMiktar,UrunFiyat = @UrunFiyat, UrunAciklama = @UrunAciklama, UrunKategori = @UrunKategori WHERE UrunId LIKE '" + UrunNo.Text + "'", con);
                    cm.Parameters.AddWithValue("@UrunAdi", textUrunAdi.Text);
                    cm.Parameters.AddWithValue("@UrunMiktar", Convert.ToInt16(textMiktar.Text));
                    cm.Parameters.AddWithValue("@UrunFiyat", textFiyat.Text);
                    cm.Parameters.AddWithValue("@UrunAciklama", textAciklama.Text);
                    cm.Parameters.AddWithValue("@UrunKategori", comboMik.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Başarı İle Güncellendi.");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
