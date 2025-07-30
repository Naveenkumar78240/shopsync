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
    public partial class Formgotpassword : Form
    {
        public Formgotpassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            // Connection string to the SQL Server database
            string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to retrieve the password for the given email
                    string query = "SELECT Userr_Password FROM navv WHERE Userr_Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string password = result.ToString();
                            MessageBox.Show($"Your password is: {password}", "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Email not found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
    }

