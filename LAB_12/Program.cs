using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LAB_12
{
    class Program
    {
        static void Main(string[] args)
        {
            var UserClassName = "LAB_12.Enrolle";

            Type myType = Type.GetType(UserClassName);
            
            //foreach (MemberInfo mi in myType.GetMembers())
            //{
            //    Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
            //}


            //Reflector.GetClassInfoInFile("LAB_12.Enrolle");
            //Reflector.DisplayPublicMethods(UserClassName);
            //Reflector.DisplayFielAndProperties(UserClassName);
            //Reflector.DisplayRealizedInterfaces(UserClassName);
            Reflector.DisplayMethodsWithParameter(UserClassName, typeof(object));
            Reflector.CallMethod("LAB_12.exe", "SayHello");
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public User(string n, int a)
            {
                Name = n;
                Age = a;
            }
            public void Display()
            {
                Console.WriteLine($"Имя: {Name}  Возраст: {Age}");
            }
            public int Payment(int hours, int perhour)
            {
                return hours * perhour;
            }
        }
    }
}
