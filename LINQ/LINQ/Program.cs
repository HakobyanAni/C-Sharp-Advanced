using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
    }

    public class Nationality
    {
        public int ID { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var peopleList = new List<Person>  // Creating peopleList adding anonymous persons
            {
                new Person{FirstName = "Kasper", LastName = "Stucki", ID = 1111},
                new Person{FirstName = "John", LastName = "Watson", ID = 222},
                new Person{FirstName = "Hakob", LastName = "Hovhannisyan", ID = 3333},
                new Person{FirstName = "Elena", LastName = "Forbes", ID = 4444},
            };

            var nationalitylist = new List<Nationality> //  Creating nationalitylist adding anonymous nationalities 
            {
                new Nationality{ID = 1111, Country = "Switzerland"},
                new Nationality{ID = 2222, Country = "United Kingdom"},
                new Nationality{ID = 3333, Country = "Armenia"},
            };

            var query = from person in peopleList  // Creating diapason from the list peopleList
                        join nation in nationalitylist  // List nationalitylist joins with the list peopleList  
                        on person.ID equals nation.ID // Equation of ID fields (for both lists)
                        orderby nation.Country // Sorting
                        select new
                        {
                            ID = person.ID,
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            Nationality = nation.Country
                        };

            foreach (var person in query)
            {
                Console.WriteLine($" {person.FirstName} {person.LastName} is from {person.Nationality}");
            }
        }
    }
}
