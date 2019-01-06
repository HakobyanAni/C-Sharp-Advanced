using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Operloading
{
    // In C# we can overload some operators by defining static member functions using the operator keyword.

    public class Box
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Box(int length, int width, int height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public static Box operator +(Box box1, Box box2) // Overloaded operator +
        {
            return new Box(box1.Length + box2.Length, box1.Height + box2.Height, box1.Width + box2.Width);
        }

        public override string ToString() // Implementation of Object.ToString() method. 
        {
            return $"(This is a new box with sides: L = {Length}, W = {Width}, H = {Height})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(1, 1, 1);
            Box box2 = new Box(2, 2, 2);
            Box box3 = box1 + box2;

            Console.WriteLine(box3.ToString());
            Console.ReadKey();
        }
    }
}
