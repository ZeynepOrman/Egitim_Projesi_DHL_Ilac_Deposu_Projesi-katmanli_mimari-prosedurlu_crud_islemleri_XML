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
    public partial class RaporlarForm : Form
    {
        public RaporlarForm()
        {
            InitializeComponent();
        }

        //private void Raporla()
        //{
        //    dataGridView1.DataSource = FRapor.Raporlama();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem == "Firmaya göre sırala")
            //{
                EFirma verial = new EFirma();
                verial.FirmaAdi = comboBox1.Text;
                dataGridView1.DataSource = FRapor.Raporlama1(verial);
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EFirma verial = new EFirma();
            verial.FirmaAdi = comboBox2.Text;
            dataGridView1.DataSource = FRapor.Raporlama2(verial);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EDepo verial = new EDepo();
            verial.DepoAdi = comboBox3.Text;
            dataGridView1.DataSource = FRapor.Raporlama4(verial);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            EGelenİlac verial = new EGelenİlac();
            //verial.GeriGelenİlacTuketimTarihi
            dataGridView1.DataSource = FRapor.Raporlama5(verial);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EGeriGelenİlac verial = new EGeriGelenİlac();

            dataGridView1.DataSource = FRapor.Raporlama3(verial);
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

        private void RaporlarForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = FComboBox.CBDoldur1();
            comboBox1.DisplayMember = "FirmaAdi";
            comboBox1.ValueMember = "FirmaNo";
            comboBox2.DataSource = FComboBox.CBDoldur1();
            comboBox2.DisplayMember = "FirmaAdi";
            comboBox2.ValueMember = "FirmaNo";
            comboBox3.DataSource = FComboBox.CBDoldur2();
            comboBox3.DisplayMember = "DepoAdi";
            comboBox3.ValueMember = "DepoNo";
        }
    }
}
