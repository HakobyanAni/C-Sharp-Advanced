using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Companies_From_WebSite
{
    public class ActiveJobs
    {
        public string JobName { get; set; }
        public string Data { get; set; }
        public string CompanyName { get; set; }

        public ActiveJobs()
        {

        }

        public void DescribeYourself()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Here is active jobs.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(JobName);
            Console.WriteLine(Data);
            Console.WriteLine(CompanyName);
        }
    }
}
