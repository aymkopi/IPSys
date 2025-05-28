using System;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            LoadForm(new dashboardPage());
            TestConnection();

            this.DoubleBuffered = true;
        }

        public static void TestConnection()
        {
            SqlConnection conn = new SqlConnection(
                @"Data Source = DESKTOP-0IG0ARM\SQLEXPRESS;
                  Initial Catalog = owlie;
                  Integrated Security = True;
                  Trust Server Certificate = True"
            );
            try
            {
                conn.Open();
               // MessageBox.Show("Connected!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }

        public static string ConnectionString()
        {
            return "Data Source=DESKTOP-0IG0ARM\\SQLEXPRESS;" +
                   "Initial Catalog= owlie;" +
                   "Integrated Security=True;" +
                   "Trust Server Certificate=True";
        }

        private void LoadForm(object Form)
        {
            if (mainPanel.Controls.Count > 0)
                mainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(f);
            mainPanel.Tag = f;
            f.Show();
            
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close(); // When MainPage closes, Program.cs will re-show login
        }
        private void ToggleButton(AntdUI.Button selectedBtn)
        {
            var buttons = new List<AntdUI.Button> { dashboardBtn, bookingsBtn, clientsBtn, servicesBtn, employeesBtn, projectsBtn };

            foreach (var btn in buttons)
            {
                if (btn == selectedBtn)
                {
                    // Toggle ON the clicked button
                    btn.Toggle = true;
                }
                else
                {
                    // Toggle OFF the others
                    btn.Toggle = false;
                }
            }
        }
        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(dashboardBtn);
            LoadForm(new dashboardPage());
        }
        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(bookingsBtn);
            LoadForm(new bookingsPage());
        }
        private void employeesBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(employeesBtn);
            LoadForm(new EmployeesPage());
        }
        private void clientsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(clientsBtn);
            LoadForm(new ClientPage());
        }
        private void servicesBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(servicesBtn);
            LoadForm(new ServicesPage());
        }
        
        private void reviewsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(projectsBtn);
            LoadForm(new ProjectsPage());
        }

        private void NavigationBarPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
