using System.Data;
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

            // Batch data loading and UI updates
            LoadDataIntoTable(EventsTable);
        }

        public void InitializeDashboardCharts()
        {
            // Suspend layout updates during chart initialization
            SuspendLayout();

            EarningsChart.Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = new int[12] {5, 4, 12, 30, 4, 22, 6, 17, 0, 0, 0, 0}
                }
            };

            EarningsChart.XAxes = new List<Axis>
            {
                new()
                {
                    Labels = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
                }
            };

            BookingsChart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = new int[7] {12, 9, 3, 0, 4, 15, 1 },
                    DataLabelsMaxWidth = 4,
                }
            };

            BookingsChart.XAxes = new List<Axis>
            {
                new()
                {
                    Labels = new string[7] {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}
                }
            };

            // Apply consistent background colors
            EarningsChart.BackColor = Color.White;
            BookingsChart.BackColor = Color.White;

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
