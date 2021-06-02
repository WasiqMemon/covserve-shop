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
    public partial class Cart : Form
    {
        public static int removeid;
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public static string label = "";
        public Cart()
        {
            InitializeComponent();
            
            con.ConnectionString = @"Data Source =DESKTOP-JBODFNH\SERVER404; Initial Catalog = Online_Retail; Integrated Security = True";
            
            cmd = new SqlCommand("select idStock, ProductName, Price, sp.Quantity from Stock inner join [Shopping Cart] sp on sp.Stock_idStock=Stock.idStock where Order_2_idOrder_2=(select MAX(idOrder_2) from Order_2)",con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            cmd = new SqlCommand("update Order_2 set TotalAmount=(select sum(Price) from Stock inner join [Shopping Cart] sp on sp.Stock_idStock=Stock.idStock where Order_2_idOrder_2=(select MAX(idOrder_2) from Order_2)) ",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            cmd = new SqlCommand("select TotalAmount from Order_2 where idOrder_2=(select MAX(idOrder_2) from Order_2)", con);
            con.Open();
            label3.Text = cmd.ExecuteScalar().ToString();
            con.Close();


            //this.dataGridView1.Rows.Add(false, 2145 , "starry lamp", "32.99", 1);
            //this.dataGridView1.Rows.Add(false, 2135, "starry shooter", "100", 1);
        }
        public Cart(bool check, int id, string pname, float price, int quantity)
        {
            InitializeComponent();
            this.dataGridView1.Rows.Add(check, id, pname, price, quantity);
        }
        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;
            
            int q = (int)dataGridView1.Rows[index].Cells[3].Value;
            Console.WriteLine(q);
        }

        private void populize_grid()
        {
            this.dataGridView1.Rows.Add("1", "XX");
        }

        

        private void Cart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_RetailDataSet1.Shopping_Cart' table. You can move, or remove it, as needed.
            this.shopping_CartTableAdapter1.Fill(this.online_RetailDataSet1.Shopping_Cart);
            // TODO: This line of code loads data into the 'covServeDataSet3.Shopping_Cart' table. You can move, or remove it, as needed.
            //this.shopping_CartTableAdapter.Fill(this.covServeDataSet3.Shopping_Cart);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            



            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("delete from [Shopping Cart] where Stock_idStock=@id and Order_2_idOrder_2=(select max(idOrder_2) from Order_2)",con);
            cmd.Parameters.AddWithValue("@id", removeid);
            con.Open();
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Select_products sproducts = new Select_products();
            sproducts.Show();
            this.Hide();
        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Place_order placeorder = new Place_order(GetDataTableFromDGV(dataGridView1), label);
            placeorder.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("delete from [Shopping Cart] where Stock_idStock=@id and Order_2_idOrder_2=(select max(idOrder_2) from Order_2)", con);
            cmd.Parameters.AddWithValue("@id", id);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            

            update_table();
            


        }

        private void update_table()
        {
            con.ConnectionString = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            cmd = new SqlCommand("select idStock, ProductName, Price, sp.Quantity from Stock inner join [Shopping Cart] sp on sp.Stock_idStock=Stock.idStock where Order_2_idOrder_2=(select MAX(idOrder_2) from Order_2)", con);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            cmd = new SqlCommand("update Order_2 set TotalAmount=(select sum(Price) from Stock inner join [Shopping Cart] sp on sp.Stock_idStock=Stock.idStock where Order_2_idOrder_2=(select MAX(idOrder_2) from Order_2)) ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            cmd = new SqlCommand("select TotalAmount from Order_2 where idOrder_2=(select MAX(idOrder_2) from Order_2)", con);
            con.Open();
            label3.Text = cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length>0)
            {
                string str = label3.Text;
                string q = textBox1.Text;

                float price = float.Parse(str);
                int x = 0;

                Int32.TryParse(textBox1.Text, out x);
                price = price * x;
                Console.WriteLine(price);
                
                Console.WriteLine(label3.Text);
                con.ConnectionString = @"Data Source = DESKTOP-JBODFNH\SERVER404; Initial Catalog = Online_Retail; Integrated Security = True";
                cmd = new SqlCommand("update [Shopping Cart] set Quantity=@q where Order_2_idOrder_2=(select MAX(idOrder_2) from Order_2)",con);
                cmd.Parameters.AddWithValue("@q", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                update_table();
                label3.Text = price.ToString();
            }
        }
    }
}
