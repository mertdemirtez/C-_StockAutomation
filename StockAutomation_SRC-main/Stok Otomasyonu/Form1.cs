using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Otomasyonu
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source = MERT\\MSSQLSERVER2; Initial Catalog = Stok3; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        { // Ekle Butonu //

            String t1 = textBox1.Text; // MalzemeKodu //
            String t2 = textBox2.Text; // MalzemeAdi  //
            String t3 = textBox3.Text; // YillikSatis //
            String t4 = textBox4.Text; // BirimFiyat //
            String t5 = textBox5.Text; // MinimumStok //
            String t6 = textBox6.Text; // TSuresi //


            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Malzemeler(MalzemeKodu,MalzemeAdi,YillikSatis,BirimFiyat,MinStok,TSuresi) VALUES ('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()  // Veritabanı görüntülenmesi //
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Malzemeler ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        { // SİLME BUTONU //

            String t1 = textBox1.Text; // Seçilen satırın malzeme kodunu al //
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("DELETE FROM Malzemeler WHERE MalzemeKodu=('" + t1 + "')", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text; // MalzemeKodu //
            String t2 = textBox2.Text; // MalzemeAdi  //
            String t3 = textBox3.Text; // YillikSatis //
            String t4 = textBox4.Text; // BirimFiyat //
            String t5 = textBox5.Text; // MinimumStok //
            String t6 = textBox6.Text; // TSuresi //

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("UPDATE Malzemeler SET MalzemeKodu='" + t1 + "',MalzemeAdi='" + t2 + "',YillikSatis='" + t3 + "',BirimFiyat='" + t4 + "',MinStok='" + t5 + "',TSuresi='" + t6 + "' WHERE MalzemeKodu='" + t1+ "' " , baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            listele();
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void lblHoşgeldiniz_Click(object sender, EventArgs e)
        {

        }
    }
}

