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
    public partial class Gelenİlacform : Form
    {
        public Gelenİlacform()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            dataGridView1.DataSource = FGelenİlac.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EGelenİlac ekleme = new EGelenİlac();
            ekleme.GelenİlacAdi= textBox1.Text;
            ekleme.GelenİlacBarkodNo = Convert.ToInt32(textBox2.Text);
            ekleme.GelenİlacUretimTarihi = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            ekleme.GelenİlacTuketimTarihi = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            ekleme.GelenİlacAlinanFirma = textBox5.Text;
            ekleme.GelenİlacSatilanFirma = textBox6.Text;
            FGelenİlac.Ekleme(ekleme);
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EGelenİlac yenile = new EGelenİlac();
            yenile.GelenİlacNo = Convert.ToInt32(textBox1.Tag);
            yenile.GelenİlacAdi = textBox1.Text;
            yenile.GelenİlacBarkodNo = Convert.ToInt32(textBox2.Text);
            yenile.GelenİlacUretimTarihi = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            yenile.GelenİlacTuketimTarihi = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            yenile.GelenİlacAlinanFirma = textBox5.Text;
            yenile.GelenİlacSatilanFirma = textBox6.Text;
            FGelenİlac.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EGelenİlac sil = new EGelenİlac();
            sil.GelenİlacNo = Convert.ToInt32(textBox1.Tag);
            FGelenİlac.Sil(sil);
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
            textBox1.Tag = satir.Cells["GelenİlacNo"].Value.ToString();
            textBox1.Text = satir.Cells["GelenİlacAdi"].Value.ToString();
            textBox2.Text = satir.Cells["GelenİlacBarkodNo"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["GelenİlacUretimTarihi"].Value.ToString();
            dateTimePicker2.Text = satir.Cells["GelenİlacTuketimTarihi"].Value.ToString();
            textBox5.Text = satir.Cells["GelenİlacAlinanFirma"].Value.ToString();
            textBox6.Text = satir.Cells["GelenİlacSatilanFirma"].Value.ToString();

        }

        private void Gelenİlacform_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            EGelenİlac ara = new EGelenİlac();
            ara.GelenİlacAdi = textBox1.Text;
            dataGridView1.DataSource = FArama.Arama3(ara);
        }

    }
}

//dateTimePicker2.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
//dateTimePicker1.Value.ToShortDateString()
