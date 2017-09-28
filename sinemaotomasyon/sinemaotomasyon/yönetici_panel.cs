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
    public partial class yönetici_panel : Form
    {
        public yönetici_panel()
        {
            InitializeComponent();

        }
        SqlConnection bagla = new SqlConnection("server=localhost;database=sinema_rezervasyon;integrated security=true");

        void baglan()
        {
            if(bagla.State==ConnectionState.Closed)
            {

            bagla.Open();
         }

        }
        void grid_vericek(string sql,DataGridView gridview) //datagridview e databasedeki bilgiler gelecek
        {
            baglan();
            SqlCommand komut = new SqlCommand(sql,bagla);
            DataTable taplo = new DataTable();
            taplo.Load(komut.ExecuteReader());
            gridview.DataSource = taplo;
            bagla.Close();
           

        }

        private void yönetici_panel_Load(object sender, EventArgs e)
        {
            grid_vericek("SELECT*FROM satilanbilet",MusteriDataGrid);
            grid_vericek("SELECT*FROM filmler",FilmDataGrid);
            grid_vericek("SELECT*FROM calisan",CalisandataGrid);
            
        }

        private void Eklebutton_Click(object sender, EventArgs e)
        {
            baglan();
            SqlCommand komut = new SqlCommand("INSERT INTO filmler(film_adi,yönetmen,film_tur) VALUES('" + filmtext.Text + "','" + yonetmentext.Text + "','" + turtext.Text + "')",bagla);
            komut.ExecuteNonQuery();
            //datagrid i kayıt ekledikten sonra yenilemek için
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from filmler", bagla);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "filmler");
            FilmDataGrid.DataSource = dtSet.Tables["filmler"];

           
            bagla.Close();
            MessageBox.Show(filmtext.Text+"/"+yonetmentext.Text+"/"+turtext.Text+" filmi eklendi. ");
            filmtext.Text = "";
            yonetmentext.Text = "";
            turtext.Text = "";
            
        }

        private void satisbutton_Click(object sender, EventArgs e)
        {
            baglan();
            SqlCommand komut = new SqlCommand("INSERT INTO satilanbilet(film_id,salon_id, tarih, seans,adi,soyad,koltuk_no,ucret) VALUES('" + film_idtext.Text + "','" + salon_idtext.Text + "','" + Tarihtext.Text + "','" + Seanstext.Text + "','" + adtext.Text + "','" + soyadtext.Text + "','" + koltuktext.Text + "','" + Fiyattext.Text + "')", bagla);
            komut.ExecuteNonQuery();

            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT * FROM satilanbilet", bagla);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "satilanbilet");
            MusteriDataGrid.DataSource = dtSet.Tables["satilanbilet"];
            bagla.Dispose();
            bagla.Close();
            MessageBox.Show(adtext.Text+" kişi eklenmiştir");
            film_idtext.Text = ""; Seanstext.Text = ""; Fiyattext.Text = "";
            adtext.Text = ""; soyadtext.Text = ""; koltuktext.Text = "";
            salon_idtext.Text = ""; Tarihtext.Text = "";

        }

        private void FilmSilbutton_Click(object sender, EventArgs e)
        {
            
            if (filmnotext.Text != "")
            {
                baglan();
                SqlCommand komut = new SqlCommand("DELETE  FROM filmler WHERE film_id="+filmnotext.Text,bagla);
                komut.ExecuteNonQuery();

                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from filmler", bagla);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "filmler");
                FilmDataGrid.DataSource = dtSet.Tables["filmler"];
               
                bagla.Close();
                MessageBox.Show(filmtext.Text + " filmi silindi. ");
                filmtext.Text = "";
                yonetmentext.Text = "";
                turtext.Text = "";
            }
            else
            {
                MessageBox.Show("film id boş");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Close();
        }

        private void SatisSilButton_Click(object sender, EventArgs e)
        {
                baglan();
            if (SatisIdtext.Text != "")
            {
                SqlCommand komut = new SqlCommand("DELETE  FROM satilanbilet WHERE satis_id=" + SatisIdtext.Text, bagla);
                komut.ExecuteNonQuery();

                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from satilanbilet ", bagla);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "satis_id");
                MusteriDataGrid.DataSource = dtSet.Tables["satis_id"];
                
                bagla.Close();
                MessageBox.Show(SatisIdtext.Text + " kişi silindi silindi. ");
                SatisIdtext.Text = "";
               
            }
            else
            {
                MessageBox.Show("SatışID boş");
            }

        }

        private void CalisanEklebutton_Click(object sender, EventArgs e)
        {
            baglan();
            SqlCommand komut = new SqlCommand("INSERT INTO calisan(adi,parola,yetki)VALUES('" + adtextBox.Text + "','" + parolaText.Text + "','" + comboYetki.Text+"')",bagla);
            komut.ExecuteNonQuery();
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT * FROM calisan", bagla);
            DataSet dtSet = new DataSet();//kişi kaydı eklendiğinde datagrid panelini güncellemek için 
            dtAdapter.Fill(dtSet, "calisan");
            CalisandataGrid.DataSource = dtSet.Tables["calisan"];
            bagla.Dispose();
            bagla.Close();
            MessageBox.Show("kayıt eklenmiştir");
            adtextBox.Text = ""; parolaText.Text = ""; comboYetki.Text = "";
        }

        private void CalisanKaldirButton_Click(object sender, EventArgs e)
        {
            baglan();
            SqlCommand komut = new SqlCommand("DELETE FROM calisan WHERE id = "+kaldirText.Text,bagla);
            komut.ExecuteNonQuery();
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT * FROM calisan", bagla);
            DataSet dtSet = new DataSet();//kişi kaydı eklendiğinde datagrid panelini güncellemek için 
            dtAdapter.Fill(dtSet, "calisan");
            CalisandataGrid.DataSource = dtSet.Tables["calisan"];
            bagla.Dispose();
            bagla.Close();
            MessageBox.Show("kayıt silinmiştir");
            kaldirText.Text = "";

        }

        private void saloneklebutton_Click(object sender, EventArgs e)
        {
            salonekle git = new salonekle();
            git.Show();
            this.Close();
        }



    }
}
