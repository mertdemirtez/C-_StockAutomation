using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Stok_Otomasyonu
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String KullaniciAdi = textBox1.Text;
            String Sifre = textBox2.Text;   

            con = new SqlConnection("Data Source=MERT\\MSSQLSERVER2;Initial Catalog=Login;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;   
            com.CommandText =(" Select *from GirisEkrani WHERE KullaniciAdi='" +textBox1.Text+ "' And Sifre='" +textBox2.Text+"'");
            
            dr = com.ExecuteReader();

            if (dr.Read())
            {

                MessageBox.Show("Tebrikler Giriş Başarılı...");
                Form1 gecis = new Form1();
                gecis.Show();
                this.Hide();   
            }

            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");


            }

            con.Close();





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form3 gecis = new Form3();
            gecis.Show();
            this.Hide();
        }
    }
}
