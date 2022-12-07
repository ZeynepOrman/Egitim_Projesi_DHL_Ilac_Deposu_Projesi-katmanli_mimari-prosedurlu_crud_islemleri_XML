using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entity;
using Facade;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DHLİlacDeposu_Projesi
{
    public partial class Firmaform : Form
    {
        public Firmaform()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            dataGridView1.DataSource = FFirma.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void Error_Handle(string message = "Güncelleme başarısız!")
        {
            MessageBox.Show(message);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            EFirma ekleme = new EFirma();
            ekleme.FirmaAdi = textBox1.Text;
            ekleme.FirmaSorumlusu = textBox2.Text;
            ekleme.BorcDurumu = Convert.ToInt32(textBox3.Text);
            FFirma.Ekleme(ekleme);
            Liste();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            EFirma yenile = new EFirma();
            yenile.FirmaNo = Convert.ToInt32(textBox1.Tag);
            yenile.FirmaAdi = textBox1.Text;
            yenile.FirmaSorumlusu = textBox2.Text;
            yenile.BorcDurumu = Convert.ToInt32(textBox3.Text);
            FFirma.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EFirma sil = new EFirma();
            sil.FirmaNo = Convert.ToInt32(textBox1.Tag);
            FFirma.Sil(sil);
            Liste();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Anaekranform go = new Anaekranform();
            go.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["FirmaNo"].Value.ToString();
            textBox1.Text = satir.Cells["FirmaAdi"].Value.ToString();
            textBox2.Text = satir.Cells["FirmaSorumlusu"].Value.ToString();
            textBox3.Text = satir.Cells["BorcDurumu"].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EFirma ara = new EFirma();
            ara.FirmaAdi = textBox1.Text;
            dataGridView1.DataSource = FArama.Arama2(ara);
        }


    }
}
