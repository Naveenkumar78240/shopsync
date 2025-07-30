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

namespace Computer_shop_management.pal
{
    public partial class UserControlDashboard : UserControl
    {
        private string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";
        public UserControlDashboard()
        {
            InitializeComponent();
            

        }
        private void UpdateTotalProductCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Products";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int totalProducts = (int)cmd.ExecuteScalar();
                        label2.Text = totalProducts.ToString(); // Update label
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void UpdateTotalOrderCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Orders";  // Count total orders

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int totalOrders = (int)cmd.ExecuteScalar();  // Execute query
                        label4.Text = "Total Orders: " + totalOrders.ToString(); // Update label
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoadTotalRevenue()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(Paid_Amount) FROM Orders";  // Get total revenue
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)  // Check for NULL value
                {
                    decimal totalRevenue = Convert.ToDecimal(result);
                    label8.Text = "Total Revenue: $" + totalRevenue.ToString("0.00"); // Display revenue
                }
                else
                {
                    label8.Text = "Total Revenue: $0.00"; // Handle case when no revenue
                }
            }
        }

        // Call this method in relevant places:
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Existing code for adding product...
            UpdateTotalProductCount();  // Update the count after adding
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdateTotalProductCount();

        }

        



        private void label4_Click(object sender, EventArgs e)
        {
            UpdateTotalOrderCount();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
