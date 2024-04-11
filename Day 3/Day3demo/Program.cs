namespace Day3demo
{
    internal class Program
    {
        static int TakeNumber()
        {
            Console.WriteLine("Enter the number :");
            int num = int.Parse(Console.ReadLine());
            return num;

        }
        static string getOperation()
        {
            Console.WriteLine("Enter the operation :");
            string op = Console.ReadLine();
            return op;
        }
        static int doOperation(int num1, int num2, string op)
        {
            if (op.Equals("add")) {
                return num1 + num2;
            }
            else if (op.Equals("sub")) {
                return num2 - num1;
            }
            else if (op.Equals("mul")) {
                return num1 * num2;
            }
            else if (op.Equals("div")) {
                return num1 / num2;
            }
            else if (op.Equals("rem"))
            {
                return num1 % num2;
            }
            return -1;
        }
        static void printResult(int ans,string op)
        {
            Console.WriteLine($"The {op} of two numbers is {ans}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("hello guys");
            while (true)
            {
                Console.WriteLine("Do want to do a operation");
                string e = Console.ReadLine();
                if(e.Equals("yes"))
                    Calculate();
                else
                    break;
            }
        }

        private static void Calculate()
        {
            int num1 = TakeNumber();
            int num2 = TakeNumber();
            string op = getOperation();
            int ans = doOperation(num1, num2, op);
            printResult(ans,op);
        }
    }
}
