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
    public partial class MusteriForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public MusteriForm()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbMusteri", con);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MusteriModulForm musteriModul = new MusteriModulForm();
            musteriModul.btnSave.Enabled = true;
            musteriModul.btnUpdate.Enabled = false;
            musteriModul.ShowDialog();
            LoadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                MusteriModulForm musteriModul = new MusteriModulForm();
                musteriModul.MusteriNo.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                musteriModul.textCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                musteriModul.textCPhoneNo.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();


                musteriModul.btnSave.Enabled = false;
                musteriModul.btnUpdate.Enabled = true;
                musteriModul.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Müşteriyi Silmek İstediğinizden Emin misiniz ?", "Müşteri Siliniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbMusteri WHERE MusteriNo LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi.");
                }
            }
            LoadCustomer();
        }
    }
}
