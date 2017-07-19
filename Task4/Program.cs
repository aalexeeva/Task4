using System;
using System.Linq;
using static System.Console;

namespace Task4
{
    class Program
    {
        public static string Input(bool ok)
        {
            string a = string.Empty;
            bool kek = false;
            while (!kek)
            {
                ConsoleKeyInfo keyPress = ReadKey(true);
                int input = keyPress.KeyChar;
                if (ok) kek = Convert.ToInt32(input) == 48 || Convert.ToInt32(input) == 49;
                else kek = Convert.ToInt32(input) == 49;
                if (kek)
                {
                    if (input == 48)
                    {
                        Write(0);
                        a += '0';
                    }
                    else
                    {
                        Write(1);
                        a += '1';
                    }
                }
            } 
            return a;
        }

        static void Main(string[] args)
        {
            int n = 0;
            bool ok = false;
            do
            {
                try
                {
                    WriteLine("Введите натуральное число n:");
                    n = Convert.ToInt32(ReadLine());
                    if (n > 0) ok = true;
                    else WriteLine("Число должно быть натуральным, т.е. быть строго больше 0");
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка при вводе числа");
                }
                catch (OverflowException)
                {
                    WriteLine("Ошибка при вводе числа");
                }
            } while (!ok);

            var p = string.Empty;
            WriteLine("Введите двоичное число длины {0}:", n);
            for (var i = 1; i <= n; i++)
                p += Input(i != n);

            int[] number = new int[n];
            for (int i = 0; i < n; i++) number[i] = Int32.Parse(p[i].ToString());
            bool kek = true;
            for (var i = 0; i < n; i++)
            {
                if (number[i] == 0)
                {
                    number[i] = 1;
                    break;
                }
                else kek = false;
            }

            WriteLine("\nПолученный результат:");
            if (!kek)
            {
                p += "1";
                var newp = p.Reverse();
                WriteLine(newp);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Write(number[n-1-i]);
                }
            }
            ReadKey();
        }
    }
}
