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


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-N9LKLML\\SQLEXPRESS;Initial Catalog=personel11;Integrated Security=True";
        SqlConnection Connect = new SqlConnection(constring);

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personel11DataSet.bilgiler11' table. You can move, or remove it, as needed.
            this.bilgiler11TableAdapter.Fill(this.personel11DataSet.bilgiler11);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connect.State == ConnectionState.Closed)
                {
                    Connect.Open();
                    string kayitekle = "insert into bilgiler11(adi, soyadi) values (@kisi_adi,@kisi_soyadi)";
                    SqlCommand komut = new SqlCommand(kayitekle, Connect);
                    komut.Parameters.AddWithValue("@kisi_adi", textBox1.Text);
                    komut.Parameters.AddWithValue("@kisi_soyadi", textBox2.Text);

                    komut.ExecuteNonQuery();
                    Connect.Close();
                    MessageBox.Show("işlem yapıldı");
                }



            }
            catch (Exception uyari)
            {
                MessageBox.Show("uyarınız var" + uyari);

                throw;
            }
        }
    }
}
