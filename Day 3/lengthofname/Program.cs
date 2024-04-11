namespace lengthofname
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = getname();
            int len = lengthofname(name);
            printResult(len, name);
        }
        static string getname()
        {
            Console.WriteLine("Enter your name : ");
            string name = Console.ReadLine();
            return name;
        }
        static void printResult(int len, string name)
        {
            Console.WriteLine($"The length of the name {name} is {len}");
        }
        static int lengthofname(string name)
        {
            int cnt = 0;
            foreach(char c in name.ToCharArray())
            {
                cnt++;
            }
            return cnt;
        }
    }
}
