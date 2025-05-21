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

        AntList<Client> clientList;
        AntList<Client> filteredEmpList;

        public ClientPage()
        {
            InitializeComponent();
            InitializeTableColumns();
            LoadClientData();

        }

        private void InitializeTableColumns()
        {

            clientTable.Columns = new ColumnCollection()
            {
                new ColumnCheck("Selected")
                {
                    Fixed = true,
                    Width = "50"
                },
                new Column("ClientID", "ID")
                {
                    //Width = "80",
                    Align = ColumnAlign.Center,
                },
                new Column("ClientName", "Name")
                {
                    Align = ColumnAlign.Center,
                    Width = "300",
                    Fixed = true,
                },
                new Column("ClientContact", "Contact Number")
                {
                    Align = ColumnAlign.Center,
                    Width = "150",
                    Fixed = true
                },
                new Column("ClientEmail", "Email")
                {
                    Align = ColumnAlign.Center,
                    Width = "300",
                    Fixed = true,
                },
                new Column("ClientAddress", "Address")
                {
                    Align = ColumnAlign.Center
                },
                new Column("TotalBookings", "Bookings")
                {
                    //Width = "120",
                    Align = ColumnAlign.Center,

                },
                new ColumnSwitch("Enabled", "Actions", ColumnAlign.Center)
                {
                    Call= (value,record, i_row, i_col) =>{
                        // Perform time-consuming operation
                        Thread.Sleep(2000);
                        AntdUI.Message.info(this, value.ToString(),autoClose:1);
                        return value;
                    }
                },
                new Column("BtnsCellLinks", "Links", ColumnAlign.Center)




            };
        }
        private void LoadClientData()
        {
            // Define your Client class to match your table columns
            clientList = new AntList<Client>();

            string sql = @"
                SELECT 
                    c.Client_ID AS ClientID,
                    c.Client_Name AS ClientName,
                    c.Contact_Num AS ClientContact,
                    c.Client_Email AS ClientEmail,
                    c.Client_Address AS ClientAddress,
                    COUNT(b.Booking_ID) AS TotalBookings,
                    1 AS Enabled
                FROM 
                    Clients c
                LEFT JOIN 
                    Bookings b ON c.Client_ID = b.Client_ID
                GROUP BY 
                    c.Client_ID, c.Client_Name, c.Contact_Num, c.Client_Email, c.Client_Address
                ORDER BY 
                    c.Client_ID ASC;
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
                        clientList.Add(new Client
                            {
                                Selected = false,
                                ClientID = reader["ClientID"].ToString(),
                                ClientName = reader["ClientName"].ToString(),
                                ClientContact = reader["ClientContact"].ToString(),
                                ClientEmail = reader["ClientEmail"].ToString(),
                                ClientAddress = reader["ClientAddress"].ToString(),
                                TotalBookings = Convert.ToInt32(reader["TotalBookings"]),
                                Enabled = Convert.ToBoolean(reader["Enabled"]),
                                BtnsCellLinks = new CellLink[]{ new CellButton(Guid.NewGuid().ToString(), "Edit", TTypeMini.Default), new CellButton(Guid.NewGuid().ToString(), "Delete", TTypeMini.Primary), }
                            }
                        );
                    }
                }
            }
            clientTable.Binding(clientList);
        }

        public class Client
        {
            public bool Selected { get; set; }
            public string ClientID { get; set; }
            public string ClientName { get; set; }
            public string ClientContact { get; set; }
            public string ClientAddress { get; set; }
            public string ClientEmail { get; set; }
            public int TotalBookings { get; set; }
            public bool Enabled { get; set; } 
            public CellLink[] BtnsCellLinks { get; set; }
        }
    }
}
