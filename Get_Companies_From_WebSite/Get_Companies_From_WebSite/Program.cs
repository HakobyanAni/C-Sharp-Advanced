using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Get_Companies_From_WebSite
{
    class Program
    {
        public static void WriteExceptionInFile(string e)
        {
            FileStream fileStream = new FileStream("Exception.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.Write(e + "\n");
            writer.Flush();
            fileStream.Close();
        }

        static void Main(string[] args)
        {
            string url = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";
            JobWebSite jobWebSite = new JobWebSite("staff.am", url);
            List<Company> comps = Helper.ScrapForStaffAM(jobWebSite.URL);
            jobWebSite.AllCompanies = comps;
            Console.Clear();

            foreach (var company in jobWebSite.AllCompanies)
            {
                company.DescribeYourself();
            }

            // Filtering the list AllCompanies 
            var filterList = jobWebSite.AllCompanies.Where(x => x.NumbOfEmployees > 50 && x.Jobs.Any(y => y.JobName.ToLower().Contains("engineer"))).ToList();
            foreach (var company in filterList)
            {
                Console.WriteLine(company);
            }

            Console.ReadKey();
        }
    }
}
