using AntdUI;
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

namespace IPSys
{

    public partial class EmployeeEdit : Form
    {
        private Form form;
        private Employee employee;
        private bool isAdd;
        EmployeesPage ep = new EmployeesPage();

        string connectionString = MainPage.ConnectionString();

        List<string> roleNames = new List<string>();
        public EmployeeEdit()
        {
            InitializeComponent();
            InitEmpRoleContents();
            flowPanel.Visible = false;
            inputEmpID.Text = "Auto-Generated"; // Placeholder for new employee
            inputEmpID.Enabled = false;
            isAdd = true;

            if (employee == null)
            {
                employee = new Employee();
            }
        }

        private void InitEmpRoleContents()
        {
            string query = "SELECT Role_Name FROM EmployeeRole";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roleNames.Add(reader["Role_Name"].ToString());
                    }
                }
            }

            inputEmpRole.Items.Clear();
            inputEmpRole.Items.AddRange(roleNames.ToArray());

        }

        public EmployeeEdit(Form form, Employee employee)
        {
            this.form = form;
            this.employee = employee;
            InitializeComponent();

            editBtn.Visible = true;
            deleteBtn.Visible = true;

            inputEmpID.Enabled = false;
            inputEmpName.Enabled = false;
            inputEmpRole.Enabled = false;
            inputEmpAddress.Enabled = false;
            inputEmpContact.Enabled = false;

            InitEmpRoleContents();

            inputEmpID.Text = employee.EmpID;
            inputEmpName.Text = employee.EmpName;
            inputEmpRole.Text = employee.EmpRole;
            inputEmpAddress.Text = employee.EmpAddress;
            inputEmpContact.Text = employee.EmpContact;
            IsActiveSwitch.Checked = employee.IsActive;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                employee.EmpID = inputEmpID.Text;
            }
            employee.EmpName = inputEmpName.Text;
            employee.EmpRole = inputEmpRole.Text;
            employee.EmpAddress = inputEmpAddress.Text;
            employee.EmpContact = inputEmpContact.Text;
            employee.IsActive = IsActiveSwitch.Checked;

            if (isAdd)
            {
               ep.InsertEmployeeToDatabase(employee);
                ep.Refresh();
            }

            this.Close();
        }
        
        private void inputClientName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                saveButton.Enabled = true; // Enable save button initially

                // Validate each input and update status
                if (string.IsNullOrWhiteSpace(inputEmpName?.Text))
                {
                    inputEmpName.Status = TType.Error;
                    saveButton.Enabled = false;
                }
                else
                {
                    inputEmpName.Status = TType.None;
                }

                if (string.IsNullOrWhiteSpace(inputEmpAddress?.Text))
                {
                    inputEmpAddress.Status = TType.Error;
                    saveButton.Enabled = false;
                }
                else
                {
                    inputEmpAddress.Status = TType.None;
                }

                if (string.IsNullOrWhiteSpace(inputEmpContact?.Text) || inputEmpContact.Text.Any(char.IsAsciiLetter) ||
                    inputEmpContact.Text.Length != 11 || !inputEmpContact.Text.StartsWith("09"))
                {
                    saveButton.Enabled = false;
                    inputEmpContact.Status = TType.Error;

                    AntdUI.Tooltip.open(new AntdUI.Tooltip.Config(inputEmpContact, "Please enter a valid number.")
                    {
                        Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        ArrowAlign = TAlign.BL,
                    });
                }
                else
                {
                    inputEmpContact.Status = TType.None;
                    this.Focus();
                }
            } catch (Exception ex)
            {
                
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            inputEmpName.Enabled = true;
            inputEmpRole.Enabled = true;
            inputEmpAddress.Enabled = true;
            inputEmpContact.Enabled = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            bool isClosed = false;
            AntdUI.Modal.open(new AntdUI.Modal.Config(new EmployeesPage(), "Remove Employee?", "")
            {
                Icon = TType.Warn,
                Font = new Font("Poppins", 9, FontStyle.Regular),
                Padding = new Size(24, 20),
                Mask = false,
                CancelFont = new Font("Poppins", 9, FontStyle.Bold),
                OkFont = new Font("Poppins", 9, FontStyle.Bold),
                OkText = "Yes",
                OnOk = config =>
                {
                    ep.DeleteEmployeeFromDatabase(employee);
                    ep.LoadEmployeeData();
                    ep.Refresh();
                    isClosed = true;
                    return true;
                }
            });
            if (isClosed)
            {
                this.Close();
            }
            
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            bool isClosed = false;
            AntdUI.Modal.open(new AntdUI.Modal.Config(new EmployeesPage(), "Discard Changes?", "")
            {
                Icon = TType.Info,
                Font = new Font("Poppins", 9, FontStyle.Regular),
                Padding = new Size(24, 20),
                Mask = false,
                CancelFont = new Font("Poppins", 9, FontStyle.Bold),
                OkFont = new Font("Poppins", 9, FontStyle.Bold),
                OkText = "Yes",
                OnOk = config =>
                {
                    isClosed = true;
                    return true;
                }
            });
            if (isClosed)   
            {
                this.Close();
            }

        }
    }
}
