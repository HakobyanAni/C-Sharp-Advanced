using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Advanced_C_Sharp
{
    enum Position
    {
        junior,
        middle,
        senior
    }

    class Employee
    {
        public string name;
        public Position position;

        public Employee(string name, Position position)
        {
            this.name = name;
            this.position = position;
        }
    }

    static class Accauntant
    {
        public static double AskForBonus(Employee worker, int hours)
        {
            Position position = worker.position;
            double bonus = 0;

            switch (position)
            {
                case Position.junior:
                    {
                        if (hours >= 100)
                        {
                            bonus = hours * 20;
                        }
                        break;
                    }

                case Position.middle:
                    {
                        if (hours >= 80)
                        {
                            bonus = hours * 30;
                        }
                        break;
                    }

                case Position.senior:
                    {
                        if (hours >= 50)
                        {
                            bonus = hours * 45;
                        }
                        break;
                    }

                default:
                    bonus = 0;
                    break;
            }
            return bonus;
        }

        public static void PrintPosition(Employee worker)
        {
            Console.WriteLine(worker.position);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("John, Arthur, Jane and Helen work in a big programming company.");
            Employee emp1 = new Employee("John", Position.junior);
            Employee emp2 = new Employee("Arthur", Position.middle);
            Employee emp3 = new Employee("Jane", Position.senior);
            Employee emp4 = new Employee("Helen", Position.junior);

            Console.WriteLine("They asked for a premium. So you can see the information about " +
                              "working hours(monthly) premium on the following table.");
            Console.WriteLine("John   -  150 h  -  " + Accauntant.AskForBonus(emp1, 150) + "$");
            Console.WriteLine("Arthur -  80 h   -  " + Accauntant.AskForBonus(emp1, 80) + "$");
            Console.WriteLine("Jane   -  85 h   -  " + Accauntant.AskForBonus(emp2, 85) + "$");
            Console.WriteLine("Helen  -  100 h  -  " + Accauntant.AskForBonus(emp4, 100) + "$");

            Console.ReadKey();
        }
    }
}
