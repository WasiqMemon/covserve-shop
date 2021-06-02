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

namespace Project_retail
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;

            Int32.TryParse(SignIn.ID, out x);
            
            conn.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = conn.CreateCommand();
            cmd.CommandText = "Execute Update_customer @fname, @lname, @email, @phone, @id, @city, @country, @region,@Badd,@Sadd";
            cmd.Parameters.AddWithValue("@fname", textBox1.Text);
            cmd.Parameters.AddWithValue("@lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox7.Text);
            cmd.Parameters.AddWithValue("@city", textBox8.Text);
            cmd.Parameters.AddWithValue("@country", textBox4.Text);
            cmd.Parameters.AddWithValue("@Sadd", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@Badd", richTextBox2.Text);
            cmd.Parameters.AddWithValue("@region", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Account account = new Account();
            account.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'project_retailDataSet4.Region' table. You can move, or remove it, as needed.
            //this.regionTableAdapter.Fill(this.project_retailDataSet4.Region);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
