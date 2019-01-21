using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            if (!IsMagazineEmpty)
            {
                for (int i = 0; i < countOfShoots; i++)
                {
                    Console.ReadLine();
                    Magazine.Pop();
                    ClearCurrentConsoleLine();
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("----->");
                    Thread.Sleep(300);
                    return false;
                }
            }
            else
            {
                return true;
            }
            return false;
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
