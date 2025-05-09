using System.Data;
using System.Globalization;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Data.SqlClient;


namespace IPSys
{
    public partial class dashboardPage : Form
    {
        public string connectionString = "Data Source=DESKTOP-0IG0ARM\\SQLEXPRESS;" +
               "Initial Catalog=owlie;" +
               "Integrated Security=True;" +
               "Trust Server Certificate=True";

        public string TableOrder = "";

        public dashboardPage()
        {
            InitializeComponent();

            // Enable double buffering to reduce flickering during rendering
            this.DoubleBuffered = true;

            // Optimize initialization
            InitializeDashboardCharts();
            InitializeDashboardStats();

            // Batch data loading and UI updates
            LoadDataIntoTable(EventsTable);
           
        }

        private void InitializeDashboardStats()
        {
            int bookingCount = 0;
            int clientCount = 0;
            int employeeCount = 0;
            decimal earnings = 0;

            string connectionString = MainPage.ConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Bookings
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Bookings", conn))
                    {
                        bookingCount = (int)cmd.ExecuteScalar();
                    }

                    // Clients
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Clients", conn))
                    {
                        clientCount = (int)cmd.ExecuteScalar();
                    }

                    // Employees
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", conn))
                    {
                        employeeCount = (int)cmd.ExecuteScalar();
                    }

                    // Earnings (assumes Bookings.Cost is the revenue per booking)
                    using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Cost), 0) FROM Bookings", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                            earnings = Convert.ToDecimal(result);
                    }
                }

                // Assign to labels (adjust names as per your Designer)
                totalBookingsLbl.Text = bookingCount.ToString();
                totalClientsLbl.Text = clientCount.ToString();
                totalStaffLbl.Text = employeeCount.ToString();
                totalRevenueLbl.Text = earnings.ToString("C", CultureInfo.GetCultureInfo("en-PH")); // Currency format
            }
            catch (Exception ex)
            {
                totalBookingsLbl.Text = "Error";
                totalClientsLbl.Text = "Error";
                totalStaffLbl.Text = "Error";
                totalRevenueLbl.Text = "Error";
            }
        }

        public void InitializeDashboardCharts()
        {
            // Suspend layout updates during chart initialization
            SuspendLayout();

            int[] bookingsPerMonth = new int[12];

            string connectionString = MainPage.ConnectionString();
            string query = @"
        SELECT 
            MONTH(DateFrom) AS [Month], 
            COUNT(*) AS [BookingCount]
        FROM Bookings
        GROUP BY MONTH(DateFrom)
        ORDER BY [Month]";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int month = reader.GetInt32(0); // 1-based: Jan=1, Dec=12
                                int count = reader.GetInt32(1);
                                // Adjust index for 0-based array
                                if (month >= 1 && month <= 12)
                                    bookingsPerMonth[month - 1] = count;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally handle error/log
            }

            BookingsChart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = bookingsPerMonth,
                    
                }
            };

            BookingsChart.XAxes = new List<Axis>
            {
                new()
                {
                    Labels = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
                }
            };

            EarningsChart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = new int[7] {12, 9, 3, 0, 4, 15, 1 },
                    DataLabelsMaxWidth = 4,
                }
            };

            EarningsChart.XAxes = new List<Axis>
            {
                new()
                {
                    Labels = new string[7] {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}
                }
            };

            // Apply consistent background colors
            BookingsChart.BackColor = Color.White;
            EarningsChart.BackColor = Color.White;

            // Resume layout updates after chart initialization
            ResumeLayout();
        }

        private void LoadDataIntoTable(AntdUI.Table TableToFill)
        {
            // Suspend layout updates to batch data loading and UI updates
            TableToFill.SuspendLayout();

            string query = "";

            // Dynamically generate query based on selected index
            if (sortEventsBtn.SelectedIndex == 0)
            {
                TableOrder = "ORDER BY b.event_name ASC";
            }
            else
            {
                TableOrder = "ORDER BY b.dateFrom DESC";
            }

            if (TableToFill == EventsTable)
            {
                query = @"SELECT 
                          b.event_name AS [Name],
                          b.dateFrom AS [Date],
                          b.time AS [Time],
                          b.location AS [Location]
                          FROM bookings b
                          INNER JOIN events e ON b.event_id = e.event_id
                          " + TableOrder;
            }
            else if (TableToFill == ClientsTable)
            {
                query = @"SELECT";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable usersDataTable = new DataTable();
                adapter.Fill(usersDataTable);

                // Bind data to the table
                TableToFill.DataSource = usersDataTable;
            }

            // Resume layout updates after data loading
            TableToFill.ResumeLayout();
        }

        private void sortEventsBtn_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            // Debounce sorting to avoid frequent refreshes
            System.Windows.Forms.Timer debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
            debounceTimer.Tick += (s, args) =>
            {
                debounceTimer.Stop();
                LoadDataIntoTable(EventsTable);
                EventsTable.Focus();
            };
            debounceTimer.Start();
        }
    }
}
