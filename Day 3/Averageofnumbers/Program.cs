
namespace Averageofnumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ans = findAverage();
            printResult(ans);
        }

        private static void printResult(int ans)
        {
            Console.WriteLine($"The average of the numbers divisible by 7 is {ans}");
        }

        static int findAverage()
        {
            Console.WriteLine("Enter the numbers one by one :");
            int num1;
            int total = 0;
            int n = 0; 
            while (int.TryParse(Console.ReadLine(), out num1) && num1 > 0)
            {
                if(num1 % 7 == 0)
                {
                    total += num1;
                    n++;
                }
            }
            return total / n;
        }
    }
}
