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
            eventsFlowPanel = new AntdUI.FlowPanel();
            panel3 = new AntdUI.Panel();
            label2 = new AntdUI.Label();
            panel4 = new AntdUI.Panel();
            label1 = new AntdUI.Label();
            gridPanel1 = new AntdUI.GridPanel();
            empRolePanel = new AntdUI.Panel();
            label3 = new AntdUI.Label();
            employeeRolesFlowPanel = new AntdUI.FlowPanel();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            gridPanel1.SuspendLayout();
            empRolePanel.SuspendLayout();
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
            servicesFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            servicesFlowPanel.AutoScroll = true;
            servicesFlowPanel.BackColor = Color.Transparent;
            servicesFlowPanel.Location = new Point(8, 41);
            servicesFlowPanel.Name = "servicesFlowPanel";
            servicesFlowPanel.Size = new Size(1191, 165);
            servicesFlowPanel.TabIndex = 18;
            servicesFlowPanel.Text = "flowPanel1";
            // 
            // eventsFlowPanel
            // 
            eventsFlowPanel.Align = AntdUI.TAlignFlow.Left;
            eventsFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            eventsFlowPanel.AutoScroll = true;
            eventsFlowPanel.BackColor = Color.Transparent;
            eventsFlowPanel.Location = new Point(8, 41);
            eventsFlowPanel.Name = "eventsFlowPanel";
            eventsFlowPanel.Size = new Size(1191, 165);
            eventsFlowPanel.TabIndex = 19;
            eventsFlowPanel.Text = "flowPanel1";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(servicesFlowPanel);
            panel3.Location = new Point(3, 223);
            panel3.Name = "panel3";
            panel3.Shadow = 5;
            panel3.Size = new Size(1207, 214);
            panel3.TabIndex = 20;
            panel3.Text = "panel3";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Poppins", 14.25F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(16, 15);
            label2.Name = "label2";
            label2.Size = new Size(220, 27);
            label2.TabIndex = 24;
            label2.Text = "Packages";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(label1);
            panel4.Controls.Add(eventsFlowPanel);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Shadow = 5;
            panel4.Size = new Size(1207, 214);
            panel4.TabIndex = 21;
            panel4.Text = "panel4";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 14.25F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(16, 14);
            label1.Name = "label1";
            label1.Size = new Size(220, 27);
            label1.TabIndex = 23;
            label1.Text = "Events";
            // 
            // gridPanel1
            // 
            gridPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPanel1.Controls.Add(empRolePanel);
            gridPanel1.Controls.Add(panel3);
            gridPanel1.Controls.Add(panel4);
            gridPanel1.Location = new Point(89, 94);
            gridPanel1.Name = "gridPanel1";
            gridPanel1.Size = new Size(1213, 662);
            gridPanel1.Span = "100%; 100%; 100%";
            gridPanel1.TabIndex = 22;
            gridPanel1.Text = "gridPanel1";
            // 
            // empRolePanel
            // 
            empRolePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            empRolePanel.Controls.Add(label3);
            empRolePanel.Controls.Add(employeeRolesFlowPanel);
            empRolePanel.Location = new Point(3, 443);
            empRolePanel.Name = "empRolePanel";
            empRolePanel.Shadow = 5;
            empRolePanel.Size = new Size(1207, 214);
            empRolePanel.TabIndex = 22;
            empRolePanel.Text = "panel5";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Poppins", 14.25F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(16, 18);
            label3.Name = "label3";
            label3.Size = new Size(220, 27);
            label3.TabIndex = 25;
            label3.Text = "Employee Roles";
            // 
            // employeeRolesFlowPanel
            // 
            employeeRolesFlowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeeRolesFlowPanel.AutoScroll = true;
            employeeRolesFlowPanel.BackColor = Color.Transparent;
            employeeRolesFlowPanel.Location = new Point(8, 41);
            employeeRolesFlowPanel.Name = "employeeRolesFlowPanel";
            employeeRolesFlowPanel.Size = new Size(1191, 165);
            employeeRolesFlowPanel.TabIndex = 18;
            employeeRolesFlowPanel.Text = "flowPanel";
            // 
            // ServicesPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImage = Properties.Resources.Untitled_design;
            ClientSize = new Size(1342, 785);
            Controls.Add(gridPanel1);
            Controls.Add(lblServices);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServicesPage";
            Text = "ServicesPage";
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            gridPanel1.ResumeLayout(false);
            empRolePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label lblServices;
        private AntdUI.FlowPanel servicesFlowPanel;
        private AntdUI.FlowPanel eventsFlowPanel;
        private AntdUI.Panel panel3;
        private AntdUI.Panel panel4;
        private AntdUI.GridPanel gridPanel1;
        private AntdUI.Panel empRolePanel;
        private AntdUI.FlowPanel employeeRolesFlowPanel;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private AntdUI.Label label3;
    }
}