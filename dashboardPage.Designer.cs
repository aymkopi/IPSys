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
            panel6 = new AntdUI.Panel();
            table2 = new AntdUI.Table();
            label11 = new AntdUI.Label();
            panel5 = new AntdUI.Panel();
            table1 = new AntdUI.Table();
            label10 = new AntdUI.Label();
            panel4 = new AntdUI.Panel();
            bookingsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label9 = new AntdUI.Label();
            panel3 = new AntdUI.Panel();
            clientsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            label8 = new AntdUI.Label();
            panel2 = new AntdUI.Panel();
            label6 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            label7 = new AntdUI.Label();
            label2 = new AntdUI.Label();
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
            gridPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
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
            gridPanel1.Size = new Size(1046, 459);
            gridPanel1.Span = "70% 30%;70% 30%";
            gridPanel1.TabIndex = 8;
            gridPanel1.Text = "gridPanel1";
            // 
            // panel6
            // 
            panel6.Controls.Add(table2);
            panel6.Controls.Add(label11);
            panel6.Location = new Point(741, 238);
            panel6.Name = "panel6";
            panel6.Shadow = 5;
            panel6.Size = new Size(296, 211);
            panel6.TabIndex = 3;
            panel6.Text = "panel6";
            // 
            // table2
            // 
            table2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table2.Empty = false;
            table2.Location = new Point(24, 51);
            table2.Name = "table2";
            table2.Size = new Size(251, 143);
            table2.TabIndex = 18;
            table2.Text = "clientReviews";
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(24, 16);
            label11.Name = "label11";
            label11.Size = new Size(219, 29);
            label11.TabIndex = 17;
            label11.Text = "Client Reviews";
            // 
            // panel5
            // 
            panel5.Controls.Add(table1);
            panel5.Controls.Add(label10);
            panel5.Location = new Point(9, 238);
            panel5.Name = "panel5";
            panel5.Shadow = 5;
            panel5.Size = new Size(714, 211);
            panel5.TabIndex = 2;
            panel5.Text = "panel5";
            // 
            // table1
            // 
            table1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table1.Empty = false;
            table1.Location = new Point(20, 51);
            table1.Name = "table1";
            table1.Size = new Size(675, 143);
            table1.TabIndex = 17;
            table1.Text = "incomingBookings";
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(29, 16);
            label10.Name = "label10";
            label10.Size = new Size(219, 29);
            label10.TabIndex = 16;
            label10.Text = "Incoming Bookings";
            // 
            // panel4
            // 
            panel4.Controls.Add(bookingsChart);
            panel4.Controls.Add(label9);
            panel4.Location = new Point(741, 9);
            panel4.Name = "panel4";
            panel4.Shadow = 5;
            panel4.Size = new Size(296, 211);
            panel4.TabIndex = 1;
            panel4.Text = "panel4";
            // 
            // bookingsChart
            // 
            bookingsChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bookingsChart.BackColor = Color.Transparent;
            bookingsChart.BackgroundImageLayout = ImageLayout.None;
            bookingsChart.Location = new Point(24, 53);
            bookingsChart.MatchAxesScreenDataRatio = false;
            bookingsChart.Name = "bookingsChart";
            bookingsChart.Size = new Size(251, 137);
            bookingsChart.TabIndex = 17;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(24, 18);
            label9.Name = "label9";
            label9.Size = new Size(184, 29);
            label9.TabIndex = 16;
            label9.Text = "Bookings";
            // 
            // panel3
            // 
            panel3.Controls.Add(clientsChart);
            panel3.Controls.Add(label8);
            panel3.Location = new Point(9, 9);
            panel3.Name = "panel3";
            panel3.Shadow = 5;
            panel3.Size = new Size(714, 211);
            panel3.TabIndex = 0;
            panel3.Text = "panel3";
            // 
            // clientsChart
            // 
            clientsChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientsChart.BackColor = Color.Transparent;
            clientsChart.BackgroundImageLayout = ImageLayout.None;
            clientsChart.Location = new Point(20, 53);
            clientsChart.MatchAxesScreenDataRatio = false;
            clientsChart.Name = "clientsChart";
            clientsChart.Size = new Size(675, 137);
            clientsChart.TabIndex = 16;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(29, 18);
            label8.Name = "label8";
            label8.Size = new Size(219, 29);
            label8.TabIndex = 15;
            label8.Text = "Clients";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label2);
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
            panel2.Size = new Size(1029, 101);
            panel2.TabIndex = 7;
            panel2.Text = "panel2";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(793, 46);
            label6.Name = "label6";
            label6.Size = new Size(120, 29);
            label6.TabIndex = 14;
            label6.Text = "245";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(604, 46);
            label4.Name = "label4";
            label4.Size = new Size(120, 29);
            label4.TabIndex = 11;
            label4.Text = "245";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(793, 25);
            label7.Name = "label7";
            label7.Size = new Size(120, 29);
            label7.TabIndex = 12;
            label7.Text = "Revenue";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Poppins ExtraBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(392, 46);
            label2.Name = "label2";
            label2.Size = new Size(120, 29);
            label2.TabIndex = 8;
            label2.Text = "245";
            // 
            // avatar4
            // 
            avatar4.Anchor = AnchorStyles.None;
            avatar4.BackColor = Color.IndianRed;
            avatar4.Location = new Point(730, 25);
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
            label5.Location = new Point(604, 25);
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
            totalClientsLbl.Location = new Point(212, 46);
            totalClientsLbl.Name = "totalClientsLbl";
            totalClientsLbl.Size = new Size(111, 29);
            totalClientsLbl.TabIndex = 5;
            totalClientsLbl.Text = "245";
            // 
            // avatar3
            // 
            avatar3.Anchor = AnchorStyles.None;
            avatar3.BackColor = Color.IndianRed;
            avatar3.Location = new Point(541, 25);
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
            label3.Location = new Point(392, 25);
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
            label1.Location = new Point(212, 25);
            label1.Name = "label1";
            label1.Size = new Size(101, 29);
            label1.TabIndex = 4;
            label1.Text = "Total Clients";
            // 
            // avatar2
            // 
            avatar2.Anchor = AnchorStyles.None;
            avatar2.BackColor = Color.IndianRed;
            avatar2.Location = new Point(329, 25);
            avatar2.Name = "avatar2";
            avatar2.Round = true;
            avatar2.Size = new Size(50, 50);
            avatar2.TabIndex = 7;
            avatar2.Text = "";
            // 
            // avatar1
            // 
            avatar1.Anchor = AnchorStyles.None;
            avatar1.BackColor = Color.IndianRed;
            avatar1.Location = new Point(149, 25);
            avatar1.Name = "avatar1";
            avatar1.Round = true;
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
            avatarIcon.Location = new Point(958, 33);
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
            searchBar.Size = new Size(891, 50);
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
            panel1.Size = new Size(1085, 116);
            panel1.TabIndex = 9;
            panel1.Text = "panel1";
            // 
            // dashboardPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1094, 712);
            Controls.Add(gridPanel1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboardPage";
            Text = "Form1";
            gridPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.GridPanel gridPanel1;
        private AntdUI.Panel panel6;
        private AntdUI.Panel panel5;
        private AntdUI.Panel panel4;
        private AntdUI.Panel panel3;
        private AntdUI.Panel panel2;
        private AntdUI.Label label2;
        private AntdUI.Avatar avatar4;
        private AntdUI.Label totalClientsLbl;
        private AntdUI.Avatar avatar3;
        private AntdUI.Label label3;
        private AntdUI.Label label1;
        private AntdUI.Avatar avatar2;
        private AntdUI.Avatar avatar1;
        private AntdUI.Avatar avatarIcon;
        private AntdUI.Input searchBar;
        private AntdUI.Label label6;
        private AntdUI.Label label4;
        private AntdUI.Label label7;
        private AntdUI.Label label5;
        private AntdUI.Panel panel1;
        private AntdUI.Label label8;
        private AntdUI.Label label9;
        private AntdUI.Label label11;
        private AntdUI.Label label10;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart clientsChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart bookingsChart;
        private AntdUI.Table table1;
        private AntdUI.Table table2;
    }
}