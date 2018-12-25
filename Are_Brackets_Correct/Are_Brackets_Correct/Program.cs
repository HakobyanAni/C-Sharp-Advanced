using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        public static void IsBracketCorrect(string text)
        {
            string brackets = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(' || text[i] == '{' || text[i] == '[' || text[i] == '<' ||
                    text[i] == ')' || text[i] == '}' || text[i] == ']' || text[i] == '>')
                {
                    brackets += text[i];
                }
            }

            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets.Contains("()") || brackets.Contains("[]") || brackets.Contains("{}") || brackets.Contains("<>"))
                {
                    brackets = brackets.Replace("()", "");
                    brackets = brackets.Replace("{}", "");
                    brackets = brackets.Replace("[]", "");
                    brackets = brackets.Replace("<>", "");
                }
            }

            if (brackets == "")
            {
                Console.WriteLine("All brackets are correct.");
            }
            else
            {
                Console.WriteLine("Brackets are not correct.");
            }
        }

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            IsBracketCorrect(text);
            Console.ReadKey();
        }
    }
}
