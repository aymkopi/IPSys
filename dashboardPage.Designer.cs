namespace IPSys
{
    partial class dashboardPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboardPage));
            gridPanel1 = new AntdUI.GridPanel();
            panel5 = new AntdUI.Panel();
            sortEventsBtn = new AntdUI.Select();
            EventsTable = new AntdUI.Table();
            label10 = new AntdUI.Label();
            panel4 = new AntdUI.Panel();
            monthlyEarningsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label9 = new AntdUI.Label();
            panel3 = new AntdUI.Panel();
            BookingsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label8 = new AntdUI.Label();
            panel2 = new AntdUI.Panel();
            totalRevenueLbl = new AntdUI.Label();
            totalStaffLbl = new AntdUI.Label();
            label7 = new AntdUI.Label();
            totalBookingsLbl = new AntdUI.Label();
            avatar4 = new AntdUI.Avatar();
            label5 = new AntdUI.Label();
            totalClientsLbl = new AntdUI.Label();
            avatar3 = new AntdUI.Avatar();
            label3 = new AntdUI.Label();
            label1 = new AntdUI.Label();
            avatar2 = new AntdUI.Avatar();
            avatar1 = new AntdUI.Avatar();
            avatarIcon = new AntdUI.Avatar();
            searchBar = new AntdUI.Input();
            panel1 = new AntdUI.Panel();
            label11 = new AntdUI.Label();
            ClientsTable = new AntdUI.Table();
            panel6 = new AntdUI.Panel();
            gridPanel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // gridPanel1
            // 
            gridPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPanel1.BackColor = Color.Transparent;
            gridPanel1.Controls.Add(panel6);
            gridPanel1.Controls.Add(panel5);
            gridPanel1.Controls.Add(panel4);
            gridPanel1.Controls.Add(panel3);
            gridPanel1.Gap = 6;
            gridPanel1.Location = new Point(19, 241);
            gridPanel1.Name = "gridPanel1";
            gridPanel1.Size = new Size(1036, 466);
            gridPanel1.Span = "70% 30%;70% 30%";
            gridPanel1.TabIndex = 8;
            gridPanel1.Text = "gridPanel1";
            // 
            // panel5
            // 
            panel5.Controls.Add(sortEventsBtn);
            panel5.Controls.Add(EventsTable);
            panel5.Controls.Add(label10);
            panel5.Location = new Point(9, 242);
            panel5.Name = "panel5";
            panel5.Shadow = 5;
            panel5.Size = new Size(707, 215);
            panel5.TabIndex = 2;
            panel5.Text = "panel5";
            // 
            // sortEventsBtn
            // 
            sortEventsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sortEventsBtn.BorderWidth = 0F;
            sortEventsBtn.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sortEventsBtn.HandDragFolder = false;
            sortEventsBtn.Items.AddRange(new object[] { "Name", "Incoming" });
            sortEventsBtn.Location = new Point(528, 14);
            sortEventsBtn.Name = "sortEventsBtn";
            sortEventsBtn.PlaceholderText = "Sort";
            sortEventsBtn.Round = true;
            sortEventsBtn.SelectionColor = Color.Transparent;
            sortEventsBtn.Size = new Size(163, 31);
            sortEventsBtn.TabIndex = 19;
            sortEventsBtn.TextAlign = HorizontalAlignment.Right;
            sortEventsBtn.SelectedIndexChanged += sortEventsBtn_SelectedIndexChanged;
            // 
            // EventsTable
            // 
            EventsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EventsTable.DefaultExpand = true;
            EventsTable.Empty = false;
            EventsTable.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EventsTable.Gap = 20;
            EventsTable.Location = new Point(20, 51);
            EventsTable.Name = "EventsTable";
            EventsTable.Size = new Size(668, 147);
            EventsTable.TabIndex = 17;
            EventsTable.Text = "incomingBookings";
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(29, 16);
            label10.Name = "label10";
            label10.Size = new Size(219, 29);
            label10.TabIndex = 16;
            label10.Text = "Events";
            // 
            // panel4
            // 
            panel4.Controls.Add(monthlyEarningsChart);
            panel4.Controls.Add(label9);
            panel4.Location = new Point(734, 9);
            panel4.Name = "panel4";
            panel4.Shadow = 5;
            panel4.Size = new Size(293, 215);
            panel4.TabIndex = 1;
            panel4.Text = "panel4";
            // 
            // monthlyEarningsChart
            // 
            monthlyEarningsChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            monthlyEarningsChart.BackColor = Color.Transparent;
            monthlyEarningsChart.BackgroundImageLayout = ImageLayout.None;
            monthlyEarningsChart.Location = new Point(24, 53);
            monthlyEarningsChart.MatchAxesScreenDataRatio = false;
            monthlyEarningsChart.Name = "monthlyEarningsChart";
            monthlyEarningsChart.Size = new Size(248, 141);
            monthlyEarningsChart.TabIndex = 17;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(24, 18);
            label9.Name = "label9";
            label9.Size = new Size(184, 29);
            label9.TabIndex = 16;
            label9.Text = "Earnings";
            // 
            // panel3
            // 
            panel3.Controls.Add(BookingsChart);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(9, 9);
            panel3.Name = "panel3";
            panel3.Shadow = 5;
            panel3.Size = new Size(707, 215);
            panel3.TabIndex = 0;
            panel3.Text = "'";
            // 
            // BookingsChart
            // 
            BookingsChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BookingsChart.BackColor = Color.Transparent;
            BookingsChart.BackgroundImageLayout = ImageLayout.None;
            BookingsChart.Location = new Point(20, 53);
            BookingsChart.MatchAxesScreenDataRatio = false;
            BookingsChart.Name = "BookingsChart";
            BookingsChart.Size = new Size(668, 141);
            BookingsChart.TabIndex = 16;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(29, 18);
            label8.Name = "label8";
            label8.Size = new Size(219, 29);
            label8.TabIndex = 15;
            label8.Text = "Bookings";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(totalRevenueLbl);
            panel2.Controls.Add(totalStaffLbl);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(totalBookingsLbl);
            panel2.Controls.Add(avatar4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(totalClientsLbl);
            panel2.Controls.Add(avatar3);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(avatar2);
            panel2.Controls.Add(avatar1);
            panel2.Location = new Point(27, 125);
            panel2.Name = "panel2";
            panel2.Shadow = 5;
            panel2.Size = new Size(1019, 101);
            panel2.TabIndex = 7;
            panel2.Text = "panel2";
            // 
            // totalRevenueLbl
            // 
            totalRevenueLbl.Anchor = AnchorStyles.None;
            totalRevenueLbl.BackColor = Color.Transparent;
            totalRevenueLbl.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalRevenueLbl.Location = new Point(788, 46);
            totalRevenueLbl.Name = "totalRevenueLbl";
            totalRevenueLbl.Size = new Size(120, 29);
            totalRevenueLbl.TabIndex = 14;
            totalRevenueLbl.Text = "245";
            // 
            // totalStaffLbl
            // 
            totalStaffLbl.Anchor = AnchorStyles.None;
            totalStaffLbl.BackColor = Color.Transparent;
            totalStaffLbl.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalStaffLbl.Location = new Point(599, 46);
            totalStaffLbl.Name = "totalStaffLbl";
            totalStaffLbl.Size = new Size(120, 29);
            totalStaffLbl.TabIndex = 11;
            totalStaffLbl.Text = "245";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(788, 25);
            label7.Name = "label7";
            label7.Size = new Size(120, 29);
            label7.TabIndex = 12;
            label7.Text = "Revenue";
            // 
            // totalBookingsLbl
            // 
            totalBookingsLbl.Anchor = AnchorStyles.None;
            totalBookingsLbl.BackColor = Color.Transparent;
            totalBookingsLbl.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalBookingsLbl.Location = new Point(387, 46);
            totalBookingsLbl.Name = "totalBookingsLbl";
            totalBookingsLbl.Size = new Size(120, 29);
            totalBookingsLbl.TabIndex = 8;
            totalBookingsLbl.Text = "245";
            // 
            // avatar4
            // 
            avatar4.Anchor = AnchorStyles.None;
            avatar4.Image = Properties.Resources._4;
            avatar4.Location = new Point(725, 25);
            avatar4.Name = "avatar4";
            avatar4.Round = true;
            avatar4.Size = new Size(50, 50);
            avatar4.TabIndex = 13;
            avatar4.Text = "";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(599, 25);
            label5.Name = "label5";
            label5.Size = new Size(120, 29);
            label5.TabIndex = 9;
            label5.Text = "Total Staff";
            // 
            // totalClientsLbl
            // 
            totalClientsLbl.Anchor = AnchorStyles.None;
            totalClientsLbl.BackColor = Color.Transparent;
            totalClientsLbl.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalClientsLbl.Location = new Point(207, 46);
            totalClientsLbl.Name = "totalClientsLbl";
            totalClientsLbl.Size = new Size(111, 29);
            totalClientsLbl.TabIndex = 5;
            totalClientsLbl.Text = "245";
            // 
            // avatar3
            // 
            avatar3.Anchor = AnchorStyles.None;
            avatar3.Image = Properties.Resources._3;
            avatar3.Location = new Point(536, 25);
            avatar3.Name = "avatar3";
            avatar3.Round = true;
            avatar3.Size = new Size(50, 50);
            avatar3.TabIndex = 10;
            avatar3.Text = "";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(387, 25);
            label3.Name = "label3";
            label3.Size = new Size(139, 29);
            label3.TabIndex = 6;
            label3.Text = "Total Bookings";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(207, 25);
            label1.Name = "label1";
            label1.Size = new Size(101, 29);
            label1.TabIndex = 4;
            label1.Text = "Total Clients";
            // 
            // avatar2
            // 
            avatar2.Anchor = AnchorStyles.None;
            avatar2.Image = Properties.Resources._2;
            avatar2.Location = new Point(324, 25);
            avatar2.Name = "avatar2";
            avatar2.Round = true;
            avatar2.Size = new Size(50, 50);
            avatar2.TabIndex = 7;
            avatar2.Text = "";
            // 
            // avatar1
            // 
            avatar1.Anchor = AnchorStyles.None;
            avatar1.Image = Properties.Resources._1;
            avatar1.ImageFit = AntdUI.TFit.Fill;
            avatar1.Location = new Point(144, 25);
            avatar1.Name = "avatar1";
            avatar1.Round = true;
            avatar1.ShadowColor = SystemColors.ActiveCaptionText;
            avatar1.Size = new Size(50, 50);
            avatar1.TabIndex = 4;
            avatar1.Text = "";
            // 
            // avatarIcon
            // 
            avatarIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            avatarIcon.BackColor = Color.LightGray;
            avatarIcon.BadgeMode = true;
            avatarIcon.Image = Properties.Resources.Treasurer;
            avatarIcon.LoadingProgress = 1F;
            avatarIcon.Location = new Point(948, 33);
            avatarIcon.Name = "avatarIcon";
            avatarIcon.Round = true;
            avatarIcon.ShadowOffsetY = 3;
            avatarIcon.Size = new Size(50, 50);
            avatarIcon.TabIndex = 6;
            avatarIcon.Text = "";
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBar.IconRatio = 1F;
            searchBar.Location = new Point(35, 33);
            searchBar.Name = "searchBar";
            searchBar.PlaceholderText = " Search anything";
            searchBar.Prefix = (Image)resources.GetObject("searchBar.Prefix");
            searchBar.Radius = 15;
            searchBar.Round = true;
            searchBar.Size = new Size(881, 50);
            searchBar.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(searchBar);
            panel1.Controls.Add(avatarIcon);
            panel1.Location = new Point(27, -8);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5, 0, 0, 0);
            panel1.Shadow = 5;
            panel1.Size = new Size(1075, 116);
            panel1.TabIndex = 9;
            panel1.Text = "panel1";
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(24, 16);
            label11.Name = "label11";
            label11.Size = new Size(219, 29);
            label11.TabIndex = 17;
            label11.Text = "Clients";
            // 
            // ClientsTable
            // 
            ClientsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ClientsTable.Empty = false;
            ClientsTable.Location = new Point(24, 51);
            ClientsTable.Name = "ClientsTable";
            ClientsTable.Size = new Size(248, 147);
            ClientsTable.TabIndex = 18;
            ClientsTable.Text = "clientReviews";
            // 
            // panel6
            // 
            panel6.Controls.Add(ClientsTable);
            panel6.Controls.Add(label11);
            panel6.Location = new Point(734, 242);
            panel6.Name = "panel6";
            panel6.Shadow = 5;
            panel6.Size = new Size(293, 215);
            panel6.TabIndex = 3;
            panel6.Text = "panel6";
            // 
            // dashboardPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImage = Properties.Resources.Untitled_design;
            ClientSize = new Size(1084, 719);
            Controls.Add(gridPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboardPage";
            Text = "Form1";
            gridPanel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.GridPanel gridPanel1;
        private AntdUI.Panel panel5;
        private AntdUI.Panel panel4;
        private AntdUI.Panel panel3;
        private AntdUI.Panel panel2;
        private AntdUI.Label totalBookingsLbl;
        private AntdUI.Avatar avatar4;
        private AntdUI.Label totalClientsLbl;
        private AntdUI.Avatar avatar3;
        private AntdUI.Label label3;
        private AntdUI.Label label1;
        private AntdUI.Avatar avatar2;
        private AntdUI.Avatar avatar1;
        private AntdUI.Avatar avatarIcon;
        private AntdUI.Input searchBar;
        private AntdUI.Label totalRevenueLbl;
        private AntdUI.Label totalStaffLbl;
        private AntdUI.Label label7;
        private AntdUI.Label label5;
        private AntdUI.Panel panel1;
        private AntdUI.Label label8;
        private AntdUI.Label label9;
        private AntdUI.Label label10;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart BookingsChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart monthlyEarningsChart;
        private AntdUI.Table EventsTable;
        private AntdUI.Select sortEventsBtn;
        private AntdUI.Panel panel6;
        private AntdUI.Table ClientsTable;
        private AntdUI.Label label11;
    }
}