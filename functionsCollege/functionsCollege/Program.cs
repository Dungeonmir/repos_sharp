using System;

namespace functions
{
    class Program
    {
        static int factor(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * factor(n - 1);
            }


        }
        static void factorVoid(out int r)
        {

            int n = 5;
            int fac = 1;
            for (int i = n + 1; i > 1; i--)
            {
                fac = fac * (i - 1);
            }
            r = fac;
        }

        static void changeVar(ref int a, ref int b)
        {
            /* Написать метод, использующий два передаваемых по ссылке
            параметра типа int a и b и меняющий их местами, если число b меньше числа
            а. (Использовать модификатор ref). */
            if (b <a){
                b = a + b;
                a = b - a;
                b = b - a;
            }
        }

        static int isSimple( int n)
        {
            /*Написать метод, определяющий, является ли число простым.
       Использовать его для нахождения количества простых чисел на интервале от
       m до n и их вывода на экран*/

            int k = 2;
            while (n % k != 0)
            {

                k++;

            }

            if (n == k)
            {
                return k;
                
            }
            else
            {
                return n = -1;
               
            }


        }

       
        static int returnMaxDigit(int n)
        {
            /*Реализовать метод возвращающий максимальную цифру числа*/
            int max = int.MinValue;
            while (n>0)
            {
                if (n % 10>max)
                {
                    max = n % 10;
                }
                
                n = n / 10;
            }

            return max;
                        
        }
        
        static int returnNumberOfSearchedWord(string str, string word)
        {
            /*Реализовать метод находящий сколько раз встречается в строке
слово введенное пользователем*/
             int n = 0;

            int i = 0;
            string[] words = str.Split(' ', '.', ',');
            for (i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    n++;
                }
            }
            return n;
        }

      

        static void Main(string[] args)
        {
            string str = "hello go hello, for dor hello, hello go fdfo hello. dsf";
            string word = "hello";
            int n = returnNumberOfSearchedWord(str, word);
            Console.WriteLine(n);
            

            }
    }
}
