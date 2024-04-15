using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Delete an Employee by ID");
            Console.WriteLine("5. Update Employee Details");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        SearchAndDeleteEmployee();
                        break;
                    case 5:
                        SearchAndUpdate();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            bool flag = false;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    flag = true;
                    PrintEmployee(employees[i]);
                }  
            }
            if(flag == false)
            {
                Console.WriteLine("No Employees are present..");
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndDeleteEmployee()
        {
            int id = GetIdFromConsole();
            DeleteEmployeeById(id);
            Console.WriteLine($"The Employee id {id} is been deleted!!");

        }
        void SearchAndUpdate()
        {
            int id = GetIdFromConsole();
            UpdateEmployeeById(id);
            Console.WriteLine($"The Employee details of id : {id} has been updated");

        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        void UpdateEmployeeById(int id)
        {
            Employee employee = null;
            bool flag = false;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    flag = true;
                    Console.WriteLine("What do u want to update 1.Name\t 2.Date Of Birth\t 3.Basic Salary\t");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Enter the new name for the employee : ");
                            employees[i].Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the new DOB : ");
                            employees[i].DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter the new Basic Salary : ");
                            employees[i].Salary = Convert.ToDouble(Console.ReadLine());
                            break;
                    }
                    break;

                }
            }
            if(flag == false)
            {
                Console.WriteLine($"No Employee with id {id}");
            }
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
        void DeleteEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
            //program.StartGame();
        }
        void StartGame()
        {
            Console.WriteLine("Enter the secret string :");
            string secret = Console.ReadLine();
            secret = secret.ToLower();
            bool ans = false;
            do
            {
                Console.WriteLine("Enter the guess string :");
                string guess = Console.ReadLine();
                guess = guess.ToLower();
                ans = CowsAndBullsGame(secret, guess);
            } while (ans != true);
            Console.WriteLine("Correctly guessed !! You have won");
        }
        bool CowsAndBullsGame(string secret, string guess)
        {
            int[] secretarray = new int[26];
            int[] guessarray = new int[26];
            int cows = 0;
            int bulls = 0;
            for(int i = 0; i < secret.Length; i++)
            {
                int s = secret[i] - 'a';
                int g = guess[i] - 'a';
                if(s == g)
                {
                    cows++;
                }
                else
                {
                    secretarray[s]++;
                    guessarray[g]++;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                bulls += Math.Min(secretarray[i], guessarray[i]);
            }
            Console.WriteLine($"COWS : {cows} and BULLS : {bulls}");
            return (cows == 4 && bulls == 0) ? true : false;
        }
    }
}
