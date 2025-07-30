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
    public partial class UserControlBrand : UserControl
    {
        private string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";

        public UserControlBrand()
        {
            InitializeComponent();
            LoadBrands();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                    }

        private void tpAddBrand_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string brandName = txtBrandname1.Text.Trim();
            string status = cmbStatus1.SelectedItem?.ToString();

            // Validate input
            if (string.IsNullOrEmpty(brandName) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Insert brand into database
                using (SqlConnection conn = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "INSERT INTO Bran (Bran_Name, Bran_Status) VALUES (@BranName, @BranStatus)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranName", brandName);
                        cmd.Parameters.AddWithValue("@BranStatus", status);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Brand added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();

                        }
                        else
                        {
                            MessageBox.Show("Failed to add brand.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            txtBrandname1.Clear();
            cmbStatus1.SelectedIndex = -1;
        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tpManageBrand_Click(object sender, EventArgs e)
        {

        }

        private void tpOptions_Click(object sender, EventArgs e)
        {

        }
        private void LoadBrands()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Bran";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvBrand.DataSource = dt;
            }
        }

        private void UserControlBrand_Load(object sender, EventArgs e)
        {
            LoadBrands();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string brandName = txtbrandname2.Text;
            string status = cmbstatus2.Text;

            if (!string.IsNullOrEmpty(brandName) && !string.IsNullOrEmpty(status))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Bran SET Bran_Status = @status WHERE Bran_Name = @name";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", brandName);
                    cmd.Parameters.AddWithValue("@status", status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Brand updated successfully!");
                    LoadBrands();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string brandName =txtbrandname2.Text;

            if (!string.IsNullOrEmpty(brandName))
            {
                using (SqlConnection con = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
                {
                    string query = "DELETE FROM Bran WHERE Bran_Name = @name";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", brandName);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Brand removed successfully!");
                    LoadBrands();
                }
            }
            else
            {
                MessageBox.Show("Please enter a brand name.");
            }
        }

        private void SearchBrandByName(string brandName)
        {
            using (SqlConnection con = new SqlConnection("Data Source = SIVAKUMAR\\SQLEXPRESS; Initial Catalog = nikaa; Integrated Security = True"))
            {
                // SQL query to search brands by name
                string query = "SELECT * FROM Bran WHERE Bran_Name LIKE @brandName";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                // Add the search term with wildcard characters
                adapter.SelectCommand.Parameters.AddWithValue("@brandName", "%" + brandName + "%");

                // Fill the DataTable and bind it to the DataGridView
                DataTable dt = new DataTable();
                adapter.Fill(dt);
               dgvBrand.DataSource = dt; // dgvBrands is your DataGridView for displaying results
            }

        }

        private void txtSarchBrandName_TextChanged(object sender, EventArgs e)
        {
            string brandName = txtSarchBrandName.Text.Trim(); // Get the search term
            SearchBrandByName(brandName);
        }

        private void UserControlBrand_Load_1(object sender, EventArgs e)
        {

        }

        private void txtBrandname1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Bran";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                label8.Text = " " + count.ToString(); // Update label
            }

        }
    }
}


