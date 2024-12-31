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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Petrol_Ofisi1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=LAPTOP-34D9I3MG\\SQLEXPRESS;Initial Catalog=Benzin_istasyonu;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection baglanti_1 = new SqlConnection(conString);
        DataTable Tablo = new DataTable();

        private void listele()
        {
            if (baglanti_1.State == ConnectionState.Closed)

                baglanti_1.Open();
            SqlCommand komut = new SqlCommand("Select *From Yakit_Bilgi", baglanti_1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox_YakitTipi.Items.Add(dr[0].ToString());

            }

            baglanti_1.Close();

        }

        private void listele_2()
        {
            if (baglanti_1.State == ConnectionState.Closed)

                baglanti_1.Open();
            SqlCommand komut_2 = new SqlCommand("Select *From Personel_Bilgi", baglanti_1);
            SqlDataReader dr_2 = komut_2.ExecuteReader();
            while (dr_2.Read())
            {
                comboBox_Kullanıcı.Items.Add(dr_2["Personel_AdiSoyadi"].ToString());

            }

            baglanti_1.Close();

        }

        private void listele_3()
        {
            if (baglanti_1.State == ConnectionState.Closed)

                baglanti_1.Open();
            for (int i = 1; i < 6; i++)
            {
                combobox_PompaNumarası.Items.Add(i);
            }
            baglanti_1.Close();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

            listele();
            listele_2();
            listele_3();

        }

        private void button_PompaUyg_Click(object sender, EventArgs e)
        {

            //---------------------------Araç Plakası Kayıt Etme PlakaTextBox-----------------------------------------------
            try
            {
                if (baglanti_1.State == ConnectionState.Closed)

                    baglanti_1.Open();

                string kayit = "insert into Yakit_Satis(Arac_Plakasi) values(@Arac_Plakasi)";

                SqlCommand komut = new SqlCommand(kayit, baglanti_1);

                komut.Parameters.AddWithValue("@Arac_Plakasi", textBox_AracPlakasi.Text);

                komut.ExecuteNonQuery();


                baglanti_1.Close();

                MessageBox.Show("Kayıt Eklendi!");

                comboBox_YakitTipi.SelectedIndex = -1;
                comboBox_Kullanıcı.SelectedIndex = -1;
                textBox_AracPlakasi.Text = "";


            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi: " + hata.Message);
            }
            //==========================================================================================================

            //--------------------------------- Verilen Yakıt Litresini Tabloya Kayıt Etme LitreTextBox-----------------------------
            try
            {
                if (baglanti_1.State == ConnectionState.Closed)

                    baglanti_1.Open();

                string kayit_3 = "insert into Yakit_Satis(Verilen_YakitLitresi) values(@Verilen_YakitLitresi)";
                SqlCommand komut_3 = new SqlCommand(kayit_3, baglanti_1);
                komut_3.Parameters.AddWithValue("@Verilen_YakitLitresi", textBox_Litre.Text);
                komut_3.ExecuteNonQuery();
                baglanti_1.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi: " + hata.Message);
            }
            textBox_Litre.Text = "";
            //============================================================================================================
        }
        //------------------Temizle Butonu-----------------------------------------------------

            //==================================================================================================
        }
    

}

