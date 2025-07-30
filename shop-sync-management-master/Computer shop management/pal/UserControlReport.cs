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
    public partial class UserControlReport : UserControl
    {
        private string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";


        public UserControlReport()
        {
            InitializeComponent();
            LoadCustomerData();
            dgvReport.AutoGenerateColumns = true;
            LoadCustomerComboBox();
            LoadCustomerComboBox2();
            LoadTotalOrders();
        }


        private void LoadCustomerData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Order_Id, Start_Date, End_Date, Customer_Name, Customer_Number, Grand_Total FROM Report";

                if (!string.IsNullOrEmpty(txtReportNameName.Text.Trim()))
                {
                    query += " WHERE Customer_Name LIKE @CustomerName";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                try
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@CustomerName", "%" + txtReportNameName.Text.Trim() + "%");
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found for the specified customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvReport.DataSource = null;
                        return;
                    }

                    dgvReport.AutoGenerateColumns = false;
                    dgvReport.Columns.Clear();

                    dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Order ID", DataPropertyName = "Order_Id" });
                    dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Start Date", DataPropertyName = "Start_Date" });
                    dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "End Date", DataPropertyName = "End_Date" });
                    dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Customer Name", DataPropertyName = "Customer_Name" });
                    dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Customer Number", DataPropertyName = "Customer_Number" });
                    dgvReport.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Grand Total", DataPropertyName = "Grand_Total" });

                    dgvReport.DataSource = dt;
                    dgvReport.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }







        }
        private void LoadCustomerComboBox()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Customer_Number, Customer_Name, Grand_Total FROM Orders"; // Fetch from Orders
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No customer data found in the Orders table!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Bind ComboBox
                    comboBox1.DataSource = dt;
                    cmbProduct.DataSource = dt;
                    comboBox2.DataSource = dt;

                    cmbProduct.DisplayMember = "Customer_Name"; // Display customer name
                    comboBox1.ValueMember = "Customer_Number"; // Use customer number as the value
                    comboBox2.ValueMember = "Grand_Total"; // Show grand total
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddOrder()
        {
            DateTime orderDate = DateTime.Now;
            string customerName = cmbProduct.Text.Trim();
            string customerNumber = comboBox1.SelectedValue?.ToString();
            decimal grandTotal;

            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerNumber))
            {
                MessageBox.Show("Please select a valid customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(comboBox2.Text, out grandTotal))
            {
                MessageBox.Show("Invalid Grand Total value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert Order into the Orders table first
                    string insertOrderQuery = @"
                INSERT INTO Orders (Orders_Date, Customer_Name, Customer_Number, Grand_Total) 
                VALUES (@orderDate, @name, @number, @total)";

                    using (SqlCommand cmd = new SqlCommand(insertOrderQuery, conn))
                    {
                        cmd.Parameters.Add("@orderDate", SqlDbType.DateTime).Value = orderDate;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = customerName;
                        cmd.Parameters.Add("@number", SqlDbType.VarChar, 15).Value = customerNumber;
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = grandTotal;

                        cmd.ExecuteNonQuery();
                    }

                    // Insert data into Report table
                    string insertReportQuery = @"
                INSERT INTO Report (Start_Date, End_Date, Customer_Name, Customer_Number, Grand_Total)
                VALUES (@orderDate, @orderDate, @name, @number, @total)";

                    using (SqlCommand cmd = new SqlCommand(insertReportQuery, conn))
                    {
                        cmd.Parameters.Add("@orderDate", SqlDbType.DateTime).Value = orderDate;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = customerName;
                        cmd.Parameters.Add("@number", SqlDbType.VarChar, 15).Value = customerNumber;
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = grandTotal;

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerData(); // Reload data to reflect changes
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrder();
            LoadCustomerData();

        }
        private void LoadTotalOrders()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(Grand_Total) FROM Orders"; // Sum all Grand_Total values
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        label5.Text = $"Total Orders: {Convert.ToDecimal(result):C}"; // Format as currency
                    }
                    else
                    {
                        label5.Text = "Total Orders: $0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void tpManageReport_Click(object sender, EventArgs e)
        {

        }

        private void tpReport_Click(object sender, EventArgs e)
        {

        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void UpdateOrder()
        {

            if (dgvReport.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract selected row values
            string cname1 = dgvReport.SelectedRows[0].Cells["Customer_Name"].Value.ToString();
            string cno = dgvReport.SelectedRows[0].Cells["Customer_Number"].Value.ToString();
            decimal grandTotal;

            if (!decimal.TryParse(cgrnad.Text, out grandTotal))
            {
                MessageBox.Show("Invalid Grand Total value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Report SET Grand_Total = @total WHERE Customer_Name = @name AND Customer_Number = @number";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = grandTotal;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = cname1;
                        cmd.Parameters.Add("@number", SqlDbType.VarChar, 15).Value = cno;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerData(); // Refresh only if update was successful
                        }
                        else
                        {
                            MessageBox.Show("No matching order found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





    


        private void RemoveOrder()
        {
            if (dgvReport.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cname1 = dgvReport.SelectedRows[0].Cells["Customer_Name"].Value.ToString();
            int orderId = Convert.ToInt32(dgvReport.SelectedRows[0].Cells["Order_Id"].Value);

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the order for {cname1}?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Report WHERE Order_Id = @orderId AND Customer_Name = @name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = cname1; // Adjust size if needed

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerData(); // Refresh data grid
                        }
                        else
                        {
                            MessageBox.Show("No matching order found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database Error: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            UpdateOrder();
            LoadCustomerData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveOrder();
            LoadCustomerData();
        }

        private void tooptions_Click(object sender, EventArgs e)
        {

        }
        private void LoadCustomerComboBox2()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Customer_Number, Customer_Name, Grand_Total FROM Orders"; // Fetch from Orders
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No customer data found in the Orders table!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Bind ComboBox for the second set of controls
                    cname1.DataSource = dt;
                    cno.DataSource = dt;
                    cgrnad.DataSource = dt;

                    cname1.DisplayMember = "Customer_Name"; // Display customer name
                    cno.ValueMember = "Customer_Number"; // Use customer number as value
                    cgrnad.ValueMember = "Grand_Total"; // Show grand total
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void txtReportNameName_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerData();

        }
    }




}


