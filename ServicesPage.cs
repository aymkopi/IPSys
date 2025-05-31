using IPSys.Properties;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Button = AntdUI.Button;
using Label = AntdUI.Label;
using Padding = System.Windows.Forms.Padding;
using AntdUI;

namespace IPSys
{
    public partial class ServicesPage : Form
    {
        private readonly string connectionString = MainPage.ConnectionString();

        // Class-level controls for Add New Package
        private AntdUI.Input pCostInput;
        private AntdUI.Input packageNameInput;
        private AntdUI.Button addButton;

        // Class-level controls for Add New Event
        private AntdUI.Input eCostInput;
        private AntdUI.Input eventNameInput;
        private AntdUI.Button addEventButton;

        private AntdUI.Input empCostInput;
        private AntdUI.Input empRoleInput;
        private AntdUI.Button addEmpRoleButton;


        public ServicesPage()
        {
            InitializeComponent();
            AddNewPackagePanel(); // Add at the top
            AddNewEventPanel();   // Add at the top
            InitializePackagesData();
            InitializeEventsData();
            InitializeEmployeeRolesData();
        }

        private void AddNewPackagePanel()
        {
            if (packageNameInput == null)
                packageNameInput = new Input()
                {
                    Location = new Point(12, 58),
                    Name = "packageName",
                    Size = new Size(162, 40),
                    TabIndex = 1
                };
            if (pCostInput == null)
                pCostInput = new Input()
                {
                    Location = new Point(12, 118),
                    Name = "packageCost",
                    Size = new Size(119, 40),
                    TabIndex = 2
                };
            if (addButton == null)
            {
                addButton = new Button
                {
                    BorderWidth = 1F,
                    Location = new Point(134, 117),
                    Name = "addButton",
                    Size = new Size(40, 40),
                    TabIndex = 6,
                    Enabled = false
                };
                addButton.Click += AddNewPackage_Click;
            }

            var addNewLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins Medium", 11.25F, FontStyle.Bold),
                Location = new Point(98, 13),
                Name = "addNew",
                Size = new Size(75, 23),
                TabIndex = 3,
                Text = "Add New",
                TextAlign = ContentAlignment.MiddleRight
            };
            var nameLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins", 9.75F, FontStyle.Regular),
                Location = new Point(18, 41),
                Name = "packageLabel2",
                Size = new Size(75, 23),
                TabIndex = 4,
                Text = "Name:"
            };
            var costLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins", 9.75F, FontStyle.Regular),
                Location = new Point(18, 101),
                Name = "packageLabel3",
                Size = new Size(75, 23),
                TabIndex = 5,
                Text = "Cost:"
            };

            var addPackagePanel = new AntdUI.Panel
            {
                Name = "panelAddNewPackage",
                BackgroundImage = Properties.Resources.bg1,
                Size = new Size(189, 173),
                BackColor = Color.Transparent,
                Shadow = 5,
            };

            addPackagePanel.Controls.Add(addButton);
            addPackagePanel.Controls.Add(addNewLabel);
            addPackagePanel.Controls.Add(pCostInput);
            addPackagePanel.Controls.Add(packageNameInput);
            addPackagePanel.Controls.Add(costLabel);
            addPackagePanel.Controls.Add(nameLabel);

            servicesFlowPanel.Controls.Add(addPackagePanel);

            // Only wire up once
            packageNameInput.TextChanged -= PackageInputs_TextChanged;
            pCostInput.TextChanged -= PackageInputs_TextChanged;
            packageNameInput.TextChanged += PackageInputs_TextChanged;
            pCostInput.TextChanged += PackageInputs_TextChanged;
        }

        private void AddNewEventPanel()
        {
            if (eventNameInput == null)
                eventNameInput = new Input()
                {
                    Location = new Point(12, 58),
                    Name = "eventName",
                    Size = new Size(162, 40),
                    TabIndex = 1
                };
            if (eCostInput == null)
                eCostInput = new Input()
                {
                    Location = new Point(12, 118),
                    Name = "eventCost",
                    Size = new Size(119, 40),
                    TabIndex = 2
                };
            if (addEventButton == null)
            {
                addEventButton = new Button
                {
                    BorderWidth = 1F,
                    Location = new Point(134, 117),
                    Name = "addEventButton",
                    Size = new Size(40, 40),
                    TabIndex = 6,
                    Enabled = false
                };
                addEventButton.Click += AddNewEvent_Click;
            }

            var addNewLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins Medium", 11.25F, FontStyle.Bold),
                Location = new Point(98, 13),
                Name = "addEventNew",
                Size = new Size(75, 23),
                TabIndex = 3,
                Text = "Add New",
                TextAlign = ContentAlignment.MiddleRight
            };
            var nameLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins", 9.75F, FontStyle.Regular),
                Location = new Point(18, 41),
                Name = "eventLabel2",
                Size = new Size(75, 23),
                TabIndex = 4,
                Text = "Name:"
            };
            var costLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins", 9.75F, FontStyle.Regular),
                Location = new Point(18, 101),
                Name = "eventLabel3",
                Size = new Size(75, 23),
                TabIndex = 5,
                Text = "Cost:"
            };

            var addEventPanel = new AntdUI.Panel
            {
                Name = "panelAddNewEvent",
                BackgroundImage = Properties.Resources.bg1,
                Size = new Size(189, 173),
                BackColor = Color.Transparent,
                Shadow = 5,
            };

            addEventPanel.Controls.Add(addEventButton);
            addEventPanel.Controls.Add(addNewLabel);
            addEventPanel.Controls.Add(eCostInput);
            addEventPanel.Controls.Add(eventNameInput);
            addEventPanel.Controls.Add(costLabel);
            addEventPanel.Controls.Add(nameLabel);

            eventsFlowPanel.Controls.Add(addEventPanel);

            // Only wire up once
            eventNameInput.TextChanged -= EventInputs_TextChanged;
            eCostInput.TextChanged -= EventInputs_TextChanged;
            eventNameInput.TextChanged += EventInputs_TextChanged;
            eCostInput.TextChanged += EventInputs_TextChanged;
        }

        private void PackageInputs_TextChanged(object sender, System.EventArgs e)
        {
            addButton.Enabled = !string.IsNullOrWhiteSpace(packageNameInput.Text) && !string.IsNullOrWhiteSpace(pCostInput.Text);
        }

        private void EventInputs_TextChanged(object sender, System.EventArgs e)
        {
            addEventButton.Enabled = !string.IsNullOrWhiteSpace(eventNameInput.Text) && !string.IsNullOrWhiteSpace(eCostInput.Text);
        }

        private void InitializePackagesData()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT Package_ID, Package_Type, Cost, IsActive FROM Packages ORDER BY Package_ID DESC";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    servicesFlowPanel.AutoScroll = true;
                    servicesFlowPanel.SuspendLayout();
                    servicesFlowPanel.Controls.Clear();

                    AddNewPackagePanel(); // always at the top

                    if (reader.HasRows)
                    {
                        int panelIndex = 0;
                        while (reader.Read())
                        {
                            AntdUI.Panel packagePanel = new AntdUI.Panel
                            {
                                Name = $"panel{panelIndex}",
                                BackgroundImage = Properties.Resources.bg1,
                                Location = new Point(3, 3),
                                Size = new Size(189, 173),
                                BackColor = Color.Transparent,
                                Shadow = 5,
                                Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                            };

                            AntdUI.FlowPanel optionsFlowPanel = new AntdUI.FlowPanel
                            {
                                Name = $"flowPanel{panelIndex}",
                                Align = AntdUI.TAlignFlow.Right,
                                BackColor = Color.Transparent,
                                Location = new Point(122, 113),
                                Visible = true,
                                Size = new Size(49, 44),
                            };

                            AntdUI.Label packageNameLabel = new AntdUI.Label
                            {
                                Name = $"packageNameLabel{panelIndex}",
                                TextMultiLine = true,
                                BackColor = Color.Transparent,
                                Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(24, 20),
                                Size = new Size(75, 23),
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                TabIndex = 0,
                                Text = reader.GetString(1),
                                AutoSize = true
                            };

                            AntdUI.Input packageCostInput = new AntdUI.Input
                            {
                                Name = $"packageIDLabel{panelIndex}",
                                Enabled = false,
                                Tag = reader.GetInt32(0),
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(20, 116),
                                PrefixFore = SystemColors.ActiveBorder,
                                PrefixText = "₱",
                                Visible = true,
                                Size = new Size(115, 40),
                                ForeColor = System.Drawing.SystemColors.ControlDark,
                                TabIndex = 4,
                                Text = reader.GetInt32(2).ToString(),
                            };

                            AntdUI.Switch packageStatus = new Switch()
                            {
                                Name = $"packageSwitch{panelIndex}",
                                Tag = reader.GetInt32(0).ToString(),
                                BackColor = Color.Transparent,
                                Location = new Point(128, 19),
                                Size = new Size(43, 30),
                                TabIndex = 27,
                                Checked = reader.GetBoolean(3),
                                Enabled = true,
                            };

                            AntdUI.Button editButton = new AntdUI.Button
                            {
                                Name = $"editButton{panelIndex}",
                                Tag = reader.GetInt32(0),
                                Visible = true,
                                BorderWidth = 1F,
                                Ghost = false,
                                Icon = Properties.Resources.edit_100dp_000000_FILL0_wght400_GRAD0_opsz48,
                                IconGap = 0F,
                                IconRatio = 0.7F,
                                Location = new Point(9, 3),
                                Margin = new Padding(3, 3, 0, 3),
                                Size = new Size(40, 40),
                                TabIndex = 21,
                            };
                            AntdUI.Button saveButton = new AntdUI.Button
                            {
                                Tag = reader.GetInt32(0),
                                BorderWidth = 1F,
                                Enabled = false,
                                Visible = true,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Ghost = false,
                                Icon = Properties.Resources.save_100dp_000000_FILL0_wght400_GRAD0_opsz48,
                                IconRatio = 1F,
                                Location = new Point(6, 49),
                                Margin = new Padding(3, 3, 0, 3),
                                Name = "saveButton",
                                Size = new Size(40, 40),
                                TabIndex = 9,
                            };

                            packageStatus.Click += ChangeServiceStatusSwitch_Click;
                            editButton.Click += EditButton_Click;
                            saveButton.Click += SaveButton_Click;

                            packagePanel.Controls.Add(packageStatus);
                            packagePanel.Controls.Add(packageNameLabel);
                            packagePanel.Controls.Add(packageCostInput);
                            optionsFlowPanel.Controls.Add(saveButton);
                            optionsFlowPanel.Controls.Add(editButton);
                            packagePanel.Controls.Add(optionsFlowPanel);

                            servicesFlowPanel.Controls.Add(packagePanel);

                            panelIndex++;
                        }
                    }
                    servicesFlowPanel.ResumeLayout();
                }
            }
            servicesFlowPanel.AutoScroll = true;
        }

        private void InitializeEventsData()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT Event_ID, Event_Type, Cost, IsActive FROM Events ORDER BY Event_ID DESC";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    eventsFlowPanel.AutoScroll = true;
                    eventsFlowPanel.SuspendLayout();
                    eventsFlowPanel.Controls.Clear();

                    AddNewEventPanel(); // always at the top

                    if (reader.HasRows)
                    {
                        int panelIndex = 0;
                        while (reader.Read())
                        {
                            AntdUI.Panel eventsPanel = new AntdUI.Panel
                            {
                                Name = $"panel{panelIndex}",
                                BackgroundImage = Properties.Resources.bg1,
                                Location = new Point(3, 3),
                                Size = new Size(189, 173),
                                BackColor = Color.Transparent,
                                Shadow = 5,
                                Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                            };

                            AntdUI.FlowPanel optionsFlowPanel = new AntdUI.FlowPanel
                            {
                                Name = $"flowPanel{panelIndex}",
                                Align = AntdUI.TAlignFlow.Right,
                                BackColor = Color.Transparent,
                                Location = new Point(122, 113),
                                Visible = true,
                                Size = new Size(49, 44),
                            };

                            AntdUI.Label eventNameLabel = new AntdUI.Label
                            {
                                Name = $"eventNameLabel{panelIndex}",
                                BackColor = Color.Transparent,
                                Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(24, 20),
                                Size = new Size(113, 23),
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                TabIndex = 0,
                                Text = reader.GetString(1),
                                AutoSize = true
                            };

                            AntdUI.Input eventCostInput = new AntdUI.Input
                            {
                                Name = $"eventIDLabel{panelIndex}",
                                Enabled = false,
                                Tag = reader.GetInt32(0),
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(20, 116),
                                PrefixFore = SystemColors.ActiveBorder,
                                PrefixText = "₱",
                                Visible = true,
                                Size = new Size(115, 40),
                                ForeColor = System.Drawing.SystemColors.ControlDark,
                                TabIndex = 4,
                                Text = reader.GetDecimal(2).ToString("F"),
                            };

                            AntdUI.Switch eventStatus = new Switch()
                            {
                                Name = $"eventSwitch{panelIndex}",
                                Tag = reader.GetInt32(0).ToString(),
                                BackColor = Color.Transparent,
                                Location = new Point(128, 19),
                                Size = new Size(43, 30),
                                TabIndex = 27,
                                Checked = reader.GetBoolean(3),
                                Enabled = true,
                            };

                            AntdUI.Button editButton = new AntdUI.Button
                            {
                                Name = $"editButton{panelIndex}",
                                Tag = reader.GetInt32(0),
                                Visible = true,
                                BorderWidth = 1F,
                                Ghost = false,
                                Icon = Properties.Resources.edit_100dp_000000_FILL0_wght400_GRAD0_opsz48,
                                IconGap = 0F,
                                IconRatio = 0.7F,
                                Location = new Point(9, 3),
                                Margin = new Padding(3, 3, 0, 3),
                                Size = new Size(40, 40),
                                TabIndex = 21,
                            };
                            AntdUI.Button saveButton = new AntdUI.Button
                            {
                                Tag = reader.GetInt32(0),
                                BorderWidth = 1F,
                                Enabled = false,
                                Visible = true,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Ghost = false,
                                Icon = Properties.Resources.save_100dp_000000_FILL0_wght400_GRAD0_opsz48,
                                IconRatio = 1F,
                                Location = new Point(6, 49),
                                Margin = new Padding(3, 3, 0, 3),
                                Name = "saveButton",
                                Size = new Size(40, 40),
                                TabIndex = 9,
                            };

                            eventStatus.Click += ChangeEventStatusSwitch_Click;
                            editButton.Click += EditEventButton_Click;
                            saveButton.Click += SaveEventButton_Click;
                            
                            eventsPanel.Controls.Add(eventStatus);
                            eventsPanel.Controls.Add(eventNameLabel);
                            eventsPanel.Controls.Add(eventCostInput);
                            optionsFlowPanel.Controls.Add(saveButton);
                            optionsFlowPanel.Controls.Add(editButton);
                            eventsPanel.Controls.Add(optionsFlowPanel);

                            eventsFlowPanel.Controls.Add(eventsPanel);

                            panelIndex++;
                        }
                    }
                    eventsFlowPanel.ResumeLayout();
                }
            }
            eventsFlowPanel.AutoScroll = true;
        }

        private void AddNewPackage_Click(object? sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(packageNameInput.Text) || string.IsNullOrWhiteSpace(pCostInput.Text))
            {
                AntdUI.Notification.error(this, "Validation Error", "Please enter both Name and Cost.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                return;
            }
            if (!int.TryParse(pCostInput.Text, out int cost))
            {
                AntdUI.Notification.error(this, "Invalid Cost", "Please enter a valid number for cost.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                return;
            }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("INSERT INTO Packages (Package_Type, Cost, IsActive) VALUES (@Type, @Cost, @IsActive)", conn))
                {
                    cmd.Parameters.AddWithValue("@Type", packageNameInput.Text.Trim());
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                AntdUI.Notification.success(this, "Package Added", "The new package has been added successfully.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                packageNameInput.Text = "";
                pCostInput.Text = "";
                InitializePackagesData();
            }
            catch (System.Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Failed to add package: {ex.Message}", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
            }
        }

        private void AddNewEvent_Click(object? sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(eventNameInput.Text) || string.IsNullOrWhiteSpace(eCostInput.Text))
            {
                AntdUI.Notification.error(this, "Validation Error", "Please enter both Name and Cost.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                return;
            }
            if (!decimal.TryParse(eCostInput.Text, out decimal cost))
            {
                AntdUI.Notification.error(this, "Invalid Cost", "Please enter a valid number for cost.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                return;
            }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("INSERT INTO Events (Event_Type, Cost, IsActive) VALUES (@Type, @Cost, @IsActive)", conn))
                {
                    cmd.Parameters.AddWithValue("@Type", eventNameInput.Text.Trim());
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                AntdUI.Notification.success(this, "Event Added", "The new event has been added successfully.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                eventNameInput.Text = "";
                eCostInput.Text = "";
                InitializeEventsData();
            }
            catch (System.Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Failed to add event: {ex.Message}", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
            }
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            if (sender is AntdUI.Button saveBtn && saveBtn.Tag is int packageId)
            {
                var parentPanel = saveBtn.Parent;
                while (parentPanel != null && !(parentPanel is AntdUI.Panel))
                    parentPanel = parentPanel.Parent;

                if (parentPanel is AntdUI.Panel packagePanel)
                {
                    var packageCostInput = packagePanel.Controls
                        .OfType<AntdUI.Input>()
                        .FirstOrDefault(inp => inp.Tag is int id && id == packageId);

                    if (packageCostInput != null)
                    {
                        if (int.TryParse(packageCostInput.Text, out int newCost))
                        {
                            using (var conn = new SqlConnection(connectionString))
                            using (var cmd = new SqlCommand("UPDATE Packages SET Cost = @Cost WHERE Package_ID = @ID", conn))
                            {
                                cmd.Parameters.AddWithValue("@Cost", newCost);
                                cmd.Parameters.AddWithValue("@ID", packageId);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                            AntdUI.Notification.success(this, "Update Succeeded", "The package cost has been updated successfully.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));

                            packageCostInput.Enabled = false;
                            packageCostInput.ForeColor = System.Drawing.SystemColors.ControlDark;

                            saveBtn.Enabled = false;
                            saveBtn.Visible = true;

                            var optionsFlowPanel = packagePanel.Controls.OfType<AntdUI.FlowPanel>().FirstOrDefault();
                            if (optionsFlowPanel != null)
                            {
                                var editButton = optionsFlowPanel.Controls
                                    .OfType<AntdUI.Button>()
                                    .FirstOrDefault(btn => btn.Name.StartsWith("editButton") && btn.Tag is int id && id == packageId);
                                if (editButton != null)
                                {
                                    editButton.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            AntdUI.Notification.error(this, "Invalid Input", "Please enter a valid cost amount.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                        }
                    }
                }
            }
        }

        private void SaveEventButton_Click(object sender, System.EventArgs e)
        {
            if (sender is AntdUI.Button saveBtn && saveBtn.Tag is int eventId)
            {
                var parentPanel = saveBtn.Parent;
                while (parentPanel != null && !(parentPanel is AntdUI.Panel))
                    parentPanel = parentPanel.Parent;

                if (parentPanel is AntdUI.Panel eventPanel)
                {
                    var eventCostInput = eventPanel.Controls
                        .OfType<AntdUI.Input>()
                        .FirstOrDefault(inp => inp.Tag is int id && id == eventId);

                    if (eventCostInput != null)
                    {
                        if (decimal.TryParse(eventCostInput.Text, out decimal newCost))
                        {
                            using (var conn = new SqlConnection(connectionString))
                            using (var cmd = new SqlCommand("UPDATE Events SET Cost = @Cost WHERE Event_ID = @ID", conn))
                            {
                                cmd.Parameters.AddWithValue("@Cost", newCost);
                                cmd.Parameters.AddWithValue("@ID", eventId);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                            AntdUI.Notification.success(this, "Update Succeeded", "The event cost has been updated successfully.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));

                            eventCostInput.Enabled = false;
                            eventCostInput.ForeColor = System.Drawing.SystemColors.ControlDark;

                            saveBtn.Enabled = false;
                            saveBtn.Visible = true;

                            var optionsFlowPanel = eventPanel.Controls.OfType<AntdUI.FlowPanel>().FirstOrDefault();
                            if (optionsFlowPanel != null)
                            {
                                var editButton = optionsFlowPanel.Controls
                                    .OfType<AntdUI.Button>()
                                    .FirstOrDefault(btn => btn.Name.StartsWith("editButton") && btn.Tag is int id && id == eventId);
                                if (editButton != null)
                                {
                                    editButton.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            AntdUI.Notification.error(this, "Invalid Input", "Please enter a valid cost amount.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                        }
                    }
                }
            }
        }

        private void EditButton_Click(object sender, System.EventArgs e)
        {
            if (sender is AntdUI.Button clickedButton && clickedButton.Tag is int packageId)
            {
                var parentPanel = clickedButton.Parent;
                while (parentPanel != null && !(parentPanel is AntdUI.Panel))
                    parentPanel = parentPanel.Parent;

                if (parentPanel is AntdUI.Panel packagePanel)
                {
                    var packageCostInput = packagePanel.Controls
                        .OfType<AntdUI.Input>()
                        .FirstOrDefault(inp => inp.Tag is int id && id == packageId);
                    if (packageCostInput != null)
                    {
                        packageCostInput.Enabled = true;
                        packageCostInput.ForeColor = Color.Black;
                    }

                    clickedButton.Visible = false;

                    var optionsFlowPanel = packagePanel.Controls
                        .OfType<AntdUI.FlowPanel>()
                        .FirstOrDefault();
                    if (optionsFlowPanel != null)
                    {
                        var saveButton = optionsFlowPanel.Controls
                            .OfType<AntdUI.Button>()
                            .FirstOrDefault(btn => btn.Name == "saveButton" && btn.Tag is int id && id == packageId);
                        if (saveButton != null)
                        {
                            saveButton.Enabled = true;
                            saveButton.Visible = true;
                        }
                    }
                }
            }
        }

        private void EditEventButton_Click(object sender, System.EventArgs e)
        {
            if (sender is AntdUI.Button clickedButton && clickedButton.Tag is int eventId)
            {
                var parentPanel = clickedButton.Parent;
                while (parentPanel != null && !(parentPanel is AntdUI.Panel))
                    parentPanel = parentPanel.Parent;

                if (parentPanel is AntdUI.Panel eventPanel)
                {
                    var eventCostInput = eventPanel.Controls
                        .OfType<AntdUI.Input>()
                        .FirstOrDefault(inp => inp.Tag is int id && id == eventId);
                    if (eventCostInput != null)
                    {
                        eventCostInput.Enabled = true;
                        eventCostInput.ForeColor = Color.Black;
                    }

                    clickedButton.Visible = false;

                    var optionsFlowPanel = eventPanel.Controls
                        .OfType<AntdUI.FlowPanel>()
                        .FirstOrDefault();
                    if (optionsFlowPanel != null)
                    {
                        var saveButton = optionsFlowPanel.Controls
                            .OfType<AntdUI.Button>()
                            .FirstOrDefault(btn => btn.Name == "saveButton" && btn.Tag is int id && id == eventId);
                        if (saveButton != null)
                        {
                            saveButton.Enabled = true;
                            saveButton.Visible = true;
                        }
                    }
                }
            }
        }

        private void ChangeEventStatusSwitch_Click(object? sender, System.EventArgs e)
        {
            if (sender is Switch clickedSwitch && clickedSwitch.Tag is not null)
            {
                string eventID = clickedSwitch.Tag.ToString()!;
                string sql = "";

                if (clickedSwitch.Checked)
                    sql = "UPDATE Events SET IsActive = 1 WHERE Event_ID = @EventID";
                else
                    sql = "UPDATE Events SET IsActive = 0 WHERE Event_ID = @EventID";

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

        private void ChangeServiceStatusSwitch_Click(object sender, System.EventArgs e)
        {
            if (sender is Switch clickedSwitch && clickedSwitch.Tag is not null)
            {
                string packageID = clickedSwitch.Tag.ToString()!;
                string sql = "";
                if (clickedSwitch.Checked)
                    sql = "UPDATE Packages SET IsActive = 1 WHERE Package_ID = @PackageID";
                else
                    sql = "UPDATE Packages SET IsActive = 0 WHERE Package_ID = @PackageID";
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
        private void InitializeEmployeeRolesData()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = "SELECT E_Role_ID, Role_Name, Rate, IsActive FROM EmployeeRole ORDER BY E_Role_ID DESC";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    employeeRolesFlowPanel.AutoScroll = true;
                    employeeRolesFlowPanel.SuspendLayout();
                    employeeRolesFlowPanel.Controls.Clear();

                    AddNewEmployeeRolePanel(); // always at the top

                    if (reader.HasRows)
                    {
                        int panelIndex = 0;
                        while (reader.Read())
                        {
                            AntdUI.Panel empRolePanel = new AntdUI.Panel
                            {
                                Name = $"empRolePanel{panelIndex}",
                                BackgroundImage = Properties.Resources.bg1,
                                Location = new Point(3, 3),
                                Size = new Size(189, 173),
                                BackColor = Color.Transparent,
                                Shadow = 5,
                                Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                            };

                            AntdUI.FlowPanel optionsFlowPanel = new AntdUI.FlowPanel
                            {
                                Name = $"empRoleFlowPanel{panelIndex}",
                                Align = AntdUI.TAlignFlow.Right,
                                BackColor = Color.Transparent,
                                Location = new Point(122, 113),
                                Visible = true,
                                Size = new Size(49, 44),
                            };

                            AntdUI.Label empRoleNameLabel = new AntdUI.Label
                            {
                                Name = $"empRoleNameLabel{panelIndex}",
                                BackColor = Color.Transparent,
                                Font = new Font("Poppins", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                                Location = new Point(24, 20),
                                Size = new Size(113, 23),
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                TabIndex = 0,
                                Text = reader.GetString(1),
                                AutoSize = true
                            };

                            AntdUI.Input empRoleCostInput = new AntdUI.Input
                            {
                                Name = $"empRoleIDLabel{panelIndex}",
                                Enabled = false,
                                Tag = reader.GetInt32(0),
                                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Location = new Point(20, 116),
                                PrefixFore = SystemColors.ActiveBorder,
                                PrefixText = "₱",
                                Visible = true,
                                Size = new Size(115, 40),
                                ForeColor = System.Drawing.SystemColors.ControlDark,
                                TabIndex = 4,
                                Text = reader.GetInt32(2).ToString()
                            };

                            AntdUI.Switch empRoleStatus = new Switch()
                            {
                                Name = $"empRoleSwitch{panelIndex}",
                                Tag = reader.GetInt32(0).ToString(),
                                BackColor = Color.Transparent,
                                Location = new Point(128, 19),
                                Size = new Size(43, 30),
                                TabIndex = 27,
                                Checked = reader.GetBoolean(3),
                                Enabled = true,
                            };

                            AntdUI.Button editButton = new AntdUI.Button
                            {
                                Name = $"editButton{panelIndex}",
                                Tag = reader.GetInt32(0),
                                Visible = true,
                                BorderWidth = 1F,
                                Ghost = false,
                                Icon = Properties.Resources.edit_100dp_000000_FILL0_wght400_GRAD0_opsz48,
                                IconGap = 0F,
                                IconRatio = 0.7F,
                                Location = new Point(9, 3),
                                Margin = new Padding(3, 3, 0, 3),
                                Size = new Size(40, 40),
                                TabIndex = 21,
                            };
                            AntdUI.Button saveButton = new AntdUI.Button
                            {
                                Tag = reader.GetInt32(0),
                                BorderWidth = 1F,
                                Enabled = false,
                                Visible = true,
                                Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                                Ghost = false,
                                Icon = Properties.Resources.save_100dp_000000_FILL0_wght400_GRAD0_opsz48,
                                IconRatio = 1F,
                                Location = new Point(6, 49),
                                Margin = new Padding(3, 3, 0, 3),
                                Name = "saveButton",
                                Size = new Size(40, 40),
                                TabIndex = 9,
                            };

                            empRoleStatus.Click += ChangeEmpRoleStatusSwitch_Click;
                            editButton.Click += EditEmpRoleButton_Click;
                            saveButton.Click += SaveEmpRoleButton_Click;

                            empRolePanel.Controls.Add(empRoleStatus);
                            empRolePanel.Controls.Add(empRoleNameLabel);
                            empRolePanel.Controls.Add(empRoleCostInput);
                            optionsFlowPanel.Controls.Add(saveButton);
                            optionsFlowPanel.Controls.Add(editButton);
                            empRolePanel.Controls.Add(optionsFlowPanel);

                            employeeRolesFlowPanel.Controls.Add(empRolePanel);

                            panelIndex++;
                        }
                    }
                    employeeRolesFlowPanel.ResumeLayout();
                }
            }
            employeeRolesFlowPanel.AutoScroll = true;
        }

        private void SaveEmpRoleButton_Click(object? sender, EventArgs e)
        {
            if (sender is AntdUI.Button saveBtn && saveBtn.Tag is int roleId)
            {
                // Find parent panel
                var parentPanel = saveBtn.Parent;
                while (parentPanel != null && !(parentPanel is AntdUI.Panel))
                    parentPanel = parentPanel.Parent;

                if (parentPanel is AntdUI.Panel empRolePanel)
                {
                    // Find the cost input by Tag
                    var empRoleCostInput = empRolePanel.Controls
                        .OfType<AntdUI.Input>()
                        .FirstOrDefault(inp => inp.Tag is int id && id == roleId);

                    if (empRoleCostInput != null)
                    {
                        if (decimal.TryParse(empRoleCostInput.Text, out decimal newCost))
                        {
                            using (var conn = new SqlConnection(connectionString))
                            using (var cmd = new SqlCommand("UPDATE EmployeeRole SET Rate = @Rate WHERE E_Role_ID = @ID", conn))
                            {
                                cmd.Parameters.AddWithValue("@Rate", newCost);
                                cmd.Parameters.AddWithValue("@ID", roleId);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                            AntdUI.Notification.success(this, "Update Succeeded", "The employee role cost has been updated successfully.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));

                            empRoleCostInput.Enabled = false;
                            empRoleCostInput.ForeColor = System.Drawing.SystemColors.ControlDark;

                            saveBtn.Enabled = false;
                            saveBtn.Visible = true;

                            var optionsFlowPanel = empRolePanel.Controls.OfType<AntdUI.FlowPanel>().FirstOrDefault();
                            if (optionsFlowPanel != null)
                            {
                                var editButton = optionsFlowPanel.Controls
                                    .OfType<AntdUI.Button>()
                                    .FirstOrDefault(btn => btn.Name.StartsWith("editButton") && btn.Tag is int id && id == roleId);
                                if (editButton != null)
                                {
                                    editButton.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            AntdUI.Notification.error(this, "Invalid Input", "Please enter a valid cost amount.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                        }
                    }
                }
            }
        }

        private void EditEmpRoleButton_Click(object? sender, EventArgs e)
        {
            if (sender is AntdUI.Button clickedButton && clickedButton.Tag is int roleId)
            {
                var parentPanel = clickedButton.Parent;
                while (parentPanel != null && !(parentPanel is AntdUI.Panel))
                    parentPanel = parentPanel.Parent;

                if (parentPanel is AntdUI.Panel empRolePanel)
                {
                    var empRoleCostInput = empRolePanel.Controls
                        .OfType<AntdUI.Input>()
                        .FirstOrDefault(inp => inp.Tag is int id && id == roleId);
                    if (empRoleCostInput != null)
                    {
                        empRoleCostInput.Enabled = true;
                        empRoleCostInput.ForeColor = Color.Black;
                    }

                    clickedButton.Visible = false;

                    var optionsFlowPanel = empRolePanel.Controls
                        .OfType<AntdUI.FlowPanel>()
                        .FirstOrDefault();
                    if (optionsFlowPanel != null)
                    {
                        var saveButton = optionsFlowPanel.Controls
                            .OfType<AntdUI.Button>()
                            .FirstOrDefault(btn => btn.Name == "saveButton" && btn.Tag is int id && id == roleId);
                        if (saveButton != null)
                        {
                            saveButton.Enabled = true;
                            saveButton.Visible = true;
                        }
                    }
                }
            }
        }

        private void ChangeEmpRoleStatusSwitch_Click(object? sender, EventArgs e)
        {
            if (sender is Switch clickedSwitch && clickedSwitch.Tag is not null)
            {
                string roleId = clickedSwitch.Tag.ToString()!;
                string sql = "";

                if (clickedSwitch.Checked)
                    sql = "UPDATE EmployeeRole SET IsActive = 1 WHERE E_Role_ID = @RoleID";
                else
                    sql = "UPDATE EmployeeRole SET IsActive = 0 WHERE E_Role_ID = @RoleID";

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleID", roleId);
                        cmd.ExecuteNonQuery();
                    }
                }
                AntdUI.Notification.info(this, "Operation Success", "", autoClose: 3, align: TAlignFrom.TR);
            }
        }

        private void AddNewEmployeeRolePanel()
        {
            if (empRoleInput == null)
                empRoleInput = new Input()
                {
                    Location = new Point(12, 58),
                    Name = "empRoleName",
                    Size = new Size(162, 40),
                    TabIndex = 1
                };
            if (empCostInput == null)
                empCostInput = new Input()
                {
                    Location = new Point(12, 118),
                    Name = "empRoleCost",
                    Size = new Size(119, 40),
                    TabIndex = 2
                };
            if (addEmpRoleButton == null)
            {
                addEmpRoleButton = new Button
                {
                    BorderWidth = 1F,
                    Location = new Point(134, 117),
                    Name = "addEmpRoleButton",
                    Size = new Size(40, 40),
                    TabIndex = 6,
                    Enabled = false
                };
                addEmpRoleButton.Click += AddNewEmpRole_Click;
            }

            var addNewLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins Medium", 11.25F, FontStyle.Bold),
                Location = new Point(72, 13),
                Name = "addEmpRoleNew",
                Size = new Size(100, 23),
                TabIndex = 3,
                Text = "Add Role",
                TextAlign = ContentAlignment.MiddleRight
            };
            var nameLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins", 9.75F, FontStyle.Regular),
                Location = new Point(18, 41),
                Name = "empRoleLabel2",
                Size = new Size(75, 23),
                TabIndex = 4,
                Text = "Role:"
            };
            var costLabel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Poppins", 9.75F, FontStyle.Regular),
                Location = new Point(18, 101),
                Name = "empRoleLabel3",
                Size = new Size(75, 23),
                TabIndex = 5,
                Text = "Cost:"
            };

            var addEmpRolePanel = new AntdUI.Panel
            {
                Name = "panelAddNewEmpRole",
                BackgroundImage = Properties.Resources.bg1,
                Size = new Size(189, 173),
                BackColor = Color.Transparent,
                Shadow = 5,
            };

            addEmpRolePanel.Controls.Add(addEmpRoleButton);
            addEmpRolePanel.Controls.Add(addNewLabel);
            addEmpRolePanel.Controls.Add(empCostInput);
            addEmpRolePanel.Controls.Add(empRoleInput);
            addEmpRolePanel.Controls.Add(costLabel);
            addEmpRolePanel.Controls.Add(nameLabel);

            // Make sure you have a FlowPanel named employeeRolesFlowPanel on your form!
            employeeRolesFlowPanel.Controls.Add(addEmpRolePanel);

            // Only wire up once
            empRoleInput.TextChanged -= EmpRoleInputs_TextChanged;
            empCostInput.TextChanged -= EmpRoleInputs_TextChanged;
            empRoleInput.TextChanged += EmpRoleInputs_TextChanged;
            empCostInput.TextChanged += EmpRoleInputs_TextChanged;
        }

        private void EmpRoleInputs_TextChanged(object sender, System.EventArgs e)
        {
            addEmpRoleButton.Enabled = !string.IsNullOrWhiteSpace(empRoleInput.Text) && !string.IsNullOrWhiteSpace(empCostInput.Text);
        }

        // 4. Add New Employee Role Click handler
        private void AddNewEmpRole_Click(object? sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(empRoleInput.Text) || string.IsNullOrWhiteSpace(empCostInput.Text))
            {
                AntdUI.Notification.error(this, "Validation Error", "Please enter both Role Name and Cost.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                return;
            }
            if (!decimal.TryParse(empCostInput.Text, out decimal rate))
            {
                AntdUI.Notification.error(this, "Invalid Cost", "Please enter a valid number for cost.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                return;
            }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("INSERT INTO EmployeeRole (Role_Name, Rate, IsActive) VALUES (@Role, @Rate, @IsActive)", conn))
                {
                    cmd.Parameters.AddWithValue("@Role", empRoleInput.Text.Trim());
                    cmd.Parameters.AddWithValue("@Rate", rate);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                AntdUI.Notification.success(this, "Role Added", "The new employee role has been added successfully.", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                empRoleInput.Text = "";
                empCostInput.Text = "";
                InitializeEmployeeRolesData();
            }
            catch (System.Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Failed to add employee role: {ex.Message}", autoClose: 3, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
            }
        }
    }



}