namespace IPSys
{
    partial class bookingsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bookingsPage));
            label8 = new AntdUI.Label();
            panel1 = new AntdUI.Panel();
            calendar = new AntdUI.Calendar();
            panel2 = new AntdUI.Panel();
            CreateBookingButton = new AntdUI.Button();
            stackPanel1 = new AntdUI.StackPanel();
            panel3 = new AntdUI.Panel();
            buttonGoToEvent = new AntdUI.Button();
            package = new AntdUI.Label();
            eventHead = new AntdUI.Label();
            buttonDeleteBooking = new AntdUI.Button();
            buttonEditBooking = new AntdUI.Button();
            dateTime = new AntdUI.Label();
            badgeEventStatus = new AntdUI.Badge();
            client = new AntdUI.Label();
            eventName = new AntdUI.Label();
            label2 = new AntdUI.Label();
            label1 = new AntdUI.Label();
            divider1 = new AntdUI.Divider();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            stackPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Poppins", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(52, 38);
            label8.Name = "label8";
            label8.Size = new Size(220, 50);
            label8.TabIndex = 16;
            label8.Text = "Calendar";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(calendar);
            panel1.Location = new Point(27, 94);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(605, 598);
            panel1.TabIndex = 17;
            panel1.Text = "panel1";
            // 
            // calendar
            // 
            calendar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar.BadgeSize = 4F;
            calendar.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calendar.Full = true;
            calendar.Location = new Point(25, 21);
            calendar.Name = "calendar";
            calendar.Size = new Size(560, 555);
            calendar.TabIndex = 0;
            calendar.Text = "calendar1";
            calendar.DateChanged += calendar1_DateChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.Controls.Add(CreateBookingButton);
            panel2.Controls.Add(stackPanel1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(divider1);
            panel2.Location = new Point(652, -5);
            panel2.Name = "panel2";
            panel2.Shadow = 5;
            panel2.Size = new Size(449, 724);
            panel2.TabIndex = 18;
            panel2.Text = "panel2";
            // 
            // CreateBookingButton
            // 
            CreateBookingButton.Icon = (Image)resources.GetObject("CreateBookingButton.Icon");
            CreateBookingButton.IconGap = 0F;
            CreateBookingButton.IconPosition = AntdUI.TAlignMini.Bottom;
            CreateBookingButton.IconRatio = 1F;
            CreateBookingButton.Location = new Point(355, 44);
            CreateBookingButton.Name = "CreateBookingButton";
            CreateBookingButton.Shape = AntdUI.TShape.Circle;
            CreateBookingButton.Size = new Size(67, 57);
            CreateBookingButton.TabIndex = 22;
            CreateBookingButton.Type = AntdUI.TTypeMini.Primary;
            CreateBookingButton.Click += CreateBookingButton_Click;
            // 
            // stackPanel1
            // 
            stackPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            stackPanel1.AutoScroll = true;
            stackPanel1.BackColor = Color.Transparent;
            stackPanel1.Controls.Add(panel3);
            stackPanel1.Controls.Add(label2);
            stackPanel1.Location = new Point(22, 132);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Padding = new Padding(5);
            stackPanel1.Size = new Size(408, 565);
            stackPanel1.TabIndex = 21;
            stackPanel1.Text = "stackPanel1";
            stackPanel1.Vertical = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonGoToEvent);
            panel3.Controls.Add(package);
            panel3.Controls.Add(eventHead);
            panel3.Controls.Add(buttonDeleteBooking);
            panel3.Controls.Add(buttonEditBooking);
            panel3.Controls.Add(dateTime);
            panel3.Controls.Add(badgeEventStatus);
            panel3.Controls.Add(client);
            panel3.Controls.Add(eventName);
            panel3.Location = new Point(8, 37);
            panel3.Name = "panel3";
            panel3.Shadow = 5;
            panel3.ShadowColor = SystemColors.MenuHighlight;
            panel3.ShadowOpacity = 0.3F;
            panel3.Size = new Size(392, 154);
            panel3.TabIndex = 24;
            panel3.Text = "panel3";
            // 
            // buttonGoToEvent
            // 
            buttonGoToEvent.Icon = Properties.Resources.right_arrow;
            buttonGoToEvent.IconGap = 1F;
            buttonGoToEvent.IconPosition = AntdUI.TAlignMini.Top;
            buttonGoToEvent.Location = new Point(337, 16);
            buttonGoToEvent.Name = "buttonGoToEvent";
            buttonGoToEvent.Size = new Size(40, 33);
            buttonGoToEvent.TabIndex = 19;
            buttonGoToEvent.Type = AntdUI.TTypeMini.Primary;
            // 
            // package
            // 
            package.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            package.Location = new Point(23, 101);
            package.Name = "package";
            package.Prefix = "";
            package.Size = new Size(231, 14);
            package.TabIndex = 22;
            package.Text = "osjfoiwfjvn";
            // 
            // eventHead
            // 
            eventHead.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            eventHead.Location = new Point(23, 116);
            eventHead.Name = "eventHead";
            eventHead.Prefix = "";
            eventHead.Size = new Size(231, 14);
            eventHead.TabIndex = 21;
            eventHead.Text = "Client";
            // 
            // buttonDeleteBooking
            // 
            buttonDeleteBooking.BorderWidth = 1F;
            buttonDeleteBooking.Ghost = true;
            buttonDeleteBooking.Icon = Properties.Resources.delete;
            buttonDeleteBooking.IconGap = 0F;
            buttonDeleteBooking.Location = new Point(326, 95);
            buttonDeleteBooking.Name = "buttonDeleteBooking";
            buttonDeleteBooking.Size = new Size(50, 35);
            buttonDeleteBooking.TabIndex = 20;
            buttonDeleteBooking.Type = AntdUI.TTypeMini.Error;
            // 
            // buttonEditBooking
            // 
            buttonEditBooking.BorderWidth = 1F;
            buttonEditBooking.Ghost = true;
            buttonEditBooking.Icon = Properties.Resources.edit;
            buttonEditBooking.IconGap = 0F;
            buttonEditBooking.Location = new Point(278, 95);
            buttonEditBooking.Name = "buttonEditBooking";
            buttonEditBooking.Size = new Size(50, 35);
            buttonEditBooking.TabIndex = 19;
            buttonEditBooking.Type = AntdUI.TTypeMini.Warn;
            // 
            // dateTime
            // 
            dateTime.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTime.ForeColor = SystemColors.ControlDark;
            dateTime.Location = new Point(23, 43);
            dateTime.Name = "dateTime";
            dateTime.Prefix = "";
            dateTime.PrefixColor = Color.AliceBlue;
            dateTime.PrefixSvg = "C:\\Users\\Justine\\source\\repos\\IPSys\\Resources\\calendar.png";
            dateTime.Size = new Size(132, 23);
            dateTime.SuffixColor = Color.AliceBlue;
            dateTime.SuffixSvg = "C:\\Users\\Justine\\source\\repos\\IPSys\\Resources\\calendar.png";
            dateTime.TabIndex = 4;
            dateTime.Text = "Date";
            // 
            // badgeEventStatus
            // 
            badgeEventStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            badgeEventStatus.DotRatio = 0.57F;
            badgeEventStatus.Location = new Point(406, 25);
            badgeEventStatus.Name = "badgeEventStatus";
            badgeEventStatus.Size = new Size(22, 24);
            badgeEventStatus.State = AntdUI.TState.Processing;
            badgeEventStatus.TabIndex = 3;
            badgeEventStatus.Text = "";
            // 
            // client
            // 
            client.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            client.Location = new Point(23, 87);
            client.Name = "client";
            client.Prefix = "";
            client.Size = new Size(231, 14);
            client.TabIndex = 1;
            client.Text = "Niosdjfihvuef";
            // 
            // eventName
            // 
            eventName.Font = new Font("Poppins Medium", 11.25F, FontStyle.Bold);
            eventName.Location = new Point(44, 21);
            eventName.Name = "eventName";
            eventName.Size = new Size(286, 23);
            eventName.TabIndex = 0;
            eventName.Text = "Event Name";
            // 
            // label2
            // 
            label2.Font = new Font("Poppins Medium", 11.25F, FontStyle.Bold);
            label2.Location = new Point(8, 8);
            label2.Name = "label2";
            label2.Size = new Size(392, 23);
            label2.TabIndex = 23;
            label2.Text = "Event Name";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 56);
            label1.Name = "label1";
            label1.Size = new Size(220, 28);
            label1.TabIndex = 19;
            label1.Text = "Bookings";
            // 
            // divider1
            // 
            divider1.BackColor = Color.Transparent;
            divider1.Location = new Point(31, 83);
            divider1.Name = "divider1";
            divider1.Orientation = AntdUI.TOrientation.Left;
            divider1.Size = new Size(387, 10);
            divider1.TabIndex = 20;
            divider1.Text = "";
            divider1.TextPadding = 0F;
            divider1.Thickness = 1.5F;
            // 
            // bookingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImage = Properties.Resources.Untitled_design;
            ClientSize = new Size(1094, 712);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "bookingsPage";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            stackPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label8;
        private AntdUI.Panel panel1;
        private AntdUI.Calendar calendar;
        private AntdUI.Panel panel2;
        private AntdUI.Label label1;
        private AntdUI.Divider divider1;
        private AntdUI.StackPanel stackPanel1;
        private AntdUI.Button CreateBookingButton;
        private AntdUI.Panel panel3;
        private AntdUI.Button buttonGoToEvent;
        private AntdUI.Label package;
        private AntdUI.Label eventHead;
        private AntdUI.Button buttonDeleteBooking;
        private AntdUI.Button buttonEditBooking;
        private AntdUI.Label dateTime;
        private AntdUI.Badge badgeEventStatus;
        private AntdUI.Label client;
        private AntdUI.Label eventName;
        private AntdUI.Label label2;
    }
}