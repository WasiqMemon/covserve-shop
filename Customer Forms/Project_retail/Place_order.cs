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
    public partial class Place_order : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        public Place_order()
        {
            InitializeComponent();
            
            
        }
        public Place_order(object dataSource, string money)
        {
            InitializeComponent();
            dataGridView2.DataSource = dataSource;
            label8.Text = money;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your order has been placed, Thanks for shopping!");
        }

        private void Place_order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_RetailDataSet2.Shopping_Cart' table. You can move, or remove it, as needed.
            this.shopping_CartTableAdapter.Fill(this.online_RetailDataSet2.Shopping_Cart);
            int x = 0;

            Int32.TryParse(SignIn.ID, out x);
            // Address
            conn.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("select ShippingAddress from User_2 where idUser_2=@id",conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label4.Text = (string)cmd.ExecuteScalar();
            conn.Close();

            //Phone number
            cmd = new SqlCommand("select PhoneNumber from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label5.Text= (string)cmd.ExecuteScalar();
            
            conn.Close();

            // Email Address
            
            cmd = new SqlCommand("select EmailAddress from User_2 where idUser_2=@id", conn);
            cmd.Parameters.AddWithValue("@id", x);
            conn.Open();
            label6.Text = (string)cmd.ExecuteScalar();
            conn.Close();
            //label4.Text = SignIn.ID.ToString();

            cmd = new SqlCommand("select TotalAmount from Order_2 where idOrder_2=(select MAX(idOrder_2) from Order_2)", conn);
            conn.Open();
            label8.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
