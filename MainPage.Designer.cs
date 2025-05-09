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
            NavigationBarPanel = new AntdUI.Panel();
            reviewsBtn = new AntdUI.Button();
            employeesBtn = new AntdUI.Button();
            earningsBtn = new AntdUI.Button();
            clientsBtn = new AntdUI.Button();
            bookingsBtn = new AntdUI.Button();
            dashboardBtn = new AntdUI.Button();
            logoutBtn = new AntdUI.Button();
            mainPanel = new Panel();
            NavigationBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavigationBarPanel
            // 
            NavigationBarPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            NavigationBarPanel.Controls.Add(reviewsBtn);
            NavigationBarPanel.Controls.Add(employeesBtn);
            NavigationBarPanel.Controls.Add(earningsBtn);
            NavigationBarPanel.Controls.Add(clientsBtn);
            NavigationBarPanel.Controls.Add(bookingsBtn);
            NavigationBarPanel.Controls.Add(dashboardBtn);
            NavigationBarPanel.Controls.Add(logoutBtn);
            NavigationBarPanel.Location = new Point(-10, -13);
            NavigationBarPanel.Name = "NavigationBarPanel";
            NavigationBarPanel.Shadow = 10;
            NavigationBarPanel.Size = new Size(298, 704);
            NavigationBarPanel.TabIndex = 2;
            NavigationBarPanel.Click += NavigationBarPanel_Click;
            // 
            // reviewsBtn
            // 
            reviewsBtn.Anchor = AnchorStyles.Top;
            reviewsBtn.Location = new Point(65, 474);
            reviewsBtn.Name = "reviewsBtn";
            reviewsBtn.Shape = AntdUI.TShape.Round;
            reviewsBtn.Size = new Size(165, 39);
            reviewsBtn.TabIndex = 6;
            reviewsBtn.Text = "Reviews";
            reviewsBtn.ToggleType = AntdUI.TTypeMini.Primary;
            reviewsBtn.Click += reviewsBtn_Click;
            // 
            // employeesBtn
            // 
            employeesBtn.Anchor = AnchorStyles.Top;
            employeesBtn.Location = new Point(65, 275);
            employeesBtn.Name = "employeesBtn";
            employeesBtn.Shape = AntdUI.TShape.Round;
            employeesBtn.Size = new Size(165, 39);
            employeesBtn.TabIndex = 5;
            employeesBtn.Text = "Employees";
            employeesBtn.ToggleType = AntdUI.TTypeMini.Primary;
            employeesBtn.Click += employeesBtn_Click;
            // 
            // earningsBtn
            // 
            earningsBtn.Anchor = AnchorStyles.Top;
            earningsBtn.Location = new Point(65, 336);
            earningsBtn.Name = "earningsBtn";
            earningsBtn.Shape = AntdUI.TShape.Round;
            earningsBtn.Size = new Size(165, 39);
            earningsBtn.TabIndex = 4;
            earningsBtn.Text = "Earnings";
            earningsBtn.ToggleType = AntdUI.TTypeMini.Primary;
            earningsBtn.Click += earningsBtn_Click;
            
            // 
            // clientsBtn
            // 
            clientsBtn.Anchor = AnchorStyles.Top;
            clientsBtn.Location = new Point(65, 403);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Shape = AntdUI.TShape.Round;
            clientsBtn.Size = new Size(165, 39);
            clientsBtn.TabIndex = 3;
            clientsBtn.Text = "Clients";
            clientsBtn.ToggleType = AntdUI.TTypeMini.Primary;
            clientsBtn.Click += clientsBtn_Click;
            // 
            // bookingsBtn
            // 
            bookingsBtn.Anchor = AnchorStyles.Top;
            bookingsBtn.Location = new Point(65, 213);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Shape = AntdUI.TShape.Round;
            bookingsBtn.Size = new Size(165, 39);
            bookingsBtn.TabIndex = 2;
            bookingsBtn.Text = "Bookings";
            bookingsBtn.Click += bookingsBtn_Click;
            // 
            // dashboardBtn
            // 
            dashboardBtn.Anchor = AnchorStyles.Top;
            dashboardBtn.Location = new Point(65, 154);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Shape = AntdUI.TShape.Round;
            dashboardBtn.Size = new Size(165, 39);
            dashboardBtn.TabIndex = 1;
            dashboardBtn.Text = "Dashboard";
            dashboardBtn.Toggle = true;
            dashboardBtn.ToggleType = AntdUI.TTypeMini.Primary;
            dashboardBtn.Click += dashboardBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(71, 616);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(96, 30);
            logoutBtn.TabIndex = 0;
            logoutBtn.Text = "Log out";
            logoutBtn.Click += logoutBtn_Click;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Location = new Point(284, -2);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(982, 683);
            mainPanel.TabIndex = 6;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1264, 681);
            ControlBox = false;
            Controls.Add(mainPanel);
            Controls.Add(NavigationBarPanel);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HH Production Booking System";
            WindowState = FormWindowState.Maximized;
            NavigationBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Panel NavigationBarPanel;
        private AntdUI.Button reviewsBtn;
        private AntdUI.Button employeesBtn;
        private AntdUI.Button earningsBtn;
        private AntdUI.Button clientsBtn;
        private AntdUI.Button bookingsBtn;
        private AntdUI.Button dashboardBtn;
        private AntdUI.Button logoutBtn;
        private Panel mainPanel;
    }
}
