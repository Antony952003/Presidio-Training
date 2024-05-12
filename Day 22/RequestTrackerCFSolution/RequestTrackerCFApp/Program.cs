using RequestTrackerCFBLLibrary;
using RequestTrackerCFBLLibrary.BLInterfaces;
using RequestTrackerCFModel;

namespace RequestTrackerCFApp
{
    public class Program
    {
        Employee? LoggedInEmployee;
        IEmployeeLoginBL employeeLoginBL;
        IAdminBL adminBL;
        IUserBL userBL;
        public Program() {
            employeeLoginBL = new EmployeeLoginBL();
            adminBL = new AdminBL();
            userBL = new UserBL();
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            var result = await employeeLoginBL.Login(employee);
            if (!result)
            {
                Console.Out.WriteLine("Invalid username or password");
                return;
            }
            await Console.Out.WriteLineAsync("Login Success");
            var LoginEmployee = await employeeLoginBL.GetEmployee(username);
            LoggedInEmployee = LoginEmployee;
            if(LoggedInEmployee.Role == "Admin")
            {
                await AdminDriver(LoginEmployee);
            }
            else if(LoggedInEmployee.Role == "User")
            {
                await UserDriver(LoginEmployee);
            }
        }
        async Task AdminDriver(Employee employee)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the choice : ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("1.Raise Request\n" +
                    "2.View All Requests\n" +
                    "3.View Admin Requests\n" +
                    "4.View Solutions for Admin Requests\n" +
                    "5.View Solutions Given By Admin\n"+
                "6.Give Feedback\n" +
                "7.Respond To Solution\n" +
                "8.Provide Solution\n" +
                "9.Mark Request as Closed\n" +
                "10.View Feedbacks\n" +
                "11.Logout");
                Console.WriteLine("-----------------------------------------------");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddRequest();
                        break;
                    case "2":
                        await ViewAllRequests();
                        break;
                    case "3":
                        await ViewRequestDetails();
                        break;
                    case "4":
                        await ViewUserSolutions();
                        break;
                    case "5":
                        await ViewAdminSolutions();
                        break;
                    case "6":
                        await GiveFeedback();
                        break;
                    case "7":
                        await RespondToSolution();
                        break;
                    case "8":
                        await ProvideSolution();
                        break;
                    case "9":
                        await MarkRequestAsClosed();
                        break;
                    case "10":
                        await ViewFeedbacks();
                        break;
                    case "11":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            //Admin
            //Raise Request
            //View Request Status(All Requests)
            //View Solutions(All Solutions)
            //Give Feedback(Only for request raised by them)
            //Respond to Solution(Only for request raised by them)
            //Provide Solution
            //Mark Request as Closed
            //View Feedbacks(Only feedbacks given to them)
        }
        async Task UserDriver(Employee employee)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the choice : ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("1.Raise Request\n2.View All Requests\n3.View Solutions\n" +
                "4.Give Feedback\n5.Respond To Solution\n6.Logout");
                Console.WriteLine("-----------------------------------------------");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddRequest();
                        break;
                    case "2":
                        await ViewRequestDetails();
                        break;
                    case "3":
                        await ViewUserSolutions();
                        break;
                    case "4":
                        await GiveFeedback();
                        break;
                    case "5":
                        await RespondToSolution();
                        break;
                    case "6":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                //User
                //Raise Request
                //View Request Status
                //View Solutions
                //Give Feedback
                //Respond to Solution
            }
            }
        async Task AddRequest()
        {
            Console.Write("Request Message: ");
            string? requestMessage = Console.ReadLine() ?? "";
            DateTime requestDate = DateTime.Now;

            Request request = new Request
            {
                RequestMessage = requestMessage,
                RequestDate = requestDate,
                RequestStatus = "Opened",
                RequestRaisedBy = LoggedInEmployee.Id,
                RequestClosedBy = null
            };

            var AddedRequest = await userBL.RaiseRequest(request,LoggedInEmployee.Id);
            Console.WriteLine($"{AddedRequest}\n has been added succesfully");
        }
        async Task<int> ViewRequestDetails()
        {
            var requestDetails = await userBL.GetAllRequestsById(LoggedInEmployee.Id);
            if(requestDetails == null)
            {
                Console.WriteLine("Request not found!");
                return 0;
            }
            foreach (var request in requestDetails)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(request.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
            return requestDetails.Count;
        }
        async Task<int> ViewAllRequests()
        {
            var requestDetails = await adminBL.GetAllRequestsReceived();
            if (requestDetails == null)
            {
                Console.WriteLine("Request not found!");
                return 0;
            }
            foreach (var request in requestDetails)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(request.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
            return requestDetails.Count;
        }
        async Task<int> ViewUserSolutions()
        {
            int IsRequestFound = await ViewRequestDetails();
            if(IsRequestFound == 0) { Console.WriteLine("No requests found!!!"); return 0; }
            Console.WriteLine("Enter Request Number to View Solutions:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var AllSolutions = await userBL.ViewSolutions(requestNumber);
            if (AllSolutions == null)
            {
                Console.WriteLine("There are no solutions for this request !!!");
                return 0;
            }
            foreach (var Solution in AllSolutions)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(Solution.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
            return AllSolutions.Count;
        }
        async Task<int> ViewAdminSolutions()
        {
            var AllSolutionsGivenByAdmin = await adminBL.GetAllSolutions(LoggedInEmployee.Id);
            if (AllSolutionsGivenByAdmin == null)
            {
                Console.WriteLine("There are no solutions given by admin");
                return 0;
            }
            foreach (var Solution in AllSolutionsGivenByAdmin)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(Solution.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
            return AllSolutionsGivenByAdmin.Count;
        }

        async Task GiveFeedback()
        {
            var SolutionsPresent = await ViewUserSolutions();
            if (SolutionsPresent == 0)
            {
                return;
            }
            Console.WriteLine("Enter the solution ID to give feedback:");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your rating (out of 5): ");
            int rating = Convert.ToInt32(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter your remarks: ");
            string remarks = Console.ReadLine() ?? "";

            var feedback = new SolutionFeedback
            {
                Rating = rating,
                Remarks = remarks,
                SolutionId = solutionId,
                FeedbackBy = LoggedInEmployee.Id,
                FeedbackDate = DateTime.Now
            };

            var result = await userBL.GiveFeedBack(LoggedInEmployee.Id, feedback, solutionId);
            Console.WriteLine("Feedback submitted successfully.");
        }

        async Task RespondToSolution()
        {
            ViewUserSolutions();
            Console.WriteLine("Enter the solution ID to respond:");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your response: ");
            string response = Console.ReadLine() ?? "";
            var solution = await userBL.RespondToSolution(solutionId,response);
            if (solution == null)
            {
                Console.WriteLine("Solution not found.");
                return;
            }
            Console.WriteLine("Response submitted successfully.");
        }
        async Task ProvideSolution()
        {
            Console.WriteLine("Enter Request Number to Provide Solution:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var res = await adminBL.GetRequest(LoggedInEmployee.Id, requestNumber);
            if (res.RequestStatus == "Closed")
            {
                Console.WriteLine("Request is already closed.");
                return;
            }
            Console.WriteLine("Enter Solution Description:");
            string solutionDescription = Console.ReadLine() ?? "";

            var solution = new RequestSolution
            {
                SolutionDescription = solutionDescription,
                RequestId = requestNumber,
                SolvedBy = LoggedInEmployee?.Id ?? 0,
            };

            await adminBL.ProvideSolution(solution);
            Console.WriteLine("Solution provided successfully.");

        }
        async Task MarkRequestAsClosed()
        {
            var allRequests = await adminBL.GetAllRequestsAdminProvidedSolution(LoggedInEmployee.Id);
            foreach (var request in allRequests)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(request.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
            Console.WriteLine("Enter the Request which you want to close (Request Id): ");
            int reqid = Convert.ToInt32(Console.ReadLine());
            adminBL.CloseRequest(reqid, LoggedInEmployee.Id);
        }
        async Task ViewFeedbacks()
        {
            var AllAdminSolutions = await ViewAdminSolutions();
            Console.WriteLine("Do you want to view" +
                "1. All Feedbacks" +
                "2. FeedBacks of Specific Solution");
            int ch = Convert.ToInt32(Console.ReadLine());
            if(ch == 1)
            {
                adminBL.GetAllFeedbacks(LoggedInEmployee.Id);
            }
            else if(ch == 2)
            {
                Console.WriteLine("Enter the solution id of the feedbacks u want : ");
                int SolutionId = Convert.ToInt32(Console.ReadLine());
                var SolutionsFeedbacks = await adminBL.GetFeedbacksofSolution(SolutionId);
                foreach(var solution in SolutionsFeedbacks)
                {
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine(solution.ToString());
                    Console.WriteLine("-----------------------------------------------");
                }
            }
        }
        async Task EmployeeRegisterAsync(string name, string password, string role)
        {
            //int id = await userBL.GenerateId();
            Employee employee = new Employee()
            {
                Name = name,
                Password = password,
                Role = role
            };
            var result = await employeeLoginBL.Register(employee);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Registered Successfully");
            }
            else
            {
                await Console.Out.WriteLineAsync("Invalid User or User Already exists");
            }
        }
        async Task GetLoginDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }
        async Task GetRegisterDetails()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Name");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await Console.Out.WriteLineAsync("Please enter your Role ");
            string role = Console.ReadLine() ?? "";
            await EmployeeRegisterAsync(name, password, role);
        }
        async Task Starter()
        {
            bool flag =false;
            while (!flag)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Welcome to Request Tracker");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-----------------------------------------------");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await GetLoginDetails();
                        break;
                    case "2":
                        await GetRegisterDetails();
                        break;
                    case "3":
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!flag)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static async Task Main(string[] args)
        {
            await new Program().Starter();
        }
    }
}
