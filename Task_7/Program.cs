using System;
using System.IO;
using System.Text;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            WeatherDays july = new WeatherDays();
            july.FromFileOrKeyboard();

            Console.ReadKey();
        }
    }
    
    public class WeatherDays
    {
        private WeatherParametersDay[] julyArray = new WeatherParametersDay[31];
        public void ReadFromFile()  // читаємо з файлу
        { 
            string path = @"..\data.txt";
            try
            {
                StreamReader sr = new StreamReader(path);
                int rows = CountRows(path);
                if (rows != 31)
                {
                    Console.WriteLine("\nКількість днів у липні 31! Зміни дані у файлі і спробуй ще раз.");
                }
                else
                {
                    for (int i = 0; i < rows; i++)
                    {
                        WeatherParametersDay day = new WeatherParametersDay();
                        julyArray[i] = day;
                        day.SetParametersFromFile(sr);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nФайл не знайдено. Спробуй ще раз.");
            }
        }

        public void ReadFromKeyboard()  // читаємо з клавіатури
        {
            for (int i = 0; i < 31; i++)
            {
                WeatherParametersDay day = new WeatherParametersDay();
                julyArray[i] = day;
                day.SetParameters();
            }
        }

        public void SunnyDays()  // кількість сонячних днів
        {
            int counter = 0;
            for (int i = 0; i < 31; i++)
            {
                if (julyArray[i].GetWeatherKey() == 7)
                {
                    counter++;
                }
            }
            Console.WriteLine($"\nСонячних днів в місяці: {counter}.");
        }
        //
        public void RainAndThunder()  // кількість дощови та грозових днів
        {
            int counter = 0;
            for (int i = 0; i < 31; i++)
            {
                if (julyArray[i].GetWeatherKey() == 1 || julyArray[i].GetWeatherKey() == 2 || julyArray[i].GetWeatherKey() == 3)
                {
                    counter++;
                }
            }
            Console.WriteLine($"\nКількість днів, коли був дощ чи гроза: {counter}.");
        }
        public void MinMaxNightTemp()  // максимальна та мінімальна температура вдень
        {
            double min = 100;
            double max = -100;
        
            for (int i = 0; i < 31; i++)
            {
                if (julyArray[i].GetDayTemp() <= min)
                {
                    min = julyArray[i].GetDayTemp();
                }
                if (julyArray[i].GetDayTemp() >= max)
                {
                    max = julyArray[i].GetDayTemp();
                }
            }
            Console.WriteLine("Максимальна температура вдень у липні: " + max);
            Console.WriteLine("Мінімальна температура вдень у липні: " + min);
        }

        public void DisplayData()  // вивід даних за всі дні
        {
            Console.WriteLine("\nДень \tТип погоди \tДенна темп-ра (C) \tНічна темп-ра (C) \tАтмосферний тиск \tКількість опадів");
            Console.WriteLine();
            for (int i = 0; i < julyArray.Length; i++)
            {
                Console.WriteLine($"{julyArray[i].GetDayNumber()}\t{julyArray[i].GetWeather()}\t\t\t{julyArray[i].GetDayTemp()}\t\t\t{julyArray[i].GetNightTemp()}\t\t\t{julyArray[i].GetAtmPressure()}\t\t\t{julyArray[i].GetPrecipitation()}");
            }
        }

        public void FromFileOrKeyboard() // користувач обирає звідки читати
        {
            string selection;
            while (true)
            {
                try
                {
                    Console.Write("Ввести дані з клавіатури(1) чи з файлу(2): ");
                    selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            ReadFromKeyboard();
                            DisplayData();
                            SunnyDays();
                            RainAndThunder();
                            MinMaxNightTemp();
                            break;
                        case "2":
                            ReadFromFile();
                            DisplayData();
                            SunnyDays();
                            RainAndThunder();
                            MinMaxNightTemp();
                            break;
                        default:
                            Console.WriteLine("\nВведіть лише 1 або 2!\n");
                            continue;
                    }
                    break;

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nВведіть лише 1 або 2!\n");
                }
            }
        }

        public int CountRows(string path)  // визначаємо кількість рядків у файлі
        {
            int count = 0;
            foreach (string i in File.ReadAllLines(path))
            {
                count++;
            }
            return count;
        }
    }
    public class WeatherParametersDay
    {
        enum WeatherType // створюэмо enum для перерахування типів погоди
        {
            Empty = 0,
            Rain = 1,
            Light = 2,
            Thunder = 3,
            Snow = 4,
            Fog = 5,
            Darkly = 6,
            Sunny = 7
        }
        
        private int numberDay;
        private int type;
        private double dayTemp;
        private double nightTemp;
        private double atmPressure;
        private double precipitation;

        public void SetParameters() // вводимо всі параметри з клавіатури
        {

            while (true) // день
            {
                try
                {
                    Console.Write("\nВведіть день місяця: ");
                    numberDay = int.Parse(Console.ReadLine()); 
                    if ((numberDay <= 0) || (numberDay > 31))
                    {
                        Console.WriteLine("Липень має лише 31 день! Спробуйте ще раз.\n");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви можете ввести лише ціле число!\n");
                }
            }

            while (true) // тип погоди
            {
                try
                {
                    Console.WriteLine("Введіть тип погоди: \nНе визначено - 0\nДощ - 1\nКороткочасний дощ - 2\nГроза - 3\nСніг - 4\nТуман - 5\nПохмуро - 6\nСонячно - 7\n");
                    type = int.Parse(Console.ReadLine());
                    if (type == 0 || type == 1 || type == 2 || type == 3 || type == 4 || type == 5 || type == 6 || type == 7)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вкажіть число від 1 до 7, що відповідає типу погоди!\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вкажіть число від 1 до 7, що відповідає типу погоди!\n");
                }
            }

            while (true) // температура вдень
            {
                try
                {
                    Console.Write($"Введіть денну температуру в {numberDay}-й день: ");
                    dayTemp = double.Parse(Console.ReadLine());
                    if ((dayTemp < -10) || (dayTemp > 60))
                    {
                        Console.WriteLine("Занадто низька або висока температура для липня. Спробуйте ще раз!\n");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви можете ввести лише число!\n");
                }
            }

            while (true) // температура вночі
            {
                try
                {
                    Console.Write($"Введіть нічну температуру в {numberDay}-й день: ");
                    nightTemp = double.Parse(Console.ReadLine());
                    if ((nightTemp < -10) || (nightTemp > 60))
                    {
                        Console.WriteLine("Занадто низька або висока температура для липня. Спробуйте ще раз!\n");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви можете ввести лише число!\n");
                }
            }

            while (true) // атмосферний тиск
            {
                try
                {
                    Console.Write($"Вкажіть середній атмосферний тиск за {numberDay}-у добу у мм рт. ст: ");
                    atmPressure = double.Parse(Console.ReadLine());
                    if ((atmPressure < 700) || (atmPressure > 800))
                    {
                        Console.WriteLine("Занадто високий чи низький атмосферний тиск! Він має бути в межах 700 і 800. Спробуйте ще раз.\n");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви можете ввести лише число!\n");
                }
            }

            while (true) // кількість опадів
            {
                try
                {
                    Console.Write($"Введіть кількість опадів за {numberDay}-у добу у мм/день: ");
                    precipitation = double.Parse(Console.ReadLine());
                    if ((precipitation < 0) || (precipitation > 100))
                    {
                        Console.WriteLine("Занадто висока чи низька кількість опадів. Спробуйте ще раз у діапазоні 0 - 100.\n");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви можете ввести лише число!\n");
                }
            }
        }

        public void SetParametersFromFile(StreamReader sr) // перевірки даних з файлу
        {

            string row = sr.ReadLine();
            string[] parameters = row.Split(';');

            if (parameters.Length != 6)
            {
                Console.WriteLine("\nНевірна кількість даних про погоду у рядку. Зробіть відповідні зміни і спробуйте ще раз!\n");
            }
            else
            {
                try
                {
                    numberDay = int.Parse(parameters[0]);
                    type = int.Parse(parameters[1]);
                    dayTemp = double.Parse(parameters[2]);
                    nightTemp = double.Parse(parameters[3]);
                    atmPressure = double.Parse(parameters[4]);
                    precipitation = double.Parse(parameters[5]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОдин із параметрів задано не коректно. Змініть дані у файлі і спробуйте ще раз.\n");
                }
            }
        }

        public int GetDayNumber()
        {
            return numberDay;
        }
        public object GetWeather()
        {
            return (WeatherType)type;
        }

        public int GetWeatherKey()
        {
            return type;
        }

        public double GetDayTemp()
        {
            return dayTemp;
        }

        public double GetNightTemp()
        {
            return nightTemp;
        }

        public double GetAtmPressure()
        {
            return atmPressure;
        }

        public double GetPrecipitation()
        {
            return precipitation;
        }
    }
}