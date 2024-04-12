using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validcard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the card number : ");
            string creditCardNumber = Console.ReadLine();

            char[] charArray = creditCardNumber.ToCharArray();
            Array.Reverse(charArray);
            string reversedNumber = new string(charArray);

            int sum = Sumofreverseddigits(reversedNumber);
            ValidityCheckofSum(sum);
        }

        static int Sumofreverseddigits(string reversedNumber)
        {
            int sum = 0;
            bool doubleDigit = false;
            for (int i = 0; i < reversedNumber.Length; i++)
            {
                int digit = int.Parse(reversedNumber[i].ToString());

                if (doubleDigit)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit = (digit % 10) + 1;
                    }
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }
            return sum;
        }
        static void ValidityCheckofSum(int sum)
        {
            Console.WriteLine(sum+" ");
            bool isValid = sum % 10 == 0;

            if (isValid)
            {
                Console.WriteLine("The credit card number is valid.");
            }
            else
            {
                Console.WriteLine("The credit card number is invalid.");
            }
        }
    }
}
