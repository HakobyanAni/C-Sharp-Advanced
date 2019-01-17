using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubFollowers
{
    public static class GitHubAgent
    {
        public static void LoadingWaiter(LoaderTypes loader, Task task)
        {
            switch (loader)
            {
                case LoaderTypes.Points:
                    while (!task.IsCompleted)
                    {
                        ClearCurrentConsoleLine();
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(". ");
                        }
                    }
                    break;
                case LoaderTypes.Followers:
                    while (!task.IsCompleted)
                    {
                        GitHubAgent.ClearCurrentConsoleLine();
                        Thread.Sleep(400);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Followers !");
                        Thread.Sleep(400);

                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case LoaderTypes.FollowerURL:
                    while (!task.IsCompleted)
                    {
                        GitHubAgent.ClearCurrentConsoleLine();
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("* * * * * * * * * ");
                        Thread.Sleep(300);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case LoaderTypes.Repository:
                    while (!task.IsCompleted)
                    {
                        GitHubAgent.ClearCurrentConsoleLine();
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Repozitories !");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                case LoaderTypes.Followings:
                    while (!task.IsCompleted)
                    {
                        GitHubAgent.ClearCurrentConsoleLine();
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Followings !");
                        Thread.Sleep(500);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine();

        }

        public static List<User> GetFollowerList(object followersInJson)
        {
            string followersJSON = (string)followersInJson;
            // Create followerInfo list and put there deserialized followerTaskResult
            List<FollowerInfo> followerInfo = JsonConvert.DeserializeObject<List<FollowerInfo>>(followersJSON);

            // Create list of User classes so as to add there followerinfo
            List<User> followersList = new List<User>();

            // Get followers' names and add them to the followersList
            //foreach(FollowerInfo follower in followerInfo)
            //{
            //    User temp = GitHubAgent.GetUserByURL(follower.URL);
            //    Console.WriteLine(temp.ToString());
            //    followersList.Add(temp);
            //}

            // Another way to get followers' names and add them to the followersList by Parallel
            Parallel.ForEach(followerInfo, follower =>
            {
                User temp = GitHubAgent.GetUserByURL(follower.URL);
                followersList.Add(temp);
            }
            );
            return followersList;
        }

        public static async Task<List<User>> GetFollowerListAsync(string followersINJSON)
        {
            return await Task<List<User>>.Factory.StartNew(GetFollowerList, followersINJSON);
        }

        public static string GetDataFromURL(object url)
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

        // ANOTHER ASYNC WAY TO GET DATA FROM URL 
        //public static async Task<string> GetDataFromURLHTTPClientAsync(object url)
        //{
        //    Thread.Sleep(5000);

        //    string url1 = (string)url;

        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync(url1);
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    return responseBody; 
        //}

        public static async Task<string> GetDataFromURLAsync(object url)
        {
            return await Task<string>.Factory.StartNew(GetDataFromURL, url);
        }

        public static User GetUserByURL(object url)
        {
            string userInfiInJSON = GetDataFromURL(url);
            return JsonConvert.DeserializeObject<User>(userInfiInJSON);
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
