using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Operations_With_Lambda_Operator
{
    public delegate double Arithmetic(double VariableOne, double VariableTwo);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please select the arithmetic operation you want: + , - , * or /");
            string arithOperation = Console.ReadLine();

            Arithmetic operation = null;

            switch (arithOperation)
            {
                case "+":
                    operation = (x, y) => { return x + y; };
                    break;
                case "-":
                    operation = (x, y) => { return x - y; };
                    break;
                case "*":
                    operation = (x, y) => { return x * y; };
                    break;
                case "/":
                    operation = (x, y) =>
                    {
                        if (y != 0)
                        {
                            return x / y;
                        }
                        else
                        {
                            Console.WriteLine("You cann't divide number on 0");
                            return 0;
                        }
                    };
                    break;
                default:
                    Console.WriteLine("Wrong operation!");
                    break;
            }

            Console.WriteLine("-------------------------------");

            if (operation != null)
            {
                Console.WriteLine($"{num1} {arithOperation} {num2} is {operation(num1, num2)}");
            }

            Console.ReadKey();
        }
    }
}