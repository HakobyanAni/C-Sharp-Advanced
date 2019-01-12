using Newtonsoft.Json; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MinistryOfCulture minCulture = new MinistryOfCulture()
                {
                    Name = "Ministry of Culture",
                    Adress = "Yerevan, Vazgen Sargsyan 3",
                    PhoneNumber = "011523939",
                    Email = "mincult.am",
                    MuseumsCount = 5000,
                    StaffCount = 600,
                    Departments = new List<Department>()
                {
                    new Department("HR", 5),
                    new Department("Orders", 4)
                }
                };

                MinistryOfFinance minFinance = new MinistryOfFinance(21, "Ministry of Finance", "Yerevan, Melik Adamyan 1", "minfin.am", "011800156", 1800);
                minFinance.Departments.Add(new Department("HR", 15));
                minFinance.Departments.Add(new Department("Business", 11));
                minFinance.Departments.Add(new Department("Statistic", 10));

                // OR
                //minFinance.Departments = new List<Department> 
                //    {
                //        new Department("Business", 15),
                //        new Department("Statistics", 10)
                //    };


                // Serializing objects and writing them in file
                string minCultureToJSON = JsonConvert.SerializeObject(minCulture, Formatting.Indented);
                File.WriteAllText(@"C:\Users\ganih\source\repos\Homework_Advanced_C_Sharp\Attribute\minCultureToJSON.txt", minCultureToJSON);

                string minFinanceToJSON = JsonConvert.SerializeObject(minFinance, Formatting.Indented);
                File.WriteAllText(@"C:\Users\ganih\source\repos\Homework_Advanced_C_Sharp\Attribute\minFinanceToJSON.txt", minFinanceToJSON);

                // Deserializing objects
                string objectCultStringFromFile = File.ReadAllText(@"C:\Users\ganih\source\repos\Homework_Advanced_C_Sharp\Attribute\minCultureOtherJSON.txt");
                MinistryOfCulture deserializedFromFileM = JsonConvert.DeserializeObject<MinistryOfCulture>(objectCultStringFromFile);

                string objectFinStringFromFile = File.ReadAllText(@"C:\Users\ganih\source\repos\Homework_Advanced_C_Sharp\Attribute\minFinanceToJSON.txt");
                MinistryOfFinance deserializedFromFileF = JsonConvert.DeserializeObject<MinistryOfFinance>(objectFinStringFromFile);

                Console.WriteLine(deserializedFromFileM.MuseumsCount);
                Console.WriteLine(deserializedFromFileF.BanksCount);
            }

            catch (DirectoryNotFoundException exc) // Object - Exception - SystemException - IOException - DirectoryNotFoundException
            {
                Console.WriteLine($"Folder is not found. - {exc.Message}, Method - {new StackTrace(exc).GetFrame(0).GetMethod().Name}");
            }

            catch (FileNotFoundException ex) // Object - Exception - SystemException - IOException - FileNotFoundException
            {
                Console.WriteLine($"File is not found. - {ex.Message}, Method - {new StackTrace(ex).GetFrame(0).GetMethod().Name}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Attention ! There is a problem with   object. - {e.Message}, Method - {new StackTrace(e).GetFrame(0).GetMethod().Name}");
            }

            Console.ReadKey();
        }
    }
}
