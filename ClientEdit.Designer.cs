namespace IPSys
{
    partial class ClientEdit
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
            inputClientID = new AntdUI.Input();
            lblClientName = new AntdUI.Label();
            label1 = new AntdUI.Label();
            inputClientName = new AntdUI.Input();
            inputClientEmail = new AntdUI.Input();
            label2 = new AntdUI.Label();
            inputClientContact = new AntdUI.Input();
            label3 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            saveButton = new AntdUI.Button();
            SuspendLayout();
            // 
            // inputClientID
            // 
            inputClientID.Enabled = false;
            inputClientID.Font = new Font("Poppins", 9.75F);
            inputClientID.Location = new Point(31, 78);
            inputClientID.Name = "inputClientID";
            inputClientID.Size = new Size(290, 40);
            inputClientID.TabIndex = 0;
            // 
            // lblClientName
            // 
            lblClientName.Font = new Font("Poppins", 9.75F);
            lblClientName.Location = new Point(44, 61);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(75, 23);
            lblClientName.TabIndex = 1;
            lblClientName.Text = "ID";
            // 
            // label1
            // 
            label1.Font = new Font("Poppins", 9.75F);
            label1.Location = new Point(44, 128);
            label1.Name = "label1";
            label1.Size = new Size(75, 23);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // inputClientName
            // 
            inputClientName.Font = new Font("Poppins", 9.75F);
            inputClientName.Location = new Point(31, 145);
            inputClientName.Name = "inputClientName";
            inputClientName.Size = new Size(290, 40);
            inputClientName.TabIndex = 2;
            inputClientName.TextChanged += inputClientName_TextChanged;
            // 
            // inputClientEmail
            // 
            inputClientEmail.Font = new Font("Poppins", 9.75F);
            inputClientEmail.Location = new Point(31, 283);
            inputClientEmail.Name = "inputClientEmail";
            inputClientEmail.Size = new Size(290, 40);
            inputClientEmail.TabIndex = 6;
            inputClientEmail.TextChanged += inputClientName_TextChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Poppins", 9.75F);
            label2.Location = new Point(44, 266);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 7;
            label2.Text = "Email";
            // 
            // inputClientContact
            // 
            inputClientContact.Font = new Font("Poppins", 9.75F);
            inputClientContact.Location = new Point(31, 216);
            inputClientContact.Name = "inputClientContact";
            inputClientContact.Size = new Size(290, 40);
            inputClientContact.TabIndex = 4;
            inputClientContact.TextChanged += inputClientName_TextChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Poppins", 9.75F);
            label3.Location = new Point(44, 199);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 5;
            label3.Text = "Contact";
            // 
            // label4
            // 
            label4.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 22);
            label4.Name = "label4";
            label4.Size = new Size(176, 23);
            label4.TabIndex = 8;
            label4.Text = "Client Details";
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveButton.Location = new Point(212, 339);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(109, 37);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save";
            saveButton.Click += saveButton_Click;
            // 
            // ClientEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 669);
            Controls.Add(saveButton);
            Controls.Add(label4);
            Controls.Add(inputClientEmail);
            Controls.Add(label2);
            Controls.Add(inputClientContact);
            Controls.Add(label3);
            Controls.Add(inputClientName);
            Controls.Add(label1);
            Controls.Add(inputClientID);
            Controls.Add(lblClientName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientEdit";
            Text = "ClientEdit";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Input inputClientID;
        private AntdUI.Label lblClientName;
        private AntdUI.Label label1;
        private AntdUI.Input inputClientName;
        private AntdUI.Input inputClientEmail;
        private AntdUI.Label label2;
        private AntdUI.Input inputClientContact;
        private AntdUI.Label label3;
        private AntdUI.Label label4;
        private AntdUI.Button saveButton;
    }
}