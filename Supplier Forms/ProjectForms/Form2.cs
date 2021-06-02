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
    public partial class Form2 : Form
    {
        public static int ID;
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select idSupplier from Supplier where EmailAddress = @email and Login_Password = @pwd", con);
            SqlDataReader dbr;

            cmd.Parameters.AddWithValue("@email", textBox1.Text);
            cmd.Parameters.AddWithValue("@pwd", textBox2.Text);

            dbr = cmd.ExecuteReader();

            while (dbr.Read())
            {
                ID = dbr.GetInt32(0);
            }

            if (ID == 0)
            {
                MessageBox.Show("Email or Password is incorrect");
            }
            else {
                
                Form5 f5 = new Form5();
                f5.Show();
                ClearData();
                this.Hide();
            }
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
