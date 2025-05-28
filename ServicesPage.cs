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
    public partial class ServicesPage : Form
    {
        public ServicesPage()
        {
            InitializeComponent();
        }

        private void InitializeServicesData()
        {
            string query = @"
                SELECT
                   p.Package_ID AS PackageID,
                   p.Package_Type AS PackageType,
                   
                        FROM Packages,
                ";
        }
    }
}
