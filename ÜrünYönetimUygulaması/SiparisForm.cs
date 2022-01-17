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
    public partial class SiparisForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public SiparisForm()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbSiparis", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SiparisModulForm siparisModul = new SiparisModulForm();
            siparisModul.btnOrdAdd.Enabled = true;
            siparisModul.btnUpdate.Enabled = false;
            siparisModul.ShowDialog();
            LoadOrder();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                SiparisModulForm siparisModul = new SiparisModulForm();
                siparisModul.lblOrId.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                siparisModul.SiparisGun.Text = dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString();
                siparisModul.textUrunNo.Text = dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                siparisModul.textMusteriNo.Text = dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString();
                siparisModul.MiktarAyar.Value = Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString());
                siparisModul.textFiyat.Text = dgvOrder.Rows[e.RowIndex].Cells[6].Value.ToString();

                siparisModul.btnOrdAdd.Enabled = false;
                siparisModul.btnUpdate.Enabled = true;
                siparisModul.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Kullanıcıyı Silmek İstediğinizden Emin misiniz ?", "Kullanıcı Siliniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbSiparis WHERE SiparisId LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi.");
                }
            }
            LoadOrder();
        }
    }

}
