using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pract
{
    /*
using System;

using System.Linq;

namespace ConsoleApp1

{

    class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("Введите строку: ");

            string str = Console.ReadLine();

            int letters, upperSymbols, lowerSymbols, digitSymbols, whitespaceSymbols, pynctuationSymbols;

            statistic(str, out int symbols, out letters, out upperSymbols, out lowerSymbols, out digitSymbols, out whitespaceSymbols, out pynctuationSymbols);

            Console.WriteLine($"Кол-во символов: {symbols} \nВсего букв букв: {letters} " +

            $"\nВерхний регистр: {upperSymbols} \nНижний регистр: {lowerSymbols} \nЦифры: {digitSymbols} \nПробелов: {whitespaceSymbols} \nЗнаков препинания: {pynctuationSymbols}");

        }

        static void statistic(string str, out int symbols, out int letters, out int upperSymbols, out int lowerSymbols, out int digitSymbols, out int whitespaceSymbols, out int pynctuationSymbols)

        {

            symbols = str.Length;

            letters = 0;

            foreach (var el in str) if (char.IsLetter(el)) letters++;

            upperSymbols = 0; lowerSymbols = 0;

            foreach (var el in str) if (char.IsUpper(el)) upperSymbols++;

            foreach (var el in str) if (char.IsLower(el)) lowerSymbols++;

            digitSymbols = 0;

            foreach (var el in str) if (char.IsDigit(el)) digitSymbols++;

            pynctuationSymbols = 0;

            foreach (var el in str) if (char.IsPunctuation(el)) pynctuationSymbols++;

            whitespaceSymbols = 0;
            foreach (var el in str) if (char.IsWhiteSpace(el)) whitespaceSymbols++;
        }
    }
}*/
    
    public static class String
    {
        public static int nmbrOfLetters(this string str)
        {
            int nmbr = 0;
            foreach (char ch in str) if(char.IsLetter(ch)) nmbr++;
            return nmbr;
        }
        public static int nmbrOfUpSmbls(this string str)
        {
            int nmbr = 0;
            foreach (char ch in str) if (char.IsUpper(ch)) nmbr++;
            return nmbr;
        }
        public static int nmbrOfLowSmbls(this string str)
        {
            int nmbr = 0;
            foreach (char ch in str) if (char.IsLower(ch)) nmbr++;
            return nmbr;
        }
        public static int nmbrOfDigits(this string str)
        {
            int nmbr = 0;
            foreach (char ch in str) if (char.IsDigit(ch)) nmbr++;
            return nmbr;
        }
        public static int nmbrOfPunctuations(this string str)
        {
            int nmbr = 0;
            foreach (char ch in str) if (char.IsPunctuation(ch)) nmbr++;
            return nmbr;
        }
        public static int nmbrOfSpaces(this string str)
        {
            int nmbr = 0;
            foreach (char ch in str) if (char.IsWhiteSpace(ch)) nmbr++;
            return nmbr;
        }

    }



    class Program
    {


        public static Dictionary<string, int> stringStatistic(string str)
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();
            stats["Number of digits"] = str.nmbrOfDigits();
            stats["Number of upperCase symbols"] = str.nmbrOfUpSmbls();
            stats["Number of lowercase symbols"] = str.nmbrOfLowSmbls();
            stats["Number of whitespaces"] = str.nmbrOfSpaces();
            stats["Number of letters"] = str.nmbrOfLetters();
            stats["Number of punctuation marks"] = str.nmbrOfPunctuations();
            return stats;
        }
        
       
        public static void inputNumber(out int number)
        {
            string tmpLine = Console.ReadLine();

            int.TryParse(tmpLine, out number);
        }
        public static void inputNumber(out float number)
        {
            string tmpLine = Console.ReadLine();

            float.TryParse(tmpLine, out number);
        }
        public static void inputNumber(out double number)
        {
            string tmpLine = Console.ReadLine();

            double.TryParse(tmpLine, out number);
        }
        static readonly string textFile = "menuOptions.txt";


        static void Main(string[] args)
        {
            Random rand = new Random();
            void inputMenu(int number)
            {
                Console.Clear();
                Console.WriteLine($"Вы ввели {number}\n");
            }
            void loadMenu(out string[] lines)
            {
                if (!File.Exists(textFile))
                {
                    var fileStream = File.Create(textFile);
                    fileStream.Close();
                }
                lines = File.ReadAllLines(textFile);
            }
            void showMenu(string[] lines)
            {
                var counter = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                    {

                        if (lines[i - 1] == "")
                        {

                            Console.WriteLine($"{counter + 1}. {lines[i]}");
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine($"    {lines[i]}");
                        }
                    }
                }
                Console.WriteLine($"\n0. Выйти из приложения");
                Console.WriteLine();
            }
            void showMenuItem(string[] lines, int number)
            {
                var counter = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "")
                    {
                        counter++;
                        if (counter == number)
                        {
                            Console.WriteLine($"{counter}. {lines[i + 1]}");
                            i++;
                            while (lines[i] != "")
                            {
                                i++;
                                Console.WriteLine($"    {lines[i]}");

                            }
                            Console.WriteLine();

                        }



                    }
                }
            }
            void fillArray(int[] arr, int min, int max)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(min, max);
                }
            }
            string[] options;
            Console.OutputEncoding = Encoding.UTF8;
            loadMenu(out options);

            int sw = -1;
            
            while (sw != 0)
            {
                
                Console.WriteLine("Нажмите enter для продолжения...");
                Console.ReadLine();
                Console.Clear();
                showMenu(options);
                string tmpLine = Console.ReadLine();

                if (!int.TryParse(tmpLine, out sw))
                {
                    sw = -1;
                }
                inputMenu(sw);
                showMenuItem(options, sw);
                switch (sw)
                {
                    case 0:
                        Console.WriteLine("Закрываемся...");
                        break;
                    case 1:
                        task1();
                        break;
                    case 2:
                        task2();
                        break;
                    case 3:
                        task3();
                        break;
                    case 4:
                        task4();
                        break;
                    case 5:
                        task5();
                        break;
                    case 6:
                        task6();
                        break;
                    case 7:
                        task7();
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;


                }
            }
            void task1() {
                int b = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[b];
                int c = 0;
                int[] aa = new int[a.Length];
                Random rnd = new Random();
                for (int i = 0; i < b; i++)
                {
                    a[i] = rnd.Next(-2, 2);
                }
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write(a[i] + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == 0)
                    {
                        c++;
                    }
                    else
                    {
                        aa[i - c] = a[i];
                    }
                }
                for (int i = 0; i < aa.Length; i++)
                {
                    if (aa[i] == 0)
                    {
                        aa[i] = -1;
                    }
                }
                for (int i = 0; i < aa.Length; i++)
                {
                    Console.Write(aa[i] + " ");
                }
            }
            void task2() {
                int[] arr = new int[10];
                fillArray(arr, -2, 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
                Array.Sort(arr);
                Array.Reverse(arr);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            void task3() {
            Console.WriteLine("\nENTER NUMBER\n");
                int n;
                int [] arr = new int[60];
                fillArray(arr, -10, 10);
                n = Convert.ToInt32(Console.ReadLine());
                int counter = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                    if((i+20)%20==0)Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i]==n)
                    {
                        counter++;
                    }
                }
                Console.WriteLine(n  +" встретился " + counter + " раз");

            }
            void task4() {
                /*В двумерном массиве порядка M на N поменяйте местами заданные столбцы.*/
                int m, n;
                Console.WriteLine("Enter m ");
                inputNumber(out m);
                Console.WriteLine("Enter n ");
                inputNumber(out n);
                int[,] arr = new int[m,n];
                int[,] arrOut= new int[n,m];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        arr[i,j] = rand.Next(0, 10);
                        Console.Write(arr[i, j] + "\t");
                    }
                    Console.WriteLine() ;
                }
                Console.WriteLine("\n");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        arrOut[i, j] =arr[j,i];
                        Console.Write(arrOut[i, j] + "\t");
                    }
                   Console.WriteLine();
                }
                
            }
            void task5() {

                Console.WriteLine("Enter string: ");

                string str = Console.ReadLine();
                Console.WriteLine();
                Dictionary<string, int> stats;
                stats = stringStatistic(str);
                foreach (var item in stats)
                {
                    Console.WriteLine($"{item.Key} = {item.Value}");
                }

            }
            void task6() {
                char ch;
                string str;
                Console.WriteLine("Enter string");
                str = Console.ReadLine();
                Console.WriteLine("Enter character");
                ch = Console.ReadLine()[0];
                str = str.Remove(str.LastIndexOf(ch), str.Length - str.LastIndexOf(ch));
                str = str.Replace(ch, Char.ToUpper(ch));

                Console.WriteLine(str);
            }
            void task7()
            {
                double x, y,z;
                double x1,y1,z1;
                x = 0.143;
                y = 0.284;
                z = 0.063;
                x1 = x;
                y1 = y;
                z1 = z;
                Console.WriteLine();
                for (int i = 0; i < 20; i++)
                {
                   
                    
                   
                    x1 = 0.143 - 0.334 * x - 0.218 * y + 0.048 * z;
                    x = x1;
                    y1 = 0.284 - 0.157 * x - 0.0495 * y - 0.384 * z;
                    y = y1;
                    z1 = 0.063 - 0.088 * x + 0.346 * y - 0.0326 * z;
                    z = z1;

                    Console.WriteLine($"x{i+1} = {x1}");
                    Console.WriteLine($"y{i + 1} = {y1}");
                    Console.WriteLine($"z{i + 1} = {z1}\n");
                }
            }
        }
        
    }
}

