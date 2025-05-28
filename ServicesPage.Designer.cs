namespace IPSys
{
    partial class ServicesPage
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
            lblServices = new AntdUI.Label();
            flowPanel = new AntdUI.FlowPanel();
            panel1 = new AntdUI.Panel();
            lblService = new AntdUI.Label();
            flowPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblServices
            // 
            lblServices.BackColor = Color.Transparent;
            lblServices.Font = new Font("Poppins", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServices.Location = new Point(57, 38);
            lblServices.Name = "lblServices";
            lblServices.Size = new Size(220, 50);
            lblServices.TabIndex = 17;
            lblServices.Text = "Services";
            // 
            // flowPanel
            // 
            flowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPanel.Controls.Add(panel1);
            flowPanel.Location = new Point(57, 137);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(978, 194);
            flowPanel.TabIndex = 18;
            flowPanel.Text = "flowPanel1";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblService);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(348, 142);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // lblService
            // 
            lblService.BackColor = Color.Transparent;
            lblService.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblService.Location = new Point(44, 21);
            lblService.Name = "lblService";
            lblService.Size = new Size(75, 23);
            lblService.TabIndex = 0;
            lblService.Text = "lblService";
            // 
            // ServicesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1094, 712);
            Controls.Add(flowPanel);
            Controls.Add(lblServices);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServicesPage";
            Text = "ServicesPage";
            flowPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label lblServices;
        private AntdUI.FlowPanel flowPanel;
        private AntdUI.Panel panel1;
        private AntdUI.Label lblService;
    }
}