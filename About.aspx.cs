using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;
using Microsoft.Win32;
//using System.Windows.Forms.OpenFileDialog

namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
               using (SqlCommand cmd = new SqlCommand("INSERT INTO sTable(Name_Description, Price, Image) values (@Name_Description, @Price, @Image)",cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name_Description", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Price", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Image", Image1.ImageUrl);
                    cmd.ExecuteNonQuery();
                    
                }
            }
        
        }
        public void LoadData()
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
               using(DataTable dt = new DataTable("sTable"))
                {
                    SqlDataAdapter adaptater = new SqlDataAdapter("select *from sTable", cnn);
                    adaptater.Fill(dt);
                    GridView1.DataSource = dt;
                }
            }
        }
        byte [] ConvertImageToBytes(Image img)
       {
           using (MemoryStream sn = new MemoryStream())
          {
                img.Save(sn, System.Drawing.Imaging.ImageFormat.Png);
               return sn.ToArray();
           }
       }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using(MemoryStream sn = new MemoryStream(data))
            {
                return Image.FromStream(sn);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
          //  using(OpenFileDialog file = new OpenFileDialog())
        Image1.ImageUrl = TextBox3.Text;
         
          LoadData();
         //   Image1.ImageUrl =Image.FromStream(OpenFile.)
        }

    }
}