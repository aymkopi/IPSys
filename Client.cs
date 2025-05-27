using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntdUI;

namespace IPSys
{
    public class Client
    {
        public bool selected;
        public string clientID;
        public string clientName;
        public string clientContact;
        public string clientEmail;
        public int totalBookings;
        public bool enabled = false;
        public CellLink[] btnsCellLinks;


        public Client() { }
        public bool Selected { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientContact { get; set; }
        public string ClientEmail { get; set; }
        public int TotalBookings { get; set; }
        public bool Enabled { get; set; }
        public CellLink[] BtnsCellLinks { get; set; }
    }
}
