
namespace Computer_shop_management.pal
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMove = new System.Windows.Forms.Panel();
            this.btnsuer = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.btnorder = new System.Windows.Forms.Button();
            this.btnproduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btndashboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateandtime = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeanddate = new System.Windows.Forms.Timer(this.components);
            this.userControlDashboard2 = new Computer_shop_management.pal.UserControlDashboard();
            this.userControlBrand1 = new Computer_shop_management.pal.UserControlBrand();
            this.userControlCategory1 = new Computer_shop_management.pal.UserControlCategory();
            this.userControlProduct1 = new Computer_shop_management.pal.UserControlProduct();
            this.userControlOrder1 = new Computer_shop_management.pal.UserControlOrder();
            this.userControlReport1 = new Computer_shop_management.pal.UserControlReport();
            this.userControlusers1 = new Computer_shop_management.pal.UserControlusers();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.pnlMove);
            this.panel1.Controls.Add(this.btnsuer);
            this.panel1.Controls.Add(this.btnreport);
            this.panel1.Controls.Add(this.btnorder);
            this.panel1.Controls.Add(this.btnproduct);
            this.panel1.Controls.Add(this.btnCategory);
            this.panel1.Controls.Add(this.btnBrand);
            this.panel1.Controls.Add(this.btndashboard);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 884);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(25, 822);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(244, 48);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Logout";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // pnlMove
            // 
            this.pnlMove.BackColor = System.Drawing.Color.White;
            this.pnlMove.Location = new System.Drawing.Point(0, 207);
            this.pnlMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMove.Name = "pnlMove";
            this.pnlMove.Size = new System.Drawing.Size(13, 47);
            this.pnlMove.TabIndex = 10;
            // 
            // btnsuer
            // 
            this.btnsuer.FlatAppearance.BorderSize = 0;
            this.btnsuer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsuer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsuer.ForeColor = System.Drawing.Color.White;
            this.btnsuer.Image = ((System.Drawing.Image)(resources.GetObject("btnsuer.Image")));
            this.btnsuer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsuer.Location = new System.Drawing.Point(33, 714);
            this.btnsuer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsuer.Name = "btnsuer";
            this.btnsuer.Size = new System.Drawing.Size(232, 89);
            this.btnsuer.TabIndex = 8;
            this.btnsuer.Text = "Users";
            this.btnsuer.UseVisualStyleBackColor = true;
            this.btnsuer.Click += new System.EventHandler(this.btnsuer_Click);
            // 
            // btnreport
            // 
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.Color.White;
            this.btnreport.Image = ((System.Drawing.Image)(resources.GetObject("btnreport.Image")));
            this.btnreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreport.Location = new System.Drawing.Point(25, 623);
            this.btnreport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(243, 73);
            this.btnreport.TabIndex = 7;
            this.btnreport.Text = "Report";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnorder
            // 
            this.btnorder.FlatAppearance.BorderSize = 0;
            this.btnorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnorder.ForeColor = System.Drawing.Color.White;
            this.btnorder.Image = ((System.Drawing.Image)(resources.GetObject("btnorder.Image")));
            this.btnorder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnorder.Location = new System.Drawing.Point(32, 532);
            this.btnorder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnorder.Name = "btnorder";
            this.btnorder.Size = new System.Drawing.Size(233, 86);
            this.btnorder.TabIndex = 6;
            this.btnorder.Text = "Order";
            this.btnorder.UseVisualStyleBackColor = true;
            this.btnorder.Click += new System.EventHandler(this.btnorder_Click);
            // 
            // btnproduct
            // 
            this.btnproduct.FlatAppearance.BorderSize = 0;
            this.btnproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproduct.ForeColor = System.Drawing.Color.White;
            this.btnproduct.Image = ((System.Drawing.Image)(resources.GetObject("btnproduct.Image")));
            this.btnproduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduct.Location = new System.Drawing.Point(25, 455);
            this.btnproduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnproduct.Name = "btnproduct";
            this.btnproduct.Size = new System.Drawing.Size(259, 84);
            this.btnproduct.TabIndex = 5;
            this.btnproduct.Text = " Product";
            this.btnproduct.UseVisualStyleBackColor = true;
            this.btnproduct.Click += new System.EventHandler(this.btnproduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(21, 368);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(263, 82);
            this.btnCategory.TabIndex = 4;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnBrand
            // 
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrand.ForeColor = System.Drawing.Color.White;
            this.btnBrand.Image = ((System.Drawing.Image)(resources.GetObject("btnBrand.Image")));
            this.btnBrand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrand.Location = new System.Drawing.Point(29, 299);
            this.btnBrand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Size = new System.Drawing.Size(251, 48);
            this.btnBrand.TabIndex = 3;
            this.btnBrand.Text = "   Brand";
            this.btnBrand.UseVisualStyleBackColor = true;
            this.btnBrand.Click += new System.EventHandler(this.btnBrand_Click);
            // 
            // btndashboard
            // 
            this.btndashboard.FlatAppearance.BorderSize = 0;
            this.btndashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndashboard.ForeColor = System.Drawing.Color.White;
            this.btndashboard.Image = ((System.Drawing.Image)(resources.GetObject("btndashboard.Image")));
            this.btndashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.Location = new System.Drawing.Point(33, 207);
            this.btndashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Size = new System.Drawing.Size(236, 64);
            this.btndashboard.TabIndex = 2;
            this.btndashboard.Text = "    DashBoard";
            this.btndashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndashboard.UseVisualStyleBackColor = true;
            this.btndashboard.Click += new System.EventHandler(this.btndashboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Computer shop management";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this.pnlMove;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.dateandtime);
            this.panel2.Controls.Add(this.lblusername);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(292, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 100);
            this.panel2.TabIndex = 1;
            // 
            // dateandtime
            // 
            this.dateandtime.AutoSize = true;
            this.dateandtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateandtime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateandtime.Location = new System.Drawing.Point(1088, 55);
            this.dateandtime.Name = "dateandtime";
            this.dateandtime.Size = new System.Drawing.Size(33, 20);
            this.dateandtime.TabIndex = 5;
            this.dateandtime.Text = "{?}";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblusername.Location = new System.Drawing.Point(152, 55);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(33, 20);
            this.lblusername.TabIndex = 3;
            this.lblusername.Text = "{?}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "WELCOME:";
            // 
            // timeanddate
            // 
            this.timeanddate.Enabled = true;
            this.timeanddate.Interval = 6000;
            this.timeanddate.Tick += new System.EventHandler(this.dateandtime_Tick);
            // 
            // userControlDashboard2
            // 
            this.userControlDashboard2.BackColor = System.Drawing.Color.White;
            this.userControlDashboard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDashboard2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlDashboard2.Location = new System.Drawing.Point(292, 100);
            this.userControlDashboard2.Margin = new System.Windows.Forms.Padding(5);
            this.userControlDashboard2.Name = "userControlDashboard2";
            this.userControlDashboard2.Size = new System.Drawing.Size(1264, 784);
            this.userControlDashboard2.TabIndex = 2;
            // 
            // userControlBrand1
            // 
            this.userControlBrand1.BackColor = System.Drawing.Color.White;
            this.userControlBrand1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlBrand1.Location = new System.Drawing.Point(292, 100);
            this.userControlBrand1.Margin = new System.Windows.Forms.Padding(5);
            this.userControlBrand1.Name = "userControlBrand1";
            this.userControlBrand1.Size = new System.Drawing.Size(1264, 784);
            this.userControlBrand1.TabIndex = 3;
            // 
            // userControlCategory1
            // 
            this.userControlCategory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlCategory1.Location = new System.Drawing.Point(292, 100);
            this.userControlCategory1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userControlCategory1.Name = "userControlCategory1";
            this.userControlCategory1.Size = new System.Drawing.Size(1264, 784);
            this.userControlCategory1.TabIndex = 4;
            // 
            // userControlProduct1
            // 
            this.userControlProduct1.BackColor = System.Drawing.Color.White;
            this.userControlProduct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlProduct1.Location = new System.Drawing.Point(292, 100);
            this.userControlProduct1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userControlProduct1.Name = "userControlProduct1";
            this.userControlProduct1.Size = new System.Drawing.Size(1264, 784);
            this.userControlProduct1.TabIndex = 5;
            // 
            // userControlOrder1
            // 
            this.userControlOrder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlOrder1.Location = new System.Drawing.Point(292, 100);
            this.userControlOrder1.Margin = new System.Windows.Forms.Padding(5);
            this.userControlOrder1.Name = "userControlOrder1";
            this.userControlOrder1.Size = new System.Drawing.Size(1264, 784);
            this.userControlOrder1.TabIndex = 6;
            // 
            // userControlReport1
            // 
            this.userControlReport1.BackColor = System.Drawing.Color.White;
            this.userControlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlReport1.Location = new System.Drawing.Point(292, 100);
            this.userControlReport1.Margin = new System.Windows.Forms.Padding(5);
            this.userControlReport1.Name = "userControlReport1";
            this.userControlReport1.Size = new System.Drawing.Size(1264, 784);
            this.userControlReport1.TabIndex = 7;
            // 
            // userControlusers1
            // 
            this.userControlusers1.BackColor = System.Drawing.Color.White;
            this.userControlusers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlusers1.Location = new System.Drawing.Point(292, 100);
            this.userControlusers1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userControlusers1.Name = "userControlusers1";
            this.userControlusers1.Size = new System.Drawing.Size(1264, 784);
            this.userControlusers1.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1556, 884);
            //this.Controls.Add(this.userControlusers1);
            //this.Controls.Add(this.userControlReport1);
            //this.Controls.Add(this.userControlOrder1);
            //this.Controls.Add(this.userControlProduct1);
            //this.Controls.Add(this.userControlCategory1);
            //this.Controls.Add(this.userControlBrand1);
            //this.Controls.Add(this.userControlDashboard2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Button btndashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.Button btnproduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Panel pnlMove;
        private System.Windows.Forms.Button btnsuer;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dateandtime;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.Timer lblTimeandDate;
        private System.Windows.Forms.Timer timeanddate;
        private System.Windows.Forms.Button btnClose;
        private UserControlDashboard userControlDashboard1;
        private UserControlDashboard userControlDashboard2;
        private UserControlBrand userControlBrand1;
        private UserControlCategory userControlCategory1;
        private UserControlProduct userControlProduct1;
        private UserControlOrder userControlOrder1;
        private UserControlReport userControlReport1;
        private UserControlusers userControlusers1;
        // private DataSet dataSet1;
        //private UserControlDashboard userControlDashboard1;
        //private UserControlBrand userControlBrand1;
        //private UserControlDashboard userControlDashboard2;
        //private UserControlBrand userControlBrand2;
        //private UserControlCategory userControlCategory1;
    }
}