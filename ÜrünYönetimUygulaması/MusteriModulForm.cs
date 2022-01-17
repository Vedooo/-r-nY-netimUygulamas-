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
    public partial class MusteriModulForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();

        public MusteriModulForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Müşteriyi Kaydetmek İstiyor musunuz ?", "Kaydediliyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbMusteri(MusteriAdi,MusteriTelNo)VALUES(@MusteriAdi,@MusteriTelNo)", con);
                    cm.Parameters.AddWithValue("@MusteriAdi", textCName.Text);
                    cm.Parameters.AddWithValue("@MusteriTelNo", textCPhoneNo.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri Başarı İle Kaydedildi.");
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
            textCName.Clear();
            textCPhoneNo.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Müşteriyi Güncellemek İstiyor musunuz ?", "Güncelleniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbMusteri SET MusteriAdi =@MusteriAdi ,MusteriTelNo = @MusteriTelNo WHERE MusteriNo LIKE '" + MusteriNo.Text + "'", con);
                    cm.Parameters.AddWithValue("@MusteriAdi", textCName.Text);
                    cm.Parameters.AddWithValue("@MusteriTelNo", textCPhoneNo.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri Başarı İle Güncellendi.");
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
