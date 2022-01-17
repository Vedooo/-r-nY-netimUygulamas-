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
    public partial class KategoriForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public KategoriForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbKategori", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KategoriModulForm kategoriModul = new KategoriModulForm();
            kategoriModul.btnSave.Enabled = true;
            kategoriModul.btnUpdate.Enabled = false;
            kategoriModul.ShowDialog();
            LoadCategory();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                KategoriModulForm kategoriModul = new KategoriModulForm();
                kategoriModul.CategoryId.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                kategoriModul.textCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                kategoriModul.btnSave.Enabled = false;
                kategoriModul.btnUpdate.Enabled = true;
                kategoriModul.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bu Kategoriyi Silmek İstediğinizden Emin misiniz ?", "Kategori Siliniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbKategori WHERE KategoriNo LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kategori Başarıyla Silindi.");
                }
            }
            LoadCategory();
        }
    }
}
