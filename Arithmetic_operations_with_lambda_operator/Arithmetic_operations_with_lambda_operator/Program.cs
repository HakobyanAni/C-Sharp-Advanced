using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Operations_With_Lambda_Operator
{
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
            ArithOp oper;
            switch (arithOperation)
            {
                case "+":
                    oper = ArithOp.Add;
                    break;
                case "-":
                    oper = ArithOp.Sub;
                    break;
                case "*":
                    oper = ArithOp.Mul;
                    break;
                case "/":
                    oper = ArithOp.Div;
                    break;
                default:
                    oper = ArithOp.Undefined;
                    Console.WriteLine("Wrong operation ! Try again.");
                    break;
            }

            ArrayList res = new ArrayList();

            if (oper != ArithOp.Undefined)
            {
                res = ArithmeticOp.ArithmeticOperation(num1, num2, oper);

                if (!(bool)res[0])
                {
                    Console.WriteLine("Try again !");
                }
                else
                {
                    Console.WriteLine($"{num1} {arithOperation} {num2} is {res[1]}");
                }
            }
            Console.ReadKey();
        }
    }
}