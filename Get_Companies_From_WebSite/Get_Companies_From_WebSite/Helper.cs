using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Get_Companies_From_WebSite
{
    public static class Helper
    {
        public static string ScrollToEndAndGetSource(string url)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"C:\Users\ganih\Downloads\Get_Companies_From_WebSite\Get_Companies_From_WebSite\bin\Debug";
            ChromeDriver chromeDriver = new ChromeDriver(directory, chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);

            long scrollHeight = 0;
           
            do
            {
                IJavaScriptExecutor js = chromeDriver;
                long newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

                if (newScrollHeight == scrollHeight)
                {
                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(2000);
                }
            } while (true);

            return chromeDriver.PageSource;
        }

        // ---------->   Need to correct bugs   <--------- 

        //public static List<ActiveJobs> SearchActiveJobForCompany(HtmlDocument doc)
        //{
        //    string pathForNames = "//div[@class=\"job-inner job-item-title\"]";
        //    string pathForData = "//div[@class='job-inner job-list-deadline']";
        //    string pathForLoacation = "//div[@class='job-inner job-location']";

        //    HtmlNodeCollection jobItemTitle = doc.DocumentNode.SelectNodes(pathForNames);
        //    HtmlNodeCollection jobԼistDeadline = doc.DocumentNode.SelectNodes(pathForData);
        //    HtmlNodeCollection jobLocation = doc.DocumentNode.SelectNodes(pathForLoacation);

        //    List<ActiveJobs> allActiveJobs = new List<ActiveJobs>();

        //if(jobItemTitle != null && )
        //{
        //    for (int i = 0; i < jobItemTitle.Count; i++) 
        //    {
        //        var location = jobLocation[i].InnerText.Replace(" ", "").Replace("\n", "");
        //        var names = (jobItemTitle[i].InnerText.Replace(" ", "").Split('\n')
        //        .Select(item => item.Replace("\r", ""))).ToArray();

        //        var data = jobԼistDeadline[i].InnerText.Replace(" ", "").Split('\n')
        //                    .Select(item => item.Replace("\r", ""))
        //                    .Where(item => !string.IsNullOrEmpty(item)).ToArray();
        //        allActiveJobs.Add(new ActiveJobs { JobName = names[1], CompanyName = names[2], Data = string.Join(" ", data), Location = location });
        //    }
        //}

        //    return allActiveJobs;
        //}

        public static List<Company> ScrapForStaffAM(object data)
        {
            DataModel dataTemp = data as DataModel;

            string urll = (string)dataTemp.Url;
            HtmlWeb web = new HtmlWeb();

            dataTemp.Status = "Scrolling .....";
            string content = ScrollToEndAndGetSource(urll);
            dataTemp.flag = false;
            dataTemp.Status = "Gathering Info of Companies....";
            Thread.Sleep(350); 
            dataTemp.flag = true;

            Console.WriteLine();

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
            int count = nodes.Count;
            int currentCompanyNumber = 0;
            try
            {
                foreach (var compURL in compURLList)
                {
                    currentCompanyNumber++;
                    dataTemp.Status = $"Remaining {(currentCompanyNumber*100)/count} % ....";
                    HtmlDocument htmlDoc = web.Load(compURL);
                    string companyProperties = "//p[@class=\"professional-skills-description\"]";
                    HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties); // All the property values in a collection 
                    Company company = new Company();
                  ////  company.Jobs = SearchActiveJobForCompany(htmlDoc);

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
                            if (int.TryParse(node.InnerText, out int x))
                            {
                                company.NumbOfEmployees = x;
                            }
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
                throw e;
            }
            return allCompanies;
        }

        public static async Task<List<Company>> ScrapForStaffAMAsync(object data) 
        {
            return await Task<List<Company>>.Factory.StartNew(ScrapForStaffAM, data);
        }
    }
}
