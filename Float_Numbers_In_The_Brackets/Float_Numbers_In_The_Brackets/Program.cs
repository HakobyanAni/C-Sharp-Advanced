using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Float_Numbers_In_The_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<float> FloatNumbers = new List<float>();

            string bracketsToOpen = "({[<";
            string bracketsToClose = ")}]>";
            
            for(int i = 0; i < bracketsToClose.Length; i++)
            {
                string pattern = $@"\{bracketsToOpen[i]}([-+]?\d+[.]\d+)\{bracketsToClose[i]}";
                MatchCollection matches = Regex.Matches(text, pattern);
                for(int j = 0; j < matches.Count; j++)
                {
                    FloatNumbers.Add((Convert.ToSingle(matches[j].Value.Substring(1, matches[j].Length - 2))));
                }
            }

            for(int i = 0; i < FloatNumbers.Count; i++)
            {
                Console.WriteLine(FloatNumbers[i]);
            }
            Console.ReadKey();
        }
    }
}
