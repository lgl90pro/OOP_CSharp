using System;
using System.Text;

namespace Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            MyComplex a = new MyComplex(1, 1);
            MyComplex b = new MyComplex();
            MyComplex c = new MyComplex(1);
            MyComplex d = new MyComplex();

            Console.WriteLine("Введіть число D:");
            d.InputFromTerminal();
            Console.WriteLine();

            c = a + b;
            Console.WriteLine($"А + B = {c.ToString()}");

            c = a + 10.5;
            Console.WriteLine($"А + 10.5 = {c.ToString()}");

            c = 10.5 + a;
            Console.WriteLine($"10.5 + А  = {c.ToString()}");

            d = -c;
            Console.WriteLine($"-C = {d.ToString()}");

            c = a + b + c + d;
            Console.WriteLine($"A + B + C + D = {c.ToString()}");
            
            c = a * b;
            Console.WriteLine($"А * B = {c.ToString()}");

            c = 10.5 * a;
            Console.WriteLine($"А * 10.5 = {c.ToString()}");
            
            Console.WriteLine();
            Console.WriteLine($"A = {a.ToString()}");
            Console.WriteLine($"B = {b.ToString()}");
            Console.WriteLine($"C = {c.ToString()}");
            Console.WriteLine($"D = {d.ToString()}");
        }
    }
    
    class MyComplex
    {
        private double re;
        private double im;

        public MyComplex(double initRe = 0, double initIm = 0)
        {
            re = initRe;
            im = initIm;
        }

        public double GetReal()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введіть дійсне число: ");
                    re = Double.Parse(Console.ReadLine());
                    break;
                } 
                catch (FormatException)
                {
                    Console.Write("Невірно вказане дійсне число. Спробуйте ще раз.");
                }

            }
            return re;
        }
        public double GetImaginary()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введіть уявну частину: ");
                    im = Double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Невірно вказане уявне число. Спробуйте ще раз.");
                }

            }
            return im;
        }

        public void InputFromTerminal()
        {
            GetReal();
            GetImaginary();
        }
        

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re + b.re, a.im + b.im);
        }
        public static MyComplex operator +(MyComplex a, double b)
        {
            return new MyComplex(a.re + b, a.im);
        }
        public static MyComplex operator +(double b, MyComplex a)
        {
            return new MyComplex(b + a.re, a.im);
        }
        public static MyComplex operator -(MyComplex a)
        {
            return new MyComplex(-a.re, -a.im);
        }
        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re * b.im + a.im * b.re);
        }
        public static MyComplex operator *(double b, MyComplex a)
        {
            return new MyComplex(a.re * 0 + a.im * b);
        }
        public static MyComplex operator *(MyComplex a, double b)
        {
            return new MyComplex(a.re * 0 + a.im * b);
        }
        
        public override string ToString()
        {
            if (im == 0)
            {
                return $"{re}";
            }
            else if (re == 0)
            {
                return $"{im}i";
            }
            else
            {
                if (im >= 0)
                {
                    return $"{re} + {im}i";
                }
                else
                {
                    return $"{re} {im}i";
                }
            }
        }
    }
}