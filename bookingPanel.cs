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



namespace IPSys
{
    public partial class bookingPanel : Form
    {
        public Boolean isCreateButtonEnabled = false;

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
            if (inputEventName == null)
            {
                isCreateButtonEnabled = false;
            }
            if (selectEventType.SelectedIndex == -1)
            {
                isCreateButtonEnabled = false;
            }
            if (selectMultiplePackageInclusion.Items.Count == 0)
            {
                isCreateButtonEnabled = false;
            }
            if (datePickerRange == null)
            {
                isCreateButtonEnabled = false;
            }
            if (timePicker == null || timePicker.Value == TimeSpan.Zero)
            {
                isCreateButtonEnabled = false;
            }
            if (inputClientName == null)
            {
                isCreateButtonEnabled = false;
            }
            if (inputContactNum == null)
            {
                isCreateButtonEnabled = false;
            }
            if (selectMultipleEmployeesAssigned.Items.Count == 0)
            {
                isCreateButtonEnabled = false;
            }


        }

    }
}
