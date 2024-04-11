namespace UsernamePasswordValid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidateUser();
        }
        static void ValidateUser()
        {
            int attempts = 3;
            while(attempts > 0)
            {
                Console.WriteLine($"You have {attempts} attempts left..");
                Console.WriteLine("Enter the username :");
                string username = Console.ReadLine();
                Console.WriteLine("Enter the password :");
                string password = Console.ReadLine();
                if(checkUser(username, password))
                {
                    Console.WriteLine($"Hi {username}, you are logged in...");
                    break;
                }else
                {
                    attempts--;
                    Console.WriteLine("The username or password is wrong");
                }
            }
            if(attempts == 0)
            {
                Console.WriteLine("You have exceeded the number of attempts and stop");
            }
        }
        static bool checkUser(string name, string password)
        {
            if(name.Equals("ABC") && password.Equals("123"))
            {
                return true;
            }
            return false;
        }
    }
}
