using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Companies_From_WebSite
{
    public static class Helper
    {
        public static string ToScroll(string url)
        {

            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--disable-images");

            string directory = @"C:\Users\ganih\source\repos\Homework_Advanced_C_Sharp\Homework1_JSON\bin\Debug";
            ChromeDriver chromeDriver = new ChromeDriver(directory, co);
            chromeDriver.Navigate().GoToUrl(url);
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");

                }
                catch (Exception e)
                {
                }
                Thread.Sleep(1500);
            }
            return chromeDriver.PageSource;
        }

        public static void SearchActiveJob(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string job = "//div[@class=\"job-inner job-item-title\"]";

            string job2 = "//div[@class='job-inner job-list-deadline']";
            HtmlNodeCollection jobItemTitle = doc.DocumentNode.SelectNodes(job);
            HtmlNodeCollection jobԼistDeadline = doc.DocumentNode.SelectNodes(job2);
            List<ActiveJobs> activeJobs = new List<ActiveJobs>();
            for (int i = 0; i < jobItemTitle.Count; i++)
            {
                string[] splitText = jobItemTitle[i].InnerText.Split('\n');
                string[] splitText2 = jobԼistDeadline[i].InnerText.Split('\n');
                string temp = splitText2[3] + splitText2[4] + splitText2[5];
                activeJobs.Add(new ActiveJobs { JobName = splitText[1], CompanyName = splitText[2], Data = temp });
            }

            foreach (var item in activeJobs)
            {
                Console.WriteLine($"Company:{item.CompanyName},Data:{item.Data},Job:{item.JobName}");
            }
            Console.ReadLine();
        }

        public static List<Company> ScrapForStaffAM(string url)
        {
            HtmlWeb web = new HtmlWeb();
            string content = ToScroll(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            string className = "//div[@class=\"company-action company_inner_right\"]";

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(className);
            List<string> compURLList = new List<string>();  // Create company url list
            int fail = 0;
            foreach (HtmlNode node in nodes)
            {
                try
                {
                    string href = node.InnerHtml;
                    var splited = href.Split('"')[1];
                    compURLList.Add(@"https://staff.am" + splited); // Fill the company url list

                }
                catch (Exception)
                {
                    fail++;
                }
            }

            List<Company> allCompanies = new List<Company>(); // Create company list which will include all companies whith their info
            try
            {
                foreach (var compURL in compURLList)
                {
                    HtmlDocument htmlDoc = web.Load(compURL);
                    string companyProperties = "//p[@class=\"professional-skills-description\"]";
                    HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties); // All the property values in a collection 
                    Company company = new Company();

                    foreach (var node in htmlNodes)
                    {
                        string inner = node.InnerText;
                        if (inner.ToLower().Contains("industry"))
                        {
                            company.Industry = node.InnerText;
                        }
                        else if (inner.ToLower().Contains("type"))
                        {
                            company.Type = node.InnerText;

                        }
                        else if (inner.ToLower().Contains("number of employees"))
                        {
                            company.NumbOfEmployees = node.InnerText;

                        }
                        else if (inner.ToLower().Contains("data of foundation"))
                        {
                            company.DataOfFoundation = node.InnerText;
                        }
                        else if (inner.ToLower().Contains("website"))
                        {
                            company.WebSite = node.InnerText;
                        }
                        else if (inner.ToLower().Contains("address"))
                        {
                            company.Adress = node.InnerText;
                        }
                    }

                    string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
                    HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
                    if (htmlNodesAboutComp != null && htmlNodesAboutComp.Count > 0)
                    {
                        string text = htmlNodesAboutComp[0].InnerText.Replace("\n", "");
                        company.AboutCompany = text; // Find text about company
                    }

                    string companyName = "//h1[@class=\"text-left\"]";
                    HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);
                    if (htmlNodesAboutComp != null && htmlNodeOfName.Count > 0)
                    {
                        company.Name = htmlNodeOfName[0].InnerText; // Find company name
                    }

                    allCompanies.Add(company);  // Add company to the list
                }
            }
            catch (Exception e)
            {
                Program.WriteExceptionInFile(e.Message);
            }
            return allCompanies;
        }
    }

}
