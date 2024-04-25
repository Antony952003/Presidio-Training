using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System.Collections.Concurrent;

namespace ShoppingFE
{
    public class Program
    {
        public delegate T calcDel<T>(T n1, T n2);//creating a type that refferes to a method
        //void Calculate(calcDel cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Program program = new Program();
            //calcDel<int> c1 = program.Add;
            //calcDel<float> c2 = (n1,n2) => {
            //    return n1+n2;
            //};
            //float n1 = 10.2f;
            //float n2 = 10.3f;
            //float result = c2(n1,n2);
            //Console.WriteLine(result);
            //int[] numbers = { 10, 15, 80, 94, 103, 89, 90, 122 };
            //int[] ans = (numbers.ToList().FindAll((num) => (num >= 80))).ToArray();
            //foreach(int num in ans)
            //{
            //    Console.WriteLine(num+" ");
            //}
            //IRepository<int, Customer> customerRepo = new CustomerRepository();
            //customerRepo.Add(new Customer { Id = 1, Name = "Ramu", Age = 23 });
            //customerRepo.Add(new Customer { Id = 2, Name = "Ramu", Age = 31 });
            //customerRepo.Add(new Customer { Id = 3, Name = "Komu", Age = 27 });
            //var customers = customerRepo.GetAll().ToList();
            //customers = customers.OrderBy(cust => cust.Name).ThenByDescending(cust => cust.Age).ToList();
            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}
            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

            int[] evenNumebrs = numbers.EvenCatch();
            foreach (int n in evenNumebrs)
                Console.WriteLine(n);
            //string message = "Hello World";
            //message = message.Reverse();
            //Console.WriteLine(message);
        }
    }

    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 == 0)
                    result.Add(num);
            return result.ToArray();
        }
    }

}
