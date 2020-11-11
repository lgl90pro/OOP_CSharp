using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int a;
            double b;
            long c;
            Console.Write("Введіть int: ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Число не int!\n");
                Console.Write("Введіть int: ");
            }
            Console.Write("Введіть double: ");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Число не double!\n");
                Console.Write("Введіть double: ");
            }
            Console.Write("Введіть long: ");
            while (!long.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Число не long!\n");
                Console.Write("Введіть long: ");
            }
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        }
    }
}