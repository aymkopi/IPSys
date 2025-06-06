﻿namespace IPSys
{
    partial class EmployeeEdit
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
            inputEmpID = new AntdUI.Input();
            lblClientName = new AntdUI.Label();
            label1 = new AntdUI.Label();
            inputEmpName = new AntdUI.Input();
            inputEmpAddress = new AntdUI.Input();
            label2 = new AntdUI.Label();
            label3 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            saveButton = new AntdUI.Button();
            inputEmpContact = new AntdUI.Input();
            label5 = new AntdUI.Label();
            label6 = new AntdUI.Label();
            IsActiveSwitch = new AntdUI.Switch();
            inputEmpRole = new AntdUI.Select();
            editBtn = new AntdUI.Button();
            closeBtn = new AntdUI.Button();
            flowPanel = new AntdUI.FlowPanel();
            flowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // inputEmpID
            // 
            inputEmpID.Enabled = false;
            inputEmpID.Font = new Font("Poppins", 9.75F);
            inputEmpID.Location = new Point(31, 88);
            inputEmpID.Name = "inputEmpID";
            inputEmpID.Size = new Size(215, 40);
            inputEmpID.TabIndex = 0;
            // 
            // lblClientName
            // 
            lblClientName.Font = new Font("Poppins", 9.75F);
            lblClientName.Location = new Point(44, 71);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(75, 23);
            lblClientName.TabIndex = 1;
            lblClientName.Text = "ID";
            // 
            // label1
            // 
            label1.Font = new Font("Poppins", 9.75F);
            label1.Location = new Point(44, 138);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // inputEmpName
            // 
            inputEmpName.Font = new Font("Poppins", 9.75F);
            inputEmpName.Location = new Point(31, 155);
            inputEmpName.Name = "inputEmpName";
            inputEmpName.Size = new Size(290, 40);
            inputEmpName.TabIndex = 2;
            inputEmpName.TextChanged += inputClientName_TextChanged;
            // 
            // inputEmpAddress
            // 
            inputEmpAddress.Font = new Font("Poppins", 9.75F);
            inputEmpAddress.Location = new Point(31, 301);
            inputEmpAddress.Name = "inputEmpAddress";
            inputEmpAddress.Size = new Size(290, 40);
            inputEmpAddress.TabIndex = 6;
            inputEmpAddress.TextChanged += inputClientName_TextChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Poppins", 9.75F);
            label2.Location = new Point(44, 284);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 7;
            label2.Text = "Address";
            // 
            // label3
            // 
            label3.Font = new Font("Poppins", 9.75F);
            label3.Location = new Point(44, 209);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 5;
            label3.Text = "Role";
            // 
            // label4
            // 
            label4.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 30);
            label4.Name = "label4";
            label4.Size = new Size(220, 23);
            label4.TabIndex = 8;
            label4.Text = "Employee Profile";
            // 
            // saveButton
            // 
            saveButton.Enabled = false;
            saveButton.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveButton.Location = new Point(96, 46);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(109, 37);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save";
            saveButton.Click += saveButton_Click;
            // 
            // inputEmpContact
            // 
            inputEmpContact.Font = new Font("Poppins", 9.75F);
            inputEmpContact.Location = new Point(31, 375);
            inputEmpContact.Name = "inputEmpContact";
            inputEmpContact.Size = new Size(290, 40);
            inputEmpContact.TabIndex = 10;
            inputEmpContact.TextChanged += inputClientName_TextChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Poppins", 9.75F);
            label5.Location = new Point(44, 358);
            label5.Name = "label5";
            label5.Size = new Size(75, 23);
            label5.TabIndex = 11;
            label5.Text = "Contact";
            // 
            // label6
            // 
            label6.Font = new Font("Poppins", 9.75F);
            label6.Location = new Point(261, 72);
            label6.Name = "label6";
            label6.Size = new Size(58, 23);
            label6.TabIndex = 13;
            label6.Text = "Active?";
            // 
            // IsActiveSwitch
            // 
            IsActiveSwitch.Checked = true;
            IsActiveSwitch.Location = new Point(252, 90);
            IsActiveSwitch.Name = "IsActiveSwitch";
            IsActiveSwitch.Size = new Size(65, 36);
            IsActiveSwitch.TabIndex = 14;
            // 
            // inputEmpRole
            // 
            inputEmpRole.Font = new Font("Poppins", 9.75F);
            inputEmpRole.Location = new Point(31, 229);
            inputEmpRole.Name = "inputEmpRole";
            inputEmpRole.Size = new Size(290, 40);
            inputEmpRole.TabIndex = 15;
            // 
            // editBtn
            // 
            editBtn.BorderWidth = 1F;
            editBtn.Ghost = true;
            editBtn.Icon = Properties.Resources.edit;
            editBtn.IconGap = 0F;
            editBtn.Location = new Point(99, 3);
            editBtn.Margin = new Padding(3, 3, 0, 3);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(109, 37);
            editBtn.TabIndex = 21;
            editBtn.Type = AntdUI.TTypeMini.Warn;
            editBtn.Click += editBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Icon = Properties.Resources.close_100dp_000000_FILL0_wght400_GRAD0_opsz48;
            closeBtn.IconGap = -0.5F;
            closeBtn.IconRatio = 1F;
            closeBtn.Location = new Point(297, 12);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(38, 38);
            closeBtn.TabIndex = 24;
            closeBtn.Text = "\u007f";
            closeBtn.Click += closeBtn_Click;
            // 
            // flowPanel
            // 
            flowPanel.Align = AntdUI.TAlignFlow.Right;
            flowPanel.Controls.Add(saveButton);
            flowPanel.Controls.Add(editBtn);
            flowPanel.Location = new Point(113, 428);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(208, 45);
            flowPanel.TabIndex = 25;
            flowPanel.Text = "flowPanel";
            // 
            // EmployeeEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 669);
            Controls.Add(flowPanel);
            Controls.Add(closeBtn);
            Controls.Add(inputEmpRole);
            Controls.Add(IsActiveSwitch);
            Controls.Add(label6);
            Controls.Add(inputEmpContact);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(inputEmpAddress);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(inputEmpName);
            Controls.Add(label1);
            Controls.Add(inputEmpID);
            Controls.Add(lblClientName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeEdit";
            Text = "ClientEdit";
            flowPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Input inputEmpID;
        private AntdUI.Label lblClientName;
        private AntdUI.Label label1;
        private AntdUI.Input inputEmpName;
        private AntdUI.Input inputEmpAddress;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private AntdUI.Label label4;
        private AntdUI.Button saveButton;
        private AntdUI.Input inputEmpContact;
        private AntdUI.Label label5;
        private AntdUI.Label label6;
        private AntdUI.Switch IsActiveSwitch;
        private AntdUI.Select inputEmpRole;
        private AntdUI.Button editBtn;
        private AntdUI.Button closeBtn;
        private AntdUI.FlowPanel flowPanel;
    }
}