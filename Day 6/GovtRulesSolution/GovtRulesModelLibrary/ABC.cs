using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesModelLibrary
{
    public class ABC : Company, IGovtRules
    {
        public ABC(int empId, string name, string dept, string desg, double basicSalary) : base(empId, name, dept, desg, basicSalary)
        {
        }
        double IGovtRules.EmployeePF(double basicSalary)
        {
            double employeeContribution = basicSalary * 0.12;
            double employerContribution = basicSalary * 0.0833; 
            double pensionFund = employerContribution * 0.0367;
            return employeeContribution + employerContribution + pensionFund;
        }

        double IGovtRules.GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if(serviceCompleted > 20)
            {
                return 3 * basicSalary;
            }
            else if(serviceCompleted > 10)
                return 2 * basicSalary;
            else if(serviceCompleted < 5)
            {
                return 0;
            }
            return basicSalary;
        }

        string IGovtRules.LeaveDetails()
        {
            return "Leave Details for ABC are:\n" +
               "1 day of Casual Leave per month\n" +
               "12 days of Sick Leave per year\n" +
               "10 days of Privilege Leave per year";
        }
    }
}
