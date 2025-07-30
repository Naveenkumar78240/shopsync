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
    public partial class FormLogin : Form
    {
        private bool isPasswordVisible = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Connection string to the SQL Server database
            string connectionString = "Data Source=SIVAKUMAR\\SQLEXPRESS;Initial Catalog=nikaa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to check the username and password
                    string query = "SELECT COUNT(1) FROM  navv WHERE Userr_Name = @Username AND Userr_Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            // Open main form on successful login
                            FormMain form = new FormMain();
                            form.name = txtUsername.Text;
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void forgotpassword_Click(object sender, EventArgs e)
        {
            Formgotpassword formgotPassword = new Formgotpassword();
            formgotPassword.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void picshow_Click(object sender, EventArgs e)
        {
            if (picshow.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                picshow.Visible = false;
                picHide.Visible = true;
            }
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = true;
                picshow.Visible = true;
                picHide.Visible = false;
            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        
    }
}
