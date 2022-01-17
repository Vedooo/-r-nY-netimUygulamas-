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
    public partial class UrunForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UrunForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUrun WHERE CONCAT(UrunId,UrunAdi,UrunFiyat,UrunAciklama,UrunKategori) LIKE '%" + textSearch.Text + "%'", con);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UrunModuleForm urunModul = new UrunModuleForm();
            urunModul.btnSave.Enabled = true;
            urunModul.btnUpdate.Enabled = false;
            urunModul.ShowDialog();
            LoadProduct();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UrunModuleForm urunModul = new UrunModuleForm();
                urunModul.UrunNo.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                urunModul.textUrunAdi.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                urunModul.textMiktar.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                urunModul.textFiyat.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                urunModul.textAciklama.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                urunModul.comboMik.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                urunModul.btnSave.Enabled = false;
                urunModul.btnUpdate.Enabled = true;
                urunModul.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Ürünü Silmek İstediğinizden Emin misiniz ?", "Ürün Kaydı Siliniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUrun WHERE UrunId LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Başarıyla Silindi.");
                }
            }
            LoadProduct();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
