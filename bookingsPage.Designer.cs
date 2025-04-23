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
            table1 = new AntdUI.Table();
            panel1.SuspendLayout();
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
            label8.Text = "Events";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(table1);
            panel1.Location = new Point(27, 94);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(1029, 598);
            panel1.TabIndex = 17;
            panel1.Text = "panel1";
            // 
            // table1
            // 
            table1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table1.BackColor = Color.Transparent;
            table1.ColumnFont = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            table1.DefaultExpand = true;
            table1.Empty = false;
            table1.FixedHeader = false;
            table1.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            table1.Location = new Point(20, 20);
            table1.Name = "table1";
            table1.Size = new Size(989, 556);
            table1.TabIndex = 0;
            table1.Text = "table1";
            // 
            // bookingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1094, 712);
            Controls.Add(panel1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "bookingsPage";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label8;
        private AntdUI.Panel panel1;
        private AntdUI.Table table1;
    }
}