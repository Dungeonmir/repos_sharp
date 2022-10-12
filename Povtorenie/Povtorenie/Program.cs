using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pract
{
    class Program
    {
        public static void inputNumber(out int number)
        {
            string tmpLine = Console.ReadLine();

            int.TryParse(tmpLine, out number);
        }
        public static void inputNumber(out double number)
        {
            string tmpLine = Console.ReadLine();

            double.TryParse(tmpLine, out number);
        }
        static readonly string textFile = "menuOptions.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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

            string[] options;
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
            void task1()
            {
                Console.WriteLine("Введите число а");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите степень");
                double step = Convert.ToDouble(Console.ReadLine());
                double otv = 1;
                if (step > 0)
                {
                    for (int i = 0; i < step; i++)
                    {
                        otv *= a;
                    }
                }
                else
                {
                    for (int i = 0; i > step; i--)
                    {
                        otv *= a;

                    }
                    otv = 1 / otv;
                }
                Console.WriteLine(otv);

            }
            void task2()
            {
                Console.WriteLine("Введите строку");
                string a = Console.ReadLine();
                int strLength = 0;
                int strDiffSymbol = 0;
                int strDiffLetters = 0;
                int strPunctMarks = 0;
                int strWords = 0;
                strLength = a.Length;
                var hash = a.ToHashSet();
                hash.Remove(' ');
                strDiffSymbol = hash.Count();
                string regExpLetters = "[a-zA-Zа-яА-ЯёЁ]";
                Regex rgxLetters = new Regex(regExpLetters);
                string s = null;
                foreach (Match match in rgxLetters.Matches(a))
                {
                    s += match.Value;

                }
                for (int i = 0; i < s.Length; i++)
                {
                    int c = s.IndexOf(s[i]);
                    if (c == i)
                    {
                        strDiffLetters += 1;
                    }

                }

                string regExpPunctMarks = "[^\\w\\s]";
                Regex rgxPunctMarks = new Regex(regExpPunctMarks);
                foreach (Match match in rgxPunctMarks.Matches(a))
                {
                    strPunctMarks += 1;
                }

                string regExpWords = "[a-zA-Z]*";
                Regex rgxWords = new Regex(regExpWords);
                foreach (Match match in rgxWords.Matches(a))
                {
                    if (match.Length > 0)
                    {
                        strWords += 1;
                    }

                }

                Console.WriteLine($"Количество символов = {strLength}");
                Console.WriteLine($"Количество различных символов = {strDiffSymbol}");
                Console.WriteLine($"Количество различных букв = {strDiffLetters}");
                Console.WriteLine($"Количество знаков препинания = {strPunctMarks}");
                Console.WriteLine($"Количество слов = {strWords}");
            }
            void task3()
            {
                var rand = new Random();
                int a = 0;
                int b = 0;
                inputNumber(out a);
                inputNumber(out b);
                int[,] arr = new int[a, b];
                int otv = 1;
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        arr[i, j] = rand.Next(1, 9);
                        Console.Write(arr[i, j] + " ");
                        if (i == j)
                        {
                            otv *= arr[i, j];
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Произведение элементов главной диагонали квадратной матрицы = " + otv);


            }
            void task4()
            {
                int number;
                inputNumber(out number);
                int first = 1;
                int second = 1;
                int sum = 0;

                int j = 2;
                while (j <= number)
                {
                    sum = first + second;
                    first = second;
                    second = sum;
                    j++;
                }
                int firstn = 2;
                second = 1;
                sum = 0;
                j = 2;
                while (j <= number)
                {
                    sum = firstn + second;
                    firstn = second;
                    second = sum;
                    j++;
                }
                Console.WriteLine("Номер в последовательности " + number + ", соответсвующее число " + first);
                Console.WriteLine("Номер в последовательности " + number + ", соответсвующее число " + firstn);
            }
            void task5()
            {
                int n;
                int m;
                Console.WriteLine("Введите первое число");
                inputNumber(out n);
                Console.WriteLine("Введите второе число");
                inputNumber(out m);
                int nok = 0;
                for (int i = 0; i < (n * m + 1); i++)
                {
                    if (i % m == 0 && i % n == 0)
                    {
                        nok = i;
                        if (nok != 0)
                        {
                            break;
                        }

                    }
                }
                Console.WriteLine(nok);
            }
            void task6()
            {
                var rand = new Random();
                int a = 0;
                int b = 0;
                Console.WriteLine("Введите длину массива");
                inputNumber(out a);

                int[] arr = new int[a];
                int sum = 0;
                int proizv = 1;
                for (int i = 0; i < a; i++)
                {
                    arr[i] = rand.Next(1, 100);
                    Console.Write(arr[i] + " ");
                    if ((i + 2) % 2 == 0)
                    {
                        sum += arr[i];
                        proizv *= arr[i];
                    }
                }
                Console.WriteLine("\nСумма элементов матрицы = " + sum);
                Console.WriteLine("Произведение элементов матрицы = " + proizv);
            }
            void task7()
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                char ch1 = str1.Last();
                char ch2 = str2.Last();
                int b = str1.LastIndexOf(ch1) + 1;
                int c = str2.LastIndexOf(ch2) + 1;
                Console.WriteLine($"Длина первой строки = {b}\nДлина второй строки = {c}");
                if (b > c)
                {
                    Console.WriteLine($"{str1} > {str2}");
                }
                else if (b < c)
                {
                    Console.WriteLine($"{str1} < {str2}");
                }
                else
                {
                    Console.WriteLine($"{str1} = {str2}");
                }
                // alternative str.ToCharArray().Count

            }

        }

        private static object Compare(string? str1, string? str2, bool v)
        {
            throw new NotImplementedException();
        }
    }
}


