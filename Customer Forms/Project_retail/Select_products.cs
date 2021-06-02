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

    public partial class Select_products : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public Select_products()
        {
            InitializeComponent();

        }

        private void Select_products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_RetailDataSet3.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter3.Fill(this.online_RetailDataSet3.Stock);
            // TODO: This line of code loads data into the 'covServeDataSet1.Stock' table. You can move, or remove it, as needed.
            ///this.stockTableAdapter2.Fill(this.covServeDataSet1.Stock);
            // TODO: This line of code loads data into the 'covServeDataSet.Stock' table. You can move, or remove it, as needed.
            //this.stockTableAdapter1.Fill(this.covServeDataSet.Stock);
            comboBox1.Text = "Filter by Category";
            // TODO: This line of code loads data into the 'northwindDataSet1.Products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter1.Fill(this.northwindDataSet1.Products);
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            // TODO: This line of code loads data into the 'project_retailDataSet3.Stock' table. You can move, or remove it, as needed.
            //this.stockTableAdapter.Fill(this.project_retailDataSet3.Stock);
            /// to populate the grid with the products
            

            PopulateDataGridView();
            PopulateComboBox();

            /// new query
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            label8.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            label9.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            label10.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            label11.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();

            // Console.WriteLine(dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString());


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            con = new SqlConnection(source);
           
            if (comboBox1.SelectedIndex >= 0)
            {
                string query2 = "select * from Stock where Category_idCategory in (select idCategory from Category where Name=@catname)";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@catname", comboBox1.SelectedItem);
                con.Open();
                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }


            if (textBox1.Text.Length>0)
            {
                string query = "SELECT distinct idStock, ProductName, ItemsLeft, Price, Sale_Discount, Picture FROM Stock, Category  WHERE ProductName LIKE @product";

                con.Open();
                cmd = new SqlCommand(query, con);
                if (textBox1.Text == String.Empty)
                {
                    cmd.Parameters.AddWithValue("@product", '%');
                }
                else
                {
                    cmd.Parameters.AddWithValue("@product", textBox1.Text.Trim());
                }

                cmd.ExecuteNonQuery();
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }


            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void PopulateDataGridView()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("select * from Stock", con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            
        }

        private void PopulateComboBox()
        {
            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            con = new SqlConnection(source);
            
            SqlDataReader dr;
            string query = "SELECT distinct Name FROM Category INNER JOIN Stock ON Stock.Category_idCategory = Category.idCategory";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex < 0)
            {
                comboBox1.Text = "Filter by Category";
            }
            else
            {
                comboBox1.Text = comboBox1.SelectedText;
            }

            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            con = new SqlConnection(source);
            

            

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            int rowIndex = dataGridView1.CurrentRow.Index;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            string productN = row.Cells[1].Value.ToString();
            string price = row.Cells[3].Value.ToString();
            float pricef = float.Parse(price);
            int ID = (int)row.Cells[0].Value;
            Console.WriteLine(rowIndex);

            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            con = new SqlConnection(source);
            
            string query = "insert into [Shopping Cart] (Order_2_idOrder_2, Stock_idStock,Quantity) values ((select max(idOrder_2) from Order_2), @sid, @q) ";
            string query2 = "select @item from Stock where idStock=@sid";
            cmd = new SqlCommand(query, con);
            
            cmd.Parameters.AddWithValue("@sid", row.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@q", 1);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            
            string pname;
            cmd = new SqlCommand(query2, con);
            cmd.Parameters.AddWithValue("@item", ProductName);
            cmd.Parameters.AddWithValue("@sid", 10);
            con.Open();
            pname = (string)cmd.ExecuteScalar();
            Console.WriteLine(pname);
            con.Close();

            cmd = new SqlCommand("update Stock set ItemsLeft=ItemsLeft-1, ItemsSold=ItemsSold+1 where idStock=@sid",con);
            cmd.Parameters.AddWithValue("@sid", row.Cells[0].Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();





            

        }

        private void insert_cart(string sid)
        {
            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            con = new SqlConnection(source);
            // stock name
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
