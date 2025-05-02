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
        private readonly Form bookingsPage;

        private string connectionString = MainPage.ConnectionString();

        public bookingPanel(Form bookingsPage)
        {
            this.bookingsPage = bookingsPage ?? throw new ArgumentNullException(nameof(bookingsPage));
            InitializeComponent();
            ApplyRoundedCorners(7);
            InitializeInputItems();
        }

        public void InitializeInputItems()
        {
            List<string> packageNames = new List<string>();
            List<string> eventTypes = new List<string>();
            List<string> clientNames = new List<string>();
            List<string> employeeNames = new List<string>();

            try
            {
                // Fetch package names
                string packageQuery = "SELECT Package_Type FROM Packages";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(packageQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                packageNames.Add(reader["Package_Type"].ToString());
                            }
                        }
                    }
                }

                // Fetch event types
                string eventQuery = "SELECT Event_Type FROM Events";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(eventQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                eventTypes.Add(reader["Event_Type"].ToString());
                            }
                        }
                    }
                }

                // Fetch client names
                string clientQuery = "SELECT Client_Name FROM Clients";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(clientQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientNames.Add(reader["Client_Name"].ToString());
                            }
                        }
                    }
                }

                // Fetch employee names
                string employeeQuery = "SELECT Employee_Name FROM Employees";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(employeeQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employeeNames.Add(reader["Employee_Name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            foreach (string packageName in packageNames)
            {
                selectMultiplePackageInclusion.Items.Add(packageName);
            }
            foreach (string eventType in eventTypes)
            {
                selectEventType.Items.Add(eventType);
            }
            foreach (string employeeName in employeeNames)
            {
                selectMultipleEmployeesAssigned.Items.Add(employeeName);
            }
        }

        public void SubmitBookingToDB()
        {
            string eventName = inputEventName.Text;
            string eventType = selectEventType.SelectedValue.ToString();
            List<string> packageInclusions = selectMultiplePackageInclusion.SelectedValue.Cast<string>().ToList();
            DateTime eventDateFrom = datePickerRange.Value[0];
            DateTime eventDateTo = datePickerRange.Value[1];
            TimeSpan eventTime = timePicker.Value;
            string location = inputLocation.Text;
            string clientName = inputClientName.Text;
            string contactNum = inputContactNum.Text;
            List<string> employeeAssigned = selectMultipleEmployeesAssigned.SelectedValue.Cast<string>().ToList();
            int paymentStatus = Convert.ToInt32(segmentPayment.SelectIndex.ToString()) + 1;
            string notes = inputNotes.Text;
            float cost = (float)inputNumber.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Check if client exists
                    int clientID;
                    string checkClientQuery = @"
                SELECT Client_ID FROM Clients WHERE Client_Name = @ClientName AND Contact_Num = @ContactNum";
                    using (SqlCommand checkCmd = new SqlCommand(checkClientQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ClientName", clientName);
                        checkCmd.Parameters.AddWithValue("@ContactNum", contactNum);

                        object result = checkCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            clientID = Convert.ToInt32(result);
                            MessageBox.Show("here");
                        }
                        else
                        {
                            // 2. Insert new client if not exists
                            string insertClientQuery = @"
                        INSERT INTO Clients (Client_Name, Contact_Num)
                        VALUES (@ClientName, @ContactNum);
                        SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insertClientCmd = new SqlCommand(insertClientQuery, conn))
                            {
                                insertClientCmd.Parameters.AddWithValue("@ClientName", clientName);
                                insertClientCmd.Parameters.AddWithValue("@ContactNum", contactNum);
                                clientID = Convert.ToInt32(insertClientCmd.ExecuteScalar());
                            }
                        }
                    }

                    // 3. Insert into Bookings and retrieve Booking_ID
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
                    SqlCommand cmd = new SqlCommand(insertBookingQuery, conn);
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@EventType", eventType);
                    cmd.Parameters.AddWithValue("@EventDateFrom", eventDateFrom);
                    cmd.Parameters.AddWithValue("@EventDateTo", eventDateTo);
                    cmd.Parameters.AddWithValue("@EventTime", eventTime);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@ClientID", clientID);
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.Parameters.AddWithValue("@PStatus_ID", paymentStatus);
                    cmd.Parameters.AddWithValue("@Notes", notes);

                    int bookingID = Convert.ToInt32(cmd.ExecuteScalar());

                    // Insert into Bookings_Services (for each package)
                    foreach (var packageType in packageInclusions)
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

                    // Insert into Bookings_Employees (for each employee)
                    foreach (var employeeName in employeeAssigned)
                    {
                        string insertEmployee = @"
                    INSERT INTO Bookings_Employees (Booking_ID, Employee_ID)
                    SELECT @BookingID, Employee_ID FROM Employees WHERE Employee_Name = @EmployeeName";
                        using (SqlCommand cmdEmp = new SqlCommand(insertEmployee, conn))
                        {
                            cmdEmp.Parameters.AddWithValue("@BookingID", bookingID);
                            cmdEmp.Parameters.AddWithValue("@EmployeeName", employeeName);
                            cmdEmp.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Booking successfully added to the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while submitting the booking: {ex.Message}");
            }
        }

        private void ApplyRoundedCorners(int cornerRadius)
        {
            // Create a new GraphicsPath for rounded corners
            GraphicsPath path = new GraphicsPath();

            // Define the rounded rectangle
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            int diameter = cornerRadius * 2;

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90); // Top-left corner
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90); // Top-right corner
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0,
                90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Apply the GraphicsPath to the form's Region
            this.Region = new Region(path);
        }

        private void bookingsInput_TextChanged(object sender, EventArgs e)
        {
            CreateButtonStatus();
        }

        private void bookingsInputSelectMultiple_SelectedValueChanged(object sender, AntdUI.ObjectsEventArgs e)
        {
            CreateButtonStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createBookingBtn_Click(object sender, EventArgs e)
        {
            Boolean closeBookingPanel = false;

            AntdUI.Modal.open(new AntdUI.Modal.Config(this, "Confirmation", "Kindly check your booking details. If all the information is correct, please confirm to proceed.")
            {
                Icon = TType.Info,
                Font = new Font("Poppins", 9, FontStyle.Regular),
                Padding = new Size(24, 20),

                CancelFont = new Font("Poppins", 9, FontStyle.Bold),
                OkFont = new Font("Poppins", 9, FontStyle.Bold),

                OnOk = config =>
                {
                    Thread.Sleep(2000);

                    AntdUI.Notification.success(bookingsPage, "Booking Created", "Your booking has been successfully created! Check your booking details below or go to your dashboard for more info.", autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));

                    // Close the booking panel dialog
                    closeBookingPanel = true;

                    return true;
                },
            });

            if (closeBookingPanel)
            {
                this.Close();
            }
        }

        private void CreateButtonStatus()
        {
            // Initialize to true and set to false if any condition is not met
            isCreateBookingBtnEnabled = true;

            // Check if the input fields are null or invalid
            if (string.IsNullOrWhiteSpace(inputEventName?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputEventName.Status = TType.Error;
            }
            else
            {
                inputEventName.Status = TType.None;
            }
            if (selectEventType.SelectedIndex == -1)
            {
                isCreateBookingBtnEnabled = false;
                selectEventType.Status = TType.Error;
            }
            else
            {
                selectEventType.Status = TType.None;
            }

            if (selectMultiplePackageInclusion.SelectedValue.Length == 0)
            {
                isCreateBookingBtnEnabled = false;
                selectMultiplePackageInclusion.Status = TType.Error;
            }
            else
            {
                selectMultiplePackageInclusion.Status = TType.None;
            }
            if (datePickerRange.Text == null || datePickerRange.Value == null || datePickerRange.Text == "")
            {
                isCreateBookingBtnEnabled = false;
                datePickerRange.Status = TType.Error;
            }
            else
            {
                datePickerRange.Status = TType.None;
            }
            if (timePicker == null || timePicker.Value == TimeSpan.Zero)
            {
                isCreateBookingBtnEnabled = false;
                timePicker.Status = TType.Error;
            }
            else
            {
                timePicker.Status = TType.None;
            }
            if (string.IsNullOrWhiteSpace(inputClientName?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputClientName.Status = TType.Error;
            }
            else
            {
                inputClientName.Status = TType.None;
            }
            if (string.IsNullOrWhiteSpace(inputContactNum?.Text) || inputContactNum.Text.Any(char.IsAsciiLetter) || inputContactNum.Text.Length != 11)
            {
                isCreateBookingBtnEnabled = false;
                inputContactNum.Status = TType.Error;

                if (inputContactNum.Text.Any(char.IsAsciiLetter))
                {
                    AntdUI.Tooltip.open(new AntdUI.Tooltip.Config(inputContactNum, "Please enter a valid number.")
                    {
                        Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        ArrowAlign = TAlign.Right,
                    });
                }
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
            else
            {
                selectMultipleEmployeesAssigned.Status = TType.None;
            }

           // isCreateBookingBtnEnabled = true;

            // Update the UI or button state if needed
            createBookingBtn.Enabled = isCreateBookingBtnEnabled;
        }

        private void selectEventType_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            CreateButtonStatus();
        }

        public void SetDataToEdit(int bookingID)
        {

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
        b.PStatus_ID,
        b.Notes,
        b.Cost
    FROM Bookings b
    INNER JOIN Clients c ON b.Client_ID = c.Client_ID
    INNER JOIN Events e ON b.Event_ID = e.Event_ID
    WHERE b.Booking_id = @BookingID;
    ";

            string packagesQuery = @"
    SELECT p.Package_Type
    FROM Bookings_Services bs
    INNER JOIN Packages p ON bs.Package_ID = p.Package_ID
    WHERE bs.Booking_id = @BookingID;
    ";

            string employeesQuery = @"
    SELECT e.Employee_Name
    FROM Bookings_Employees be
    INNER JOIN Employees e ON be.Employee_ID = e.Employee_ID
    WHERE be.Booking_id = @BookingID;
    ";

            using (SqlConnection conn = new SqlConnection(MainPage.ConnectionString()))
            {
                conn.Open();

                // Retrieve main booking details
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inputEventName.Text = reader.GetString(0);
                            selectEventType.SelectedValue = reader.GetString(1); // EventType
                            datePickerRange.Value = new DateTime[] { reader.GetDateTime(2), reader.GetDateTime(3) };
                            timePicker.Value = reader.GetTimeSpan(4);
                            inputLocation.Text = reader.GetString(5);
                            inputClientName.Text = reader.GetString(6);
                            inputContactNum.Text = reader.GetString(7);
                            segmentPayment.SelectIndex = reader.GetInt32(8) - 1;
                            inputNotes.Text = reader.IsDBNull(9) ? "" : reader.GetString(9);
                            inputNumber.Value = Convert.ToDecimal(reader.GetDouble(10)); // Assuming Cost is decimal in db and control
                        }
                    }
                }

                // Retrieve multi-select packages
                using (SqlCommand cmd = new SqlCommand(packagesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var packageList = new List<string>();
                        while (reader.Read())
                        {
                            packageList.Add(reader.GetString(0));
                        }
                        selectMultiplePackageInclusion.SelectedValue = packageList.ToArray();
                    }
                }

                // Retrieve multi-select employees
                using (SqlCommand cmd = new SqlCommand(employeesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var employeeList = new List<string>();
                        while (reader.Read())
                        {
                            employeeList.Add(reader.GetString(0));
                        }
                        selectMultipleEmployeesAssigned.SelectedValue = employeeList.ToArray();

                    }
                }
            }
        }

    }


    
}