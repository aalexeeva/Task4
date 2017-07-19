using System;
using System.Linq;
using static System.Console;

namespace Task4
{
    class Program
    {
        public static string Input(bool ok) // функция проверки ввода, разрешающая вводить только 0 и 1
        {
            string currentSymbol = string.Empty; // переменная для введенного символа
            bool convertResult = false; // переменная, определяющая верно ли введен символ
            while (!convertResult)
            {
                ConsoleKeyInfo keyPress = ReadKey(true); // ввод символа
                int input = keyPress.KeyChar; // код введенного символа
                // символ введен верно, если его код совпадает с кодом нуля или единицы
                if (ok) convertResult = Convert.ToInt32(input) == 48 || Convert.ToInt32(input) == 49;
                else convertResult = Convert.ToInt32(input) == 49;
                if (convertResult) // если символ введен верно, вывод его в консоль
                {
                    if (input == 48)
                    {
                        Write(0);
                        currentSymbol = "0"; 
                    }
                    else
                    {
                        Write(1);
                        currentSymbol = "1";
                    }
                }
            } 
            return currentSymbol;
        }

        static void Main(string[] args)
        {
            int n = 0; // длина числа
            bool ok = false; // переменная для проверки корректности ввода
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

            var p = string.Empty; // переменная для двоичного числа
            WriteLine("Введите последовательность нулей и единиц длины {0}:", n);
            for (var i = 1; i <= n; i++)
                p += Input(i != n); // ввод числа посимвольно

            int[] number = new int[n]; // переменная для результата
            for (var i = 0; i < n; i++) number[i] = int.Parse(p[i].ToString()); // перевод введенного числа в тип Int
            bool MoveRes = true; // переменная, определяющая, вычислен ли результат
            for (var i = 0; i < n; i++)
            {
                if (number[i] == 0) // поиск первого нуля в строке
                {
                    number[i] = 1; // если ноль найден, меняем его на единицу
                    break; // выходим из цикла, результат вычислен
                }
                else MoveRes = false; // если ноль не найден - результат не вычислен
            }

            WriteLine("\nПолученный результат:");
            if (MoveRes) // если результат не вычислен
            {
                p += "1"; // добавляем в конец строки единицу
                var newp = p.Reverse(); // переворачиваем строку
                WriteLine(newp); // выводим результат
            }
            else // если результат вычислен
            {
                for (int i = 0; i < n; i++) // выводим результат в обратном порядке
                { 
                    Write(number[n-1-i]);
                }
            }
            ReadKey();
        }
    }
}
