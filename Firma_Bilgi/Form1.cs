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
using System.IO;
using System.Drawing.Printing;
using System.Threading;


namespace Firma_Bilgi
{
    struct ss_general
    {
        public int aa00_int_id;
        public string aa01_str_category;
        public string aa02_str_manufacturer;
        public string aa03_str_type;
        public string aa04_str_origin;
        public string aa05_str_model;
        public string aa06_str_order_no;
        public string aa07_str_donat_no;
        public string aa08_str_photo;
    }

    struct ss_spare
    {
        public int aa00_int_id;
        public string aa01_str_offer_no;
        public string aa02_str_customer;
        public string aa03_str_manufacturer;
        public string aa04_str_description;
        public string aa05_str_comment;
        public string aa06_str_vin;
        public string aa07_str_colour;
        public string aa08_str_country;
        public string aa09_str_model;
        public string aa10_str_photo;
        public string aa11_str_photo2;
        public string aa12_str_photo3;
        public string aa13_str_photo4;
        public string aa14_str_photo5;
        public string aa15_str_photo6;

    }

   

    public partial class Form1 : Form
    {
       string vv01_str_veritabani_yolu = @"Data Source=DESKTOP-E73DNUQ;Initial Catalog=vtb_01_firma;Integrated Security=True";
        string vv02_str_komut_yazisi = "";
        SqlConnection vv03_con_baglanti1;
        SqlCommand vv04_cmd_komut1;
        SqlDataReader vv05_rdr_okuyucu1;
        SqlDataAdapter vv06_adp_adaptor1;
        DataTable vv07_tbl_tablo1;





        int ii01_id_tutucu = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            mm01_genel_tablo_doldur();
            mm02_spare_tablo_doldur();
           
        }

        // Genel Tablo doldurma
        private void mm01_genel_tablo_doldur()
        {
            vv02_str_komut_yazisi = "select " +
             "tbl_00_id AS[İD], " +
             "tbl_01_category  AS[Category], " +
             "tbl_02_manufacturer  AS[Manufacturer], " +
             "tbl_03_type  AS[Type], " +
             "tbl_04_origin  AS[Origin]," +
             "tbl_05_model  AS[Model]," +
             "tbl_06_order_no  AS[Order No]," +
             "tbl_07_donat_no  AS[Donat No]," +
             "tbl_08_photo  AS[Photo]" +
             "from tbl_00_general_data " +
             "order by tbl_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);
            dataGridView1.DataSource = vv07_tbl_tablo1;
           
            //dataGridView1.Columns[8].Visible=false;

        }

