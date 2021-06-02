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
using System.Data.Sql;

namespace Project_retail
{
    public partial class SignIn : Form
    {
        public static string ID = "";
        SqlConnection con;
        SqlCommand cmd;
        
        public SignIn()
        {
            InitializeComponent();
            
    }

        private void SignIn_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void get_ID()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("select idUser_2 from User_2 where EmailAddress=@Email and Login_Password=@pass", con);
            cmd.Parameters.AddWithValue("@Email", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            ID = cmd.ExecuteScalar().ToString();
            con.Close();
            
            int x = 0;

            Int32.TryParse(ID, out x);
            cmd = new SqlCommand("insert into Order_2 (User_2_idUser_2, OrderDate, TotalAmount) values (@id, GETDATE(), 0)", con);
            cmd.Parameters.AddWithValue("@id", x);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            con.Open();
            cmd = new SqlCommand("select * from User_2 where EmailAddress=@Email and Login_Password=@pass", con);
            cmd.Parameters.AddWithValue("@Email", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                if (reader.Read())
                {
                    get_ID();
                    
                    
                    this.Hide();
                    Select_products f2 = new Select_products(); //this is the change, code for redirect  
                    f2.ShowDialog();
                    
                    
                }
                else
                {
                    MessageBox.Show("Account Not found");
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Hide();
        }
    }
}
