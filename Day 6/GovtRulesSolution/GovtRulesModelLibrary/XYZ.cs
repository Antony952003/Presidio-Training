using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesModelLibrary
{
    public class XYZ : Company, IGovtRules
    {
        public XYZ(int empId, string name, string dept, string desg, double basicSalary) : base(empId, name, dept, desg, basicSalary)
        {
        }
        double IGovtRules.EmployeePF(double basicSalary)
        {
            double EmployeeContribution = basicSalary * 0.12;
            double EmployerContribution = basicSalary * 0.12;
            return EmployeeContribution + EmployerContribution;
        }

        double IGovtRules.GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        string IGovtRules.LeaveDetails()
        {
            return "Leave Details for XYZ are:\n" +
               "2 days of Casual Leave per month\n" +
               "5 days of Sick Leave per year\n" +
               "5 days of Privilege Leave per year";
        }
        public void PrintDetails(double PFAmount, double GratuityAmount, string LeaveDetails)
        {
            string prints = $"EmpId : {EmpId}\n" +
                $"Name : {Name}\n" +
                $"Department : {Dept}\n" +
                $"Designation : {Desg}\n" +
                $"BasicSalary : {BasicSalary}\n" +
                $"Employee PF Amount : {PFAmount}\n" +
                $"Employee Gratuity Amount : {GratuityAmount}\n" +
                $"Leave Details\n" +
                $"{LeaveDetails}\n";
            Console.WriteLine(prints);
        }
    }
}
