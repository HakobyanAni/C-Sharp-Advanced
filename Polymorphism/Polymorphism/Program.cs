using System;

namespace Polymorphism
{
    public class BaseClass
    {
        // Pattern NVI (Non- Virtual Interface)
        public void Do()
        {
            PreDoSmth();
            DoSomething();
        }

        protected void PreDoSmth()
        {
            Console.WriteLine("Method of BaseClass");
        }

        protected virtual void DoSomething()
        {
            Console.WriteLine("Virtual method of BaseClass");
        }

        public virtual void SomethingWitNew()
        {
            Console.WriteLine("5 - BaseClass");
        }
    }

    public class DerivedClass : BaseClass
    {
        protected override void DoSomething()
        {
            Console.WriteLine("Overrided method of DerivedClass");
        }

        public new void SomethingWitNew() // Killing Polymorphism
        {
            Console.WriteLine("5 - DerrivedClass");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Type: BaseClass, instance of DerivedClass
            BaseClass instance = new DerivedClass();
            instance.Do();
            instance.SomethingWitNew();
            Console.WriteLine(" ");

            // Type: DerivedClass, instance of DerivedClass
            DerivedClass derivedClass = new DerivedClass();
            derivedClass.Do();
            derivedClass.SomethingWitNew();
            Console.WriteLine(" ");

            // Type: BaseClass, instance of BaseClass
            BaseClass baseClass = new BaseClass();
            baseClass.Do();
            baseClass.SomethingWitNew();

            Console.ReadKey();
        }
    }
}
