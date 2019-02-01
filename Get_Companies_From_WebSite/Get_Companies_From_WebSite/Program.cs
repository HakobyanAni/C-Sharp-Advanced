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

        public static void Loading(Task<List<Company>> task, DataModel loading)
        {
            while (!task.IsCompleted)
            {
                
                ClearCurrentConsoleLine();
                if(loading.flag)
                {
                    foreach (var symbol in loading.Status)
                    {
                        Thread.Sleep(150);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(symbol);
                    }
                }
                else
                {
                    Console.WriteLine(loading.Status);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void Main(string[] args)
        {
            string url = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";
            JobWebSite jobWebSite = new JobWebSite("staff.am", url);

            // Sync Call
            //List<Company> comps = Helper.ScrapForStaffAM(jobWebSite.URL);
            //jobWebSite.AllCompanies = comps;

            //foreach (var company in jobWebSite.AllCompanies)
            //{
            //    company.DescribeYourself();
            //}


            // Async Call
            DataModel data = new DataModel();
            data.Url = jobWebSite.URL;
            data.Status = "Loading.....";
            data.flag = true;
            Task<List<Company>> companyTask = Helper.ScrapForStaffAMAsync(data);
            Console.Clear();
            
            Loading(companyTask, data); 
           
            foreach (var company in companyTask.Result)
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
