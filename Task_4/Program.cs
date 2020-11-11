using System;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            int a = 0; // чисельник, що задає користувач
            int b = 0; // знаменник, що задає користувач
            int c = 3; // чисельник для прикладу
            int d = 7; // знаменник для прикладу
            Operation.Input(ref a, ref b);
            Operation.Sum(a, b, c, d);
            Operation.Dif(a, b, c, d);
            Operation.Mul(a, b, c, d);
            Operation.ToDouble(a, b);

        }
    }
    class Operation
    {
        public static void Input(ref int a, ref int b) // введення даних
        {
            
            string data1 = "";
            string path = @"..\data.txt";
            while (true)
            {
                try
                {
                    Console.WriteLine("Як вводити дані:\n1. З клавіатури;\n2. З файлу.");
                    string selection = Console.ReadLine();
                    if (selection != "1" && selection != "2")
                    {
                        throw new Exception("Введіть лише 1 або 2. Повторіть спробу:\n");
                    }
                    switch (selection)
                    {
                        case "1": // з клавіатури
                            Console.WriteLine("Введіть раціональне число у вигляді \"m/n\", де m - ціле число, n - натуральне:");
                            data1 = Console.ReadLine();
                            goto case "Check";
                    
                        case "2": // з файлу
                            using (StreamReader sr = new StreamReader(path))
                            {
                                data1 = sr.ReadToEnd();
                                string[] data2 = data1.Split('/');
                                goto case "Check";
                            }
                            
                        case "Check": // перевірка даних
                            try
                            {
                                string[] data2 = data1.Split('/');
                                a = int.Parse(data2[0]);
                                b = int.Parse(data2[1]);
                                if (b <= 0)
                                {
                                    throw new Exception("Знаменник має бути натуральним числом. Повторіть спробу:\n");
                                }
                                break;
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Відсутній \"/\", повторіть спробу:\n");
                                goto case "1";
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Введені некоректні дані, повторіть спробу:\n");
                                goto case "1";
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                goto case "1";
                            }
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        } 
        public static void Sum(int a, int b, int c, int d) // сума дробів
        {
            int up1 = a * d;
            int up2 = c * b;
            int denominator = b * d;
            int numerator  = up1 + up2;
            Console.Write($"\nРезультат додавання {a}/{b} та {c}/{d}: ");
            Nod(numerator , denominator);
        }
        public static void Dif(int a, int b, int c, int d) // різниця дробів
        {
            int up1 = a * d;
            int up2 = c * b;
            int denominator = b * d;
            int numerator  = up1 - up2;
            Console.Write($"\nРезультат різниці {a}/{b} та {c}/{d}: ");
            Nod(numerator , denominator);
        }
        public static void Mul(int a, int b, int c, int d) // множення дробів
        {
            int numerator = a * c;
            int denominator = b * d;
            Console.Write($"\nРезультат множення {a}/{b} та {c}/{d}: ");
            Nod(numerator , denominator);
        }
        public static void ToDouble(int a, int b) // переведення числа в double
        {
            double aNew = Convert.ToDouble(a);
            double bNew = Convert.ToDouble(b);
            double result = aNew / bNew;
            Console.WriteLine($"\nРезультат переведення дробу {a}/{b} в double: {result:F}");
        } 
        static void Nod(int numerator, int denominator) // скорочення дробу
        {
            int numeratorCopy = numerator;
            int denominatorCopy = denominator;
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            while (numerator != 0 && denominator != 0)
            {
                if (numerator > denominator)
                {
                    numerator = numerator % denominator;
                }
                else
                {
                    denominator = denominator % numerator;
                }
            }

            int nod = numerator + denominator;
            Console.WriteLine($"{numeratorCopy / nod}/{denominatorCopy / nod}.");
        }
    }
}