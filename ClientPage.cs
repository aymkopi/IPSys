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
        AntList<Client> filteredClientList;

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
                        var clientRow = new Client{
                            Selected = false,
                            ClientID = reader["ClientID"].ToString(),
                            ClientName = reader["ClientName"].ToString(),
                            ClientContact = reader["ClientContact"].ToString(),
                            ClientEmail = reader["ClientEmail"].ToString(),
                            TotalBookings = Convert.ToInt32(reader["TotalBookings"]),
                            Enabled = Convert.ToBoolean(reader["Enabled"]),
                            BtnsCellLinks = new CellLink[] { new CellButton(Guid.NewGuid().ToString(), "Edit", TTypeMini.Default), new CellButton(Guid.NewGuid().ToString(), "Delete", TTypeMini.Primary), }
                        };
                        clientList.Add(clientRow);
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

        public void DeleteClientInDatabase(string ClientID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // 2. Delete bookings
                    string deleteBookings = "DELETE FROM Bookings WHERE Client_ID = @ClientID";
                    using (SqlCommand cmd = new SqlCommand(deleteBookings, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                        cmd.ExecuteNonQuery();
                    }
                    // 3. Delete client
                    string deleteClient = "DELETE FROM Clients WHERE Client_ID = @ClientID";
                    using (SqlCommand cmd = new SqlCommand(deleteClient, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClientID", ClientID);
                        cmd.ExecuteNonQuery();
                    }
                }
                AntdUI.Notification.success(this, "Success", "Client and associated bookings deleted successfully.", autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));

            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"An error occurred: {ex.Message}", autoClose: 5, align: TAlignFrom.BR, font: new Font("Poppins", 10, FontStyle.Regular));
            }
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
                        var form = new ClientEdit(this, client) { Size = new Size(350, 300), };
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
                        // 1. Fetch bookings for this client
                        List<string> bookingList = new List<string>();
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string sql = "SELECT Event_Name, DateFrom FROM Bookings WHERE Client_ID = @ClientID";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        bookingList.Add($"Event Name: {reader["Event_Name"]}\n, Date: {reader["DateFrom"]}");
                                    }
                                }
                            }
                        }

                        string bookingsMessage = bookingList.Count > 0
                            ? "The following bookings will also be deleted:\n\n" + string.Join("\n", bookingList)
                            : "This client has no bookings. Proceed with deletion?";

                        AntdUI.Modal.open(new AntdUI.Modal.Config(this, "Delete Client", bookingsMessage)
                        {
                            Icon = TType.Warn,
                            Font = new Font("Poppins", 9, FontStyle.Regular),
                            Padding = new Size(24, 20),
                            Mask = false,
                            CancelFont = new Font("Poppins", 9, FontStyle.Bold),
                            OkFont = new Font("Poppins", 9, FontStyle.Bold),
                            OkText = "Delete",
                            OnOk = config =>
                            {
                                DeleteClientInDatabase(client.ClientID);
                                clientList.Remove(client);
                                return true;
                            }
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

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchBar.Text?.ToLower() ?? "";

            // Filter client list based on the search text
            filteredClientList = new AntList<Client>(
                clientList.Where(cli =>
                    cli.ClientName.ToLower().Contains(searchText) ||
                    cli.ClientContact.ToLower().Contains(searchText) ||
                    cli.ClientEmail.ToLower().Contains(searchText) ||
                    cli.ClientID.ToLower().Contains(searchText)
                ).ToList()
            );

            if (SearchBar.Text == "")
            {
                clientTable.Binding(clientList);
            }
            else
            {
                // Re-bind the filtered list to the table
                clientTable.Binding(filteredClientList);
            }

            clientTable.Refresh();
        }
    }
}
