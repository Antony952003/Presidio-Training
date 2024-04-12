namespace Day4
{
    internal class Program
    {

        Employee CreateEmployeeObjectandFillthedetails(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the name of the employee : ");
            employee.name = Console.ReadLine();
            Console.WriteLine("Please enter the email of the employee :");
            return employee;


        }
        static void Main(string[] args)
        {
            //Employee employee1 = new Employee();
            //employee1.setId(1);
            //employee1.name = "Arya";
            //employee1.salary = 25000;
            //employee1.DateofBirth = new DateTime(2003, 5, 9);
            //Employee employee2 = new Employee()
            //{
            //    name = "Stark",
            //    salary= 15000,
            //    DateofBirth = new DateTime(2003,11, 9),
            //};
            //Employee employee = new Employee(1, "Arya Stark", 24000, new DateTime(2002, 04, 03));
            //employee.printEmployeedetails();
            Program program = new Program();
            Employee[] employees = new Employee[3];
            for(int i = 0; i < 3; i++)
            {
                employees[i] = program.CreateEmployeeObjectandFillthedetails(101+i);
            }


            
        }
    }
}
