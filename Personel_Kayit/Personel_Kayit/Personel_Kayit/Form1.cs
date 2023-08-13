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


namespace Personel_Kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=WINDOWS-0FIAKIQ\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void Temizle()
        {
            txtPersonelid.Text = "";
            txtPersonelAd.Text = "";
            txtPersonelSoyad.Text = "";
            TxtPersonelMeslek.Text = "";
            mskttxtPersonelMaas.Text = "";
            cmbxPersonelSehir.Text = "";
            rdBekar.Checked = false;
            rdEvli.Checked = false;
            txtPersonelAd.Focus();

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd, PerSoyad, PerSehir, PerMaas, PerMeslek, PerDurum) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtPersonelAd.Text);
            komut.Parameters.AddWithValue("@p2", txtPersonelSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbxPersonelSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskttxtPersonelMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtPersonelMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklendi.");
        }

        private void rdEvli_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rdEvli.Checked == true)
            {
               label8.Text="True";
            }
        }

        private void rdBekar_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdBekar.Checked == true)
            {
                label8.Text = "False";
                
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            // böylece data gridde herhangi bir hücreye tıklayınca secilen adlı bir değişkene atamış olduk
            txtPersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtPersonelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPersonelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbxPersonelSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskttxtPersonelMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtPersonelMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            
           

            // bu kodlarla mesela personel id sini datagridview den bir satıra tıklayınca secilen değişkenindeki degere referans alıp oradaki 0 numaralı hücrenin içindeki degeri personelid adlı değişkene taşı demiş olduk.
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                rdEvli.Checked = true;
            }
            if (label8.Text == "False")
            {
                rdBekar.Checked = true;
            }
        }
    }
}
