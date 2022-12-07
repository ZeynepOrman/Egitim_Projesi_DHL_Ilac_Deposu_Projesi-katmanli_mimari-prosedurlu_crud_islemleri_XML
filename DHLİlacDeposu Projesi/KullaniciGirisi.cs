using Entity;
using Facade;
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

namespace DHLİlacDeposu_Projesi
{
    public partial class KullaniciGirisi : Form
    {
        public KullaniciGirisi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EKullaniciGirisi eKullanici= new EKullaniciGirisi
            {
                KullaniciAdi = textBox1.Text,
                Sifre = textBox2.Text,
            };
            int result = FKullaniciGirisi.KullaniciKontrol(eKullanici);

            if (result > 0)
            {
                MessageBox.Show("Giriş Başarılı.");
                Anaekranform go = new Anaekranform();
                go.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre hatalı");
                textBox1.Clear();
                textBox2.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void KullaniciGirisi_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EKullaniciGirisi eKullaniciGirisi = new EKullaniciGirisi
            {
                KullaniciAdi = textBox3.Text,
                Sifre = textBox4.Text,
                Email = textBox5.Text,
                Telefon = maskedTextBox1.Text,
            };
            int result = FKullaniciGirisi.KullaniciKayit(eKullaniciGirisi);

            if(result>0)
            {
                MessageBox.Show("Kayıt Başarılı.");
                Anaekranform go = new Anaekranform();
                go.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Kayit hatali.Tekrar deneyiniz");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                maskedTextBox1.Clear();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
