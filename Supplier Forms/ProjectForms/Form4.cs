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

namespace ProjectForms
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Supplier where idSupplier = @id", con);
            SqlDataReader dbr;

            cmd.Parameters.AddWithValue("@id", Form2.ID);

            dbr = cmd.ExecuteReader();

            while (dbr.Read())
            {
                textBox1.Text = dbr.GetString(2);
                textBox2.Text = dbr.GetString(3);
                textBox3.Text = dbr.GetString(4);
                textBox4.Text = dbr.GetString(7);
                textBox5.Text = dbr.GetString(8);
            }

            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Supplier set CompanyName = @ComName, ContactName = @ConName, OfficeAddress = @Address, Phone = @Phone, City = @City where idSupplier = @id", con);
            cmd.Parameters.AddWithValue("@id", Form2.ID);
            cmd.Parameters.AddWithValue("@ComName", textBox1.Text);
            cmd.Parameters.AddWithValue("@ConName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@City", textBox5.Text);

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Updated Successfully");

            this.Close();
        }
    }
}
