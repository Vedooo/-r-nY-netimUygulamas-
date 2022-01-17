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
    public partial class KullanıcıModulForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();

        public KullanıcıModulForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textPass.Text != textRePass.Text)
                {
                    MessageBox.Show("Girdiğiniz Şifreler Uyuşmuyor.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Kullanıcıyı Kaydetmek İstiyor musunuz ?", "Kaydediliyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbKullanici(KullaniciAdi,İsimSoyisim,Sifre,TelNo)VALUES(@KullaniciAdi,@İsimSoyisim,@Sifre,@TelNo)", con);
                    cm.Parameters.AddWithValue("@KullaniciAdi", textUserName.Text);
                    cm.Parameters.AddWithValue("@İsimSoyisim", textFullName.Text);
                    cm.Parameters.AddWithValue("@Sifre", textPass.Text);
                    cm.Parameters.AddWithValue("@TelNo", textPhoneNo.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Başarı İle Kaydedildi.");
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            textUserName.Clear();
            textFullName.Clear();
            textPass.Clear();
            textRePass.Clear();
            textPhoneNo.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textPass.Text != textRePass.Text)
                {
                    MessageBox.Show("Girdiğiniz Şifreler Uyuşmuyor.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Kullanıcıyı Güncellemek İstiyor musunuz ?", "Güncelleniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbKullanici SET İsimSoyisim =@İsimSoyisim ,Sifre = @Sifre,TelNo = @TelNo WHERE KullaniciAdi LIKE '"+ textUserName.Text + "'", con);
                    cm.Parameters.AddWithValue("@İsimSoyisim", textFullName.Text);
                    cm.Parameters.AddWithValue("@Sifre", textPass.Text);
                    cm.Parameters.AddWithValue("@TelNo", textPhoneNo.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Başarı İle Güncellendi.");
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
