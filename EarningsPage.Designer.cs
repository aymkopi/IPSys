namespace IPSys
{
    partial class EarningsPage
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
            label8 = new AntdUI.Label();
            monthlyEarningsChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            panel1 = new AntdUI.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Poppins", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(52, 38);
            label8.Name = "label8";
            label8.Size = new Size(220, 50);
            label8.TabIndex = 17;
            label8.Text = "Earnings";
            // 
            // monthlyEarningsChart
            // 
            monthlyEarningsChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            monthlyEarningsChart.Location = new Point(12, 11);
            monthlyEarningsChart.MatchAxesScreenDataRatio = false;
            monthlyEarningsChart.Name = "monthlyEarningsChart";
            monthlyEarningsChart.Size = new Size(852, 274);
            monthlyEarningsChart.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(monthlyEarningsChart);
            panel1.Location = new Point(52, 94);
            panel1.Name = "panel1";
            panel1.Shadow = 5;
            panel1.Size = new Size(886, 308);
            panel1.TabIndex = 19;
            panel1.Text = "panel1";
            // 
            // EarningsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Untitled_design;
            ClientSize = new Size(1094, 712);
            Controls.Add(panel1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EarningsPage";
            Text = "EarningsPage";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label8;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart monthlyEarningsChart;
        private AntdUI.Panel panel1;
    }
}