using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBlLibrary
{
    public class NoDepartmentsAvailableException : Exception
    {
        string msg;
        public NoDepartmentsAvailableException() {
            msg = "No Departments in the list..";
        }

        public override string Message => msg; 
    }
}
