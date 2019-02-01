using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Companies_From_WebSite
{
    public class Company
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }
        public int NumbOfEmployees { get; set; }
        public string DataOfFoundation { get; set; }
        public string AboutCompany { get; set; }
        public List<ActiveJobs> Jobs { get; set; }
        public string WebSite { get; set; }
        public string Adress { get; set; }

        public Company()
        {

        }

        public Company(string industry, string type, int numbOfEmployees, string dataOfFoundation, string webSite, string adress)
        {
            Industry = industry;
            Type = type;
            NumbOfEmployees = numbOfEmployees;
            DataOfFoundation = dataOfFoundation;
            WebSite = webSite;
            Adress = adress;
            Jobs = new List<ActiveJobs>();
        }

        public void DescribeYourself()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"This is main information about {Name}.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Industry);
            Console.WriteLine(Type);
            Console.WriteLine(NumbOfEmployees);
            Console.WriteLine(DataOfFoundation);
            Console.WriteLine(WebSite);
            Console.WriteLine(Adress);
            Console.WriteLine("Here is active jobs.");
            //foreach (var job in Jobs)
            //{
            //    Console.WriteLine(job);
            //    Console.WriteLine("---------------");
            //}
        }
    }
}
