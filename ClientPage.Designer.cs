namespace IPSys
{
    partial class ClientPage
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
            clientTable = new AntdUI.Table();
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
            label8.TabIndex = 18;
            label8.Text = "Clients";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(clientTable);
            panel1.Location = new Point(27, 118);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(1027, 572);
            panel1.TabIndex = 19;
            panel1.Text = "panel1";
            // 
            // clientTable
            // 
            clientTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientTable.BackColor = Color.LightGray;
            clientTable.ColumnBack = Color.Gainsboro;
            clientTable.ColumnFont = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientTable.Empty = false;
            clientTable.Font = new Font("Poppins", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clientTable.Location = new Point(25, 25);
            clientTable.Name = "clientTable";
            clientTable.Size = new Size(977, 524);
            clientTable.TabIndex = 0;
            clientTable.CellButtonClick += clientTable_CellButtonClick;
            // 
            // ClientPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 719);
            Controls.Add(panel1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientPage";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label8;
        private AntdUI.Panel panel1;
        private AntdUI.Table clientTable;
    }
}