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
        // Assume you have an AntList<EmployeeRow> and a reference to your AntdUI table control
        AntList<EmployeeRow> empList;
        AntList<EmployeeRow> filteredEmpList;

        string connectionString = MainPage.ConnectionString();

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
            filteredEmpList = new AntList<EmployeeRow>(
                empList.Where(emp =>
                    emp.EmpName.ToLower().Contains(searchText) ||
                    emp.EmpRole.ToLower().Contains(searchText) ||
                    emp.EmpID.ToLower().Contains(searchText)
                ).ToList()
            );

            // Re-bind the filtered list to the table
            empTable.Binding(filteredEmpList);
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
                new ColumnSwitch("Enabled", "Active", ColumnAlign.Center)
                {
                    Call= (value,record, i_row, i_col) =>{
                        // Perform time-consuming operation
                        Thread.Sleep(2000);
                        AntdUI.Message.info(this, value.ToString(),autoClose:1);
                        return value;
                    }
                },



            };
        }
        private void LoadEmployeeData()
        {
            // Define your EmployeeRow class to match your table columns
            empList = new AntList<EmployeeRow>();

            string sql = @"
                SELECT 
                    e.Employee_ID AS EmpID,
                    e.Employee_Name AS EmpName,
                    er.Role_Name AS EmpRole,
                    COUNT(be.Booking_ID) AS BookingNum,
                    1 AS Enabled -- Replace with e.Enabled if such a column exists
                FROM 
                    Employees e
                INNER JOIN 
                    EmployeeRole er ON e.E_Role_ID = er.E_Role_ID
                LEFT JOIN 
                    Bookings_Employees be ON e.Employee_ID = be.Employee_ID
                GROUP BY 
                    e.Employee_ID, e.Employee_Name, er.Role_Name
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
                        var empRow = new EmployeeRow
                        {
                            Selected = false, // Checkbox default unchecked
                            EmpID = reader["EmpID"].ToString(),
                            EmpName = reader["EmpName"].ToString(),
                            EmpRole = reader["EmpRole"].ToString(),
                            BookingNum = Convert.ToInt32(reader["BookingNum"]),
                            Enabled = Convert.ToBoolean(reader["Enabled"]),


                        };
                        empList.Add(empRow);
                    }
                }
            }
            empTable.Binding(empList);
        }

        private void empTable_CellClick(object sender, TableClickEventArgs e)
        {
            var record = e.Record;
        }

    }

    // Define a model class for your table rows
    public class EmployeeRow
    {
        public bool Selected { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpRole { get; set; }
        public int BookingNum { get; set; }
        public bool Enabled { get; set; }
    }

}
