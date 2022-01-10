using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulAppSube2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OgrenciBL obl = new OgrenciBL();  

            MessageBox.Show(obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text, Soyad = txtSoyad.Text, Numara = txtNumara.Text, Sinifid = (int)cmbSiniflar.SelectedValue, Tckimlik = txtTcKimlik.Text })?"Ekleme Başarılı":"Ekleme Başarısız");
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
                if (cn != null)
                {
                    cn.Open();
                }
                SqlCommand cmd = new SqlCommand($"Select * from tblOgrenciler Where Numara={txtBul.Text}", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtAd.Text = dr["Ad"].ToString();
                    txtSoyad.Text = dr["Soyad"].ToString();
                    txtNumara.Text = dr["Numara"].ToString();
                    // txtSinifId.Text = dr["SinifId"].ToString();
                    txtTcKimlik.Text = dr["TcKimlik"].ToString();
                }
                dr.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)//Null Check
                {
                    cn.Close();
                }
            }
        }
        //Garbage Collector
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString))
                {
                    if (cn != null)
                    {
                        cn.Open();
                    }
                    SqlCommand cmd = new SqlCommand($"Select SinifId,SinifAd,Kontenjan from tblSiniflar ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    List<Sinif> siniflar = new List<Sinif>();


                    ; while (dr.Read())
                    {
                        siniflar.Add(new Sinif { Kontenjan = Convert.ToInt32(dr["Kontenjan"]), Sinifad = dr["SinifAd"].ToString(), Sinifid = Convert.ToInt32(dr["SinifId"]) });
                    }
                    dr.Close();
                    cmbSiniflar.DisplayMember = "Sinifad";
                    cmbSiniflar.ValueMember = "Sinifid";
                    cmbSiniflar.DataSource = siniflar;
                }





            }
            catch (Exception)
            {

            }
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)//Null Check
                {
                    cn.Close();
                    cn.Dispose();
                }
            }

        }
    }
}
//DRY: Don't Repeat Yourself