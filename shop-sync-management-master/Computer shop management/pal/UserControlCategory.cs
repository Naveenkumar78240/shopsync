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
    public partial class UserControlCategory : UserControl
    {
       
        public UserControlCategory()
        {
            InitializeComponent();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
                // Get input values
                string categoryName = txtCategoryname1.Text.Trim();
                string status = cmbStatus1.SelectedItem?.ToString();

                // Validate input
                if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Database connection string
                    using (SqlConnection conn = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
                    {
                        conn.Open();

                        // SQL query to insert a category
                        string query = "INSERT INTO Category (Category_Name, Category_Status) VALUES (@CategoryName, @CategoryStatus)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                            cmd.Parameters.AddWithValue("@CategoryStatus", status);

                            // Execute the query
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCategoryFields();
                                LoadCategories(); // Reload the data grid after insertion
                            }
                            else
                            {
                                MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ClearCategoryFields()
            {
                txtCategoryname1.Clear();
                cmbStatus1.SelectedIndex = -1;
            }

            // Method to clear input fields
            
            private void LoadCategories()
            {
                using (SqlConnection conn = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
                {
                    try
                    {
                        string query = "SELECT * FROM Category";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCategory.DataSource = dt; // Assuming dgvCategory is the DataGridView for categories
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            private void UserControlCategory_Load(object sender, EventArgs e)
            {
                LoadCategories();
            }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryname2.Text.Trim();
            string status = cmbstatus2.SelectedItem?.ToString();

            // Validate input
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Database connection string
                using (SqlConnection conn = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
                {
                    conn.Open();

                    // SQL query to update a category
                    string query = "UPDATE Category SET Category_Status = @CategoryStatus WHERE Category_Name = @CategoryName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        cmd.Parameters.AddWithValue("@CategoryStatus", status);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadCategories(); // Reload categories in the grid
                        }
                        else
                        {
                            MessageBox.Show("Category not found or no changes made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                    private void ClearFields()
                    {
                        txtCategoryname1.Clear();
                        cmbStatus1.SelectedIndex = -1;
                    }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryname2.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter the category name to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Database connection string
                using (SqlConnection conn = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
                {
                    conn.Open();

                    // SQL query to delete a category
                    string query = "DELETE FROM Category WHERE Category_Name = @CategoryName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadCategories(); // Reload categories in the grid
                        }
                        else
                        {
                            MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tpOptions_Click(object sender, EventArgs e)
        {

        }

        private void tpAddCategory_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpCategoryBrand_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
            {
                string query = "SELECT COUNT(*) FROM Category";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                label8.Text = " " + count.ToString(); // Update label
            }

        }
    }
    }
        
    
