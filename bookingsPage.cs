using System.Data;
using System.Windows.Documents;
using AntdUI;
using Microsoft.Data.SqlClient;

namespace IPSys
{
    public partial class bookingsPage : Form
    {
        string connectionString = "Data Source=DESKTOP-0IG0ARM\\SQLEXPRESS;" +
                "Initial Catalog=owlie;" +
                "Integrated Security=True;" +
                "Trust Server Certificate=True";

        public bookingsPage()
        {
            InitializeComponent();
            LoadDataIntoTable(table1);
        }

        private void LoadDataIntoTable(AntdUI.Table TableToFill)
        {
            string query = "";
            if (TableToFill == table1)
            {
                query = @"SELECT 
                e.Event_Type AS [Event Name],
                b.Date AS [Date],
                c.Client_Name AS [Client Name],
                c.Contact_Num AS [Contact],
                e.Event_Type AS [Event Type],
                p.Package_Type AS [Package Availed],
                emp.Employee_Name AS [Assigned Employees]
            FROM Bookings b
            INNER JOIN Events e ON b.Event_ID = e.Event_ID
            INNER JOIN Clients c ON b.Client_ID = c.Client_ID
            INNER JOIN Packages p ON b.Package_ID = p.Package_ID
            INNER JOIN Employees emp ON b.Employee_ID = emp.Employee_ID
            ORDER BY b.Date ASC;";
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable bookingsDataTable = new DataTable();
                adapter.Fill(bookingsDataTable);

                TableToFill.DataSource = bookingsDataTable; // This is how you bind it to AntdUI table

                table1.DataSource = bookingsDataTable;



            }
        }



    }
}
