using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ÜrünYönetimUygulaması
{
    public partial class SiparisModulForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int mik = 0;

        public SiparisModulForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbMusteri WHERE CONCAT(MusteriNo,MusteriAdi) LIKE '%"+textSearchCust.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUrun WHERE CONCAT(UrunId,UrunAdi,UrunFiyat,UrunAciklama,UrunKategori) LIKE '%" + textSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void textSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void textSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }


        private void MiktarAyar_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(MiktarAyar.Value) > mik)
            {
                MessageBox.Show("Stokta Yeterli Ürün Bulunmamakta", "Uyarı..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt16(MiktarAyar.Value) > 0)
            {
                int total = Convert.ToInt16(textFiyat.Text) * Convert.ToInt16(MiktarAyar.Value);
                textTutar.Text = total.ToString();
            }
            
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textMusteriNo.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            textMusteriAdi.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textUrunNo.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            textUrunAdi.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            mik = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
            textFiyat.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void btnOrdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textMusteriNo.Text == "")
                {
                    MessageBox.Show("Lütfen bir müşteri seçiniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textUrunNo.Text == "")
                {
                    MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Siparişi Kaydetmek İstiyor musunuz ?", "Kaydediliyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbSiparis(SiparisGun,UrunId,MusteriNo,Miktar,Fiyat,Tutar)VALUES(@SiparisGun,@UrunId,@MusteriNo,@Miktar,@Fiyat,@Tutar)", con);
                    cm.Parameters.AddWithValue("@SiparisGun", SiparisGun.Value);
                    cm.Parameters.AddWithValue("@UrunId", Convert.ToInt16(textUrunNo.Text));
                    cm.Parameters.AddWithValue("@MusteriNo", Convert.ToInt16(textMusteriNo.Text));
                    cm.Parameters.AddWithValue("@Miktar", Convert.ToInt16(MiktarAyar.Value));
                    cm.Parameters.AddWithValue("@Fiyat", Convert.ToInt16(textFiyat.Text));
                    cm.Parameters.AddWithValue("@Tutar", Convert.ToInt16(textTutar.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sipariş Başarı İle Kaydedildi.");
                    cm = new SqlCommand("UPDATE tbUrun SET UrunMiktar = (UrunMiktar-@UrunMiktar) WHERE UrunId LIKE '" + textUrunNo.Text + "'", con);
                    cm.Parameters.AddWithValue("@UrunMiktar", Convert.ToInt16(MiktarAyar.Value));
                    
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            textMusteriNo.Clear();
            textMusteriAdi.Clear();
            textUrunNo.Clear();
            textUrunAdi.Clear();
            textFiyat.Clear();
            MiktarAyar.Value = 0;
            textTutar.Clear();
            SiparisGun.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnOrdAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }
    }
}
