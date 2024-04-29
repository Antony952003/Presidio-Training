using System.Runtime.InteropServices;
using System.Text;

namespace ExcelName
{
    public class Program
    {
        public async Task<string> CalculateExcelColumn(int input)
        {
            StringBuilder str = new StringBuilder();
            while (input > 0)
            {
                char current = (char)('A' + (input - 1) % 26);
                str.Insert(0, current);
                input = input / 26;
            }
            string ans = str.ToString();
            return ans;
            Console.WriteLine(ans);
        }

        public async Task<int> getInput()
        {
            Console.WriteLine("Enter the Excel column Number : ");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        static async void Main(string[] args)
        {
            Program program = new Program();
            int input = await program.getInput();
            string ans = await program.CalculateExcelColumn(input);
            Console.WriteLine("The corresponding column name is {ans}");
        }
    }
}
