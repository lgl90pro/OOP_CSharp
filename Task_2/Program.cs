using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("Введіть зміну типу int: ");
            string a1 = Console.ReadLine();
            try
            {
                int a2 = Convert.ToInt32(a1);
            }
            catch
            {
                Console.WriteLine("Це не змінна типу int!\n");
            }

            Console.Write("Введіть зміну типу double: ");
            string b1 = Console.ReadLine();
            try
            {
                double b2 = Convert.ToDouble(b1);
            }
            catch
            {
                Console.WriteLine("Це не змінна типу double!\n");
            }

            Console.Write("Введіть зміну типу long: ");
            string c1 = Console.ReadLine();
            try
            {
                double c2 = Convert.ToInt64(c1);
            }
            catch
            {
                Console.WriteLine("Це не змінна типу long!\n");
            }

            Console.WriteLine($"a = {a1}; b = {b1}; c = {c1}");
        }
    }
}