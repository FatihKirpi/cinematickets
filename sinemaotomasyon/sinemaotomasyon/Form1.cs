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

namespace sinemaotomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } //databasei tanımladık
        SqlConnection bagla = new SqlConnection("server=localhost;database=sinema_rezervasyon;integrated security=true");
       
        public string kullanici_adi=""; // kullanıcı adı label a veri çekmek için
        public string yetki = "";
        void baglan() 
        {
            if (bagla.State == ConnectionState.Closed)
            {
                bagla.Open();
            }
        }
        void sqlvericek(string sql, ComboBox combo)//comboboxlara veritabanindan veri çekmek için 
        {
            combo.Items.Clear();
            baglan();
            SqlCommand komut = new SqlCommand(sql,bagla);
            
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                combo.Items.Add(oku[1].ToString());

            }
            bagla.Close();

 
        }

        private void filmcombo_Click(object sender, EventArgs e) //form1 designer kısmında click özelliğini açtık
        {
            sqlvericek("SELECT * FROM filmler ",  filmcombo);
        }

        private void saloncombo_Click(object sender, EventArgs e)//form1 designer kısmında click özelliğini açtık
        {
            sqlvericek("SELECT * FROM salon",saloncombo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kullanici_label.Text = kullanici_adi;
          if (yetki == "person") //yetkiden gelen bilgi düzenle butonunu aktif yada pasif yapar
            {
                duzenle.Visible = false;
            }
          else if(yetki=="admin")
          {
              duzenle.Visible = true;
          }

           
            
        }

        private void rezervebtn_Click(object sender, EventArgs e)
        {
            if (saloncombo.SelectedIndex != -1 && filmcombo.SelectedIndex != -1 && seanscombo.SelectedIndex != -1)
            {
                koltuksecim sec = new koltuksecim();
                sec.film_adi = filmcombo.Text;
                sec.salon_adi = saloncombo.Text;
                sec.seans = seanscombo.Text;
                sec.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("lütfen eksiksiz doldurunuz.");
            }
        }

        private void seanscombo_Click(object sender, EventArgs e)
        {
            sqlvericek("SELECT * FROM saat ", seanscombo);
        }

        private void duzenle_Click(object sender, EventArgs e)
        {
            yönetici_panel git = new yönetici_panel();
            git.Show();
            this.Hide();
        }

        private void Cıkısbutton_Click(object sender, EventArgs e)
        {
            giris git = new giris();
            git.Show();
            this.Close();
            

        }
        
    }
}
