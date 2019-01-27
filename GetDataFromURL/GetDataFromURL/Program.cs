using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace JSON__Threads
{
    class Program
    {
        static string GetDataFromURL(object url)
        {
            Thread.Sleep(7000);
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

        static void Main(string[] args)
        {
            Task<string> task = new Task<string>(GetDataFromURL, @"https://jsonplaceholder.typicode.com/comments");
            task.Start();

            while (!task.IsCompleted)
            {
                Console.Clear();
                Thread.Sleep(700);
                Console.Write(". ");
                Thread.Sleep(700);
                Console.Write(". ");
                Thread.Sleep(700);
                Console.Write(". ");
                Thread.Sleep(700);
            }

            Console.Clear();
            Console.WriteLine("Your data is ready, press Enter to show it");
            Console.ReadKey();

            string taskResult = task.Result;
            Console.WriteLine(taskResult);

            Console.ReadKey();
        }
    }
}
