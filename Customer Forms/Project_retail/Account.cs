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
    
    public partial class Account : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select_products sproducts = new Select_products();
            sproducts.Show();
            this.Hide();
        }

        private void populate_grid()
        {
            int x = 0;
            
            Int32.TryParse(SignIn.ID, out x);
            conn.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("select * from Order_2 where User_2_idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            cmd.ExecuteNonQuery();
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_RetailDataSet4.Order_2' table. You can move, or remove it, as needed.
            this.order_2TableAdapter2.Fill(this.online_RetailDataSet4.Order_2);
            // TODO: This line of code loads data into the 'online_RetailDataSet.Order_2' table. You can move, or remove it, as needed.
            this.order_2TableAdapter1.Fill(this.online_RetailDataSet.Order_2);
            // TODO: This line of code loads data into the 'covServeDataSet2.Order_2' table. You can move, or remove it, as needed.
            //this.order_2TableAdapter.Fill(this.covServeDataSet2.Order_2);
            int x = 0;

            Int32.TryParse(SignIn.ID, out x);
            conn.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            // Personal 
            /// Name
            cmd = new SqlCommand("select FirstName+' '+LastName from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label10.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
            /// Email
            cmd = new SqlCommand("select EmailAddress from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label11.Text = cmd.ExecuteScalar().ToString();
            conn.Close();

            // Shipping
            cmd = new SqlCommand("select ShippingAddress from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label6.Text = cmd.ExecuteScalar().ToString();
            conn.Close();

            cmd = new SqlCommand("select City from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label12.Text = cmd.ExecuteScalar().ToString();
            conn.Close();

            //Billing
            cmd = new SqlCommand("select BillingAddress from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label2.Text = cmd.ExecuteScalar().ToString();
            conn.Close();

            cmd = new SqlCommand("select City from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label5.Text = cmd.ExecuteScalar().ToString();
            conn.Close();

            populate_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;

            Int32.TryParse(SignIn.ID, out x);
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete your account?", "Account Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                conn.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
                cmd = new SqlCommand("delete from User_2 where idUser_2=@id", conn);
                cmd.Parameters.AddWithValue("@id", x);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                SignUp signup = new SignUp();
                signup.Show();
                this.Close();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
