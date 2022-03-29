using System;

namespace calc
{
    class Program
    {
        private  static double Sum(double val1, double val2)
        {
            return val1 + val2;
        }

        private static double Subtraction(double val1, double val2)
        {
            return val1 - val2;
        }

        private static double Multiplication(double val1, double val2)
        {
            return val1 * val2;
        }

        private static double Division(double val1, double val2)
        {
            return val1 / val2;
        }
        static void Main(string[] args)
        {
            double value1, value2;
            string action;

            Console.WriteLine("Введите превое число: ");
            value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число: ");
            value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Выберите операцию: +, -, *, /");
            action = Console.ReadLine();

            switch(action)
            {
                case "+":
                    Console.WriteLine($"Результат: {value1} + {value2} = " + Sum(value1, value2));
                    break;
                case "-":
                    Console.WriteLine($"Результат: {value1} - {value2} = " + Subtraction(value1, value2));
                    break;
                case "*":
                    Console.WriteLine($"Результат: {value1} * {value2} = " + Multiplication(value1, value2));
                    break;
                case "/":
                    if (value2 == 0)
                    {
                        Console.WriteLine("На 0 делить нельзя");
                        break;
                    }
                    Console.WriteLine($"Результат: {value1} / {value2} = " + Division(value1, value2));
                    break;
                default:
                    Console.WriteLine("Укажите корректную операцию");
                    break;
            }
        }
    }
}