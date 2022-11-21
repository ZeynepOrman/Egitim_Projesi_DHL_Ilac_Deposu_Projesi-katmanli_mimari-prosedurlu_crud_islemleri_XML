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
    public partial class İadeedilenilacform : Form
    {
        public İadeedilenilacform()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            dataGridView1.DataSource = FİadeEdilenİlac.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EİadeEdilenİlac ekleme = new EİadeEdilenİlac();
            ekleme.İadeEdilenİlacAdi = textBox1.Text;
            ekleme.İadeEdilenİlacBarkodNo = Convert.ToInt32(textBox2.Text);
            ekleme.İadeEdilenİlacUretimTarihi = Convert.ToDateTime(textBox3.Text);
            ekleme.İadeEdilenİlacTuketimTarihi = Convert.ToDateTime(textBox4.Text);
            ekleme.İadeEdilenİlacAlinanFirmaAdi = textBox5.Text;
            FİadeEdilenİlac.Ekleme(ekleme);
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EİadeEdilenİlac yenile = new EİadeEdilenİlac();
            yenile.İadeEdilenİlacNo = Convert.ToInt32(textBox1.Tag);
            yenile.İadeEdilenİlacAdi = textBox1.Text;
            yenile.İadeEdilenİlacBarkodNo = Convert.ToInt32(textBox2.Text);
            yenile.İadeEdilenİlacUretimTarihi = Convert.ToDateTime(textBox3.Text);
            yenile.İadeEdilenİlacTuketimTarihi = Convert.ToDateTime(textBox4.Text);
            yenile.İadeEdilenİlacAlinanFirmaAdi = textBox5.Text;
            FİadeEdilenİlac.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EİadeEdilenİlac sil = new EİadeEdilenİlac();
            sil.İadeEdilenİlacNo = Convert.ToInt32(textBox1.Tag);
            FİadeEdilenİlac.Sil(sil);
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
            textBox1.Tag = satir.Cells["İadeEdilenİlacNo"].Value.ToString();
            textBox1.Text = satir.Cells["İadeEdilenİlacAdi"].Value.ToString();
            textBox2.Text = satir.Cells["İadeEdilenİlacBarkodNo"].Value.ToString();
            textBox3.Text = satir.Cells["İadeEdilenİlacUretimTarihi"].Value.ToString();
            textBox4.Text = satir.Cells["İadeEdilenİlacTuketimTarihi"].Value.ToString();
            textBox5.Text = satir.Cells["İadeEdilenİlacAlinanFirmaAdi"].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            EİadeEdilenİlac ara = new EİadeEdilenİlac();
            ara.İadeEdilenİlacAdi = textBox1.Text;
            dataGridView1.DataSource = FArama.Arama5(ara);
        }
    }
}
