using System;
using System.Collections.Generic;
using System.Threading;

namespace Gun_Shooting
{
    public class Gun
    {
        public Types Type { get; set; }
        public Stack<Patron> Magazine { get; set; }
        public Patron Patrons { get; set; }
        public bool IsMagazineEmpty { get { return Magazine.Count == 0; } }

        public Gun(Types type, Patron patrons)
        {
            Type = type;
            Patrons = patrons;
            Magazine = new Stack<Patron>();
        }

        public void ToArm(int countOfShoots)
        {
            for (int i = 0; i < countOfShoots; i++)
            {
                Patron patron = new Patron(Patrons.Caliper, Patrons.MaxDistance);
                Magazine.Push(patron);
            }
        }

        public void ToEmptyMagazine()
        {
            Magazine.Clear();
        }

        public bool ToShoot(int countOfShoots)
        {
            for (int i = 0; i < countOfShoots; i++)
            {
                if (!IsMagazineEmpty)
                {
                    Magazine.Pop();
                    DrowArrow();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private void DrowArrow()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < Patrons.MaxDistance; i++)
            {
                Console.Write("-");
                Thread.Sleep(20);
            }
            Console.Write(">");
        }

        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
