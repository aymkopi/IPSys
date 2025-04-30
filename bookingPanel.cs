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



namespace IPSys
{
    public partial class bookingPanel : Form
    {
        public Boolean isCreateBookingBtnEnabled = false;

        public bookingPanel()
        {
            InitializeComponent();

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
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90); // Bottom-right corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Apply the GraphicsPath to the form's Region
            this.Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Reapply rounded corners when the form is resized
            ApplyRoundedCorners(7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void createButtonStatus()
        {
            // Initialize to true and set to false if any condition is not met
            isCreateBookingBtnEnabled = true;

            // Check if the input fields are null or invalid
            if (string.IsNullOrWhiteSpace(inputEventName?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }
            if (selectEventType.SelectedIndex == -1)
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }
            if (selectMultiplePackageInclusion.SelectedValue.Count() == 0)
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }
            if (datePickerRange.Text == null || datePickerRange.Value == null || datePickerRange.Text == "")
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }
            if (timePicker == null || timePicker.Value == TimeSpan.Zero)
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }
            if (string.IsNullOrWhiteSpace(inputClientName?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }
            if (string.IsNullOrWhiteSpace(inputContactNum?.Text))
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }

            if (selectMultipleEmployeesAssigned.SelectedValue.Count() == 0)
            {
                isCreateBookingBtnEnabled = false;
                inputNotes.Text += isCreateBookingBtnEnabled.ToString();
            }

            if (inputContactNum.Text.Any(char.IsAsciiLetter))
            {
                inputContactNum.Status = TType.Error;
            } else
            {
                inputContactNum.Status = TType.None;
            }


            isCreateBookingBtnEnabled = true;




                // Update the UI or button state if needed
                createBookingBtn.Enabled = isCreateBookingBtnEnabled;
        }

        private void bookingsInput_TextChanged(object sender, EventArgs e)
        {
            createButtonStatus();
        }

        private void bookingsInputSelectMultiple_SelectedValueChanged(object sender, AntdUI.ObjectsEventArgs e)
        {
            createButtonStatus();
        }

        private void selectEventType_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            createButtonStatus();
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
                    AntdUI.Notification.success(this, "Booking Created", "Your booking has been successfully created! Check your booking details below or go to your dashboard for more info.", autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                    //call method here to submit data to database
                    closeBookingPanel = true;
                    return true; 
                },
            });

            if (closeBookingPanel)
            {
                this.Close();
            }   


        }
    }
}
