using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBlLibrary
{
    public class EmployeeNotFoundException : Exception
    {
        string msg;
        public EmployeeNotFoundException() {
            msg = "Employee Not found";
        }
        public override string Message => msg;
    }
}
