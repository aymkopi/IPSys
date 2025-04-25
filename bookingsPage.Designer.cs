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
            calendar1 = new AntdUI.Calendar();
            panel2 = new AntdUI.Panel();
            stackPanel1 = new AntdUI.StackPanel();
            panel3 = new AntdUI.Panel();
            label1 = new AntdUI.Label();
            divider1 = new AntdUI.Divider();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            stackPanel1.SuspendLayout();
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
            panel1.Controls.Add(calendar1);
            panel1.Location = new Point(27, 94);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(605, 598);
            panel1.TabIndex = 17;
            panel1.Text = "panel1";
            // 
            // calendar1
            // 
            calendar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar1.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calendar1.Full = true;
            calendar1.Location = new Point(25, 21);
            calendar1.Name = "calendar1";
            calendar1.Size = new Size(560, 555);
            calendar1.TabIndex = 0;
            calendar1.Text = "calendar1";
            calendar1.DateChanged += calendar1_DateChanged_1;
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
            panel3.Location = new Point(8, 8);
            panel3.Name = "panel3";
            panel3.Shadow = 5;
            panel3.Size = new Size(392, 105);
            panel3.TabIndex = 0;
            panel3.Text = "panel3";
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
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label8;
        private AntdUI.Panel panel1;
        private AntdUI.Calendar calendar1;
        private AntdUI.Panel panel2;
        private AntdUI.Label label1;
        private AntdUI.Divider divider1;
        private AntdUI.StackPanel stackPanel1;
        private AntdUI.Panel panel3;
    }
}