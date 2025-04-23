using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPSys
{
    public partial class LoginPage : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LoginSuccessful { get; private set; } = false;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.LoginSuccessful = false;
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Add your actual login check here (e.g., username/password)
            this.LoginSuccessful = true;
            this.Close(); // Close login form to continue to MainPage
        }
    }
}