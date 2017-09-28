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
using System.Collections;  // array list kolesiyonu tanımlamak için  dinamik dizi

namespace sinemaotomasyon
{
    public partial class koltuksecim : Form
    {
        public koltuksecim()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("server=localhost;database=sinema_rezervasyon;integrated security=true");
        void baglan()
        {
            if (bagla.State == ConnectionState.Closed)
            {
                bagla.Open();
            }
        }

        public string film_adi = " ";
        public string salon_adi = " ";
        public string seans = " ";
        ArrayList koltuklar = new ArrayList();
        ArrayList iptalkltk = new ArrayList();
        int filmID = 0;
        int salonID = 0;

        

        void koltukyaz()
        {
            string koltuk = "";
            for (int i = 0; i < koltuklar.Count; i++)
            {
                koltuk += koltuklar[i].ToString() + ",";
            }
            if (koltuklar.Count >= 1)
            {
                koltuk = koltuk.Remove(koltuk.Length - 1, 1);
            }
            textkoltuk.Text = koltuk;
        }
        void biletayir() //bilet kayıt ederken satilanbilet database i ne gönderir
        {
            baglan();
            string ucret = "";
            if (ogrenciradyo.Checked) ucret = "6";
            else ucret = "10";
            for (int i = 0; i < koltuklar.Count; i++)
            {
                string sql="INSERT INTO satilanbilet(film_id,salon_id,tarih,seans,adi,soyad,koltuk_no,ucret)VALUES("+filmID+","+salonID+",'"+Tarihlabel.Text+"','"+seans+"','"+Adtext.Text+"','"+Soyadtext.Text+"'," + Convert.ToInt32(koltuklar[i]) + ",'" + ucret + "')";
                SqlCommand komut = new SqlCommand(sql,bagla);
                komut.ExecuteNonQuery();
                this.Controls.Find("btn"+koltuklar[i].ToString(),true)[0].BackColor=Color.Red;

            }
            bagla.Close();
        }
        string Ara(string sql) //alınan string degeri sql aktarılır
        {
            baglan();
            SqlCommand komut = new SqlCommand(sql,bagla);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            string deger = oku[0].ToString();
            bagla.Close();
            return deger;
        }
        void localAl()
        {
            baglan();
            string sql = "SELECT * FROM satilanbilet WHERE film_id=" + filmID + " AND salon_id=" + salonID + "AND seans='"+ seans +"'";
            SqlCommand komut = new SqlCommand(sql, bagla);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string koltukno = oku[7].ToString();
                this.Controls.Find("btn" + koltukno, true)[0].BackColor = Color.Red;
            }
            bagla.Close();
        }

        private void koltukbtn_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Chartreuse)//yeşil
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Add(((Button)sender).Text);
                }
                koltukyaz();
            }
            else if (((Button)sender).BackColor == Color.Orange) //turuncu
            {
                ((Button)sender).BackColor = Color.Chartreuse;
                if (koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Remove(((Button)sender).Text);
                }
                koltukyaz();

            }
            else {//kırmızı
                if (!iptalkltk.Contains(((Button)sender).Text))
                {
                    iptalkltk.Add(((Button)sender).Text);
                }
                else 
                {
                    iptalkltk.Remove(((Button)sender).Text);
                }
                string koltuk = "";
                for (int i = 0; i < iptalkltk.Count; i++)
                {
                    koltuk += iptalkltk[i].ToString() + ",";
                }
                if (iptalkltk.Count >= 1)
                {
                    koltuk = koltuk.Remove(koltuk.Length - 1, 1);
                }
                textiptal.Text = koltuk;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)//anlık saati labellarda gösterdik
        {
            Saatlabel.Text = DateTime.Now.ToLongTimeString();
            Tarihlabel.Text = DateTime.Now.Date.ToShortDateString();
        }

        private void koltuksecim_Load(object sender, EventArgs e)
        {
            
            filmlabel.Text = film_adi;
            seanslabel.Text = salon_adi + "/" + seans;
            timer1.Enabled = true;
            salonID = Convert.ToInt32(Ara("SELECT * FROM salon WHERE salon_adi='" + salon_adi + "'"));//ara class a veriler gönderiliyor
            filmID = Convert.ToInt32(Ara("SELECT * FROM filmler WHERE film_adi='"+film_adi+"'"));
            localAl();
        }

        private void Biletbutton_Click(object sender, EventArgs e)
        {
            if (textkoltuk.Text != "")
            {
                if (textkoltuk.Text != "" && Adtext.Text!=""&& Soyadtext.Text!="")
                {
                    biletayir();
                    MessageBox.Show(Adtext.Text+" " +Soyadtext.Text + " kişinin " +textkoltuk.Text + " no lu koltukları ayrılmıştır");
                    textkoltuk.Text = "";
                    Adtext.Text = "";
                    Soyadtext.Text = "";
                    koltuklar.Clear();
                }
                else
                {
                    MessageBox.Show("Tüm bilgileri eksiksiz doldurunuz");
                }
            }
            else
            {
                MessageBox.Show("koltuk numarası seçmediniz");
            }
        }

        private void iptalbutton_Click(object sender, EventArgs e)
        {
           
            if (textiptal.Text != "")
            { 
                baglan();
                for (int i = 0; i < iptalkltk.Count; i++)
                {
                    string sql = "DELETE FROM satilanbilet WHERE koltuk_no=" + Convert.ToInt32(iptalkltk[i]);
                    SqlCommand komut = new SqlCommand(sql,bagla);
                    komut.ExecuteNonQuery();
                    this.Controls.Find("btn" + iptalkltk[i].ToString(), true)[0].BackColor = Color.Chartreuse;
                }
                bagla.Close();
                iptalkltk.Clear();
                MessageBox.Show(textkoltuk.Text+" koltuk numaraları iptal edilmiştir.");
                textiptal.Text = "";
                Adtext.Text = "";
                Soyadtext.Text = "";
            }
            else 
            {
                MessageBox.Show("koltuk numarası seçin");
            }
        }

        private void geributton_Click(object sender, EventArgs e)
        {
            Form1 formg= new Form1();
            formg.Show();
            this.Hide();
        }


    }
}
