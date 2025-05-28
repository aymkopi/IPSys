using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class bookingPanel : Form
    {
        public Boolean isCreateBookingBtnEnabled = false;
        private Form bookingsPage;
        private string connectionString = MainPage.ConnectionString();
        private int? editingBookingID = null; // Track if we are editing

        public bookingPanel(Form bookingsPage)
        {
            this.bookingsPage = bookingsPage ?? throw new ArgumentNullException(nameof(bookingsPage));
            InitializeComponent();
            ApplyRoundedCorners(7);
            InitializeInputItems();


            if (bookingsPage is IPSys.bookingsPage bp)
            {
                // Set the date picker to the chosen date
                if (bp.DateChosen != default)
                {
                    // If your date picker is a range, set both start and end to DateChosen
                    datePickerRange.Value = new DateTime[] { bp.DateChosen, bp.DateChosen };
                }
            }

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }

        private List<string> FetchListFromDB(string query, string columnName)
        {
            var result = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[columnName].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred fetching {columnName}: {ex.Message}");
            }

            return result;
        }

        public void InitializeInputItems()
        {
            // Fetch data for dropdowns
            var packageNames = FetchListFromDB("SELECT Package_Type FROM Packages WHERE IsActive = 1", "Package_Type");
            var eventTypes = FetchListFromDB("SELECT Event_Type FROM Events WHERE IsActive = 1", "Event_Type");
            var clientNames = FetchListFromDB("SELECT Client_Name FROM Clients", "Client_Name");
            var employeeNames =
                FetchListFromDB("SELECT Employee_Name FROM Employees WHERE IsActive = 1", "Employee_Name");

            // Populate UI controls
            selectMultiplePackageInclusion.Items.AddRange(packageNames.ToArray());
            selectEventType.Items.AddRange(eventTypes.ToArray());
            selectMultipleEmployeesAssigned.Items.AddRange(employeeNames.ToArray());
        }

        public void SubmitBookingToDB()
        {

            var Booking = new Booking
            {
                EventName = inputEventName.Text,
                EventType = selectEventType.SelectedValue?.ToString() ?? "",
                PackageInclusions = selectMultiplePackageInclusion.SelectedValue.Cast<string>().ToList(),
                EventDateFrom = datePickerRange.Value[0],
                EventDateTo = datePickerRange.Value[1],
                EventTime = timePicker.Value,
                Location = inputLocation.Text,
                ClientName = inputClientName.Text,
                ContactNum = inputContactNum.Text,
                ClientEmail = InputEmail.Text,
                EmployeeAssigned = selectMultipleEmployeesAssigned.SelectedValue.Cast<string>().ToList(),
                PaymentStatus = segmentPayment.SelectIndex + 1,
                Notes = inputNotes.Text,
                Cost = (float)inputNumber.Value
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Check if client exists or insert new
                    int clientID;
                    string checkClientQuery = @"
                        SELECT Client_ID FROM Clients WHERE Client_Name = @ClientName AND Contact_Num = @ContactNum AND Client_Email = @ClientEmail";
                    using (SqlCommand checkCmd = new SqlCommand(checkClientQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ClientName", Booking.ClientName);
                        checkCmd.Parameters.AddWithValue("@ContactNum", Booking.ContactNum);
                        checkCmd.Parameters.AddWithValue("@ClientEmail", Booking.ClientEmail);

                        object result = checkCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            clientID = Convert.ToInt32(result);
                        }
                        else
                        {
                            string insertClientQuery = @"
                                INSERT INTO Clients (Client_Name, Contact_Num, Client_Email)
                                VALUES (@ClientName, @ContactNum, @ClientEmail);
                                SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insertClientCmd = new SqlCommand(insertClientQuery, conn))
                            {
                                insertClientCmd.Parameters.AddWithValue("@ClientName", Booking.ClientName);
                                insertClientCmd.Parameters.AddWithValue("@ContactNum", Booking.ContactNum);
                                insertClientCmd.Parameters.AddWithValue("@ClientEmail", Booking.ClientEmail);
                                clientID = Convert.ToInt32(insertClientCmd.ExecuteScalar());
                            }
                        }
                    }

                    int bookingID;
                    if (editingBookingID.HasValue)
                    {
                        // UPDATE existing booking
                        bookingID = editingBookingID.Value;
                        string updateBookingQuery = @"
                            UPDATE Bookings SET
                                Event_Name = @EventName,
                                Event_ID = (SELECT Event_ID FROM Events WHERE Event_Type = @EventType),
                                DateFrom = @EventDateFrom,
                                DateTo = @EventDateTo,
                                Time = @EventTime,
                                Location = @Location,
                                Client_ID = @ClientID,
                                Cost = @Cost,
                                PStatus_ID = @PStatus_ID,
                                Notes = @Notes
                            WHERE Booking_ID = @BookingID;";
                        using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@EventName", Booking.EventName);
                            cmd.Parameters.AddWithValue("@EventType", Booking.EventType);
                            cmd.Parameters.AddWithValue("@EventDateFrom", Booking.EventDateFrom);
                            cmd.Parameters.AddWithValue("@EventDateTo", Booking.EventDateTo);
                            cmd.Parameters.AddWithValue("@EventTime", Booking.EventTime);
                            cmd.Parameters.AddWithValue("@Location", Booking.Location);
                            cmd.Parameters.AddWithValue("@ClientID", clientID);
                            cmd.Parameters.AddWithValue("@Cost", Booking.Cost);
                            cmd.Parameters.AddWithValue("@PStatus_ID", Booking.PaymentStatus);
                            cmd.Parameters.AddWithValue("@Notes", Booking.Notes);
                            cmd.Parameters.AddWithValue("@BookingID", bookingID);
                            cmd.ExecuteNonQuery();
                        }

                        // Clean up old relations
                        using (SqlCommand cmd =
                               new SqlCommand("DELETE FROM Bookings_Services WHERE Booking_ID = @BookingID", conn))
                        {
                            cmd.Parameters.AddWithValue("@BookingID", bookingID);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd =
                               new SqlCommand("DELETE FROM Bookings_Employees WHERE Booking_ID = @BookingID", conn))
                        {
                            cmd.Parameters.AddWithValue("@BookingID", bookingID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // INSERT new booking
                        string insertBookingQuery = @"
                            INSERT INTO Bookings 
                                (Event_Name, Event_ID, DateFrom, DateTo, Time, Location, Client_ID, Cost, PStatus_ID, Notes) 
                            VALUES 
                                (@EventName, 
                                (SELECT Event_ID FROM Events WHERE Event_Type = @EventType), 
                                @EventDateFrom,
                                @EventDateTo,
                                @EventTime,
                                @Location,
                                @ClientID, 
                                @Cost, 
                                @PStatus_ID, 
                                @Notes
                            );
                            SELECT SCOPE_IDENTITY();";
                        using (SqlCommand cmd = new SqlCommand(insertBookingQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@EventName", Booking.EventName);
                            cmd.Parameters.AddWithValue("@EventType", Booking.EventType);
                            cmd.Parameters.AddWithValue("@EventDateFrom", Booking.EventDateFrom);
                            cmd.Parameters.AddWithValue("@EventDateTo", Booking.EventDateTo);
                            cmd.Parameters.AddWithValue("@EventTime", Booking.EventTime);
                            cmd.Parameters.AddWithValue("@Location", Booking.Location);
                            cmd.Parameters.AddWithValue("@ClientID", clientID);
                            cmd.Parameters.AddWithValue("@Cost", Booking.Cost);
                            cmd.Parameters.AddWithValue("@PStatus_ID", Booking.PaymentStatus);
                            cmd.Parameters.AddWithValue("@Notes", Booking.Notes);
                            bookingID = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    // Insert Bookings_Services for each package
                    foreach (var packageType in Booking.PackageInclusions)
                    {
                        string insertService = @"
                            INSERT INTO Bookings_Services (Booking_ID, Package_ID)
                            SELECT @BookingID, Package_ID FROM Packages WHERE Package_Type = @PackageType";
                        using (SqlCommand cmdService = new SqlCommand(insertService, conn))
                        {
                            cmdService.Parameters.AddWithValue("@BookingID", bookingID);
                            cmdService.Parameters.AddWithValue("@PackageType", packageType);
                            cmdService.ExecuteNonQuery();
                        }
                    }

                    // Insert Bookings_Employees for each assigned employee
                    foreach (var employeeName in Booking.EmployeeAssigned)
                    {
                        string insertEmployee = @"
                            INSERT INTO Bookings_Employees (Booking_ID, Employee_ID)
                            SELECT @BookingID, Employee_ID FROM Employees WHERE Employee_Name = @EmployeeName";
                        using (SqlCommand cmdEmployee = new SqlCommand(insertEmployee, conn))
                        {
                            cmdEmployee.Parameters.AddWithValue("@BookingID", bookingID);
                            cmdEmployee.Parameters.AddWithValue("@EmployeeName", employeeName);
                            cmdEmployee.ExecuteNonQuery();
                        }
                    }
                }

                if (bookingsPage is bookingsPage bp)
                {
                    if (bp.InvokeRequired)
                    {
                        bp.Invoke(new Action(() => bp.PopulateBadgesOnDates()));
                    }
                    else
                    {
                        bp.PopulateBadgesOnDates();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        /// <summary>
        /// Applies rounded corners to the form.
        /// </summary>
        private void ApplyRoundedCorners(int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            int diameter = cornerRadius * 2;

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top-left
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top-right
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left
            path.CloseFigure();

            this.Region = new Region(path);
        }

        /// <summary>
        /// Handles text change in input fields to update button status.
        /// </summary>
        private void bookingsInput_TextChanged(object sender, EventArgs e)
        {
            CreateButtonStatus();
        }

        /// <summary>
        /// Handles selection change in multi-selects to update button status.
        /// </summary>s
        private void bookingsInputSelectMultiple_SelectedValueChanged(object sender, AntdUI.ObjectsEventArgs e)
        {
            CreateButtonStatus();
        }

        /// <summary>
        /// Closes the booking panel.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles booking creation confirmation and submission.
        /// </summary>
        private void createBookingBtn_Click(object sender, EventArgs e)
        {
            Boolean closeBookingPanel = false;

            AntdUI.Modal.open(new AntdUI.Modal.Config(this, "Confirmation",
                "Kindly check your booking details. If all the information is correct, please confirm to proceed.")
            {
                Icon = TType.Info,
                Font = new Font("Poppins", 9, FontStyle.Regular),
                Padding = new Size(24, 20),
                CancelFont = new Font("Poppins", 9, FontStyle.Bold),
                OkFont = new Font("Poppins", 9, FontStyle.Bold),
                OnOk = config =>
                {
                    Thread.Sleep(2000);
                    SubmitBookingToDB();
                    AntdUI.Notification.success(bookingsPage, "Booking Created",
                        "Your booking has been successfully created! Check your booking details below or go to your dashboard for more info.",
                        autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                    closeBookingPanel = true;
                    return true;
                },
            });

            if (closeBookingPanel)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Validates all input fields and updates the create booking button status.
        /// </summary>
        private void CreateButtonStatus()
        {
            isCreateBookingBtnEnabled = true;

            // Validate each input and update status
            if (string.IsNullOrWhiteSpace(inputEventName?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputEventName.Status = TType.Error;
            }
            else inputEventName.Status = TType.None;

            if (selectEventType.SelectedIndex == -1)
            {
                isCreateBookingBtnEnabled = false;
                selectEventType.Status = TType.Error;
            }
            else selectEventType.Status = TType.None;

            if (selectMultiplePackageInclusion.SelectedValue.Length == 0)
            {
                isCreateBookingBtnEnabled = false;
                selectMultiplePackageInclusion.Status = TType.Error;
            }
            else selectMultiplePackageInclusion.Status = TType.None;

            if (datePickerRange.Text == null || datePickerRange.Value == null || datePickerRange.Text == "")
            {
                isCreateBookingBtnEnabled = false;
                datePickerRange.Status = TType.Error;
            }
            else datePickerRange.Status = TType.None;

            if (timePicker == null || timePicker.Value == TimeSpan.Zero)
            {
                isCreateBookingBtnEnabled = false;
                timePicker.Status = TType.Error;
            }
            else timePicker.Status = TType.None;

            if (string.IsNullOrWhiteSpace(inputClientName?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputClientName.Status = TType.Error;
            }
            else inputClientName.Status = TType.None;

            if (string.IsNullOrWhiteSpace(inputContactNum?.Text) || inputContactNum.Text.Any(char.IsAsciiLetter) ||
                inputContactNum.Text.Length != 11 || !inputContactNum.Text.StartsWith("09"))
            {
                isCreateBookingBtnEnabled = false;
                inputContactNum.Status = TType.Error;

                AntdUI.Tooltip.open(new AntdUI.Tooltip.Config(inputContactNum, "Please enter a valid number.")
                {
                    Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ArrowAlign = TAlign.BL,
                });
            }
            else
            {
                inputContactNum.Status = TType.None;
                this.Focus();
            }

            if (selectMultipleEmployeesAssigned.SelectedValue.Length == 0)
            {
                isCreateBookingBtnEnabled = false;
                selectMultipleEmployeesAssigned.Status = TType.Error;
            }
            else selectMultipleEmployeesAssigned.Status = TType.None;

            createBookingBtn.Enabled = isCreateBookingBtnEnabled;
        }

        /// <summary>
        /// Handles event type selection change to update button status.
        /// </summary>
        private void selectEventType_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            CreateButtonStatus();
        }

        /// <summary>
        /// Loads booking data into the form for editing.
        /// </summary>
        public void SetDataToEdit(int bookingID)
        {
            editingBookingID = bookingID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Fetch booking details
                string query = @"
                    SELECT 
                        b.Event_Name,
                        e.Event_Type,
                        b.DateFrom,
                        b.DateTo,
                        b.Time,
                        b.Location,
                        c.Client_Name,
                        c.Contact_Num,
                        c.Client_Email,
                        b.PStatus_ID,
                        b.Notes,
                        b.Cost
                    FROM Bookings b
                    INNER JOIN Clients c ON b.Client_ID = c.Client_ID
                    INNER JOIN Events e ON b.Event_ID = e.Event_ID
                    WHERE b.Booking_id = @BookingID;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inputEventName.Text = reader["Event_Name"].ToString();
                            selectEventType.SelectedValue = reader["Event_Type"].ToString();
                            datePickerRange.Value = new DateTime[]
                            {
                                Convert.ToDateTime(reader["DateFrom"]),
                                Convert.ToDateTime(reader["DateTo"])
                            };
                            timePicker.Value = (TimeSpan)reader["Time"];
                            inputLocation.Text = reader["Location"].ToString();
                            inputClientName.Text = reader["Client_Name"].ToString();
                            inputContactNum.Text = reader["Contact_Num"].ToString();
                            InputEmail.Text = reader["Client_Email"].ToString();
                            segmentPayment.SelectIndex = Convert.ToInt32(reader["PStatus_ID"]) - 1;
                            inputNotes.Text = reader["Notes"].ToString();
                            inputNumber.Value = Convert.ToDecimal(reader["Cost"]);
                        }
                    }
                }

                // Fetch package inclusions
                string packagesQuery = @"
                    SELECT p.Package_Type
                    FROM Bookings_Services bs
                    INNER JOIN Packages p ON bs.Package_ID = p.Package_ID
                    WHERE bs.Booking_id = @BookingID;
                ";
                using (SqlCommand cmd = new SqlCommand(packagesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    var packageList = new List<string>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            packageList.Add(reader["Package_Type"].ToString());
                        }
                    }

                    selectMultiplePackageInclusion.SelectedValue = packageList.ToArray();
                }

                // Fetch employees assigned
                string employeesQuery = @"
                    SELECT e.Employee_Name
                    FROM Bookings_Employees be
                    INNER JOIN Employees e ON be.Employee_ID = e.Employee_ID
                    WHERE be.Booking_id = @BookingID;
                ";
                using (SqlCommand cmd = new SqlCommand(employeesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    var empList = new List<string>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empList.Add(reader["Employee_Name"].ToString());
                        }
                    }

                    selectMultipleEmployeesAssigned.SelectedValue = empList.ToArray();
                }
            }

            // Update UI for edit mode
            createBookingLabel.Text = "Edit Booking";
            createBookingBtn.Text = "Update";
        }

        private void bookingPanel_Load(object sender, EventArgs e)
        {
            // Reserved for future use
        }

        private void CalculateRecommendedCost(int days, decimal eventCost, int totalEmpRate, int totalPkgCost)
        {
            decimal total = days * (totalEmpRate + (totalPkgCost * eventCost));
            reccomendedRate.Text = total.ToString();
            inputNumber.Value = total;
        }

        private void UpdateRecommendedPrice_TextChanged(object sender, EventArgs e)
        {
            int days = 0;
            decimal eventCost = 0;
            int totalEmployeeRate = 0;
            int totalPackageCost = 0;
            string eventType = selectEventType.Text;
            List<string> employeeNames = new List<string>();
            List<string> packageInclusions = new List<string>();
            employeeNames.Clear();
            packageInclusions.Clear();

            // Calculating days difference
            if (datePickerRange.Value != null && datePickerRange.Value.Length >= 2 &&
            datePickerRange.Value[1] != null && datePickerRange.Value[0] != null)
            {
                days = (datePickerRange.Value[1] - datePickerRange.Value[0]).Days + 1;
            }

            // Get selected package inclusions
            if (selectMultiplePackageInclusion.SelectedValue != null)
            {
                foreach (var item in selectMultiplePackageInclusion.SelectedValue)
                {
                    packageInclusions.Add(item.ToString());
                }

                // SQL query for getting total package cost
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT Cost FROM Packages WHERE Package_Type = @PackageType";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        foreach (string packageType in packageInclusions)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@PackageType", packageType);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int cost = reader.GetInt32(reader.GetOrdinal("Cost"));
                                    totalPackageCost += cost;
                                }
                            }
                        }
                    }
                }
            }

            // Get selected employee names
            if (selectMultipleEmployeesAssigned.SelectedValue != null)
            {
                foreach (var item in selectMultipleEmployeesAssigned.SelectedValue)
                {
                    employeeNames.Add(item.ToString());
                }

                // SQL query for getting total employee rate
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT er.Rate
                           FROM Employees e
                           JOIN EmployeeRole er ON e.E_Role_ID = er.E_Role_ID
                           WHERE e.Employee_Name = @EmployeeName";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        foreach (string employeeName in employeeNames)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@EmployeeName", employeeName);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int rate = reader.GetInt32(reader.GetOrdinal("Rate"));
                                    totalEmployeeRate += rate;
                                }
                            }
                        }
                    }
                }
            }

            // Get event cost based on eventType
            if (!string.IsNullOrEmpty(eventType))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT Cost FROM Events WHERE Event_Type = @Event_Type";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Event_Type", eventType);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                              
                                eventCost = reader.GetDecimal(reader.GetOrdinal("Cost"));
                            }
                        }
                    }
                }
            }

            CalculateRecommendedCost(days, eventCost, totalEmployeeRate, totalPackageCost);
        }
    }

    /// <summary>
        /// Booking data model.
        /// </summary>
        internal class Booking
    {
        public string EventName { get; set; }
        public string EventType { get; set; }
        public List<string> PackageInclusions { get; set; }
        public DateTime EventDateFrom { get; set; }
        public DateTime EventDateTo { get; set; }
        public TimeSpan EventTime { get; set; }
        public string Location { get; set; }
        public string ClientName { get; set; }
        public string ContactNum { get; set; }
        public string ClientEmail { get; set; }
        public List<string> EmployeeAssigned { get; set; }
        public int PaymentStatus { get; set; }
        public string Notes { get; set; }
        public float Cost { get; set; }

        public Booking()
        {
            PackageInclusions = new List<string>();
            EmployeeAssigned = new List<string>();
        }
    }
}


