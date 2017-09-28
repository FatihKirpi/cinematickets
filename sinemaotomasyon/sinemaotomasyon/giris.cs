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
    public partial class giris : Form
    {
        public giris()
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

        private void girisbutton_Click(object sender, EventArgs e)
        {
            baglan();
            Form1 ac = new Form1();
            SqlCommand komut = new SqlCommand("SELECT * FROM calisan WHERE adi='" + calisantext.Text + "' and parola='" + parolatext.Text + "'and yetki='"+comboBox1.Text + "'", bagla);
            SqlDataReader oku = komut.ExecuteReader();
                     
            if (oku.Read())
            {
                
                ac.kullanici_adi = calisantext.Text;
                ac.yetki = comboBox1.Text;
                bagla.Close();
                ac.Show(); 
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE YANLIŞ");
                calisantext.Text = ""; parolatext.Text = "";
            }
        }
    }
}
