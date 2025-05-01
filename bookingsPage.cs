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


        DateTime dateTimeNow = DateTime.Now;
        



        public bookingsPage()
        {
            InitializeComponent();
            PopulateSchedDates();

            this.DoubleBuffered = true;

        }
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
        SELECT b.Event_Name, c.Client_Name, b.Date, b.Time
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
                                Size = new Size(392, 145), // Example size, adjust as necessary
                                BackColor = Color.Transparent,
                                Shadow = 5,
                            };

                            // Create a label for the event name
                            AntdUI.Label eventNameLabel = new AntdUI.Label
                            {
                                Name = $"eventNameBookingLabel{panelIndex}",
                                Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(25, 22),
                                Size = new Size(75, 23),
                                Text = reader.GetString(0), // Get the EventName from the database
                                AutoSize = true
                            };

                            AntdUI.Label clientNameLabel = new AntdUI.Label
                            {
                                Name = $"clientNameBookingLabel{panelIndex}",
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(25, 50),
                                Size = new Size(329, 23),
                                Text = reader.GetString(1),
                                AutoSize = true
                            };

                            AntdUI.Label timeLabel = new AntdUI.Label
                            {
                                Name = $"timeLabel{panelIndex}",
                                Font = new Font("Poppins", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0),
                                Location = new Point(245, 42),
                                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                Size = new Size(127, 23),
                                Text = FormatTime(reader.GetTimeSpan(3)),
                                TextAlign = ContentAlignment.MiddleRight,

                            };

                            AntdUI.Badge eventBadge = new AntdUI.Badge
                            {
                                Name = $"eventBadge{panelIndex}",
                                Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(351, 13),
                                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                Size = new Size(22, 25),
                                Text = "",
                                DotRatio = 0.5F,
                                State = BadgeState(reader.GetDateTime(2)),
                            };

                            // Add the label to the panel
                            panel.Controls.Add(eventNameLabel);
                            panel.Controls.Add(clientNameLabel);
                            panel.Controls.Add(timeLabel);
                            panel.Controls.Add(eventBadge);

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

        // Helper method to format TimeSpan to 12-hour time with AM/PM
        private string FormatTime(TimeSpan timeSpan)
        {
            // Convert TimeSpan to DateTime (arbitrary date)
            DateTime dateTime = DateTime.Today.Add(timeSpan);

            // Format DateTime to 12-hour time with AM/PM
            return dateTime.ToString("hh:mm tt");
        }

        private TState BadgeState(DateTime dateTime)
        {
            if (dateTime < dateTimeNow)
            {
                return TState.Success;
            } else if(dateTime > dateTimeNow)
            {
                return TState.Primary;
            }
            else if (dateTime == dateTimeNow)
            {
                return TState.Processing;
            } else
            {
                return TState.Default;
            }
        }



        private void CreateBookingButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of the bookingPanel form
            bookingPanel bookingForm = new bookingPanel();

            // Display it as a modal dialog
            bookingForm.ShowDialog();

        }
    }
}
