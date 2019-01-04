using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_Mood
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Friend friend = new Friend("Sherlock", "Holmes", 35);
                Console.Write($"I am {friend.FirstName} {friend.LastName} Select my mood: Bad - 1, Normal - 2, Good - 3, Excellent - 4\nMood = ");

                int choosenMoodInInteger = Convert.ToInt32(Console.ReadLine());
                friend.Mood = (Moods)choosenMoodInInteger;

                switch (friend.Mood)
                {
                    case Moods.Bad:
                        friend.SayHello = delegate { Console.WriteLine("Hello Stranger."); };
                        break;
                    case Moods.Normal:
                        friend.SayHello = delegate { Console.WriteLine("Hello Brother."); };
                        break;
                    case Moods.Good:
                        friend.SayHello = () => Console.WriteLine("Hello my dear. How are you?");
                        break;
                    case Moods.Excellent:
                        friend.SayHello = delegate { Console.WriteLine("Hello my dear. I miss you."); };

                        break;
                    default:
                        break;
                }

                friend.PrintMyMood();
                friend.SayHello();

                Console.WriteLine("\n--------------------------------------------");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
