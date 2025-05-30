using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace IPSys
{
    public partial class EarningsPage : Form
    {
        string connectionString = IPSys.MainPage.ConnectionString();

        private decimal[] earningsPerMonth = new decimal[12];

        public EarningsPage()
        {
            InitializeComponent();
            UpdateEarningsData();
            InitializeMonthlyEarningsChart();
        }


        private void InitializeMonthlyEarningsChart()
        {
            SuspendLayout();

            string query = @"SELECT Earnings FROM Earnings";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    // Bookings
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                decimal earnings = Convert.ToDecimal(reader["Earnings"]);
                                // Assuming you have a method to add data to your chart
                                earningsPerMonth[i] = earnings;
                                i++;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }

            monthlyEarningsChart.Series = new ISeries[]
            {
                new ColumnSeries<decimal>
                {
                    Values = earningsPerMonth,

                }
            };

            monthlyEarningsChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                    Name = "Months"
                }
            };

        }

        public void UpdateEarningsData()
        {
            string selectQuery = @"
                SELECT FORMAT(DateFrom, 'yyyy-MM') AS [Month], SUM(Cost) AS Total_Cost
                FROM Bookings
                GROUP BY FORMAT(DateFrom, 'yyyy-MM')
                ORDER BY [Month];";

            Array.Clear(earningsPerMonth, 0, earningsPerMonth.Length);
            var monthTotals = new Dictionary<string, decimal>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string monthStr = reader["Month"].ToString();
                            decimal totalCost = reader["Total_Cost"] != DBNull.Value
                                ? Convert.ToDecimal(reader["Total_Cost"])
                                : 0m;
                            monthTotals[monthStr] = totalCost;

                            if (DateTime.TryParseExact(monthStr + "-01", "yyyy-MM-dd", null,
                                    System.Globalization.DateTimeStyles.None, out DateTime dt))
                            {
                                int month = dt.Month;
                                if (month >= 1 && month <= 12)
                                    earningsPerMonth[month - 1] = totalCost;
                            }
                        }
                    }
                }

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (var kvp in monthTotals)
                    {
                        // Convert "yyyy-MM" to "MonthName" (e.g., "2024-01" -> "January")
                        string monthStr = kvp.Key;
                        string monthName = "";
                        if (DateTime.TryParseExact(monthStr + "-01", "yyyy-MM-dd", null,
                                System.Globalization.DateTimeStyles.None, out DateTime dt))
                        {
                            monthName = dt.ToString("MMMM");
                        }
                        else
                        {
                            monthName = monthStr; // fallback
                        }

                        string upsertQuery = @"
                            SELECT 1 FROM Earnings WHERE [Month] = @Month
                                UPDATE Earnings SET Earnings = @Earnings WHERE [Month] = @Month
                            ";

                        using (var upsertCmd = new SqlCommand(upsertQuery, conn))
                        {
                            upsertCmd.Parameters.AddWithValue("@Month", monthName);
                            upsertCmd.Parameters.AddWithValue("@Earnings", kvp.Value);
                            upsertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            monthlyEarningsChart.Series = new ISeries[]
            {
                new ColumnSeries<decimal> { Values = earningsPerMonth }
            };
        }

    }
}
