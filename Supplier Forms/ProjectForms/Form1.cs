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
    public partial class Form1 : Form
    {
        
        public static int stock_id;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'online_RetailDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.online_RetailDataSet.Stock);
            PopulateDataGridView();
            PopulateComboBox();
        }

        private void PopulateDataGridView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Stock where Supplier_idSupplier = @s_id", con);
            cmd.Parameters.AddWithValue("@s_id", Form2.ID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void PopulateComboBox()
        {
            string source = @"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True";
            SqlConnection con = new SqlConnection(source);
            SqlCommand cmd;
            SqlDataReader dr;
            string query = "SELECT Name FROM Category";
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

        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Stock(Supplier_idSupplier, Category_idCategory, ProductName, ItemsLeft, ItemsSold, Price, Sale_Discount) values(@id, @Category, @Name, @Quantity, 0, @Price, 0)", con);
            cmd.Parameters.AddWithValue("@id", Form2.ID);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Category", comboBox1.SelectedIndex+1);
            cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@Price", textBox2.Text);

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();


            PopulateDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearData();
            stock_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedIndex = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()) - 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Stock set ProductName = @Name, ItemsLeft = @Quantity, Price = @Price where idStock = @id", con);
            cmd.Parameters.AddWithValue("@id", stock_id);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@Price", textBox2.Text);

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();

            ClearData();
            PopulateDataGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-JBODFNH\SERVER404;Initial Catalog=Online_Retail;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Stock where idStock = @id", con);
            cmd.Parameters.AddWithValue("@id", stock_id);
            
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();

            ClearData();
            PopulateDataGridView();
        }
    }
}
