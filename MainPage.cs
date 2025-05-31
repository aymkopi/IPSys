using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            ShowForm("dashboard");
            TestConnection();
            this.DoubleBuffered = true;
        }

        private void ShowForm(string formKey)
        {
            // Remove previous forms
            foreach (Control ctrl in mainPanel.Controls)
            {
                if (ctrl is Form frm)
                {
                    mainPanel.Controls.Remove(frm);
                    frm.Dispose();
                }
            }

            Form formToShow = formKey switch
            {
                "dashboard" => new dashboardPage(),
                "bookings" => new bookingsPage(),
                "employees" => new EmployeesPage(),
                "clients" => new ClientPage(),
                "services" => new ServicesPage(),
                "projects" => new ProjectsPage(),
                "earnings" => new EarningsPage(),
                _ => null,
            };

            if (formToShow != null)
            {
                // Load data before displaying (if method exists)
                // You can use reflection or explicit interface
                (formToShow as ILoadableForm)?.LoadData();

                formToShow.TopLevel = false;
                formToShow.Dock = DockStyle.Fill;
                formToShow.FormBorderStyle = FormBorderStyle.None;
                mainPanel.Controls.Add(formToShow);
                formToShow.Show();
                mainPanel.Tag = formToShow;
            }
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close(); // When MainPage closes, Program.cs will re-show login
        }

        private void ToggleButton(AntdUI.Button selectedBtn)
        {
            var buttons = new List<AntdUI.Button> { dashboardBtn, bookingsBtn, clientsBtn, servicesBtn, employeesBtn};

            foreach (var btn in buttons)
            {
                btn.Toggle = (btn == selectedBtn);
            }
        }
        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(dashboardBtn);
            ShowForm("dashboard");
        }
        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(bookingsBtn);
            ShowForm("bookings");
        }
        private void employeesBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(employeesBtn);
            ShowForm("employees");
        }
        private void clientsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(clientsBtn);
            ShowForm("clients");
        }
        private void servicesBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(servicesBtn);
            ShowForm("services");
        }
    }

    // Interface for forms that support data loading
    public interface ILoadableForm
    {
        void LoadData();
    }
}