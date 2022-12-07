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
    public partial class DepoPersoneliform : Form
    {
        public DepoPersoneliform()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            dataGridView1.DataSource = FDepoPersoneli.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EDepoPersoneli ekleme = new EDepoPersoneli();
            ekleme.DepoPersoneliAdSoyad = textBox1.Text;
            ekleme.Unvan = textBox2.Text;
            FDepoPersoneli.Ekleme(ekleme);
            Liste();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EDepoPersoneli yenile = new EDepoPersoneli();
            yenile.DepoPersoneliNo = Convert.ToInt32(textBox1.Tag);
            yenile.DepoPersoneliAdSoyad = textBox1.Text;
            yenile.Unvan = textBox2.Text;
            FDepoPersoneli.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EDepoPersoneli sil = new EDepoPersoneli();
            sil.DepoPersoneliNo = Convert.ToInt32(textBox1.Tag);
            FDepoPersoneli.Sil(sil);
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
            textBox1.Tag = satir.Cells["DepoPersoneliNo"].Value.ToString();
            textBox1.Text = satir.Cells["DepoPersoneliAdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["Unvan"].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            EDepoPersoneli ara = new EDepoPersoneli();
            ara.DepoPersoneliAdSoyad = textBox1.Text;
            dataGridView1.DataSource = FArama.Arama1(ara);
        }

        private void DepoPersoneliform_Load(object sender, EventArgs e)
        {

        }
    }
}
