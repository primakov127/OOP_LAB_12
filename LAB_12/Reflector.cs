using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace LAB_12
{
    static class Reflector
    {
        public static void GetClassInfoInFile(string className)
        {
            Type myType = Type.GetType(className);
            using (StreamWriter sw = new StreamWriter(@"..\..\LAB_12.txt", false, System.Text.Encoding.Default))
            {
                foreach (MemberInfo mi in myType.GetMembers())
                {
                    sw.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
                }
            }
        }

        public static void DisplayPublicMethods(string className)
        {
            Type myType = Type.GetType(className);
            MethodInfo[] methods = myType.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.Write($"public {method.ReturnType.Name} {method.Name} (");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        public static void DisplayFielAndProperties(string className)
        {
            Type myType = Type.GetType(className);

            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
        }

        public static void DisplayRealizedInterfaces(string className)
        {
            Type myType = Type.GetType(className);

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }

        public static void DisplayMethodsWithParameter(string className, Type parm)
        {
            Type myType = Type.GetType(className);
            foreach(MethodInfo method in myType.GetMethods())
            {
                foreach(ParameterInfo param in method.GetParameters())
                    if (param.ParameterType == parm)
                    {
                        Console.Write($"{method.ReturnType.Name} {method.Name} (");
                        ParameterInfo[] parameters = method.GetParameters();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                            if (i + 1 < parameters.Length) Console.Write(", ");
                        }
                        Console.WriteLine(")");
                    }
                        
            }
        }

        public static void CallMethod(string ClassName, string MethodName)
        {
            

            Assembly asm = Assembly.LoadFrom(ClassName);
            Type t = asm.GetType("LAB_12.Enrolle");

            object obj = Activator.CreateInstance(t);

            MethodInfo method = t.GetMethod(MethodName);

            string[] parm;
            // Чтение параметров из файла
            using (FileStream fstream = File.OpenRead(@"..\..\note.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                char[] separators = { ' '};
                parm = textFromFile.Split(separators);
            }
            

            

            method.Invoke(obj, new object[] {parm[0], parm[1] });
        }
    }
}
