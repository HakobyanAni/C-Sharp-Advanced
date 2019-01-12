using System.Collections.Generic;
using Newtonsoft.Json;

namespace Attribute
{
    public class GovernmentBuilding
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        [JsonIgnore]
        public string Email { get; set; }

        [JsonProperty("Phone Number")]
        public string PhoneNumber { get; set; }

        public static string Country { get; set; }

        [JsonProperty("Staff Count")]
        public int StaffCount { get; set; }

        public List<Department> Departments { get; set; }
        public GovernmentBuilding()
        {

        }

        public GovernmentBuilding(string name, string adress, string email, string phoneNumber, int staffCount)
        {
            Name = name;
            Adress = adress;
            Email = email;
            PhoneNumber = phoneNumber;
            StaffCount = staffCount;
            Departments = new List<Department>();
        }

        public GovernmentBuilding(string name, string adress, string email, string phoneNumber, int staffCount, List<Department> list)
            : this(name, adress, email, phoneNumber, staffCount)
        {
            Departments = list;
        }
    }

    public class MinistryOfFinance : GovernmentBuilding
    {
        [JsonProperty("Banks Count")]
        public int BanksCount { get; set; }

        public MinistryOfFinance()
        {

        }

        public MinistryOfFinance(int banksCount, string name, string adress, string email, string phoneNumber, int staffCount)
            : base(name, adress, email, phoneNumber, staffCount)
        {
            BanksCount = banksCount;
        }

        public MinistryOfFinance(int banksCount, string name, string adress, string email, string phoneNumber, int staffCount, List<Department> list)
            : base(name, adress, email, phoneNumber, staffCount, list)
        {
            BanksCount = banksCount;
        }
    }

    public class MinistryOfCulture : GovernmentBuilding
    {
        [JsonProperty("Museums Count")]
        public int MuseumsCount { get; set; }

        public MinistryOfCulture()
        {

        }

        public MinistryOfCulture(int museumsCount, string name, string adress, string email, string phoneNumber, int staffCount)
            : base(name, adress, email, phoneNumber, staffCount)
        {
            MuseumsCount = museumsCount;
        }

        public MinistryOfCulture(int museumsCount, string name, string adress, string email, string phoneNumber, int staffCount, List<Department> list)
            : base(name, adress, email, phoneNumber, staffCount, list)
        {
            MuseumsCount = museumsCount;
        }
    }
}