        //Spare tablo doldur
        private void mm02_spare_tablo_doldur()
        {
            vv02_str_komut_yazisi = "select " +
             "tbl_00_id AS[İD], " +
             "tbl_01_offer_no  AS[Offer No], " +
             "tbl_02_customer  AS[Customer], " +
             "tbl_03_manufacturer  AS[Manufacturer], " +
             "tbl_04_description  AS[Description]," +
             "tbl_05_comment  AS[Comment]," +
             "tbl_06_vin  AS[Vin]," +
             "tbl_07_colour  AS[Colour]," +
             "tbl_08_country  AS[Country]," +
             "tbl_09_model  AS[Model]," +
             "tbl_10_photo  AS[Photo 1]," +
             "tbl_11_photo2  AS[Photo 2]," +
             "tbl_12_photo3  AS[Photo 3]," +
             "tbl_13_photo4  AS[Photo 4]," +
             "tbl_14_photo5  AS[Photo 5]," +
            "tbl_15_photo6  AS[Photo 6]" +
             "from tbl_01_spare_parts " +
             "order by tbl_00_id ";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);
            dataGridView2.DataSource = vv07_tbl_tablo1;
            dataGridView2.Columns[10].Visible=false;
            dataGridView2.Columns[11].Visible=false;
            dataGridView2.Columns[12].Visible=false;
            dataGridView2.Columns[13].Visible=false;
            dataGridView2.Columns[14].Visible=false;
            dataGridView2.Columns[15].Visible=false;        

        }

        

        //Kaydet
        private void button1_Click(object sender, EventArgs e)
        {
            ss_general aa01 = new ss_general();
            aa01.aa01_str_category =textBox1.Text;
            aa01.aa02_str_manufacturer =textBox2.Text;
            aa01.aa03_str_type = textBox3.Text;
            aa01.aa04_str_origin = textBox4.Text;
            aa01.aa05_str_model =textBox5.Text;
            aa01.aa06_str_order_no =textBox6.Text;
            aa01.aa07_str_donat_no =textBox7.Text;
            aa01.aa08_str_photo =textBox8.Text;

            vv02_str_komut_yazisi = "insert into tbl_00_general_data" +
                "(" +

              "tbl_01_category , " +
            "tbl_02_manufacturer  , " +
            "tbl_03_type  , " +
            "tbl_04_origin ," +
            "tbl_05_model  ," +
            "tbl_06_order_no ," +
            "tbl_07_donat_no ," +
            "tbl_08_photo  )" +

             " values(" +

             "@tbl_01_category , " +
            "@tbl_02_manufacturer  , " +
            "@tbl_03_type  , " +
            "@tbl_04_origin ," +
            "@tbl_05_model  ," +
            "@tbl_06_order_no ," +
            "@tbl_07_donat_no ," +
            "@tbl_08_photo  )";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_01_category", aa01.aa01_str_category);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_02_manufacturer", aa01.aa02_str_manufacturer);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_03_type", aa01.aa03_str_type);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_04_origin", aa01.aa04_str_origin);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_05_model", aa01.aa05_str_model);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_06_order_no", aa01.aa06_str_order_no);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_07_donat_no", aa01.aa07_str_donat_no);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_08_photo", aa01.aa08_str_photo);


            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();

            vv03_con_baglanti1.Close();


            mm01_genel_tablo_doldur();
        }

        //düzenle
        private void button2_Click(object sender, EventArgs e)
        {
            ss_general aa01 = new ss_general();
            aa01.aa01_str_category =textBox1.Text;
            aa01.aa02_str_manufacturer =textBox2.Text;
            aa01.aa03_str_type = textBox3.Text;
            aa01.aa04_str_origin = textBox4.Text;
            aa01.aa05_str_model =textBox5.Text;
            aa01.aa06_str_order_no =textBox6.Text;
            aa01.aa07_str_donat_no =textBox7.Text;
            aa01.aa08_str_photo =textBox8.Text;

            vv02_str_komut_yazisi = "update tbl_00_general_data set "+

             "tbl_01_category=@tbl_01_category, " +
             "tbl_02_manufacturer=@tbl_02_manufacturer, " +
             "tbl_03_type=@tbl_03_type, " +
             "tbl_04_origin=@tbl_04_origin ," +
             "tbl_05_model=@tbl_05_model ," +
             "tbl_06_order_no=@tbl_06_order_no ," +
             "tbl_07_donat_no=@tbl_07_donat_no ," +
             "tbl_08_photo=@tbl_08_photo "+
             " where tbl_00_id=@tbl_00_id";


            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_01_category", aa01.aa01_str_category);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_02_manufacturer", aa01.aa02_str_manufacturer);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_03_type", aa01.aa03_str_type);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_04_origin", aa01.aa04_str_origin);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_05_model", aa01.aa05_str_model);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_06_order_no", aa01.aa06_str_order_no);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_07_donat_no", aa01.aa07_str_donat_no);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_08_photo", aa01.aa08_str_photo);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_00_id", ii01_id_tutucu);

            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();

            vv03_con_baglanti1.Close();

            mm01_genel_tablo_doldur();
        }

        //sil
        private void button3_Click(object sender, EventArgs e)
        {
            vv02_str_komut_yazisi = "delete from tbl_00_general_data  " +
           " where tbl_00_id=@tbl_00_id";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_00_id", ii01_id_tutucu);
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();

            vv03_con_baglanti1.Close();

            mm01_genel_tablo_doldur();
        }

        //yazdır
        private void button6_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument belge = new System.Drawing.Printing.PrintDocument();
            belge.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(ppyazdır_PrintPage);
            ppdialog.ShowDialog();
            belge.Print();
        }
        private void ppyazdır_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmap = new Bitmap(tabPage1.Width, tabPage1.Height);
            tabPage1.DrawToBitmap(bmap, new Rectangle(0, 0, tabPage1.Width, tabPage1.Height));
            RectangleF bounds1 = e.PageSettings.PrintableArea;
            float factor1 = ((float)bmap.Height/ (float)bmap.Width);
            e.Graphics.DrawImage(bmap, bounds1.Left, bounds1.Top, bounds1.Width, factor1 * bounds1.Width);
        }

        //arama yapma
        private void button7_Click(object sender, EventArgs e)
        {
            string vin_ara = textBox9.Text;

            vv02_str_komut_yazisi=  "select " +
             "tbl_00_id AS[İD], " +
             "tbl_01_offer_no  AS[Offer No], " +
             "tbl_02_customer  AS[Customer], " +
             "tbl_03_manufacturer  AS[Manufacturer], " +
             "tbl_04_description  AS[Description]," +
             "tbl_05_comment  AS[Comment]," +
             "tbl_06_vin  AS[Vin]," +
             "tbl_07_colour  AS[Colour]," +
             "tbl_08_country  AS[Country]," +
             "tbl_09_model  AS[Model]," +
            "tbl_10_photo  AS[Photo]" +
            "  from tbl_01_spare_parts" +
           " where tbl_06_vin like'%" + vin_ara + "%' " +
           " order by tbl_00_id ";



            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_06_vin", vin_ara);


            vv06_adp_adaptor1 = new SqlDataAdapter(vv04_cmd_komut1);
            vv07_tbl_tablo1 = new DataTable();
            vv06_adp_adaptor1.Fill(vv07_tbl_tablo1);
            dataGridView1.DataSource = vv07_tbl_tablo1;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation=openFileDialog1.FileName;
            textBox8.Text=openFileDialog1.FileName;

        }

        //Genel datagridde seçili satırı textlere doldurma
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            ii01_id_tutucu = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString());
            ss_general aa01 = new ss_general();
            aa01.aa01_str_category=dataGridView1[1, e.RowIndex].Value.ToString();
            aa01.aa02_str_manufacturer = dataGridView1[2, e.RowIndex].Value.ToString();
            aa01.aa03_str_type = dataGridView1[3, e.RowIndex].Value.ToString();
            aa01.aa04_str_origin = dataGridView1[4, e.RowIndex].Value.ToString();
            aa01.aa05_str_model = dataGridView1[5, e.RowIndex].Value.ToString();
            aa01.aa06_str_order_no = dataGridView1[6, e.RowIndex].Value.ToString();
            aa01.aa07_str_donat_no = dataGridView1[7, e.RowIndex].Value.ToString();
            aa01.aa08_str_photo =dataGridView1[8, e.RowIndex].Value.ToString();
            pictureBox1.ImageLocation=dataGridView1[8, e.RowIndex].Value.ToString();
          // Image.FromFile(pictureBox1.ImageLocation=dataGridView1[8,e.RowIndex].Value.ToString());

            textBox1.Text=aa01.aa01_str_category;
            textBox2.Text=aa01.aa02_str_manufacturer;
            textBox3.Text=aa01.aa03_str_type;
            textBox4.Text=aa01.aa04_str_origin;
            textBox5.Text=aa01.aa05_str_model;
            textBox6.Text=aa01.aa06_str_order_no;
            textBox7.Text=aa01.aa07_str_donat_no;
            textBox8.Text=aa01.aa08_str_photo;

        }

        //VIN kayıt tekrarı önleme
        public int VarMi(string aranan)
        {

            int sonuc;
            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            string vv02_str_komut_yazisi = "Select COUNT(tbl_06_vin) from tbl_01_spare_parts WHERE tbl_06_vin='"+aranan+"'";
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv03_con_baglanti1.Open();

            sonuc=Convert.ToInt32(vv04_cmd_komut1.ExecuteScalar());

            vv03_con_baglanti1.Close();
            return sonuc;

        }
        //Spare kaydet
        private void button4_Click(object sender, EventArgs e)
        {
            ss_spare aa01 = new ss_spare();
            aa01.aa01_str_offer_no =textBox10.Text;
            aa01.aa02_str_customer =textBox11.Text;
            aa01.aa03_str_manufacturer = textBox12.Text;
            aa01.aa04_str_description = textBox13.Text;
            aa01.aa05_str_comment =textBox14.Text;
            aa01.aa06_str_vin =textBox15.Text;
            aa01.aa07_str_colour =textBox16.Text;
            aa01.aa08_str_country =textBox17.Text;
            aa01.aa09_str_model =textBox18.Text;
            aa01.aa10_str_photo =textBox19.Text;
            aa01.aa11_str_photo2 =textBox20.Text;
            aa01.aa12_str_photo3 =textBox21.Text;
            aa01.aa13_str_photo4 =textBox22.Text;
            aa01.aa14_str_photo5 =textBox23.Text;
            aa01.aa15_str_photo6 =textBox24.Text;

            if (VarMi(textBox15.Text) != 0)
            {
                MessageBox.Show("Bu VIN ile daha önce kayıt yapılmış");
            }
            else
            {
                vv02_str_komut_yazisi = "insert into tbl_01_spare_parts" +
                    "(" +

                  "tbl_01_offer_no , " +
                "tbl_02_customer  , " +
                "tbl_03_manufacturer  , " +
                "tbl_04_description ," +
                "tbl_05_comment  ," +
                "tbl_06_vin ," +
                "tbl_07_colour ," +
                "tbl_08_country ," +
                "tbl_09_model ," +
                "tbl_10_photo ," +
                "tbl_11_photo2 ," +
                "tbl_12_photo3 ," +
                "tbl_13_photo4 ," +
                "tbl_14_photo5 ," +
                "tbl_15_photo6  )" +

                 " values(" +

                "@tbl_01_offer_no , " +
                "@tbl_02_customer  , " +
                "@tbl_03_manufacturer  , " +
                "@tbl_04_description ," +
                "@tbl_05_comment  ," +
                "@tbl_06_vin ," +
                "@tbl_07_colour ," +
                "@tbl_08_country ," +
                "@tbl_09_model ,"+
                "@tbl_11_photo2 ," +
                "@tbl_12_photo3 ," +
                "@tbl_13_photo4 ," +
                "@tbl_14_photo5 ," +
                "@tbl_15_photo6 )";

                vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
                vv03_con_baglanti1.Open();
                vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_01_offer_no", aa01.aa01_str_offer_no);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_02_customer", aa01.aa02_str_customer);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_03_manufacturer", aa01.aa03_str_manufacturer);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_04_description", aa01.aa04_str_description);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_05_comment", aa01.aa05_str_comment);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_06_vin", aa01.aa06_str_vin);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_07_colour", aa01.aa07_str_colour);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_08_country", aa01.aa08_str_country);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_09_model", aa01.aa09_str_model);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_10_photo", aa01.aa10_str_photo);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_11_photo2", aa01.aa11_str_photo2);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_12_photo3", aa01.aa12_str_photo3);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_13_photo4", aa01.aa13_str_photo4);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_14_photo5", aa01.aa14_str_photo5);
                vv04_cmd_komut1.Parameters.AddWithValue("@tbl_15_photo6", aa01.aa15_str_photo6);


                vv04_cmd_komut1.ExecuteNonQuery();
                vv04_cmd_komut1.Dispose();

                vv03_con_baglanti1.Close();

            }
            mm02_spare_tablo_doldur();
        }

        //Spare düzenle
        private void button8_Click(object sender, EventArgs e)
        {

            ss_spare aa01 = new ss_spare();
            aa01.aa01_str_offer_no =textBox10.Text;
            aa01.aa02_str_customer =textBox11.Text;
            aa01.aa03_str_manufacturer = textBox12.Text;
            aa01.aa04_str_description = textBox13.Text;
            aa01.aa05_str_comment =textBox14.Text;
            aa01.aa06_str_vin =textBox15.Text;
            aa01.aa07_str_colour =textBox16.Text;
            aa01.aa08_str_country =textBox17.Text;
            aa01.aa09_str_model =textBox18.Text;
            aa01.aa10_str_photo =textBox19.Text;
            aa01.aa11_str_photo2 =textBox20.Text;
            aa01.aa12_str_photo3 =textBox21.Text;
            aa01.aa13_str_photo4 =textBox22.Text;
            aa01.aa14_str_photo5 =textBox23.Text;
            aa01.aa15_str_photo6 =textBox24.Text;

            vv02_str_komut_yazisi = "update tbl_01_spare_parts set "+

             "tbl_01_offer_no=@tbl_01_offer_no, " +
             "tbl_02_customer=@tbl_02_customer, " +
             "tbl_03_manufacturer=@tbl_03_manufacturer, " +
             "tbl_04_description=@tbl_04_description ," +
             "tbl_05_comment=@tbl_05_comment ," +
             "tbl_06_vin=@tbl_06_vin ," +
             "tbl_07_colour=@tbl_07_colour ," +
             "tbl_08_country=@tbl_08_country ," +
             "tbl_09_model=@tbl_09_model ," +
             "tbl_10_photo=@tbl_10_photo,"+
             "tbl_11_photo2=@tbl_11_photo2 ," +
             "tbl_12_photo3=@tbl_12_photo3 ," +
             "tbl_13_photo4=@tbl_13_photo4 ," +
             "tbl_14_photo5=@tbl_14_photo5 ," +
             "tbl_15_photo6=@tbl_15_photo6"+
             " where tbl_00_id=@tbl_00_id";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_01_offer_no", aa01.aa01_str_offer_no);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_02_customer", aa01.aa02_str_customer);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_03_manufacturer", aa01.aa03_str_manufacturer);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_04_description", aa01.aa04_str_description);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_05_comment", aa01.aa05_str_comment);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_06_vin", aa01.aa06_str_vin);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_07_colour", aa01.aa07_str_colour);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_08_country", aa01.aa08_str_country);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_09_model", aa01.aa09_str_model);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_10_photo", aa01.aa10_str_photo);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_11_photo2", aa01.aa11_str_photo2);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_12_photo3", aa01.aa12_str_photo3);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_13_photo4", aa01.aa13_str_photo4);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_14_photo5", aa01.aa14_str_photo5);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_15_photo6", aa01.aa15_str_photo6);
            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_00_id", ii01_id_tutucu);

            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();

            vv03_con_baglanti1.Close();

            mm02_spare_tablo_doldur();
        }

        //Spare sil
        private void button9_Click(object sender, EventArgs e)
        {
            vv02_str_komut_yazisi = "delete from tbl_01_spare_parts  " +
          " where tbl_00_id=@tbl_00_id";

            vv03_con_baglanti1 = new SqlConnection(vv01_str_veritabani_yolu);
            vv03_con_baglanti1.Open();
            vv04_cmd_komut1 = new SqlCommand(vv02_str_komut_yazisi, vv03_con_baglanti1);

            vv04_cmd_komut1.Parameters.AddWithValue("@tbl_00_id", ii01_id_tutucu);
            vv04_cmd_komut1.ExecuteNonQuery();
            vv04_cmd_komut1.Dispose();

            vv03_con_baglanti1.Close();

            mm02_spare_tablo_doldur();
        }

        //spare datagridde seçili satırı textlere doldurma
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ii01_id_tutucu = Convert.ToInt32(dataGridView2[0, e.RowIndex].Value.ToString());
            ss_spare aa01 = new ss_spare();
            aa01.aa01_str_offer_no=dataGridView2[1, e.RowIndex].Value.ToString();
            aa01.aa02_str_customer = dataGridView2[2, e.RowIndex].Value.ToString();
            aa01.aa03_str_manufacturer = dataGridView2[3, e.RowIndex].Value.ToString();
            aa01.aa04_str_description = dataGridView2[4, e.RowIndex].Value.ToString();
            aa01.aa05_str_comment = dataGridView2[5, e.RowIndex].Value.ToString();
            aa01.aa06_str_vin = dataGridView2[6, e.RowIndex].Value.ToString();
            aa01.aa07_str_colour = dataGridView2[7, e.RowIndex].Value.ToString();
            aa01.aa08_str_country = dataGridView2[8, e.RowIndex].Value.ToString();
            aa01.aa09_str_model = dataGridView2[9, e.RowIndex].Value.ToString();
            aa01.aa10_str_photo = dataGridView2[10, e.RowIndex].Value.ToString();
            aa01.aa11_str_photo2 = dataGridView2[11, e.RowIndex].Value.ToString();
            aa01.aa12_str_photo3 = dataGridView2[12, e.RowIndex].Value.ToString();
            aa01.aa13_str_photo4 = dataGridView2[13, e.RowIndex].Value.ToString();
            aa01.aa14_str_photo5 = dataGridView2[14, e.RowIndex].Value.ToString();
            aa01.aa15_str_photo6 = dataGridView2[15, e.RowIndex].Value.ToString();
            pictureBox2.ImageLocation=dataGridView2[10, e.RowIndex].Value.ToString();
            pictureBox3.ImageLocation=dataGridView2[11, e.RowIndex].Value.ToString();
            pictureBox4.ImageLocation=dataGridView2[12, e.RowIndex].Value.ToString();
            pictureBox5.ImageLocation=dataGridView2[13, e.RowIndex].Value.ToString();
            pictureBox6.ImageLocation=dataGridView2[14, e.RowIndex].Value.ToString();
            pictureBox7.ImageLocation=dataGridView2[15, e.RowIndex].Value.ToString();


            textBox10.Text=aa01.aa01_str_offer_no;
            textBox11.Text=aa01.aa02_str_customer;
            textBox12.Text=aa01.aa03_str_manufacturer;
            textBox13.Text=aa01.aa04_str_description;
            textBox14.Text=aa01.aa05_str_comment;
            textBox15.Text=aa01.aa06_str_vin;
            textBox16.Text=aa01.aa07_str_colour;
            textBox17.Text=aa01.aa08_str_country;
            textBox18.Text=aa01.aa09_str_model;
            textBox19.Text=aa01.aa10_str_photo;
            textBox20.Text=aa01.aa11_str_photo2;
            textBox21.Text=aa01.aa12_str_photo3;
            textBox22.Text=aa01.aa13_str_photo4;
            textBox23.Text=aa01.aa14_str_photo5;
            textBox24.Text=aa01.aa15_str_photo6;

        }

        //foto ekleme
        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation=openFileDialog1.FileName;
            textBox19.Text=openFileDialog1.FileName;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox3.ImageLocation=openFileDialog1.FileName;
            textBox20.Text=openFileDialog1.FileName;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox4.ImageLocation=openFileDialog1.FileName;
            textBox21.Text=openFileDialog1.FileName;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox5.ImageLocation=openFileDialog1.FileName;
            textBox22.Text=openFileDialog1.FileName;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox6.ImageLocation=openFileDialog1.FileName;
            textBox23.Text=openFileDialog1.FileName;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox7.ImageLocation=openFileDialog1.FileName;
            textBox24.Text=openFileDialog1.FileName;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            
            System.Drawing.Printing.PrintDocument belge2 = new System.Drawing.Printing.PrintDocument();
            belge2.PrintPage+=new System.Drawing.Printing.PrintPageEventHandler(ppyazdır2_PrintPage);
            ppdialog2.ShowDialog();
            belge2.Print();
        }



        private void ppyazdır2_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmap2 = new Bitmap(tabPage2.Width, tabPage2.Height);
            tabPage2.DrawToBitmap(bmap2, new Rectangle(0, 0, tabPage2.Width, tabPage2.Height));
            RectangleF bounds2 = e.PageSettings.PrintableArea;
            float factor2 = ((float)bmap2.Height/(float)bmap2.Width);
            e.Graphics.DrawImage(bmap2, bounds2.Left, bounds2.Top, bounds2.Width, factor2*bounds2.Width);


        }

       
    }
    }

