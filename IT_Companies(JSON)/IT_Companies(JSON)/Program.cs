using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IT_Companies_JSON_
{
    class Program
    {
        public static string CallByURL(object url)
        {
            Thread.Sleep(5000);

            string url1 = (string)url;
            var webRequest = WebRequest.Create(url1) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    return contributorsAsJson;
                }
            }
        }

        public static async Task<string> CallByURLAsync(object url)
        {
            return await Task<string>.Factory.StartNew(CallByURL, url);
        }

        public static void Loading(Task<string> task)
        {
            while (!task.IsCompleted)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("L");
                Thread.Sleep(250);
                Console.Write("o");
                Thread.Sleep(250);
                Console.Write("a");
                Thread.Sleep(250);
                Console.Write("d");
                Thread.Sleep(250);
                Console.Write("i");
                Thread.Sleep(250);
                Console.Write("n");
                Thread.Sleep(250);
                Console.Write("g");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Write(".");
                Thread.Sleep(250);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string link = "https://www.itjobs.am/api/v1.0/companies";
                Task<string> task = CallByURLAsync(link);

                Loading(task);

                string dataFromURLInJSON = task.Result;

                List<ITCompany> iTCompanies = JsonConvert.DeserializeObject<List<ITCompany>>(dataFromURLInJSON);

                Console.WriteLine("Here are all IT company names.");
                Console.WriteLine();

                iTCompanies = iTCompanies.OrderByDescending(x => x.Rating).ToList();

                // Companies by their rating
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Companies by their rating");
                Console.WriteLine();

                foreach (var company in iTCompanies)
                {
                    Console.WriteLine($"rating: {company.Rating} - {company.CompanyName}");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please, write a company name to show you photos.");
                string compName = Console.ReadLine();

                ITCompany selectedCompany = null;
                foreach (var company in iTCompanies)
                {
                    if (compName == company.CompanyName)
                    {
                        selectedCompany = company;
                        break;
                    }
                }
                if (selectedCompany != null)
                {
                    if (selectedCompany.Photos.Count != 0)
                    {
                        foreach (var item in selectedCompany.Photos)
                        {
                            Process.Start(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the company {selectedCompany.CompanyName} doesn't have any photo.");
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, the company {compName} doesn't exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
