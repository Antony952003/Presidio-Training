using GovtRulesModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GovtRules
{
    public class Benefits
    {
        public void BenifitsCalculations(IGovtRules govr, double BasicSalary, float Experience, ref double GratuityAmount, ref double PFAmount,ref string LeaveDetails)
        {
            PFAmount = govr.EmployeePF(BasicSalary);
            GratuityAmount = govr.GratuityAmount(Experience, BasicSalary);
            LeaveDetails = govr.LeaveDetails();
        }
    }
}
