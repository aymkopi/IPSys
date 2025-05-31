using AntdUI;
using Panel = System.Windows.Forms.Panel;

namespace IPSys
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            NavigationBarPanel = new AntdUI.Panel();
            pictureBox1 = new PictureBox();
            employeesBtn = new AntdUI.Button();
            servicesBtn = new AntdUI.Button();
            clientsBtn = new AntdUI.Button();
            bookingsBtn = new AntdUI.Button();
            dashboardBtn = new AntdUI.Button();
            logoutBtn = new AntdUI.Button();
            mainPanel = new Panel();
            pageHeader1 = new PageHeader();
            NavigationBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // NavigationBarPanel
            // 
            NavigationBarPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            NavigationBarPanel.Controls.Add(pictureBox1);
            NavigationBarPanel.Controls.Add(employeesBtn);
            NavigationBarPanel.Controls.Add(servicesBtn);
            NavigationBarPanel.Controls.Add(clientsBtn);
            NavigationBarPanel.Controls.Add(bookingsBtn);
            NavigationBarPanel.Controls.Add(dashboardBtn);
            NavigationBarPanel.Controls.Add(logoutBtn);
            NavigationBarPanel.Location = new Point(-10, 33);
            NavigationBarPanel.Name = "NavigationBarPanel";
            NavigationBarPanel.Shadow = 10;
            NavigationBarPanel.Size = new Size(298, 658);
            NavigationBarPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources._1635765441091;
            pictureBox1.Location = new Point(71, 64);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(142, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // employeesBtn
            // 
            employeesBtn.Anchor = AnchorStyles.Top;
            employeesBtn.Font = new Font("Poppins", 11.25F, FontStyle.Bold);
            employeesBtn.Location = new Point(41, 290);
            employeesBtn.Name = "employeesBtn";
            employeesBtn.Shape = TShape.Round;
            employeesBtn.Size = new Size(207, 63);
            employeesBtn.TabIndex = 5;
            employeesBtn.Text = "Employees";
            employeesBtn.ToggleType = TTypeMini.Primary;
            employeesBtn.Click += employeesBtn_Click;
            // 
            // servicesBtn
            // 
            servicesBtn.Anchor = AnchorStyles.Top;
            servicesBtn.Font = new Font("Poppins", 11.25F, FontStyle.Bold);
            servicesBtn.Location = new Point(41, 430);
            servicesBtn.Name = "servicesBtn";
            servicesBtn.Shape = TShape.Round;
            servicesBtn.Size = new Size(207, 63);
            servicesBtn.TabIndex = 4;
            servicesBtn.Text = "Services";
            servicesBtn.ToggleType = TTypeMini.Primary;
            servicesBtn.Click += servicesBtn_Click;
            // 
            // clientsBtn
            // 
            clientsBtn.Anchor = AnchorStyles.Top;
            clientsBtn.Font = new Font("Poppins", 11.25F, FontStyle.Bold);
            clientsBtn.Location = new Point(41, 360);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Shape = TShape.Round;
            clientsBtn.Size = new Size(207, 63);
            clientsBtn.TabIndex = 3;
            clientsBtn.Text = "Clients";
            clientsBtn.ToggleType = TTypeMini.Primary;
            clientsBtn.Click += clientsBtn_Click;
            // 
            // bookingsBtn
            // 
            bookingsBtn.Anchor = AnchorStyles.Top;
            bookingsBtn.Font = new Font("Poppins", 11.25F, FontStyle.Bold);
            bookingsBtn.Location = new Point(41, 220);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Shape = TShape.Round;
            bookingsBtn.Size = new Size(207, 63);
            bookingsBtn.TabIndex = 2;
            bookingsBtn.Text = "Bookings";
            bookingsBtn.Click += bookingsBtn_Click;
            // 
            // dashboardBtn
            // 
            dashboardBtn.Anchor = AnchorStyles.Top;
            dashboardBtn.Font = new Font("Poppins", 11.25F, FontStyle.Bold);
            dashboardBtn.Location = new Point(41, 150);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Shape = TShape.Round;
            dashboardBtn.Size = new Size(207, 63);
            dashboardBtn.TabIndex = 1;
            dashboardBtn.Text = "Dashboard";
            dashboardBtn.Toggle = true;
            dashboardBtn.ToggleType = TTypeMini.Primary;
            dashboardBtn.Click += dashboardBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            logoutBtn.BackActive = Color.Red;
            logoutBtn.Icon = Properties.Resources.logout_100dp_000000_FILL0_wght400_GRAD0_opsz48;
            logoutBtn.IconRatio = 1F;
            logoutBtn.Location = new Point(22, 586);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(60, 50);
            logoutBtn.TabIndex = 0;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Location = new Point(284, 33);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(982, 648);
            mainPanel.TabIndex = 6;
            // 
            // pageHeader1
            // 
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pageHeader1.Location = new Point(0, 0);
            pageHeader1.Name = "pageHeader1";
            pageHeader1.ShowButton = true;
            pageHeader1.ShowIcon = true;
            pageHeader1.Size = new Size(1264, 35);
            pageHeader1.TabIndex = 0;
            pageHeader1.Text = "HH Production Booking and Management System";
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1264, 681);
            ControlBox = false;
            Controls.Add(pageHeader1);
            Controls.Add(mainPanel);
            Controls.Add(NavigationBarPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HH Production Booking System";
            WindowState = FormWindowState.Maximized;
            NavigationBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Panel NavigationBarPanel;
        private AntdUI.Button employeesBtn;
        private AntdUI.Button servicesBtn;
        private AntdUI.Button clientsBtn;
        private AntdUI.Button bookingsBtn;
        private AntdUI.Button dashboardBtn;
        private AntdUI.Button logoutBtn;
        private Panel mainPanel;
        private PageHeader pageHeader1;
        private PictureBox pictureBox1;
    }
}
