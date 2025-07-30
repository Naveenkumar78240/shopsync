using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace Computer_shop_management.pal
{
    public partial class UserControlOrder : UserControl
    {
        private string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";
        public UserControlOrder()
        {
            InitializeComponent();
            LoadOrders();
            LoadProducts();
            LoadProductList();
        
            }

        private void tpAddOrder_Click(object sender, EventArgs e)
        {

        }
        private void LoadOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders ORDER BY Orders_Id DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvOrders.AutoGenerateColumns = false; // Prevent auto-column mismatch
                dgvOrders.DataSource = dt;

                if (!dgvOrders.Columns.Contains("Payment_Status"))
                {
                    DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
                    statusColumn.Name = "Payment_Status";
                    statusColumn.HeaderText = "Payment Status";
                    statusColumn.DataPropertyName = "Payment_Status";
                    dgvOrders.Columns.Add(statusColumn);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string orderQuery = @"
        INSERT INTO Orders (Orders_Date, Customer_Name, Customer_Number, Total_Amount, Paid_Amount, Due_Amount, Discount, Grand_Total, Payment_Status) 
        VALUES (@date, @name, @number, @total, @paid, @due, @discount, @grand, @status);
        SELECT SCOPE_IDENTITY();";  // Get last inserted Order ID

                    using (SqlCommand orderCmd = new SqlCommand(orderQuery, conn, transaction))
                    {
                        orderCmd.Parameters.AddWithValue("@date", dtpDate.Value);
                        orderCmd.Parameters.AddWithValue("@name", txtCustomername1.Text.Trim());
                        orderCmd.Parameters.AddWithValue("@number", mtbCustomerNumber.Text.Trim());
                        orderCmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                        orderCmd.Parameters.AddWithValue("@paid", Convert.ToDecimal(numPaidAmount.Text));
                        orderCmd.Parameters.AddWithValue("@due", Convert.ToDecimal(txtDueAmount.Text));
                        orderCmd.Parameters.AddWithValue("@discount", Convert.ToDecimal(numDiscountAmount.Text));
                        orderCmd.Parameters.AddWithValue("@grand", Convert.ToDecimal(txtGrandTotal.Text));

                        // ✅ Fix: Handle null value for cmbStatus1
                        string paymentStatus = cmbStatus1.SelectedItem?.ToString() ?? "Pending";
                        orderCmd.Parameters.AddWithValue("@status", paymentStatus);

                        lastOrderId = Convert.ToInt32(orderCmd.ExecuteScalar()); // Get Order ID
                    }

                    transaction.Commit();
                    MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders(); // Refresh DataGridView
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }
        private int lastOrderId = 0; 
       

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintReceipt);
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            previewDialog.ShowDialog();


        }
        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            if (lastOrderId == 0)
            {
                MessageBox.Show("No order to print!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders WHERE Orders_Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", lastOrderId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Graphics g = e.Graphics;
                    Font font = new Font("Arial", 12);
                    Brush brush = Brushes.Black;
                    float yPos = 20;
                    float leftMargin = e.MarginBounds.Left;

                    g.DrawString("Order Receipt", new Font("Arial", 16, FontStyle.Bold), brush, leftMargin, yPos);
                    yPos += 40;
                    g.DrawString($"Order ID: {reader["Orders_Id"]}", font, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Date: {Convert.ToDateTime(reader["Orders_Date"]).ToString("dd/MM/yyyy")}", font, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Customer Name: {reader["Customer_Name"]}", font, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Total Amount: ${reader["Total_Amount"]}", font, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Paid Amount: ${reader["Paid_Amount"]}", font, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Due Amount: ${reader["Due_Amount"]}", font, brush, leftMargin, yPos);
                    yPos += 20;
                    g.DrawString($"Grand Total: ${reader["Grand_Total"]}", font, brush, leftMargin, yPos);
                    yPos += 40;
                    g.DrawString("Thank you for your purchase!", new Font("Arial", 14, FontStyle.Bold), brush, leftMargin, yPos);
                }

                reader.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null || string.IsNullOrWhiteSpace(txtRate.Text) || numQuantity.Value <= 0)
            {
                MessageBox.Show("Please select a product and enter a valid rate & quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productName = cmbProduct.Text;

            if (!decimal.TryParse(txtRate.Text, out decimal rate) || rate <= 0)
            {
                MessageBox.Show("Please enter a valid rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantity = (int)numQuantity.Value;
            decimal total = rate * quantity;

            // Check if the product already exists in DataGridView
            foreach (DataGridViewRow row in dgvProductList.Rows)
            {
                if (row.Cells["Product"].Value != null && row.Cells["Product"].Value.ToString() == productName)
                {
                    MessageBox.Show("Product already added! Modify quantity in the list.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Add row to DataGridView
            dgvProductList.Rows.Add(productName, rate, quantity, total, "Remove");

            // Update total amount
           

            // Reset fields
            cmbProduct.SelectedIndex = -1;
            txtRate.Clear();
            numQuantity.Value = 1;

        }
        


        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvProductList.Columns.Contains("Action"))
            {
                if (e.ColumnIndex == dgvProductList.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    dgvProductList.Rows.RemoveAt(e.RowIndex);
                   
                }
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcustomername2.Text))
            {
                MessageBox.Show("No customer name provided.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Orders WHERE Customer_Name = @customerName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerName", txtcustomername2.Text);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order removed successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                    else
                    {
                        MessageBox.Show("No order found for this customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }
        private void ClearOrderFields()
        {
            txtcustomername2.Clear();
            maskedTextBox2.Clear();
            txttotal2.Text = "0";
            numpaidamount2.Text = "0";
            numdueamount2.Text = "0";
            numdiscount2.Text = "0";
            numgrandtotal2.Text = "0";
            cmbstatus2.SelectedIndex = -1;
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Orders SET Paid_Amount = @paid, Due_Amount = @due, Payment_Status = @status WHERE Customer_Name = @customerName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customerName", txtcustomername2.Text.Trim());
                cmd.Parameters.AddWithValue("@paid", Convert.ToDecimal(numpaidamount2.Text));
                cmd.Parameters.AddWithValue("@due", Convert.ToDecimal(numdueamount2.Text));
                cmd.Parameters.AddWithValue("@status", cmbstatus2.SelectedItem?.ToString() ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadOrders();
            }




        }
        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Product_Name FROM Products";  // Fetch only product names
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProduct.DataSource = dt;
                cmbProduct.DisplayMember = "Product_Name"; // Show product names
                cmbProduct.ValueMember = "Product_Name";   // Store product names as values
            }
        }

        

        private void LoadProductList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Product_Name, Product_Rate FROM Products WHERE Product_Status = 'Available'";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProduct.DataSource = dt;
                    cmbProduct.DisplayMember = "Product_Name";
                    cmbProduct.ValueMember = "Product_Rate";
                    cmbProduct.SelectedIndex = -1; // Reset selection
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem != null)
            {
                DataRowView drv = cmbProduct.SelectedItem as DataRowView;
                if (drv != null)
                {
                   
                }
            }
        }


        

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True"))
            {
                string query = "SELECT COUNT(*) FROM Orders ";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                label16.Text = " " + count.ToString(); // Update label
            }

        }
    }
}
    

