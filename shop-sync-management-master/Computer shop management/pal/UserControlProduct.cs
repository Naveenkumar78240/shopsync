using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Computer_shop_management.pal
{
    public partial class UserControlProduct : UserControl
    {
        private string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";





        public UserControlProduct()
        {
            InitializeComponent();
            LoadProducts();
            LoadBrands();
            LoadCategories();






        }

        // Method to Bind Category Dropdown



        private string selectedImagePath = string.Empty;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName; // Store the path
                picPhoto.Image = System.Drawing.Image.FromFile(selectedImagePath);
            }
        }
        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Category_Name FROM Category"; // Correct table & column
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        comboBox1.Items.Clear(); // Clear previous items
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["Category_Name"].ToString()); // Correct column name
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message);
                }
            }
        }

            private void LoadBrands()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Bran_Name FROM Bran"; // Correct column name
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        cmbbrand.Items.Clear(); // Clear previous items
                        while (reader.Read())
                        {
                            cmbbrand.Items.Add(reader["Bran_Name"].ToString()); // Correct column name
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading brands: " + ex.Message);
                }
            }
        }
        

        private void LoadProducts(string filter = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Products"; // Change table name if needed
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvProduct.DataSource = dt; // Ensure you have a DataGridView named dataGridViewProducts
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading products: " + ex.Message);
                }
            }

        }
        
        private void txtSearchProductName_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchProductName.Text.Trim();
            LoadProducts(searchText);
        }
        private void LoadProductDetails(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName = @ProductName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtproductName2.Text = reader["ProductName"].ToString();
                        numRate1.Text = reader["Rate"].ToString();
                        numQuantity1.Text = reader["Quantity"].ToString();
                        txtbrand.Text = reader["Brand"].ToString();
                        txtcategory.Text = reader["Category"].ToString();
                        cmbStatus.SelectedItem = reader["Status"].ToString();
                    }

                    connection.Close();
                }
            }
        }


        private void btnchange_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET Product_Rate = @Product_Rate, Product_Quantity = @Product_Quantity, " +
                               "Product_Brand = @Product_Brand, Product_Category = @Product_Category, Product_Status = @Product_Status " +
                               "WHERE Product_Name = @Product_Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", txtproductName2.Text.Trim());
                    command.Parameters.AddWithValue("@Product_Rate", (int)numRate1.Value); // Fixed INT issue
                    command.Parameters.AddWithValue("@Product_Quantity", (int)numQuantity1.Value);
                    command.Parameters.AddWithValue("@Product_Brand", string.IsNullOrWhiteSpace(txtbrand.Text) ? "" : txtbrand.Text.Trim());
                    command.Parameters.AddWithValue("@Product_Category", string.IsNullOrWhiteSpace(txtcategory.Text) ? "" : txtcategory.Text.Trim());
                    command.Parameters.AddWithValue("@Product_Status", cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "Unavailable");

                    try
                    {
                        connection.Open();

                        // Check if product exists before updating
                        string checkQuery = "SELECT COUNT(*) FROM Products WHERE Product_Name = @Product_Name";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Product_Name", txtproductName2.Text.Trim());
                            int productCount = (int)checkCommand.ExecuteScalar();

                            if (productCount == 0)
                            {
                                MessageBox.Show("Product not found in the database.");
                                return;
                            }
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Product details updated successfully." : "No changes made.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Check if product exists before deleting
                        string checkQuery = "SELECT COUNT(*) FROM Products WHERE Product_Name = @Product_Name";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.Add("@Product_Name", SqlDbType.VarChar, 150).Value = txtproductName2.Text.Trim();
                            int productCount = (int)checkCommand.ExecuteScalar();

                            if (productCount == 0)
                            {
                                MessageBox.Show("Product not found in the database.");
                                return;
                            }
                        }

                        // Proceed with deletion
                        string query = "DELETE FROM Products WHERE Product_Name = @Product_Name";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@Product_Name", SqlDbType.VarChar, 150).Value = txtproductName2.Text.Trim();
                            int rowsAffected = command.ExecuteNonQuery();

                            MessageBox.Show(rowsAffected > 0 ? "Product removed successfully." : "Error removing product.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void tpManageProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE Product_Name = @Product_Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", txtproductName2.Text.Trim());
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtproductName2.Text = reader["Product_Name"].ToString();
                        numRate1.Text = reader["Product_Rate"].ToString();
                        numQuantity1.Text = reader["Product_Quantity"].ToString();
                        txtbrand.Text = reader["Product_Brand"].ToString();
                        txtcategory.Text = reader["Product_Category"].ToString();
                        cmbStatus.SelectedItem = reader["Product_Status"].ToString();
                    }

                    connection.Close();
                }
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductname1.Text) ||
        string.IsNullOrWhiteSpace(cmbbrand.Text) ||
        string.IsNullOrWhiteSpace(comboBox1.Text) ||
        cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string productName = txtProductname1.Text.Trim();
                decimal rate = numRate.Value;
                int quantity = (int)numQuantity.Value;
                string brand = cmbbrand.Text.Trim();
                string category = comboBox1.Text.Trim();
                string status = cmbStatus.SelectedItem.ToString();
                byte[] image = null;

                // Convert image file to byte array
                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    image = File.ReadAllBytes(selectedImagePath);
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Products (Product_Name, Product_Rate, Product_Quantity, Product_Brand, Product_Category, Product_Status, Product_Image) " +
                                   "VALUES (@Product_Name, @Product_Rate, @Product_Quantity, @Product_Brand, @Product_Category, @Product_Status, @Product_Image)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Product_Name", productName);
                        command.Parameters.AddWithValue("@Product_Rate", rate);
                        command.Parameters.AddWithValue("@Product_Quantity", quantity);
                        command.Parameters.AddWithValue("@Product_Brand", brand);
                        command.Parameters.AddWithValue("@Product_Category", category);
                        command.Parameters.AddWithValue("@Product_Status", status);

                        // Ensure Product_Image is correctly set
                        if (image != null)
                        {
                            command.Parameters.Add("@Product_Image", SqlDbType.VarBinary).Value = image;
                        }
                        else
                        {
                            command.Parameters.Add("@Product_Image", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFormFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

            private void ClearFormFields()
            {
                txtProductname1.Clear();
                numRate.Value = 0;
                numQuantity.Value = 0;
                cmbbrand.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
                cmbStatus.SelectedIndex = -1; // Deselect the combo box
                picPhoto.Text = string.Empty; // Clear the image file path
                picPhoto.Image = null; // Reset the picture box if used
            }

        private void tpAddProduct_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
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
                       label10.Text = totalProducts.ToString(); // Update label
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void tpOptions_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Method to clear form fields


    }
    

    // Method to Load Categories into ComboBox
    
}




    
       
           



        

       

        



    



























