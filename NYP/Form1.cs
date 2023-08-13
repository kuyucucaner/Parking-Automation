using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NYP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-OC7N4UV\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            textBoxNo.Text = "";
            textBoxAd.Text = "";
            textBoxSoyad.Text = "";
            comboBoxMarka.Text = "";
            textBoxPlaka.Text = "";
            maskedTextBoxTelefon.Text = "";
            labelGün.Text = "";
            labelOdenecek.Text = "";
            textBoxAd.Focus();

        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Kullanici' table. You can move, or remove it, as needed.
            this.tbl_KullaniciTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Kullanici);
           
          
        }

        private void buttonListele_Click(object sender, EventArgs e)
        {

            this.tbl_KullaniciTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Kullanici);

        }
   

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Tbl_Kullanici Where No=@k1",baglanti );
            sil.Parameters.AddWithValue("@k1", textBoxNo.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarı ile silindi.");

        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Tbl_Kullanici Set Ad=@a1,Soyad=@a2,Marka=@a3,Plaka=@a4,Telefon=@a5,Tarih=@a6 where No=@a7",baglanti );
            guncelle.Parameters.AddWithValue("@a1", textBoxAd.Text);
            guncelle.Parameters.AddWithValue("@a2", textBoxSoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", comboBoxMarka.Text);
            guncelle.Parameters.AddWithValue("@a4", textBoxPlaka.Text);
            guncelle.Parameters.AddWithValue("@a5", maskedTextBoxTelefon.Text);
            guncelle.Parameters.AddWithValue("@a6", dateTimePicker1.Text);
            guncelle.Parameters.AddWithValue("@a7", textBoxNo.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi.");
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into Tbl_Kullanici (Ad,Soyad,Marka,Plaka,Telefon,Tarih) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            ekle.Parameters.AddWithValue("@p1", textBoxAd.Text);
            ekle.Parameters.AddWithValue("@p2 ", textBoxSoyad.Text);
            ekle.Parameters.AddWithValue("@p3", comboBoxMarka.Text);
            ekle.Parameters.AddWithValue("@p4", textBoxPlaka.Text);
            ekle.Parameters.AddWithValue("@p5", maskedTextBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@p6", dateTimePicker1.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla eklendi.");

        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBoxNo.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBoxAd.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            comboBoxMarka.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBoxPlaka.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            maskedTextBoxTelefon.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime cikistarih = Convert.ToDateTime(dateTimePicker2.Text);
            DateTime giristarih = Convert.ToDateTime(dateTimePicker1.Text);
            TimeSpan sonuc = cikistarih - giristarih;
            int toplam = Convert.ToInt32(sonuc.TotalDays);
            labelGün.Text = sonuc.TotalDays.ToString() + " Gün";
            if (toplam >= 0 && toplam < 1)
            {
                labelOdenecek.Text = "0"+ "  TL"; 
            }
            else if (toplam >= 1 && toplam <= 2)
            {
               labelOdenecek.Text = "5" + "  TL";
            }
            else if (toplam >= 3 && toplam <= 5)
            {
                labelOdenecek.Text = "10" + "  TL";
            }
            else if (toplam >= 6 && toplam <= 12)
            {
                labelOdenecek .Text = "15" + "  TL";
            }
            else if (toplam >=13 && toplam <= 25)
            {
                labelOdenecek.Text = "20" + "  TL";
            }
            else if (toplam >=26 && toplam <= 50)
            {
                labelOdenecek.Text = "25" + "  TL";
            }
            else if (toplam >=51 && toplam <= 1500)
            {
                labelOdenecek.Text ="50" + "  TL";
            }
        }

    }
}
