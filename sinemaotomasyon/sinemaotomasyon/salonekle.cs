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
    public partial class salonekle : Form
    {
        public salonekle()
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
        void grid_vericek(string sql, DataGridView gridview) //datagridview e databasedeki bilgiler gelecek
        {
            baglan();
            SqlCommand komut = new SqlCommand(sql, bagla);
            DataTable taplo = new DataTable();
            taplo.Load(komut.ExecuteReader());
            gridview.DataSource = taplo;
            bagla.Close();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void salonekle_Load(object sender, EventArgs e)
        {
            grid_vericek("SELECT*FROM saat",SaatdataGrid);
            grid_vericek("SELECT*FROM salon", SalonDataGrid);
        }

        private void Eklebutton_Click(object sender, EventArgs e)
        {
            baglan();
            SqlCommand komut = new SqlCommand("INSERT INTO salon(salon_adi,koltuk_sayisi) VALUES('" + salontext.Text + "','" + koltuktext.Text + "')", bagla);
            komut.ExecuteNonQuery();
            //datagrid i kayıt ekledikten sonra yenilemek için
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from salon", bagla);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "salon");
            SalonDataGrid.DataSource = dtSet.Tables["salon"];


            bagla.Close();
            MessageBox.Show(salontext.Text + "/" + koltuktext.Text + " salon eklendi. ");
            salontext.Text = "";
            koltuktext.Text = "";
            
        }

        private void saateklebutton_Click(object sender, EventArgs e)
        {
            baglan();
            SqlCommand komut = new SqlCommand("INSERT INTO saat(saatler,) VALUES('" + saattext.Text +"')", bagla);
            komut.ExecuteNonQuery();
            //datagrid i kayıt ekledikten sonra yenilemek için
            SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from saat", bagla);
            DataSet dtSet = new DataSet();
            dtAdapter.Fill(dtSet, "saat");
            SaatdataGrid.DataSource = dtSet.Tables["saat"];


            bagla.Close();
            MessageBox.Show(saattext.Text +  " saat eklendi. ");
            saattext.Text = "";
           
        }

        private void salonkaldir_Click(object sender, EventArgs e)
        {
            if (salonnotext.Text != "")
            {
                baglan();
                SqlCommand komut = new SqlCommand("DELETE  FROM filmler WHERE salon_ıd=" + salonnotext.Text, bagla);
                komut.ExecuteNonQuery();

                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from salon", bagla);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "salon");
                SalonDataGrid.DataSource = dtSet.Tables["salon"];

                bagla.Close();
                MessageBox.Show(salonnotext.Text + " filmi silindi. ");
                salonnotext.Text = "";
                
            }
            else
            {
                MessageBox.Show("salon id boş");
            }
        }

        private void saatkaldir_Click(object sender, EventArgs e)
        {
            if (saatnotext.Text != "")
            {
                baglan();
                SqlCommand komut = new SqlCommand("DELETE  FROM filmler WHERE film_id=" + saatnotext.Text, bagla);
                komut.ExecuteNonQuery();

                SqlDataAdapter dtAdapter = new SqlDataAdapter("select * from saat", bagla);
                DataSet dtSet = new DataSet();
                dtAdapter.Fill(dtSet, "saat");
                SaatdataGrid.DataSource = dtSet.Tables["saat"];

                bagla.Close();
                MessageBox.Show(saatnotext.Text + " saat silindi. ");
                saatnotext.Text = "";
                
            }
            else
            {
                MessageBox.Show("saat id boş");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yönetici_panel git = new yönetici_panel();
            git.Show();
            this.Close();
        }

    }
}
