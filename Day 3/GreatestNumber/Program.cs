

namespace GreatestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            greatestnum();
        }

        private static void greatestnum()
        {
            Console.WriteLine("Greatest Number");
            int ans = findgreatest();
            printgreatest(ans);
        }

        private static int findgreatest()
        {
            Console.WriteLine("Enter the numbers one by one (if done then enter -1 ):");
            int num1;
            int greatest = 0;
            while(int.TryParse(Console.ReadLine(), out num1) && num1 > 0)
            {
                greatest = (num1 > greatest) ? num1 : greatest;
            }
            return greatest;
        }
        private static void printgreatest(int ans)
        {
            Console.WriteLine($"The greatest of the given numbers is {ans}");
        }
    }
}
