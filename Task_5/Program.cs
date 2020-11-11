using System;
using System.IO;
using System.Text;

namespace HelloWorld2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            string pathX = @"..\x.txt";
            string pathY = @"..\y.txt";
            double[] x = ReadFromFile(pathX);
            double[] y = ReadFromFile(pathY);
            Console.WriteLine($"Вихідний масив x: {string.Join(' ', x)}.");
            Console.WriteLine($"Вихідний масив y: {string.Join(' ', y)}.");
            double[] z = new double[x.Length];
            DivisionByThree(ref x);
            Converting(x, y, ref z);
            Console.WriteLine($"\nМасив x після зменшення непарних елементів тричі:\n{string.Join(' ', x)}.");
            Console.WriteLine($"\nМасив z: {string.Join(' ', z)}");
        }
        
        private static double[] ReadFromFile(string path)
        {
            string[] data;
            using (StreamReader sr = new StreamReader(path))
            {
                data = sr.ReadToEnd().Split("; ");
            }
            double[] array = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    array[i] = Convert.ToDouble(data[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введені некоректні дані у файлі. Перевірте дані і спробуйте ще раз.");
                    Environment.Exit(1);
                }
            }
            return array;
        }

        private static void DivisionByThree(ref double[] x)
        {
            for (int i = 0; i < x.Length; i += 2)
                x[i] /= 3;
        }

        private static void Converting(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < x.Length; i++)
                z[i] = x[i] + y[(x.Length - 1) - i];
        }
    }
}