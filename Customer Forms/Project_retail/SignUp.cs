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

    public partial class SignUp : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public static int ID2 = 0;

        public object Project_retailDataSet { get; private set; }

        public SignUp()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void get_ID2()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("select idUser_2 from Customer where EmailAddress=@Email and Login_Password=@pass", con);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            con.Open();
            ID2 = (int)cmd.ExecuteScalar();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = con.CreateCommand();
            cmd.CommandText = "Execute signup @region, @fname, @lname, @phone,@pass, @email, @Sadd, @Badd,@city, @country";
        
            cmd.Parameters.AddWithValue("@fname", textBox1.Text);
            
            cmd.Parameters.AddWithValue("@lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@region", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            cmd.Parameters.AddWithValue("@Sadd", richTextBox2.Text);
            cmd.Parameters.AddWithValue("@Badd", richTextBox1.Text);

            cmd.Parameters.AddWithValue("@city", textBox7.Text);
            cmd.Parameters.AddWithValue("@country", textBox8.Text);


            // everything is alright
            Console.WriteLine(password_check());
            if (textBox5.Text == textBox6.Text)
            {
                Console.WriteLine("Password Matched");

            }
            if (email_check() == true)
            {
                Console.WriteLine("Email is fine");
            }
            if (password_check() == true)
            {
                Console.WriteLine("Password fine");
            }

            if (email_check() == true && textBox5.Text == textBox6.Text)
            {
                con.Open();
                cmd.ExecuteNonQuery();
                

                MessageBox.Show("Account is made!");
                

                con.Close();
                SignIn signin = new SignIn();
                signin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your password doesn't match", "Confirm Password Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'project_retailDataSet1.Customer' table. You can move, or remove it, as needed.
            //this.customerTableAdapter.Fill(this.project_retailDataSet1.Customer);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool email_check()
        {
            if (!this.textBox3.Text.Contains('@') || !this.textBox3.Text.Contains('.'))
            {
                
                return false;
            }
            
            return true;
        }

        private bool password_check()
        {
            string lettersC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersS = "abcdefghijklmnopqrstuvwxyz"+lettersC;
            string num = "0123456789";
            int count = 0;
            if (textBox5.TextLength>=6 && textBox5.TextLength <= 20)
            {
                count++;
            }
            else if (textBox5.Text.Contains(lettersS)){
                count++;
            }
            else if (textBox5.Text.Contains(num))
            {
                count++;
            }
            
            if (count == 3)
            {
                Console.WriteLine(count);
                return true;
            }
            return false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]"))
            {
                MessageBox.Show("This textbox accepts only numerical characters");
                // textBox4.Text.Remove(textBox4.Text.Length - 1);
            }

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            signin.Show();
            this.Hide();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");

            }
        }
    }
}
