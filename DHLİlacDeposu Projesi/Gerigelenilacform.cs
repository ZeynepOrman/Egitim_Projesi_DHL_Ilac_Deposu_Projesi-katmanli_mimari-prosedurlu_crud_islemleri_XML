using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entity;
using Facade;

namespace DHLİlacDeposu_Projesi
{
    public partial class Gerigelenilacform : Form
    {
        public Gerigelenilacform()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            dataGridView1.DataSource = FGeriGelenİlac.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EGeriGelenİlac ekleme = new EGeriGelenİlac();
            ekleme.GeriGelenİlacAdi = textBox1.Text;
            ekleme.GeriGelenİlacBarkodNo = Convert.ToInt32(textBox2.Text);
            ekleme.GeriGelenİlacUretimTarihi = Convert.ToDateTime(textBox3.Text);
            ekleme.GeriGelenİlacTuketimTarihi = Convert.ToDateTime(textBox4.Text);
            ekleme.GeriGelenİlacSatilanFirmaAdi = textBox5.Text;
            FGeriGelenİlac.Ekleme(ekleme);
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EGeriGelenİlac yenile = new EGeriGelenİlac();
            yenile.GeriGelenİlacNo = Convert.ToInt32(textBox1.Tag);
            yenile.GeriGelenİlacAdi = textBox1.Text;
            yenile.GeriGelenİlacBarkodNo = Convert.ToInt32(textBox2.Text);
            yenile.GeriGelenİlacUretimTarihi = Convert.ToDateTime(textBox3.Text);
            yenile.GeriGelenİlacTuketimTarihi = Convert.ToDateTime(textBox4.Text);
            yenile.GeriGelenİlacSatilanFirmaAdi = textBox5.Text;
            FGeriGelenİlac.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EGeriGelenİlac sil = new EGeriGelenİlac();
            sil.GeriGelenİlacNo = Convert.ToInt32(textBox1.Tag);
            FGeriGelenİlac.Sil(sil);
            Liste();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Anaekranform go = new Anaekranform();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["GeriGelenİlacNo"].Value.ToString();
            textBox1.Text = satir.Cells["GeriGelenİlacAdi"].Value.ToString();
            textBox2.Text = satir.Cells["GeriGelenİlacBarkodNo"].Value.ToString();
            textBox3.Text = satir.Cells["GeriGelenİlacUretimTarihi"].Value.ToString();
            textBox4.Text = satir.Cells["GeriGelenİlacTuketimTarihi"].Value.ToString();
            textBox5.Text = satir.Cells["GeriGelenİlacSatilanFirmaAdi"].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EGeriGelenİlac ara = new EGeriGelenİlac();
            ara.GeriGelenİlacAdi = textBox1.Text;
            dataGridView1.DataSource = FArama.Arama4(ara);
        }
    }
}
