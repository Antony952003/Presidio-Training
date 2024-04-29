using System.Runtime.InteropServices;
using System.Text;

namespace ExcelName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            int input = 28;
            while(input > 0)
            {
                char current = (char)('A' + (input - 1) % 26);
                str.Insert(0, current);
                input = input / 26;
            }
            string ans = str.ToString();
            Console.WriteLine(ans);
        }
    }
}
