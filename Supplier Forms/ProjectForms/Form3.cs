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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PopulateComboBox()
        {
            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            SqlConnection con = new SqlConnection(source);
            SqlCommand cmd;
            SqlDataReader dr;
            string query = "SELECT Name FROM Region";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(0));
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool flag = true;
            string er = "";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Supplier values(@Region, @CompanyName, @ContactName, @OfficeAddress, @EmailAddress, @LoginPassword, @Phone, @City)", con);
 
            cmd.Parameters.AddWithValue("@Region", comboBox1.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@CompanyName", textBox1.Text);
            cmd.Parameters.AddWithValue("@ContactName", textBox2.Text);
            cmd.Parameters.AddWithValue("@OfficeAddress", textBox3.Text);
            cmd.Parameters.AddWithValue("@EmailAddress", textBox4.Text);
            cmd.Parameters.AddWithValue("@LoginPassword", textBox5.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox7.Text);
            cmd.Parameters.AddWithValue("@City", textBox8.Text);

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            if (textBox5.Text != textBox6.Text) 
            {
                flag = false;
                er += "Passwords do not match! \n";
            }
            
            if (textBox7.TextLength != 11)
            {
                flag = false;
                er += "Phone Number is not valid! \n";
            }
            
            if (flag == true)
            {
                cmd.ExecuteNonQuery();
            }
            
            con.Close();

            con.Open();
            cmd = new SqlCommand("select idSupplier from Supplier where EmailAddress = @EmailAddress", con);
            cmd.Parameters.AddWithValue("@EmailAddress", textBox4.Text);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Form2.ID = sdr.GetInt32(0);
            }

            if (Form2.ID != 0)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show(er);
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
