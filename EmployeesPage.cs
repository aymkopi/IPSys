using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;
using AntdUI;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class EmployeesPage : Form
    {

        string connectionString = MainPage.ConnectionString();

        // Assume you have an AntList<Employee> and a reference to your AntdUI table control
        AntList<Employee> empList;
        AntList<Employee> filteredEmpList;

        public EmployeesPage()
        {
            InitializeComponent();
            InitializeTableColumns();
            LoadEmployeeData();
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchBar.Text?.ToLower() ?? "";

            // Filter employee list based on the search text
            filteredEmpList = new AntList<Employee>(
                empList.Where(emp =>
                    emp.EmpName.ToLower().Contains(searchText) ||
                    emp.EmpRole.ToLower().Contains(searchText) ||
                    emp.EmpID.ToLower().Contains(searchText)
                ).ToList()
            );

            if (SearchBar.Text == "")
            {
                empTable.Binding(empList);
            }
            else
            {
                // Re-bind the filtered list to the table
                empTable.Binding(filteredEmpList);
            }

            empTable.Refresh();
        }

        private void InitializeTableColumns()
        {

            empTable.Columns = new ColumnCollection()
            {
                new ColumnCheck("Selected")
                {
                    Fixed = true,
                },
                new Column("EmpID", "ID")
                {
                    //Width = "80",
                    Align = ColumnAlign.Center,
                },
                new Column("EmpName", "Name")
                {
                    Align = ColumnAlign.Center
                },
                new Column("EmpRole", "Role")
                {
                    //Width = "200",
                    Align = ColumnAlign.Center,
                },
                new Column("BookingNum", "Bookings")
                {
                    //Width = "120",
                    Align = ColumnAlign.Center,
                },

                new ColumnSwitch("IsActive", "Active", ColumnAlign.Center)
                {
                    Call = (value, record, i_row, i_col) =>
                    {
                        // Perform time-consuming operation
                        AntdUI.Notification.success(this, "Changes Saved.", "", autoClose: 5, align: TAlignFrom.TR,
                            font: new Font("Poppins", 9, FontStyle.Regular));
                        UpdateEmployeeStatus(value, record);
                        return value;
                    }
                },
                new Column("BtnsCellLinks", "Actions", ColumnAlign.Center)
            };
        }

        private void UpdateEmployeeStatus(bool value, object? record)
        {
            string sql = @"
                UPDATE Employees
                SET IsActive = @IsActive
                WHERE Employee_ID = @EmpID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Assuming you have a way to get the selected employee's ID
                // For example, from the current row in the table
                if (record is Employee emp)
                {
                    cmd.Parameters.AddWithValue("@IsActive", value);
                    cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LoadEmployeeData()
        {
            // Define your Employee class to match your table columns
            empList = new AntList<Employee>();

            string sql = @"
                SELECT 
                    e.Employee_ID AS EmpID,
                    e.Employee_Name AS EmpName,
                    er.Role_Name AS EmpRole,
                    e.Employee_Address AS EmpAddress,
                    e.Employee_Contact AS EmpContact,
                    COUNT(be.Booking_ID) AS BookingNum,
                    e.IsActive AS IsActive
                FROM 
                    Employees e
                INNER JOIN 
                    EmployeeRole er ON e.E_Role_ID = er.E_Role_ID
                LEFT JOIN 
                    Bookings_Employees be ON e.Employee_ID = be.Employee_ID
                GROUP BY 
                    e.Employee_ID, e.Employee_Name, er.Role_Name, e.IsActive, e.Employee_Address, e.Employee_Contact
                ORDER BY 
                    e.Employee_ID;
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Clear any existing data in the table
                    //empTable.Empty = true; // Method name may differ depending on your control

                    while (reader.Read())
                    {
                        var empRow = new Employee
                        {
                            Selected = false, // Checkbox default unchecked
                            EmpID = reader["EmpID"].ToString(),
                            EmpName = reader["EmpName"].ToString(),
                            EmpRole = reader["EmpRole"].ToString(),
                            EmpAddress = reader["EmpAddress"].ToString(),
                            EmpContact = reader["EmpContact"].ToString(),
                            BookingNum = Convert.ToInt32(reader["BookingNum"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            BtnsCellLinks = new CellLink[]
                                { new CellButton(Guid.NewGuid().ToString(), "Go", TTypeMini.Default) }
                        };
                        empList.Add(empRow);
                    }
                }
            }

            empTable.Binding(empList);
        }
        private void UpdateEmployeeInDatabase(Employee employee)
        {
            {
                string query = @"
            UPDATE Employees
            SET 
                Employee_Name = @EmployeeName,
                E_Role_ID = (SELECT E_Role_ID FROM EmployeeRole WHERE Role_Name = @RoleName),
                Employee_Address = @EmployeeAddress,
                Employee_Contact = @EmployeeContact,
                IsActive = @IsActive
            WHERE 
                Employee_ID = @EmpID;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@RoleName", employee.EmpRole);
                    cmd.Parameters.AddWithValue("@EmployeeAddress", employee.EmpAddress);
                    cmd.Parameters.AddWithValue("@EmployeeContact", employee.EmpContact);
                    cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    cmd.Parameters.AddWithValue("@EmpID", employee.EmpID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertEmployeeToDatabase(Employee employee)
        {
            string query = @"
        INSERT INTO Employees 
            (Employee_Name, E_Role_ID, Employee_Address, Employee_Contact, IsActive)
        VALUES
            (   @EmployeeName,
                (SELECT E_Role_ID FROM EmployeeRole WHERE Role_Name = @RoleName),
                @EmployeeAddress,
                @EmployeeContact,
                @IsActive
            );";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmpName);
                cmd.Parameters.AddWithValue("@RoleName", employee.EmpRole);
                cmd.Parameters.AddWithValue("@EmployeeAddress", employee.EmpAddress);
                cmd.Parameters.AddWithValue("@EmployeeContact", employee.EmpContact);
                cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployeeFromDatabase(Employee employee)
        {
            string query = @"
            DELETE FROM Employees
            WHERE Employee_ID = @EmpID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", employee.EmpID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void empTable_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            var buttontext = e.Btn.Text;
            if (e.Record is Employee employee)
            {
                switch (buttontext)
                {
                    case "Go":
                        var form = new EmployeeEdit(this, employee) { Size = new Size(350, 300), };
                        AntdUI.Drawer.open(new AntdUI.Drawer.Config(ActiveForm, form)
                        {
                            OnLoad = () => { AntdUI.Message.info(this, "Entering edit", autoClose: 1); },
                            OnClose = () =>
                            {
                                UpdateEmployeeInDatabase(employee);
                                empTable.Refresh();
                                AntdUI.Message.info(this, "Edit finished", autoClose: 1);

                            }

                        });
                        break;
                }
            }
        }

        private void AddEmployeeBtn_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            AntdUI.Drawer.open(new Drawer.Config(ActiveForm, new EmployeeEdit())
            {
                OnLoad = () => { AntdUI.Message.info(this, "Entering edit", autoClose: 1); },
                OnClose = () =>
                {
                    LoadEmployeeData(); // Refresh data to show new changes
                    empTable.Refresh();
                    AntdUI.Message.info(this, "Edit finished", autoClose: 1);
                }
            });
        }
    }
}
