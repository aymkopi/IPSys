using AntdUI;
using LiveChartsCore.Drawing;
using Microsoft.Data.SqlClient;
using Button = AntdUI.Button;
using Message = AntdUI.Message;

namespace IPSys;

public partial class ServicesPage : Form
{
    private readonly string connectionString = MainPage.ConnectionString();

    public ServicesPage()
    {
        InitializeComponent();
        InitializeServicesData();
        InitializeEventsData();
    }

    private void InitializeServicesData()
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var sql = "SELECT Package_ID,Package_Type, Cost, IsActive FROM Packages ORDER BY Package_ID DESC";
            using (var cmd = new SqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Suspend layout updates during panel update
                    servicesFlowPanel.SuspendLayout();
                    servicesFlowPanel.Controls.Clear();
                    
                    if (reader.HasRows)
                    {
                        int panelIndex = 0;
                        while (reader.Read())
                        {

                            // Create a panel for the event
                            AntdUI.Panel servicePanel = new AntdUI.Panel
                            {
                                Name = $"panel{panelIndex}",
                                Size = new Size(392, 155),
                                BackColor = Color.Transparent,
                                Shadow = 5,
                                
                            };

                            AntdUI.Label serviceNameLabel = new AntdUI.Label
                            {
                                Name = $"serviceNameLabel{panelIndex}",
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(44, 21),
                                Size = new Size(286, 23),
                                TabIndex = 0,
                                Text = reader.GetString(1), // Get the EventName from the database
                                AutoSize = true
                            };

                            AntdUI.Label serviceIDLabel = new AntdUI.Label
                            {
                                Name = $"serviceIDLabel{panelIndex}",
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                ForeColor = System.Drawing.SystemColors.ControlDark,
                                Location = new Point(23, 43),
                                Size = new Size(190, 23),
                                TabIndex = 4,
                                Text = reader.GetInt32(0).ToString(),
                                TextAlign = ContentAlignment.MiddleLeft,
                            };

                            AntdUI.Label serviceCostLabel = new AntdUI.Label
                            {
                                Name = $"serviceCostLabel{panelIndex}",
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(23, 85),
                                Size = new Size(231, 15),
                                TabIndex = 1,
                                Text = "Cost: " + reader.GetInt32(2).ToString(),
                                AutoSize = true,
                            };

                            AntdUI.Switch serviceStatus = new Switch()
                            {
                                Name = $"serviceSwitch{panelIndex}",
                                Tag = reader.GetInt32(0).ToString(), // Store the Package_ID in the Tag for later use
                                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                Location = new Point(326, 102),
                                Size = new Size(50, 35),
                                TabIndex = 20,
                                Checked = reader.GetBoolean(3), // Get the IsActive status from the database
                            };
                            serviceStatus.Click += ChangeServiceStatusSwitch_Click;

                            servicePanel.Controls.Add(serviceNameLabel);
                            servicePanel.Controls.Add(serviceIDLabel);
                            servicePanel.Controls.Add(serviceCostLabel);
                            servicePanel.Controls.Add(serviceStatus);

                            servicesFlowPanel.Controls.Add(servicePanel);
                            panelIndex++;

                            servicesFlowPanel.ResumeLayout();
                        }
                    }
                }
            }
        }
    }

    private void InitializeEventsData()
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var sql = "SELECT Event_ID, Event_Type, Cost, IsActive FROM Events ORDER BY Event_ID DESC";
            using (var cmd = new SqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Suspend layout updates during panel update
                    eventsFlowPanel.SuspendLayout();
                    eventsFlowPanel.Controls.Clear();

                    if (reader.HasRows)
                    {
                        int panelIndex = 0;
                        while (reader.Read())
                        {

                            // Create a panel for the event
                            AntdUI.Panel eventsPanel = new AntdUI.Panel
                            {
                                Name = $"panel{panelIndex}",
                                Size = new Size(360, 155),
                                BackColor = Color.Transparent,
                                Shadow = 5,
                            };

                            AntdUI.Label eventNameLabel = new AntdUI.Label
                            {
                                Name = $"serviceNameLabel{panelIndex}",
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(44, 21),
                                Size = new Size(286, 23),
                                TabIndex = 0,
                                Text = reader.GetString(1), // Get the EventName from the database
                                AutoSize = true
                            };

                            AntdUI.Label eventIDLabel = new AntdUI.Label
                            {
                                Name = $"serviceIDLabel{panelIndex}",
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                ForeColor = System.Drawing.SystemColors.ControlDark,
                                Location = new Point(23, 43),
                                Size = new Size(190, 23),
                                TabIndex = 4,
                                Text = reader.GetInt32(0).ToString(),
                                TextAlign = ContentAlignment.MiddleLeft,
                            };

                            AntdUI.Label eventCostLabel = new AntdUI.Label
                            {
                                Name = $"serviceCostLabel{panelIndex}",
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(23, 85),
                                Size = new Size(231, 15),
                                TabIndex = 1,
                                Text = "Cost: " + reader.GetDecimal(2).ToString("F"),
                                AutoSize = true,
                            };

                            AntdUI.Switch eventStatus = new Switch()
                            {
                                Name = $"serviceSwitch{panelIndex}",
                                Tag = reader.GetInt32(0).ToString(), 
                                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                                Location = new Point(326, 102),
                                Size = new Size(50, 35),
                                TabIndex = 20,
                                Checked = reader.GetBoolean(3), // Get the IsActive status from the database
                            };
                            eventStatus.Click += ChangeEventStatusSwitch_Click;

                            eventsPanel.Controls.Add(eventNameLabel);
                            eventsPanel.Controls.Add(eventIDLabel);
                            eventsPanel.Controls.Add(eventCostLabel);
                            eventsPanel.Controls.Add(eventStatus);

                            eventsFlowPanel.Controls.Add(eventsPanel);
                            panelIndex++;

                            eventsFlowPanel.ResumeLayout();
                        }
                    }
                }
            }
        }
    }
    private void ChangeEventStatusSwitch_Click(object? sender, EventArgs e)
    {
        if (sender is Switch clickedSwitch && clickedSwitch.Tag is not null)
        {
            string eventID = clickedSwitch.Tag.ToString()!;
            string sql = "";

            if (clickedSwitch.Checked)
            {
                sql = "UPDATE Events SET IsActive = 1 WHERE Event_ID = @EventID";
            }
            else
            {
                sql = "UPDATE Events SET IsActive = 0 WHERE Event_ID = @EventID";
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", eventID);
                    cmd.ExecuteNonQuery();
                }
            }
            AntdUI.Notification.info(this, "Operation Success", "", autoClose: 3, align: TAlignFrom.TR);
        }
    }

    private void ChangeServiceStatusSwitch_Click(object sender, EventArgs e)
    {
        if (sender is Switch clickedSwitch && clickedSwitch.Tag is not null)
        {
            string packageID = clickedSwitch.Tag.ToString()!;
            string sql = "";
            if (clickedSwitch.Checked)
            {
                sql = "UPDATE Packages SET IsActive = 1 WHERE Package_ID = @PackageID";
            }
            else
            {
                sql = "UPDATE Packages SET IsActive = 0 WHERE Package_ID = @PackageID";
            }
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PackageID", packageID);
                    cmd.ExecuteNonQuery();
                }
            }
            AntdUI.Notification.info(this, "Operation Success", "", autoClose: 3, align: TAlignFrom.TR);
        }
    }
}