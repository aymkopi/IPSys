namespace IPSys
{
    partial class EmployeesPage
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
            empTable = new AntdUI.Table();
            SearchBar = new AntdUI.Input();
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
            label8.TabIndex = 17;
            label8.Text = "Employees";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(empTable);
            panel1.Location = new Point(27, 118);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(1027, 572);
            panel1.TabIndex = 18;
            panel1.Text = "panel1";
            // 
            // empTable
            // 
            empTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            empTable.BackColor = Color.LightGray;
            empTable.ColumnBack = Color.Gainsboro;
            empTable.ColumnFont = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            empTable.Empty = false;
            empTable.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            empTable.Location = new Point(25, 25);
            empTable.Name = "empTable";
            empTable.Size = new Size(977, 524);
            empTable.TabIndex = 0;
            empTable.CellClick += empTable_CellClick;
            // 
            // SearchBar
            // 
            SearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchBar.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.Location = new Point(684, 67);
            SearchBar.Name = "SearchBar";
            SearchBar.PlaceholderText = "   Search";
            SearchBar.Size = new Size(370, 45);
            SearchBar.TabIndex = 19;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // EmployeesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1084, 719);
            Controls.Add(SearchBar);
            Controls.Add(panel1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeesPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeePage";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Label label8;
        private AntdUI.Panel panel1;
        private AntdUI.Table empTable;
        private AntdUI.Input SearchBar;
    }
}