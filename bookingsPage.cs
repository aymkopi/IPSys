using System.Data;
using AntdUI;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class bookingsPage : Form
    {
        string connectionString = "Data Source=DESKTOP-0IG0ARM\\SQLEXPRESS;" +
                "Initial Catalog= owlie;" +
                "Integrated Security=True;" +
                "Trust Server Certificate=True";

        public List<DateTime> SchedDatesList = new List<DateTime>();
        public List<int> SchedDatesNumList = new List<int>();

        public bookingsPage()
        {
            InitializeComponent();
            PopulateSchedDates();

            this.DoubleBuffered = true;


            // LoadDataIntoTable(table1);
        }

        //private void LoadDataIntoTable(AntdUI.Table TableToFill)
        //{
        //    string query = "";
        //    if (TableToFill == table1)
        //    {
        //        query = @"SELECT 
        //        e.Event_Type AS [Event Name],
        //        b.Date AS [Date],
        //        c.Client_Name AS [Client Name],
        //        c.Contact_Num AS [Contact],
        //        e.Event_Type AS [Event Type],
        //        p.Package_Type AS [Package Availed],
        //        emp.Employee_Name AS [Assigned Employees]
        //    FROM Bookings b
        //    INNER JOIN Events e ON b.Event_ID = e.Event_ID
        //    INNER JOIN Clients c ON b.Client_ID = c.Client_ID
        //    INNER JOIN Packages p ON b.Package_ID = p.Package_ID
        //    INNER JOIN Employees emp ON b.Employee_ID = emp.Employee_ID
        //    ORDER BY b.Date ASC;";
        //    }
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
        //        DataTable bookingsDataTable = new DataTable();
        //        adapter.Fill(bookingsDataTable);

        //        TableToFill.DataSource = bookingsDataTable; // This is how you bind it to AntdUI table

        //        table1.DataSource = bookingsDataTable;
        //    }
        //}

        public void PopulateSchedDates()
        {
            string query = @"
                SELECT 
                    CAST(Date AS DATE) AS BookingDate, 
                    COUNT(*) AS BookingCount
                FROM Bookings
                GROUP BY CAST(Date AS DATE)
                ORDER BY BookingDate ASC;
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        SchedDatesList.Clear();
                        SchedDatesNumList.Clear();

                        while (reader.Read())
                        {
                            SchedDatesList.Add(reader.GetDateTime(0));
                            SchedDatesNumList.Add(reader.GetInt32(1));
                        }
                    }
                }
            }
            if (SchedDatesList.Count == 0)
            {
                MessageBox.Show("SchedDatesList is empty!");
            }


            calendar.BadgeAction = dates =>
            {
                var datebefore = dates[0];
                var dateafter = dates[1];

                // Generate DateBadges for each item in SchedDatesList with corresponding counts in SchedDatesNumList
                return SchedDatesList
                    .Select((date, index) => new DateBadge(
                        date.ToString("yyyy-MM-dd"),  // Format as "YYYY-MM-DD"
                        SchedDatesNumList[index]
                    // Use the corresponding count from SchedDatesNumList
                    ))
                    .ToList();
            };
            calendar.LoadBadge();

            GeneratePanelsForSelectedDate(calendar.Value);

        }

        private void calendar1_DateChanged(object sender, DateTimeEventArgs e)
        {
            GeneratePanelsForSelectedDate(calendar.Value);
        }

        public void GeneratePanelsForSelectedDate(DateTime selectedDate)
        {
            string query = @"
        SELECT b.Event_Name, c.Client_Name, b.Time
        FROM Bookings b
        INNER JOIN Clients c ON b.client_id = c.client_id
        WHERE CAST(b.Date AS DATE) = @SelectedDate
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Suspend layout updates during panel update
                        stackPanel1.SuspendLayout();
                        stackPanel1.Controls.Clear();

                        int panelIndex = 0;
                        while (reader.Read())
                        {
                            // Create a new panel
                            AntdUI.Panel panel = new AntdUI.Panel
                            {
                                Name = $"panel{panelIndex}",
                                Size = new Size(392, 121), // Example size, adjust as necessary
                                BackColor = Color.Transparent,
                                Shadow = 5,
                            };

                            // Create a label for the event name
                            AntdUI.Label eventNameLabel = new AntdUI.Label
                            {
                                Name = $"eventNameBookingLabel{panelIndex}",
                                Font = new Font("Poppins Medium", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(23, 19),
                                Size = new Size(75, 23),
                                Text = reader.GetString(0), // Get the EventName from the database
                                AutoSize = true
                            };

                            AntdUI.Label clientNameLabel = new AntdUI.Label
                            {
                                Name = $"clientNameBookingLabel{panelIndex}",
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(23, 48),
                                Size = new Size(329, 23),
                                Text = reader.GetString(1),
                                AutoSize = true
                            };

                            //AntdUI.Label timeLabel = new AntdUI.Label
                            //{
                            //    Name = $"timeLabel{panelIndex}",
                            //    Font = new Font("Poppins", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0),
                            //    Location = new Point(245, 42),
                            //    Size = new Size(127, 23),
                            //    Text = reader.GetString(2),
                            //    TextAlign = ContentAlignment.MiddleRight,
                            //    AutoSize = true
                            //};

                            // Add the label to the panel
                            panel.Controls.Add(eventNameLabel);
                            panel.Controls.Add(clientNameLabel);
                            //panel.Controls.Add(timeLabel);

                            // Add the panel to the StackPanel
                            stackPanel1.Controls.Add(panel);

                            panelIndex++;
                        }

                        // Resume layout updates after panel update
                        stackPanel1.ResumeLayout();
                    }
                }
            }
        }
        private void LoadForm(object Form)
        {
            if (this.Controls.Count > 0)
                this.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.Show();

        }

        private void CreateBookingButton_Click(object sender, EventArgs e)
        {
            LoadForm(new Form1());
        }   


    }
}
