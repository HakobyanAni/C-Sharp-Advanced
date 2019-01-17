using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubFollowers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter github account username : ");
            string username = Console.ReadLine();

            string api = $@"https://api.github.com/users/{username}";

            // Create task getDataTask
            Task<User> getDataTask = new Task<User>(GitHubAgent.GetUserByURL, api);

            try
            {
                // Run the task getDataTask
                getDataTask.Start();

                GitHubAgent.LoadingWaiter(LoaderTypes.Points, getDataTask);

                // Get getDataTask's result which is User class
                User user = getDataTask.Result;

                Console.WriteLine($"Data for {user.ToString()} is ready. press Enter to show it.");
                Console.ReadKey();
                Console.WriteLine($"Country: {user.Country}");
                Console.WriteLine($"Followers: {user.Followers}, Followings: {user.Following}");

                //////// GETTING USER'S ALL REPOSITORY NAMES

                // Create task which give all repos of user
                Task<string> task = GitHubAgent.GetDataFromURLAsync(user.RepositoryURL);

                GitHubAgent.LoadingWaiter(LoaderTypes.Repository, task);

                // Get all repos in JSON format 
                string allReposInJSON = task.Result;

                // Get repository list which contains Repository type classes
                List<Repository> repoList = JsonConvert.DeserializeObject<List<Repository>>(allReposInJSON);

                Console.WriteLine($"{username} repositories are ready. Click Enter to show, or Q to exit:");

                if (Console.ReadKey().Key != ConsoleKey.Q)
                {
                    //Print repo names
                    Parallel.ForEach(repoList, repo =>
                    {
                        Console.WriteLine(repo.Name);
                    }
                    );

                    ///////// GET USER'S ALL FOLLOWERS
                    Console.WriteLine("Press Enter to see followers names.");
                    // Create another task taskForFollowers
                    Task<string> taskForFollowers = new Task<string>(GitHubAgent.GetDataFromURL, user.FollowersURL);

                    // Run the task taskForFollowers
                    taskForFollowers.Start();

                    GitHubAgent.LoadingWaiter(LoaderTypes.FollowerURL, taskForFollowers);

                    Console.WriteLine("Follower URLs are ready. Starting loading.");

                    // Get taskForFollowers task's result in string (which is the api of followers)
                    string followerTaskResult = taskForFollowers.Result;

                    Task<List<User>> followerTask = GitHubAgent.GetFollowerListAsync(followerTaskResult);

                    GitHubAgent.LoadingWaiter(LoaderTypes.Followers, followerTask);

                    foreach (var fol in followerTask.Result)
                    {
                        Console.WriteLine(fol.ToString());
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}
