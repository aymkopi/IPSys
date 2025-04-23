namespace IPSys
{
    partial class LoginPage
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
            exitBtn = new AntdUI.Button();
            loginBtn = new AntdUI.Button();
            SuspendLayout();
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(477, 170);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(52, 42);
            exitBtn.TabIndex = 0;
            exitBtn.Text = "Exit";
            exitBtn.Click += exitBtn_Click;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(327, 173);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(82, 39);
            loginBtn.TabIndex = 1;
            loginBtn.Text = "Login";
            loginBtn.Click += loginBtn_Click;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(exitBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginPage";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button exitBtn;
        private AntdUI.Button loginBtn;
    }
}