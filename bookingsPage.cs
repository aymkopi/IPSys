using System.Data;
using System.Windows;
using AntdUI;
using Microsoft.Data.SqlClient;
using FontStyle = System.Drawing.FontStyle;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace IPSys
{
    public partial class bookingsPage : Form
    {
        public List<DateTime> SchedDatesList = new List<DateTime>();

        public List<int> SchedDatesNumList = new List<int>();

        private string connectionString = "Data Source=DESKTOP-0IG0ARM\\SQLEXPRESS;" +
                                "Initial Catalog= owlie;" +
                "Integrated Security=True;" +
                "Trust Server Certificate=True";

        private DateTime dateTimeNow = DateTime.Now;

        public bookingsPage()
        {
            InitializeComponent();
            PopulateSchedDates();

            this.DoubleBuffered = true;
        }

        public void GeneratePanelsForSelectedDate(DateTime selectedDate)
        {
            string query = @"
                SELECT
                    b.Event_Name, c.Client_Name, b.Date, b.Time
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

                        if (reader.HasRows)
                        {
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

                                AntdUI.Button buttonDeleteBooking = new AntdUI.Button
                                {
                                    Name = $"buttonDeleteBooking{panelIndex}",
                                    Location = new Point(334, 95),
                                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                                    Size = new Size(42, 36),
                                    BorderWidth = 1F,
                                    Ghost = true,
                                    Icon = Properties.Resources.delete,
                                    IconGap = 0F,
                                    TabIndex = 20,
                                    Type = AntdUI.TTypeMini.Error
                                };

                                AntdUI.Button buttonEditBooking = new AntdUI.Button
                                {
                                    Name = $"buttonEditBooking{panelIndex}",
                                    Location = new Point(292, 95),
                                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                                    Size = new Size(42, 36),
                                    BorderWidth = 1F,
                                    Ghost = true,
                                    Icon = Properties.Resources.edit,
                                    IconGap = 0F,
                                    TabIndex = 19,
                                    Type = AntdUI.TTypeMini.Warn,
                                };

                                buttonEditBooking.Click += DeleteBookingButton_Click;

                                // Add the label to the panel
                                panel.Controls.Add(eventNameLabel);
                                panel.Controls.Add(clientNameLabel);
                                panel.Controls.Add(timeLabel);
                                panel.Controls.Add(eventBadge);
                                panel.Controls.Add(buttonDeleteBooking);
                                panel.Controls.Add(buttonEditBooking);

                                // Add the panel to the StackPanel
                                stackPanel1.Controls.Add(panel);
                                //h
                                panelIndex++;
                            }
                        }
                        else
                        {
                            // No bookings found for the selected date
                            AntdUI.Label noBookingsLabel = new AntdUI.Label
                            {
                                Name = "noBookingsLabel",
                                Font = new Font("Poppins", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0),
                                Location = new Point(25, 22),
                                Size = new Size(200, 23),
                                Text = "No bookings found for this date.",
                                TextAlign = ContentAlignment.MiddleCenter,
                                
                            };
                            stackPanel1.Controls.Add(noBookingsLabel);
                        }


                        // Resume layout updates after panel update
                        stackPanel1.ResumeLayout();
                    }
                }
            }
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

        private TState BadgeState(DateTime dateTime)
        {
            if (dateTime < dateTimeNow)
            {
                return TState.Success;
            }
            else if (dateTime > dateTimeNow)
            {
                return TState.Primary;
            }
            else if (dateTime == dateTimeNow)
            {
                return TState.Processing;
            }
            else
            {
                return TState.Default;
            }
        }

        private void calendar1_DateChanged(object sender, DateTimeEventArgs e)
        {
            GeneratePanelsForSelectedDate(calendar.Value);
        }

        private void CreateBookingButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of the bookingPanel form
            bookingPanel bookingForm = new bookingPanel();

            // Display it as a modal dialog
            bookingForm.ShowDialog();
        }

        private void DeleteBookingButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of the bookingPanel form
            bookingPanel bookingForm = new bookingPanel();

            // Display it as a modal dialog
            bookingForm.ShowDialog();
        }

        // Helper method to format TimeSpan to 12-hour time with AM/PM
        private string FormatTime(TimeSpan timeSpan)
        {
            // Convert TimeSpan to DateTime (arbitrary date)
            DateTime dateTime = DateTime.Today.Add(timeSpan);

            // Format DateTime to 12-hour time with AM/PM
            return dateTime.ToString("hh:mm tt");
        }
    }
}