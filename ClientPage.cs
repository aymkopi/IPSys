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
using System.Windows.Input;

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
                new Column("BtnsCellLinks", "Actions", ColumnAlign.Center)
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
                    COUNT(b.Booking_ID) AS TotalBookings,
                    1 AS Enabled
                FROM 
                    Clients c
                LEFT JOIN 
                    Bookings b ON c.Client_ID = b.Client_ID
                GROUP BY 
                    c.Client_ID, c.Client_Name, c.Contact_Num, c.Client_Email
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
                            TotalBookings = Convert.ToInt32(reader["TotalBookings"]),
                            Enabled = Convert.ToBoolean(reader["Enabled"]),
                            BtnsCellLinks = new CellLink[] { new CellButton(Guid.NewGuid().ToString(), "Edit", TTypeMini.Default), new CellButton(Guid.NewGuid().ToString(), "Delete", TTypeMini.Primary), }
                        }
                        );
                    }
                }
            }
            clientTable.Binding(clientList);
        }

        public void UpdateClientInDatabase(Client client)
        {
            string sql = @"
        UPDATE Clients
        SET 
            Client_Name = @ClientName,
            Contact_Num = @ClientContact,
            Client_Email = @ClientEmail
        WHERE 
            Client_ID = @ClientID;
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                cmd.Parameters.AddWithValue("@ClientName", client.ClientName);
                cmd.Parameters.AddWithValue("@ClientContact", client.ClientContact);
                cmd.Parameters.AddWithValue("@ClientEmail", client.ClientEmail);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClientInDatabase(Client clientID)
        {
           
        }

        private void clientTable_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            var buttontext = e.Btn.Text;
            if (e.Record is Client client)
            {
                switch (buttontext)
                {
                    // Does not currently support entering full-row editing, only supports editing specific cells. It is recommended to use a modal or drawer for full-row editing.
                    case "Edit":
                        var form = new ClientEdit(this, client) { Size = new Size(350, 300),};
                        AntdUI.Drawer.open(new AntdUI.Drawer.Config(ActiveForm, form)
                        {
                            OnLoad = () =>
                            {
                                AntdUI.Message.info(this, "Entering edit", autoClose: 1);
                            },
                            OnClose = () =>
                            {
                                UpdateClientInDatabase(client);
                                clientTable.Refresh();
                                AntdUI.Message.info(this, "Edit finished", autoClose: 1);
                               
                            }
                            
                        });
                        
                        break;
                    case "Delete":
                        AntdUI.Modal.open(new AntdUI.Modal.Config(this, "Confirmation", "Are you sure you want to delete this client?")
                        {
                            Icon = TType.Info,
                            Font = new Font("Poppins", 9, FontStyle.Regular),
                            Padding = new Size(24, 20),
                            Mask = false,

                            CancelFont = new Font("Poppins", 9, FontStyle.Bold),
                            OkFont = new Font("Poppins", 9, FontStyle.Bold),
                            OkText = "Delete",
                            OnOk = config =>
                            {
                                Thread.Sleep(2000);
                                try
                                {
                                    // SQL query to drop the column
                                    string query = $"DELETE FROM Clients WHERE ClientID = {client.ClientID}";

                                    // Execute the SQL query
                                    using (SqlConnection conn = new SqlConnection(MainPage.ConnectionString()))
                                    {
                                        conn.Open();
                                        using (SqlCommand cmd = new SqlCommand(query, conn))
                                        {
                                            cmd.ExecuteNonQuery();
                                            AntdUI.Notification.success(this, "Success", "Client Deleted Successfully.", autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                                        }
                                    }

                                    clientTable.Refresh();
                                }
                                catch (Exception ex)
                                {
                                    // Handle any exceptions (e.g., column does not exist)
                                    AntdUI.Notification.error(this, "Error", $"An error occurred while deleting the column: {ex.Message}", autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
                                }
                                clientList.Remove(client);
                                return true;
                            },
                        });
                        
                        

                        break;
                    //case "AntdUI":
                    //    // Hyperlink content
                    //    AntdUI.Message.info(window, user.CellLinks.FirstOrDefault().Id, autoClose: 1);
                    //    break;
                    //case "View Image":
                    //    // Using clone can prevent the image in the table from being modified
                    //    Preview.open(new Preview.Config(window, (Image)curUser.CellImages[0].Image.Clone()));
                    //    break;
                }
            }
        }
    }
}
