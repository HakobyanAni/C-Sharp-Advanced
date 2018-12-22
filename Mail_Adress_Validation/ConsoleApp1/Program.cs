using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailAdress
{
    class Program
    {
        public static bool IsMailAdressValid(string mailAdress)
        {
            const string validationPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            var regex = new Regex(validationPattern);

            return regex.IsMatch(mailAdress);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please select your e-mail adress");
            string s = Console.ReadLine();
            if (IsMailAdressValid(s))
            {
                Console.WriteLine("Thank you, your mail is correct.");
            }
            else
            {
                Console.WriteLine("Oops! Your mail isn't valid, please try again.");
            }
        }
    }
}
