using System;
using static System.Console;

namespace Task4
{
    class Program
    {
        public static string Input(bool ok) // функция проверки ввода, разрешающая вводить только 0 и 1
        {
            var currentSymbol = string.Empty; // переменная для введенного символа
            var convertResult = false; // переменная, определяющая верно ли введен символ
            while (!convertResult)
            {
                ConsoleKeyInfo keyPress = ReadKey(true); // ввод символа
                int input = keyPress.KeyChar; // код введенного символа
                // символ введен верно, если его код совпадает с кодом нуля или единицы
                if (ok) convertResult = Convert.ToInt32(input) == 48 || Convert.ToInt32(input) == 49;
                else convertResult = Convert.ToInt32(input) == 49;
                if (!convertResult) continue;
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
            return currentSymbol;
        }

        public static bool Exit() // выход из программы
        {
            WriteLine("Желаете начать сначала или нет? \nВведите да или нет");
            var word = Convert.ToString(ReadLine()); // ответ пользователя
            Clear();
            if (word == "да" || word == "Да" || word == "ДА")
            {
                Clear();
                return false;
            }
            Clear();
            WriteLine("Вы ввели 'нет' или что-то непонятное. Нажмите любую клавишу, чтобы выйти из программы.");
            ReadKey();
            return true;
        }

        static void Main(string[] args)
        {
            bool okay;
            do
            {
                var n = 0; // длина числа
                var ok = false; // переменная для проверки корректности ввода
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

                var number = new int[n]; // переменная для результата
                for (var i = 0; i < n; i++)
                    number[i] = int.Parse(p[i].ToString()); // перевод введенного числа в тип Int
                var moveRes = true; // переменная, определяющая, вычислен ли результат
                for (var i = 0; i < n; i++)
                {
                    if (number[i] == 0) // поиск первого нуля в строке
                    {
                        number[i] = 1; // если ноль найден, меняем его на единицу
                        break; // выходим из цикла, результат вычислен
                    }
                    moveRes = false; // если ноль не найден - результат не вычислен
                }

                WriteLine("\nПолученный результат:");
                if (moveRes) // если результат не вычислен
                {
                    p += "1"; // добавляем в конец строки единицу
                    var newp = string.Empty;
                    for (var i = p.Length-1; i > 0; i--)// переворачиваем строку
                    {
                        newp += p[i];
                    }
                    WriteLine(newp); // выводим результат
                }
                else // если результат вычислен
                    for (var i = 0; i < n; i++) // выводим результат в обратном порядке
                        Write(number[n - 1 - i]);
                okay = Exit();
            } while (!okay);
        }
    }
}
