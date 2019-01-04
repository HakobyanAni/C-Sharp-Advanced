using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friends_Mood
{
    public class Friend
    {
        private string firstName;
        private string lastName;
        private int friendAge;
        public Moods Mood { get; set; }
        public Print SayHello { get; set; }

        public Friend(string firstName, string lastName, int friendAge)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.friendAge = friendAge;
            Mood = Moods.Excellent;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int FriendAge
        {
            get { return friendAge; }
            set { friendAge = value; }
        }

        public void PrintMyMood()
        {
            Console.WriteLine($"My mood is {Mood}");
        }

        public override string ToString()
        {
            return $"My name is {firstName} {lastName}. I am {friendAge} years old. My mood is {Mood}";
        }
    }
}
