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
            servicesFlowPanel = new AntdUI.FlowPanel();
            panel1 = new AntdUI.Panel();
            lblService = new AntdUI.Label();
            eventsFlowPanel = new AntdUI.FlowPanel();
            panel2 = new AntdUI.Panel();
            label1 = new AntdUI.Label();
            servicesFlowPanel.SuspendLayout();
            panel1.SuspendLayout();
            eventsFlowPanel.SuspendLayout();
            panel2.SuspendLayout();
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
            // servicesFlowPanel
            // 
            servicesFlowPanel.Align = AntdUI.TAlignFlow.Left;
            servicesFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            servicesFlowPanel.AutoScroll = true;
            servicesFlowPanel.BackColor = SystemColors.ControlDarkDark;
            servicesFlowPanel.Controls.Add(panel1);
            servicesFlowPanel.Location = new Point(57, 137);
            servicesFlowPanel.Name = "servicesFlowPanel";
            servicesFlowPanel.Size = new Size(978, 194);
            servicesFlowPanel.TabIndex = 18;
            servicesFlowPanel.Text = "flowPanel1";
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
            // eventsFlowPanel
            // 
            eventsFlowPanel.Align = AntdUI.TAlignFlow.Left;
            eventsFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            eventsFlowPanel.AutoScroll = true;
            eventsFlowPanel.BackColor = SystemColors.GradientActiveCaption;
            eventsFlowPanel.Controls.Add(panel2);
            eventsFlowPanel.Location = new Point(57, 349);
            eventsFlowPanel.Name = "eventsFlowPanel";
            eventsFlowPanel.Size = new Size(978, 213);
            eventsFlowPanel.TabIndex = 19;
            eventsFlowPanel.Text = "flowPanel1";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Shadow = 5;
            panel2.Size = new Size(348, 142);
            panel2.TabIndex = 0;
            panel2.Text = "panel2";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 21);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // ServicesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1094, 712);
            Controls.Add(eventsFlowPanel);
            Controls.Add(servicesFlowPanel);
            Controls.Add(lblServices);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServicesPage";
            Text = "ServicesPage";
            servicesFlowPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            eventsFlowPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label lblServices;
        private AntdUI.FlowPanel servicesFlowPanel;
        private AntdUI.Panel panel1;
        private AntdUI.Label lblService;
        private AntdUI.FlowPanel eventsFlowPanel;
        private AntdUI.Panel panel2;
        private AntdUI.Label label1;
    }
}