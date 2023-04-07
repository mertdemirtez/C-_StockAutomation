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

namespace Stok_Otomasyonu
{
    public partial class Form3 : Form
    {
         SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;

        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = MERT\\MSSQLSERVER2; Initial Catalog = Login; Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            String KullaniciAdi = textBox1.Text;
            String Sifre = textBox2.Text;

            con = new SqlConnection("Data Source=MERT\\MSSQLSERVER2;Initial Catalog=Login;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = (" Select *from GirisEkrani WHERE KullaniciAdi='" + textBox1.Text + "' ");

            dr = com.ExecuteReader();

            if (dr.Read())
            {

                MessageBox.Show("Bu Kullanıcı Adı Kullanılıyor Lütfen Başka Kullanıcı Adı Seçiniz...!");
                
            }

            else
            {
                

               baglanti.Open();
               SqlCommand komut = new SqlCommand("INSERT INTO GirisEkrani(KullaniciAdi,Sifre) VALUES ('" + KullaniciAdi + "','" + Sifre + "')", baglanti);
               komut.ExecuteNonQuery();
               baglanti.Close();

                MessageBox.Show("Tebrikler Kayıt Oldunuz...!");

                Form2 gecis = new Form2();
                gecis.Show();
                this.Hide();



            }

            con.Close();


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 gecis = new Form2();
            gecis.Show();
            this.Hide();
        }
    }
}
