namespace IPSys
{
    partial class bookingsPage
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
            label8 = new AntdUI.Label();
            panel1 = new AntdUI.Panel();
            calendar = new AntdUI.Calendar();
            panel2 = new AntdUI.Panel();
            stackPanel1 = new AntdUI.StackPanel();
            panel3 = new AntdUI.Panel();
            clientNameBookingLabel1 = new AntdUI.Label();
            eventNameBookingLabel1 = new AntdUI.Label();
            eventNameBookingLbl = new AntdUI.Label();
            label1 = new AntdUI.Label();
            divider1 = new AntdUI.Divider();
            timeLabel = new AntdUI.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            stackPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Poppins", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(52, 38);
            label8.Name = "label8";
            label8.Size = new Size(220, 50);
            label8.TabIndex = 16;
            label8.Text = "Calendar";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(calendar);
            panel1.Location = new Point(27, 94);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(605, 598);
            panel1.TabIndex = 17;
            panel1.Text = "panel1";
            // 
            // calendar
            // 
            calendar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar.BadgeSize = 4F;
            calendar.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calendar.Full = true;
            calendar.Location = new Point(25, 21);
            calendar.Name = "calendar";
            calendar.Size = new Size(560, 555);
            calendar.TabIndex = 0;
            calendar.Text = "calendar1";
            calendar.DateChanged += calendar1_DateChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.Controls.Add(stackPanel1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(divider1);
            panel2.Location = new Point(652, -5);
            panel2.Name = "panel2";
            panel2.Shadow = 5;
            panel2.Size = new Size(449, 724);
            panel2.TabIndex = 18;
            panel2.Text = "panel2";
            // 
            // stackPanel1
            // 
            stackPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            stackPanel1.BackColor = Color.Transparent;
            stackPanel1.Controls.Add(panel3);
            stackPanel1.Location = new Point(22, 84);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new Padding(5);
            stackPanel1.Size = new Size(408, 561);
            stackPanel1.TabIndex = 21;
            stackPanel1.Text = "stackPanel1";
            stackPanel1.Vertical = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(timeLabel);
            panel3.Controls.Add(clientNameBookingLabel1);
            panel3.Controls.Add(eventNameBookingLabel1);
            panel3.Controls.Add(eventNameBookingLbl);
            panel3.Location = new Point(8, 8);
            panel3.Name = "panel3";
            panel3.Shadow = 5;
            panel3.Size = new Size(392, 121);
            panel3.TabIndex = 0;
            panel3.Text = "panel3";
            // 
            // clientNameBookingLabel1
            // 
            clientNameBookingLabel1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientNameBookingLabel1.Location = new Point(23, 42);
            clientNameBookingLabel1.Name = "clientNameBookingLabel1";
            clientNameBookingLabel1.Size = new Size(231, 23);
            clientNameBookingLabel1.TabIndex = 1;
            clientNameBookingLabel1.Text = "Client";
            // 
            // eventNameBookingLabel1
            // 
            eventNameBookingLabel1.Font = new Font("Poppins Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventNameBookingLabel1.Location = new Point(23, 19);
            eventNameBookingLabel1.Name = "eventNameBookingLabel1";
            eventNameBookingLabel1.Size = new Size(329, 23);
            eventNameBookingLabel1.TabIndex = 0;
            eventNameBookingLabel1.Text = "Event Name";
            // 
            // eventNameBookingLbl
            // 
            eventNameBookingLbl.Font = new Font("Poppins Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventNameBookingLbl.Location = new Point(23, 19);
            eventNameBookingLbl.Name = "eventNameBookingLbl";
            eventNameBookingLbl.Size = new Size(75, 23);
            eventNameBookingLbl.TabIndex = 0;
            eventNameBookingLbl.Text = "label2";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 37);
            label1.Name = "label1";
            label1.Size = new Size(220, 28);
            label1.TabIndex = 19;
            label1.Text = "Bookings";
            // 
            // divider1
            // 
            divider1.BackColor = Color.Transparent;
            divider1.Location = new Point(31, 68);
            divider1.Name = "divider1";
            divider1.Orientation = AntdUI.TOrientation.Left;
            divider1.Size = new Size(387, 10);
            divider1.TabIndex = 20;
            divider1.Text = "";
            divider1.TextPadding = 0F;
            divider1.Thickness = 1.5F;
            // 
            // timeLabel
            // 
            timeLabel.Font = new Font("Poppins", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            timeLabel.Location = new Point(245, 42);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(127, 23);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "Client";
            timeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bookingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1094, 712);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "bookingsPage";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            stackPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label8;
        private AntdUI.Panel panel1;
        private AntdUI.Calendar calendar;
        private AntdUI.Panel panel2;
        private AntdUI.Label label1;
        private AntdUI.Divider divider1;
        private AntdUI.StackPanel stackPanel1;
        private AntdUI.Panel panel3;
        private AntdUI.Label eventNameBookingLabel1;
        private AntdUI.Label eventNameBookingLbl;
        private AntdUI.Label clientNameBookingLabel1;
        private AntdUI.Label timeLabel;
    }
}