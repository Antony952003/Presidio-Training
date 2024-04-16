namespace GovtRulesModelLibrary
{
    public class Company
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Desg { get; set; }
        public double BasicSalary { get; set; }

        public Company()
        {
            Console.WriteLine("Company class default constructor");
            EmpId = 0;
            Name = string.Empty;
            BasicSalary = 0.0;
            Dept = string.Empty;
            Desg = string.Empty;
        }
        public Company(int empId, string name, string dept, string desg, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Dept = dept;
            Desg = desg;
            BasicSalary = basicSalary;
        }
        public override string ToString()
        {
            return "Employee Id : " + EmpId
                + "\nEmployee Name : " + Name
                + "\nEmployee Dept " + Dept
                + "\nEmployee Desg : " + Desg
                + "\nEmployee BasicSalary : " + BasicSalary;
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
