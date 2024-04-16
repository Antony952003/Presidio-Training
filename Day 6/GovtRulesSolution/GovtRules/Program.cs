using GovtRulesModelLibrary;
using System.Net;

namespace GovtRules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }

        void EmployeeInteraction()
        {
            Benefits benifits = new Benefits();
            Console.WriteLine("Enter the name of the Company : ");
            string company = Console.ReadLine();
            Console.Write("Employee ID: ");
            int EmpId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Department: ");
            string Dept = Console.ReadLine();
            Console.Write("Designation: ");
            string Desg = Console.ReadLine();
            Console.Write("Basic Salary: ");
            double Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Experience :");
            float Experience = Convert.ToInt32(Console.ReadLine());
            double GratuityAmount = 0.0;
            double PFAmount = 0.0;
            string LeaveDetails = string.Empty;
            if (company == "ABC")
            {
                ABC abcCompany = new ABC(EmpId, Name, Dept, Desg, Salary);
                benifits.BenifitsCalculations(abcCompany, Salary, Experience, ref GratuityAmount,ref PFAmount,ref LeaveDetails);
                abcCompany.PrintDetails(PFAmount,GratuityAmount,LeaveDetails);
            }
            else if(company == "XYZ")
            {
                XYZ xyzCompany = new XYZ(EmpId, Name, Dept, Desg, Salary);
                benifits.BenifitsCalculations(xyzCompany, Salary, Experience, ref GratuityAmount, ref PFAmount, ref LeaveDetails);
                xyzCompany.PrintDetails(PFAmount, GratuityAmount, LeaveDetails);
            }

            
        }
    }
}
