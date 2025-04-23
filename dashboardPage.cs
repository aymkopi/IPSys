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

        public dashboardPage()
        {
            InitializeComponent();
            InitializeDashboardCharts();
            LoadDataIntoTable(table1);
        }


        private void LoadDataIntoTable(AntdUI.Table TableToFill)
        {
            string query = "";

            if (TableToFill == table1)
            {
                query = @"SELECT 
                e.event_name AS [Event Name],
                b.date AS [Date],
                b.time AS [Time],
                b.location AS [Location]
            FROM bookings b
            INNER JOIN events e ON b.event_id = e.event_id
            ORDER BY b.date ASC";

            }
            else if (TableToFill == table2)
            {
                query = @"SELECT";
            }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable usersDataTable = new DataTable();
                    adapter.Fill(usersDataTable);

                    TableToFill.DataSource = usersDataTable; // This is how you bind it to AntdUI table  
                }
        }

        public void InitializeDashboardCharts()
        {
            clientsChart.Series = new ISeries[]
          {
                new LineSeries<int>
                {
                    Values = new int[12] {5, 4, 12, 30, 4, 22, 6, 17, 0, 0, 0, 0}
                }
          };
            clientsChart.XAxes = new List<Axis>
            { new() {
                Labels = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            }
            };


            bookingsChart.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Values = new int[7] {12, 9, 3, 0, 4, 15, 1 }
                }
            };

            bookingsChart.XAxes = new List<Axis>
            {
                new()
                {
                    Labels = new string[7] {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}
                }
            };



            clientsChart.BackColor = Color.White;
            bookingsChart.BackColor = Color.White;
        }




        public void input1_KeyDown(object sender, EventArgs e)
        {
            //put in the value when enter is pressed on the input bar
        }

    }
}
