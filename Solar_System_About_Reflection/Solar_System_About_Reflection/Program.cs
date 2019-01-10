using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void ListOfMethods(Type type)
        {
            MethodInfo[] methodInfos = type.GetMethods(System.Reflection.BindingFlags.Instance
                     | BindingFlags.Static
                     | BindingFlags.Public
                     | BindingFlags.NonPublic
                     | BindingFlags.DeclaredOnly); // Getting all information about methods of the class SolarSystem

            Console.WriteLine("--> Methods and their types ");
            foreach (MethodInfo method in methodInfos)
            {
                Console.WriteLine($"{method.Name} - {method.ReturnType}");
            }
        }

        static void ListOfFields(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(System.Reflection.BindingFlags.Instance
                                    | BindingFlags.Static
                                    | BindingFlags.Public
                                    | BindingFlags.NonPublic);  // Getting all information about fields of the class SolarSystem

            Console.WriteLine("-> Field Names And Types");
            foreach (FieldInfo field in fieldInfos)
            {
                Console.WriteLine($"              { field.Name} - {field.FieldType}");
            }
        }

        static void ListOfConstructors(Type type)
        {
            ConstructorInfo[] constructorInfos = type.GetConstructors(System.Reflection.BindingFlags.Instance
                                                | BindingFlags.Static
                                                | BindingFlags.Public
                                                | BindingFlags.NonPublic); // Getting all information about constructors of the class SolarSystem

            Console.WriteLine("-> Constructors");
            Console.WriteLine("IsPrivate     IsStatic     IsPublic");
            foreach (ConstructorInfo constructor in constructorInfos)
            {
                Console.WriteLine($"    {constructor.IsPrivate}   -   {constructor.IsStatic}   -   {constructor.IsPublic}");
            }
        }

        static void Main(string[] args)
        {
            SolarSystem solarSystem = new SolarSystem();  // Creating an instance of the class SolarSystem

            Type type = solarSystem.GetType();  // Getting the type of class SolarSystem
                                                // or
                                                // Type type = typeof(SolarSystem);

            ListOfMethods(type);
            Console.WriteLine("------------------------------------------------------------");

            ListOfFields(type);
            Console.WriteLine("------------------------------------------------------------");

            ListOfConstructors(type);
            Console.WriteLine("------------------------------------------------------------");

            Console.ReadKey();
        }
    }
}
