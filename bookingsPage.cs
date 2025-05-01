using System.Data;
using AntdUI;
using Microsoft.Data.SqlClient;
using Button = AntdUI.Button;
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
            PopulateBadgesOnDates();
            // Set the default selected date to the current date
            DateTime currentDate = DateTime.Now.Date; // Use only the date part
            GeneratePanelsForSelectedDate(currentDate); // Generate panels for the current date

            this.DoubleBuffered = true;
        }

        public void GeneratePanelsForSelectedDate(DateTime selectedDate)
        {
            string query = @"
    SELECT
        b.Event_Name, c.Client_Name, b.Date, b.Time, p.Package_Type, e.Employee_Name
    FROM Bookings b
    INNER JOIN Clients c ON b.client_id = c.client_id
    INNER JOIN Packages p ON b.Package_id = p.Package_id
    INNER JOIN Employees e ON b.Employee_id = e.Employee_id
    WHERE CAST(b.Date AS DATE) >= @SelectedDate
    ORDER BY b.Date, b.Time
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
                            DateTime? currentDay = null;
                            var controlsToAdd = new List<Control>(); // Temporary list to store controls
                            int panelIndex = 0; // Initialize panel index

                            while (reader.Read())
                            {
                                DateTime eventDate = reader.GetDateTime(2);

                                // Add a label for the day if it's a new day
                                if (currentDay == null || eventDate.Date != currentDay.Value.Date)
                                {
                                    currentDay = eventDate.Date;

                                    AntdUI.Label dayLabel = new AntdUI.Label
                                    {
                                        Name = $"dayLabel{panelIndex}",
                                        Anchor = AnchorStyles.Left,
                                        Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                        Location = new Point(10, 10), // Adjust location as necessary
                                        Size = new Size(380, 40), // Adjust size as necessary
                                        Text = currentDay.Value == DateTime.Now.Date ?
                                            "Today" : currentDay.Value.ToString("MMMM d, yyyy"),
                                        TextAlign = ContentAlignment.BottomLeft,
                                    };

                                    // Add the label to the temporary list
                                    controlsToAdd.Add(dayLabel);
                                }

                                // Create a panel for the event
                                AntdUI.Panel panel = new AntdUI.Panel
                                {
                                    Name = $"panel{panelIndex}",
                                    Size = new Size(392, 155),
                                    BackColor = Color.Transparent,
                                    Shadow = 5,
                                };

                                // Create a label for the event name
                                AntdUI.Label eventNameLabel = new AntdUI.Label
                                {
                                    Name = $"eventNameBookingLabel{panelIndex}",
                                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                    Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                    Location = new Point(44, 21),
                                    Size = new Size(286, 23),
                                    TabIndex = 0,
                                    Text = reader.GetString(0), // Get the EventName from the database
                                    AutoSize = true
                                };

                                AntdUI.Label dateTimeLabel = new AntdUI.Label
                                {
                                    Name = $"dateTimeLabel{panelIndex}",
                                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                    Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                    ForeColor = System.Drawing.SystemColors.ControlDark,
                                    Location = new Point(23, 43),
                                    Size = new Size(190, 23),
                                    TabIndex = 4,
                                    Text = FormatDate(reader.GetDateTime(2)) + " | " + FormatTime(reader.GetTimeSpan(3)),
                                    TextAlign = ContentAlignment.MiddleLeft,
                                };

                                AntdUI.Label clientNameLabel = new AntdUI.Label
                                {
                                    Name = $"clientNameLabel{panelIndex}",
                                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                    Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                    Location = new Point(23, 85),
                                    Size = new Size(231, 15),
                                    TabIndex = 1,
                                    Text = "Client: " + reader.GetString(1),
                                    AutoSize = true,
                                };

                                AntdUI.Label packageNameLabel = new AntdUI.Label
                                {
                                    Name = $"packageNameLabel{panelIndex}",
                                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                    Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                    Location = new Point(23, 100),
                                    Size = new Size(231, 15),
                                    TabIndex = 22,
                                    Text = "Package: " + reader.GetString(4),
                                    AutoSize = true
                                };
                                AntdUI.Label eventHeadLabel = new AntdUI.Label
                                {
                                    Name = $"employeeNameLabel{panelIndex}",
                                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                    Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                    Location = new Point(23, 115),
                                    Size = new Size(231, 15),
                                    TabIndex = 21,
                                    Text = "Event Head: " + reader.GetString(5),
                                    AutoSize = true
                                };

                                AntdUI.Badge eventBadge = new AntdUI.Badge
                                {
                                    Name = $"badge{panelIndex}",
                                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                    DotRatio = 0.57F,
                                    Location = new Point(19, 20),
                                    Size = new Size(22, 24),
                                    TabIndex = 3,
                                    Text = "",
                                    State = BadgeState(eventDate)
                                };

                                AntdUI.Button deleteEventButton = new Button()
                                {
                                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                    BorderWidth = 1F,
                                    Ghost = true,
                                    Icon = Properties.Resources.delete,
                                    IconGap = 0F,
                                    Location = new Point(326, 102),
                                    Name = "buttonDeleteBooking",
                                    Size = new Size(50, 35),
                                    TabIndex = 20,
                                    Type = AntdUI.TTypeMini.Error,
                                };

                                AntdUI.Button editEventButton = new Button()
                                {
                                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                    BorderWidth = 1F,
                                    Ghost = true,
                                    Icon = Properties.Resources.edit,
                                    IconGap = 0F,
                                    Location = new Point(278, 102),
                                    Name = "buttonEditBooking",
                                    Size = new Size(50, 35),
                                    TabIndex = 19,
                                    Type = AntdUI.TTypeMini.Warn,
                                };

                                AntdUI.Button goToEventDetailsButton = new Button()
                                {
                                    Ghost = true,
                                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                    Icon = Properties.Resources.right_arrow,
                                    IconGap = 1F,
                                    IconRatio = 0.7F,
                                    Location = new Point(340, 18),
                                    Name = "buttonGoToEvent",
                                    Size = new Size(40, 33),
                                    TabIndex = 19,
                                };

                                panel.Controls.Add(eventNameLabel);
                                panel.Controls.Add(dateTimeLabel);
                                panel.Controls.Add(clientNameLabel);
                                panel.Controls.Add(packageNameLabel);
                                panel.Controls.Add(eventHeadLabel);
                                panel.Controls.Add(eventBadge);
                                panel.Controls.Add(deleteEventButton);
                                panel.Controls.Add(editEventButton);
                                panel.Controls.Add(goToEventDetailsButton);

                                ;
                                // Add the panel to the temporary list
                                controlsToAdd.Add(panel);
                            }

                            // Add all controls in reverse order to stackPanel1
                            for (int i = controlsToAdd.Count - 1; i >= 0; i--)
                            {
                                stackPanel1.Controls.Add(controlsToAdd[i]);
                            }
                        }
                        else
                        {
                            AntdUI.Label dayLabel = new AntdUI.Label
                            {
                                Name = "dayLabel",
                                Font = new Font("Poppins", 10F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(10, 10), // Adjust location as necessary
                                Size = new Size(380, 40), // Adjust size as necessary
                                Text = "No bookings. Add new.",
                                TextAlign = ContentAlignment.BottomCenter,
                            };

                            stackPanel1.Controls.Add(dayLabel);
                        }

                        // Resume layout updates after panel update
                        stackPanel1.ResumeLayout();
                    }
                }
            }
        }

        public void PopulateBadgesOnDates()
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

        private string FormatDate(DateTime dateTime)
        {
            // Format DateTime to 12-hour time with AM/PM
            return dateTime.ToString("MMMM dd, yyyy");
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