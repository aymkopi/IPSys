using System;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class MainPage : Form
    {
        // Preloaded forms
        private dashboardPage dashboardForm;
        private bookingsPage bookingsForm;
        private EmployeesPage employeesForm;
        private ClientPage clientsForm;
        private ServicesPage servicesForm;
        private ProjectsPage projectsForm;
        private EarningsPage earningsForm;

        public MainPage()
        {
            InitializeComponent();

            // Preload all forms
            dashboardForm = new dashboardPage();
            bookingsForm = new bookingsPage();
            employeesForm = new EmployeesPage();
            clientsForm = new ClientPage();
            servicesForm = new ServicesPage();
            projectsForm = new ProjectsPage();
            earningsForm = new EarningsPage();

            // Set forms as non-top-level and docked
            PreloadForm(dashboardForm);
            PreloadForm(bookingsForm);
            PreloadForm(employeesForm);
            PreloadForm(clientsForm);
            PreloadForm(servicesForm);
            PreloadForm(projectsForm);
            PreloadForm(earningsForm);

            // Show dashboard by default
            ShowForm(dashboardForm);

            TestConnection();
            this.DoubleBuffered = true;
        }

        private void PreloadForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = false;
            mainPanel.Controls.Add(form);
        }

        private void ShowForm(Form formToShow)
        {
            foreach (Control ctrl in mainPanel.Controls)
            {
                if (ctrl is Form frm)
                {
                    frm.Visible = (frm == formToShow);
                }
            }
            mainPanel.Tag = formToShow;
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
            var buttons = new List<AntdUI.Button> { dashboardBtn, bookingsBtn, clientsBtn, servicesBtn, employeesBtn, projectsBtn, earningsBtn };

            foreach (var btn in buttons)
            {
                btn.Toggle = (btn == selectedBtn);
            }
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(dashboardBtn);
            ShowForm(dashboardForm);
        }
        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(bookingsBtn);
            ShowForm(bookingsForm);
        }
        private void employeesBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(employeesBtn);
            ShowForm(employeesForm);
        }
        private void clientsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(clientsBtn);
            ShowForm(clientsForm);
        }
        private void servicesBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(servicesBtn);
            ShowForm(servicesForm);
        }
        private void projectsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(projectsBtn);
            ShowForm(projectsForm);
        }
        private void earningsBtn_Click(object sender, EventArgs e)
        {
            ToggleButton(earningsBtn);
            ShowForm(earningsForm);
        }

        private void NavigationBarPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
