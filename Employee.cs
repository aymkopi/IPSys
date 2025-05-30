using AntdUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSys
{
    public class Employee
    {
        public bool Selected { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpRole { get; set; }
        public string EmpAddress { get; set; }
        public string EmpContact { get; set; }
        public int BookingNum { get; set; }
        public bool IsActive { get; set; }

        public CellLink[] BtnsCellLinks { get; set; }
    }
}
