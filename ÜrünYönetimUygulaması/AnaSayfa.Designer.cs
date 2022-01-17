
namespace ÜrünYönetimUygulaması
{
    partial class AnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUs = new ÜrünYönetimUygulaması.MüşteriButonu();
            this.btnCate = new ÜrünYönetimUygulaması.MüşteriButonu();
            this.btnOrder = new ÜrünYönetimUygulaması.MüşteriButonu();
            this.btnCust = new ÜrünYönetimUygulaması.MüşteriButonu();
            this.btnProd = new ÜrünYönetimUygulaması.MüşteriButonu();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnUs);
            this.panel1.Controls.Add(this.btnCate);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.btnCust);
            this.panel1.Controls.Add(this.btnProd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 92);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(616, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "KULLANICI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(521, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "KATEGORİLER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(436, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "SİPARİŞLER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(351, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "MÜŞTERİ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(263, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ÜRÜNLER";
            this.label1.Click += new System.EventHandler(this.Ürün_Click);
            // 
            // btnUs
            // 
            this.btnUs.Image = ((System.Drawing.Image)(resources.GetObject("btnUs.Image")));
            this.btnUs.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnUs.ImageHover")));
            this.btnUs.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnUs.ImageNormal")));
            this.btnUs.Location = new System.Drawing.Point(620, 17);
            this.btnUs.Name = "btnUs";
            this.btnUs.Size = new System.Drawing.Size(57, 44);
            this.btnUs.TabIndex = 12;
            this.btnUs.TabStop = false;
            this.btnUs.Click += new System.EventHandler(this.müşteriButonu5_Click);
            // 
            // btnCate
            // 
            this.btnCate.Image = ((System.Drawing.Image)(resources.GetObject("btnCate.Image")));
            this.btnCate.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnCate.ImageHover")));
            this.btnCate.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCate.ImageNormal")));
            this.btnCate.Location = new System.Drawing.Point(535, 17);
            this.btnCate.Name = "btnCate";
            this.btnCate.Size = new System.Drawing.Size(65, 54);
            this.btnCate.TabIndex = 11;
            this.btnCate.TabStop = false;
            this.btnCate.Click += new System.EventHandler(this.btnCate_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnOrder.ImageHover")));
            this.btnOrder.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnOrder.ImageNormal")));
            this.btnOrder.Location = new System.Drawing.Point(443, 17);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(59, 54);
            this.btnOrder.TabIndex = 10;
            this.btnOrder.TabStop = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCust
            // 
            this.btnCust.Image = ((System.Drawing.Image)(resources.GetObject("btnCust.Image")));
            this.btnCust.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnCust.ImageHover")));
            this.btnCust.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCust.ImageNormal")));
            this.btnCust.Location = new System.Drawing.Point(353, 17);
            this.btnCust.Name = "btnCust";
            this.btnCust.Size = new System.Drawing.Size(51, 62);
            this.btnCust.TabIndex = 9;
            this.btnCust.TabStop = false;
            this.btnCust.Click += new System.EventHandler(this.btnCust_Click);
            // 
            // btnProd
            // 
            this.btnProd.Image = ((System.Drawing.Image)(resources.GetObject("btnProd.Image")));
            this.btnProd.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnProd.ImageHover")));
            this.btnProd.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnProd.ImageNormal")));
            this.btnProd.Location = new System.Drawing.Point(271, 17);
            this.btnProd.Name = "btnProd";
            this.btnProd.Size = new System.Drawing.Size(43, 44);
            this.btnProd.TabIndex = 0;
            this.btnProd.TabStop = false;
            this.btnProd.Click += new System.EventHandler(this.btnProd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Banner", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 39);
            this.label4.TabIndex = 8;
            this.label4.Text = "12M Stok Takip";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Aqua;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(0, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 40);
            this.panel2.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelMain.Location = new System.Drawing.Point(0, 92);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 318);
            this.panelMain.TabIndex = 2;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnaSayfa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label4;
        private MüşteriButonu btnProd;
        private MüşteriButonu btnUs;
        private MüşteriButonu btnCate;
        private MüşteriButonu btnOrder;
        private MüşteriButonu btnCust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}