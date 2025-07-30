using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_shop_management.pal
{
    public partial class FormMain : Form
    {
        public string name = "{?}";

        public FormMain()
        {
            InitializeComponent();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            movepanel(btndashboard);
          
            userControlBrand1.Visible = false;
            userControlDashboard2.Visible = true;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlusers1.Visible = false;


        }
        private void movepanel(Control btn)
        {
            pnlMove.Top = btn.Top;
            pnlMove.Height = btn.Height; 
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            lblusername.Text = name;
            timeanddate.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you want logout?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult==DialogResult.Yes)
            {
                movepanel(btnClose);
                timeanddate.Stop();
                Close();
            }
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            movepanel(btnBrand);
            userControlBrand1.Visible = true;
            userControlDashboard2.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlusers1.Visible = false;




        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            movepanel(btnCategory);
            userControlBrand1.Visible = false;
            userControlDashboard2.Visible = false;
            userControlCategory1.Visible = true;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlusers1.Visible = false;






        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            movepanel(btnproduct);
            userControlBrand1.Visible = false;
            userControlDashboard2.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = true;
            userControlOrder1.Visible = false;
            userControlusers1.Visible = false;





        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            movepanel(btnorder);
            userControlBrand1.Visible = false;
            userControlCategory1.Visible =false;
           
            userControlDashboard2.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = true;
            userControlReport1.Visible = false;
            userControlusers1.Visible = false;





        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            movepanel(btnreport);
            userControlBrand1.Visible = false;
            userControlDashboard2.Visible = false;
            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = true;


        }

        private void btnsuer_Click(object sender, EventArgs e)
        {
            movepanel(btnsuer);
            userControlBrand1.Visible = false;
            userControlDashboard2.Visible = false;

            userControlCategory1.Visible = false;
            userControlProduct1.Visible = false;
            userControlOrder1.Visible = false;
            userControlReport1.Visible = false;
            userControlusers1.Visible = true;


        }

        private void dateandtime_Tick(object sender, EventArgs e)
        {
            dateandtime.Text = DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss");
        }
        

        private void userControlDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Hide the current form (MainForm / Dashboard)

                FormLogin loginForm = new FormLogin();
                loginForm.Show();

                // Close the current form after opening login
                this.Close();
            }

        }

        private void userControlDashboard1_Load_1(object sender, EventArgs e)
        {

        }

        private void userControlBrand1_Load(object sender, EventArgs e)
        {

        }

        private void userControlBrand2_Load(object sender, EventArgs e)
        {

        }

        private void userControlCategory1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControlCategory2_Load(object sender, EventArgs e)
        {

        }

        private void userControlProduct1_Load(object sender, EventArgs e)
        {

        }

        private void userControlProduct1_Load_1(object sender, EventArgs e)
        {

        }

        private void userControlProduct1_Load_2(object sender, EventArgs e)
        {

        }

        private void userControlProduct1_Load_3(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void userControlProduct1_Load_4(object sender, EventArgs e)
        {

        }

        private void userControlReport1_Load(object sender, EventArgs e)
        {

        }

        private void userControlusers1_Load(object sender, EventArgs e)
        {

        }
    }
}

