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
            SubmitBookingToDB();
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

            isCreateBookingBtnEnabled = true;

            // Update the UI or button state if needed
            createBookingBtn.Enabled = isCreateBookingBtnEnabled;
        }

        private void selectEventType_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            CreateButtonStatus();
        }


        private void SubmitBookingToDB()
        {
            // Retrieve input values from the UI
            string eventName = inputEventName.Text;
            string eventType = selectEventType.SelectedIndex.ToString();
            string packageInclusion = selectMultiplePackageInclusion.SelectedValue.ToString();
            DateTime eventDateFrom = datePickerRange.Value[0];
            DateTime eventDateTo = datePickerRange.Value[1];
            TimeSpan eventTime = timePicker.Value;
            string location = inputLocation.Text;
            string clientName = inputClientName.Text;
            string contactNum = inputContactNum.Text;
            string employeeAssigned = selectMultipleEmployeesAssigned.SelectedValue.ToString();
            string paymentStatus = segmentPayment.SelectIndex.ToString() + 1; // Adjusted to use the value of PStatus_Type
            string notes = inputNotes.Text;
            float cost = (float)inputNumber.Value;

            MessageBox.Show(packageInclusion);

            // Connection string (replace with your own)
            string connectionString = "your_connection_string_here";

            try
            {
                // SQL query to insert booking into the database
                string query = @"
            INSERT INTO Bookings 
            (Event_Name, Event_ID, Package_ID, DateFrom, DateTo, Time, Location, Client_ID, Cost, PStatus_ID, Employee_ID, Notes, Timestamp) 
            VALUES 
            (@EventName, 
             (SELECT Event_ID FROM Events WHERE Event_Type = @EventType), 
             (SELECT Package_ID FROM Packages WHERE Package_Type = @PackageInclusion), 
             @EventDateFrom,
             @EventDateTo,
             @EventTime,
             @Location,
             (SELECT Client_ID FROM Clients WHERE Client_Name = @ClientName AND Contact_Num = @ContactNum), 
             @Cost, 
             (SELECT PStatus_ID FROM PaymentStatus WHERE PStatus_Type = @PaymentStatus), 
             (SELECT Employee_ID FROM Employees WHERE Employee_Name = @EmployeeAssigned), 
             @Notes, 
             GETDATE()
            )";

                // Open the database connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Execute the SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@EventName", eventName);
                        cmd.Parameters.AddWithValue("@EventType", eventType);
                        cmd.Parameters.AddWithValue("@PackageInclusion", packageInclusion);
                        cmd.Parameters.AddWithValue("@EventDateFrom", eventDateFrom);
                        cmd.Parameters.AddWithValue("@EventDateTo", eventDateTo);
                        cmd.Parameters.AddWithValue("@EventTime", eventTime);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@ClientName", clientName);
                        cmd.Parameters.AddWithValue("@ContactNum", contactNum);
                        cmd.Parameters.AddWithValue("@EmployeeAssigned", employeeAssigned);
                        cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        cmd.Parameters.AddWithValue("@Notes", notes);
                        cmd.Parameters.AddWithValue("@Cost", cost);

                        // Execute the query and check the result
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking successfully added to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were affected. Please check the input data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the database operation
                MessageBox.Show($"An error occurred while submitting the booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    

}