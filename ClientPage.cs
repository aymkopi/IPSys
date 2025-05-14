using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using Microsoft.Data.SqlClient;
using System.Windows.Shell;

namespace IPSys
{
    public partial class ClientPage : Form
    {
        private string connectionString = MainPage.ConnectionString();

        AntList<ClientRow> clientList;
        AntList<ClientRow> filteredEmpList;

        public ClientPage()
        {
            InitializeComponent();
            InitializeTableColumns();

        }

        private void InitializeTableColumns()
        {

            clientTable.Columns = new ColumnCollection()
            {
                new ColumnCheck("Selected")
                {
                    Fixed = true,
                },
                new Column("ClientID", "ID")
                {
                    //Width = "80",
                    Align = ColumnAlign.Center,
                },
                new Column("ClientName", "Name")
                {
                    Align = ColumnAlign.Center
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
        private void LoadClientData()
        {
            // Define your ClientRow class to match your table columns
            clientList = new AntList<ClientRow>();

            string sql = @"
                SELECT 
                    c.Client_ID AS ClientID,
                    c.Client_Name AS ClientName,
                    c.Email AS ClientEmail,
                    c.Phone AS ClientPhone,
                    c.Address AS ClientAddress,
                    c.Registration_Date AS RegistrationDate,
                    COUNT(o.Order_ID) AS TotalOrders
                FROM 
                    Clients c
                LEFT JOIN 
                    Orders o ON c.Client_ID = o.Client_ID
                GROUP BY 
                    c.Client_ID, c.Client_Name, c.Email, c.Phone, c.Address, c.Registration_Date
                ORDER BY 
                    c.Client_Name ASC;
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
                        var clientRow = new ClientRow
                        {
                            ClientID = reader["ClientID"].ToString(),
                            ClientName = reader["ClientName"].ToString(),
                           ClientPhone = reader["ClientPhone"].ToString(),
                            ClientAddress = reader["ClientAddress"].ToString(),
                            RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]), // Assuming it's a DateTime field
                            TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                        };
                        clientList.Add(clientRow);
                    }
                }
            }
            clientTable.Binding(clientList);
        }

        public class ClientRow
        {
            public string ClientID { get; set; }

            public string ClientName { get; set; }
            public string
        }
    }
}
