namespace IPSys
{
    partial class bookingPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bookingPanel));
            AntdUI.SegmentedItem segmentedItem1 = new AntdUI.SegmentedItem();
            AntdUI.SegmentedItem segmentedItem2 = new AntdUI.SegmentedItem();
            AntdUI.SegmentedItem segmentedItem3 = new AntdUI.SegmentedItem();
            eventNameLabel = new AntdUI.Label();
            createBookingLabel = new AntdUI.Label();
            label1 = new AntdUI.Label();
            inputEventName = new AntdUI.Input();
            label2 = new AntdUI.Label();
            selectEventType = new AntdUI.Select();
            selectMultiplePackageInclusion = new AntdUI.SelectMultiple();
            label3 = new AntdUI.Label();
            dateLabel = new AntdUI.Label();
            inputClientName = new AntdUI.Input();
            label4 = new AntdUI.Label();
            inputContactNum = new AntdUI.Input();
            label5 = new AntdUI.Label();
            label6 = new AntdUI.Label();
            selectMultipleEmployeesAssigned = new AntdUI.SelectMultiple();
            createBookingBtn = new AntdUI.Button();
            inputNotes = new AntdUI.Input();
            label7 = new AntdUI.Label();
            button1 = new AntdUI.Button();
            timeLabel = new AntdUI.Label();
            timePicker = new AntdUI.TimePicker();
            datePickerRange = new AntdUI.DatePickerRange();
            label8 = new AntdUI.Label();
            inputNumber = new AntdUI.InputNumber();
            label9 = new AntdUI.Label();
            label10 = new AntdUI.Label();
            label11 = new AntdUI.Label();
            segmentPayment = new AntdUI.Segmented();
            divider1 = new AntdUI.Divider();
            inputLocation = new AntdUI.Input();
            locationLabel = new AntdUI.Label();
            SuspendLayout();
            // 
            // eventNameLabel
            // 
            eventNameLabel.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventNameLabel.Location = new Point(39, 131);
            eventNameLabel.Name = "eventNameLabel";
            eventNameLabel.Size = new Size(106, 23);
            eventNameLabel.TabIndex = 2;
            eventNameLabel.TabStop = false;
            eventNameLabel.Text = "Event Name";
            // 
            // createBookingLabel
            // 
            createBookingLabel.Font = new Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createBookingLabel.Location = new Point(383, 27);
            createBookingLabel.Name = "createBookingLabel";
            createBookingLabel.Size = new Size(222, 36);
            createBookingLabel.TabIndex = 3;
            createBookingLabel.TabStop = false;
            createBookingLabel.Text = "Create Booking";
            createBookingLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Poppins", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(61, 60);
            label1.Name = "label1";
            label1.Size = new Size(901, 44);
            label1.TabIndex = 4;
            label1.TabStop = false;
            label1.Text = resources.GetString("label1.Text");
            // 
            // inputEventName
            // 
            inputEventName.Font = new Font("Poppins", 9.75F);
            inputEventName.Location = new Point(36, 151);
            inputEventName.Name = "inputEventName";
            inputEventName.Size = new Size(270, 40);
            inputEventName.TabIndex = 0;
            inputEventName.TextChanged += bookingsInput_TextChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(342, 198);
            label2.Name = "label2";
            label2.Size = new Size(106, 23);
            label2.TabIndex = 6;
            label2.Text = "Event Type";
            // 
            // selectEventType
            // 
            selectEventType.Font = new Font("Poppins", 9.75F);
            selectEventType.Location = new Point(336, 218);
            selectEventType.Name = "selectEventType";
            selectEventType.Size = new Size(152, 40);
            selectEventType.TabIndex = 2;
            selectEventType.SelectedIndexChanged += selectEventType_SelectedIndexChanged;
            // 
            // selectMultiplePackageInclusion
            // 
            selectMultiplePackageInclusion.Font = new Font("Poppins", 9.75F);
            selectMultiplePackageInclusion.Location = new Point(36, 218);
            selectMultiplePackageInclusion.Name = "selectMultiplePackageInclusion";
            selectMultiplePackageInclusion.Size = new Size(292, 40);
            selectMultiplePackageInclusion.TabIndex = 1;
            selectMultiplePackageInclusion.SelectedValueChanged += bookingsInputSelectMultiple_SelectedValueChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(42, 198);
            label3.Name = "label3";
            label3.Size = new Size(176, 23);
            label3.TabIndex = 9;
            label3.TabStop = false;
            label3.Text = "Package Inclusion";
            // 
            // dateLabel
            // 
            dateLabel.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateLabel.Location = new Point(320, 133);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(151, 23);
            dateLabel.TabIndex = 11;
            dateLabel.TabStop = false;
            dateLabel.Text = "Date";
            // 
            // inputClientName
            // 
            inputClientName.Font = new Font("Poppins", 9.75F);
            inputClientName.Location = new Point(39, 297);
            inputClientName.Name = "inputClientName";
            inputClientName.Size = new Size(270, 40);
            inputClientName.TabIndex = 5;
            inputClientName.TextChanged += bookingsInput_TextChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(42, 277);
            label4.Name = "label4";
            label4.Size = new Size(106, 23);
            label4.TabIndex = 13;
            label4.TabStop = false;
            label4.Text = "Client Name";
            // 
            // inputContactNum
            // 
            inputContactNum.Font = new Font("Poppins", 9.75F);
            inputContactNum.Location = new Point(323, 297);
            inputContactNum.Name = "inputContactNum";
            inputContactNum.Size = new Size(202, 40);
            inputContactNum.TabIndex = 6;
            inputContactNum.TextChanged += bookingsInput_TextChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(326, 277);
            label5.Name = "label5";
            label5.Size = new Size(106, 23);
            label5.TabIndex = 15;
            label5.Text = "Contact";
            // 
            // label6
            // 
            label6.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(42, 356);
            label6.Name = "label6";
            label6.Size = new Size(203, 23);
            label6.TabIndex = 18;
            label6.TabStop = false;
            label6.Text = "Employee/s Assigned";
            // 
            // selectMultipleEmployeesAssigned
            // 
            selectMultipleEmployeesAssigned.Font = new Font("Poppins", 9.75F);
            selectMultipleEmployeesAssigned.Location = new Point(36, 376);
            selectMultipleEmployeesAssigned.Name = "selectMultipleEmployeesAssigned";
            selectMultipleEmployeesAssigned.Size = new Size(292, 40);
            selectMultipleEmployeesAssigned.TabIndex = 7;
            selectMultipleEmployeesAssigned.SelectedValueChanged += bookingsInputSelectMultiple_SelectedValueChanged;
            // 
            // createBookingBtn
            // 
            createBookingBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createBookingBtn.Enabled = false;
            createBookingBtn.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createBookingBtn.Location = new Point(836, 578);
            createBookingBtn.Name = "createBookingBtn";
            createBookingBtn.Size = new Size(120, 43);
            createBookingBtn.TabIndex = 12;
            createBookingBtn.Text = "Create";
            createBookingBtn.Type = AntdUI.TTypeMini.Primary;
            createBookingBtn.Click += createBookingBtn_Click;
            // 
            // inputNotes
            // 
            inputNotes.AllowDrop = true;
            inputNotes.Font = new Font("Poppins", 9.75F);
            inputNotes.Location = new Point(36, 456);
            inputNotes.Multiline = true;
            inputNotes.Name = "inputNotes";
            inputNotes.PlaceholderText = "Enter additional notes here...";
            inputNotes.Size = new Size(606, 165);
            inputNotes.TabIndex = 9;
            // 
            // label7
            // 
            label7.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(41, 436);
            label7.Name = "label7";
            label7.Size = new Size(173, 23);
            label7.TabIndex = 21;
            label7.TabStop = false;
            label7.Text = "Additional Notes";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackHover = Color.Red;
            button1.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(710, 578);
            button1.Name = "button1";
            button1.Size = new Size(120, 43);
            button1.TabIndex = 11;
            button1.Text = "Cancel";
            button1.Click += button1_Click;
            // 
            // timeLabel
            // 
            timeLabel.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeLabel.Location = new Point(553, 133);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(77, 23);
            timeLabel.TabIndex = 24;
            timeLabel.TabStop = false;
            timeLabel.Text = "Time";
            // 
            // timePicker
            // 
            timePicker.Font = new Font("Poppins", 9.75F);
            timePicker.Format = "HH:mm";
            timePicker.Location = new Point(548, 151);
            timePicker.Name = "timePicker";
            timePicker.Size = new Size(94, 40);
            timePicker.TabIndex = 4;
            timePicker.Text = "00:00";
            timePicker.TextChanged += bookingsInput_TextChanged;
            // 
            // datePickerRange
            // 
            datePickerRange.Font = new Font("Poppins", 9.75F);
            datePickerRange.Format = "MM-dd-yy";
            datePickerRange.Location = new Point(314, 151);
            datePickerRange.Name = "datePickerRange";
            datePickerRange.Size = new Size(226, 40);
            datePickerRange.TabIndex = 3;
            datePickerRange.TextChanged += bookingsInput_TextChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(840, 500);
            label8.Name = "label8";
            label8.Size = new Size(106, 23);
            label8.TabIndex = 27;
            label8.Text = "Total";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // inputNumber
            // 
            inputNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            inputNumber.DecimalPlaces = 2;
            inputNumber.Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            inputNumber.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            inputNumber.Location = new Point(786, 519);
            inputNumber.Name = "inputNumber";
            inputNumber.PrefixText = "₱";
            inputNumber.Size = new Size(170, 41);
            inputNumber.TabIndex = 10;
            inputNumber.Text = "0.00";
            inputNumber.TextAlign = HorizontalAlignment.Right;
            inputNumber.ThousandsSeparator = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.Font = new Font("Poppins", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonShadow;
            label9.Location = new Point(809, 456);
            label9.Name = "label9";
            label9.Size = new Size(137, 23);
            label9.TabIndex = 29;
            label9.Text = "Recommended Rate";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ButtonShadow;
            label10.Location = new Point(809, 473);
            label10.Name = "label10";
            label10.Size = new Size(137, 23);
            label10.TabIndex = 30;
            label10.Text = "0.00";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(353, 356);
            label11.Name = "label11";
            label11.Size = new Size(95, 23);
            label11.TabIndex = 31;
            label11.TabStop = false;
            label11.Text = "Payment";
            // 
            // segmentPayment
            // 
            segmentPayment.BackActive = Color.DodgerBlue;
            segmentPayment.BackColor = SystemColors.ControlLightLight;
            segmentPayment.BarColor = SystemColors.Highlight;
            segmentPayment.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            segmentPayment.ForeActive = SystemColors.ControlLightLight;
            segmentPayment.Full = true;
            segmentedItem1.Badge = null;
            segmentedItem1.BadgeAlign = AntdUI.TAlignFrom.TR;
            segmentedItem1.BadgeBack = null;
            segmentedItem1.BadgeMode = false;
            segmentedItem1.BadgeOffsetX = 0;
            segmentedItem1.BadgeOffsetY = 0;
            segmentedItem1.BadgeSize = 0.6F;
            segmentedItem1.BadgeSvg = null;
            segmentedItem1.Text = "Unpaid";
            segmentedItem2.Badge = null;
            segmentedItem2.BadgeAlign = AntdUI.TAlignFrom.TR;
            segmentedItem2.BadgeBack = null;
            segmentedItem2.BadgeMode = false;
            segmentedItem2.BadgeOffsetX = 0;
            segmentedItem2.BadgeOffsetY = 0;
            segmentedItem2.BadgeSize = 0.6F;
            segmentedItem2.BadgeSvg = null;
            segmentedItem2.Text = "Partial";
            segmentedItem3.Badge = null;
            segmentedItem3.BadgeAlign = AntdUI.TAlignFrom.TR;
            segmentedItem3.BadgeBack = null;
            segmentedItem3.BadgeMode = false;
            segmentedItem3.BadgeOffsetX = 0;
            segmentedItem3.BadgeOffsetY = 0;
            segmentedItem3.BadgeSize = 0.6F;
            segmentedItem3.BadgeSvg = null;
            segmentedItem3.Text = "Full";
            segmentPayment.Items.Add(segmentedItem1);
            segmentPayment.Items.Add(segmentedItem2);
            segmentPayment.Items.Add(segmentedItem3);
            segmentPayment.Location = new Point(353, 381);
            segmentPayment.Name = "segmentPayment";
            segmentPayment.SelectIndex = 0;
            segmentPayment.Size = new Size(282, 32);
            segmentPayment.TabIndex = 8;
            segmentPayment.Text = "segmented1";
            // 
            // divider1
            // 
            divider1.BackColor = Color.Transparent;
            divider1.Location = new Point(658, 167);
            divider1.Name = "divider1";
            divider1.Orientation = AntdUI.TOrientation.Left;
            divider1.Size = new Size(19, 430);
            divider1.TabIndex = 33;
            divider1.Text = "";
            divider1.Vertical = true;
            // 
            // inputLocation
            // 
            inputLocation.Font = new Font("Poppins", 9.75F);
            inputLocation.Location = new Point(496, 218);
            inputLocation.Name = "inputLocation";
            inputLocation.Size = new Size(146, 40);
            inputLocation.TabIndex = 34;
            // 
            // locationLabel
            // 
            locationLabel.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationLabel.Location = new Point(499, 198);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(106, 23);
            locationLabel.TabIndex = 35;
            locationLabel.TabStop = false;
            locationLabel.Text = "Location";
            // 
            // bookingPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(993, 645);
            Controls.Add(inputLocation);
            Controls.Add(locationLabel);
            Controls.Add(divider1);
            Controls.Add(segmentPayment);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(inputNumber);
            Controls.Add(label8);
            Controls.Add(datePickerRange);
            Controls.Add(timeLabel);
            Controls.Add(timePicker);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(inputNotes);
            Controls.Add(createBookingBtn);
            Controls.Add(label6);
            Controls.Add(selectMultipleEmployeesAssigned);
            Controls.Add(inputContactNum);
            Controls.Add(label5);
            Controls.Add(inputClientName);
            Controls.Add(label4);
            Controls.Add(dateLabel);
            Controls.Add(label3);
            Controls.Add(selectMultiplePackageInclusion);
            Controls.Add(selectEventType);
            Controls.Add(label2);
            Controls.Add(inputEventName);
            Controls.Add(label1);
            Controls.Add(createBookingLabel);
            Controls.Add(eventNameLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "bookingPanel";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "bookingPanel";
            TransparencyKey = Color.FromArgb(192, 0, 192);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Label eventNameLabel;
        private AntdUI.Label createBookingLabel;
        private AntdUI.Label label1;
        private AntdUI.Input inputEventName;
        private AntdUI.Label label2;
        private AntdUI.Select selectEventType;
        private AntdUI.SelectMultiple selectMultiplePackageInclusion;
        private AntdUI.Label label3;
        private AntdUI.TimePicker timePicker1;
        private AntdUI.Label dateLabel;
        private AntdUI.Input inputClientName;
        private AntdUI.Label label4;
        private AntdUI.Input inputContactNum;
        private AntdUI.Label label5;
        private AntdUI.Label label6;
        private AntdUI.SelectMultiple selectMultipleEmployeesAssigned;
        private AntdUI.Button createBookingBtn;
        private AntdUI.Input inputNotes;
        private AntdUI.Label label7;
        private AntdUI.Button button1;
        private AntdUI.Label timeLabel;
        private AntdUI.TimePicker timePicker;
        private AntdUI.DatePickerRange datePickerRange;
        private AntdUI.Label label8;
        private AntdUI.InputNumber inputNumber;
        private AntdUI.Label label9;
        private AntdUI.Label label10;
        private AntdUI.Label label11;
        private AntdUI.Segmented segmentPayment;
        private AntdUI.Divider divider1;
        private AntdUI.Input inputLocation;
        private AntdUI.Label locationLabel;
    }
}