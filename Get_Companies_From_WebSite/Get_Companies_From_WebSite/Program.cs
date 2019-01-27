using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Get_Companies_From_WebSite
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            string className2 = "//div[@class=\"company-action company_inner_right\"]";

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(className2);
            List<string> compURLList = new List<string>();
            foreach (HtmlNode node in nodes)
            {
                string href = node.InnerHtml;
                var splited = href.Split(' ')[1];
                var urlcomp = splited.Substring(6, splited.Length - 7);
                compURLList.Add(@"https://staff.am" + urlcomp);
            }

            string l = compURLList[0];

            HtmlDocument htmlDoc = web.Load(l);
            string companyProperties = "//p[@class=\"professional-skills-description\"]";
            HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

            Company company_1 = new Company(htmlNodes[0].InnerText, htmlNodes[1].InnerText, htmlNodes[2].InnerText, htmlNodes[3].InnerText, htmlNodes[4].InnerText, htmlNodes[5].InnerText);

            string companyName = "//h1[@class=\"text-left\"]";
            HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);

            foreach (var name in htmlNodeOfName)
            {
                company_1.Name = name.InnerText;
            }

            company_1.DescribeYourself();



            Console.ReadKey();
        }
    }
}
