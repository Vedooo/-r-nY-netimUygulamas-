using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ÜrünYönetimUygulaması
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void müşteriButonu1_Click(object sender, EventArgs e)
        {

        }

        private void Ürün_Click(object sender, EventArgs e)
        {

        }

        private void müşteriButonu5_Click(object sender, EventArgs e)
        {
            openChildForm(new KullanıcıForm());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            openChildForm(new MusteriForm());
        }

        private void btnCate_Click(object sender, EventArgs e)
        {
            openChildForm(new KategoriForm());
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            openChildForm(new UrunForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new SiparisForm());
        }
    }
}
