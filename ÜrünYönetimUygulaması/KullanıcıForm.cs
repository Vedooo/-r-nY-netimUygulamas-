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
    public partial class KullanıcıForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rakes\Documents\12m.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public KullanıcıForm()
        {
            InitializeComponent();
            LoadUser();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                KullanıcıModulForm kullanıcıModul = new KullanıcıModulForm();
                kullanıcıModul.textUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                kullanıcıModul.textFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                kullanıcıModul.textPass.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                kullanıcıModul.textPhoneNo.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                kullanıcıModul.btnSave.Enabled = false;
                kullanıcıModul.btnUpdate.Enabled = true;
                kullanıcıModul.textUserName.Enabled = false;
                kullanıcıModul.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Kullanıcıyı Silmek İstediğinizden Emin misiniz ?", "Kullanıcı Siliniyor..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbKullanici WHERE KullaniciAdi LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "' ", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi.");
                }
            }
            LoadUser();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbKullanici", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KullanıcıModulForm kullanıcıModule = new KullanıcıModulForm();
            kullanıcıModule.btnSave.Enabled = true;
            kullanıcıModule.btnUpdate.Enabled = false;
            kullanıcıModule.ShowDialog();
            LoadUser();
        }

    }
}
