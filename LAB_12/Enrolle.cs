using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    class Enrolle : IComparable<Enrolle>
    {
        private static int counter = 0;

        public string name { get; set; }
        private readonly int age;
        private int ctPoints;
        public int[] marks;

        public int Age
        {
            get { return age; }
        }

        public int CTPoints
        {
            get { return ctPoints; }
            set { ctPoints = value; }
        }


        public Enrolle()
        {
            name = "unknown";
            age = -1;
            ctPoints = -1;
            counter++;
        }

        public Enrolle(string name, int age, int ctPoints, int[] marks)
        {
            this.name = name;
            this.age = age;
            this.ctPoints = ctPoints;
            this.marks = new int[marks.Length];
            for (var i = 0; i < marks.Length; i++)
                this.marks[i] = marks[i];
            counter++;
        }

        public Enrolle(Enrolle existingEnrolle)
        {
            this.name = existingEnrolle.name;
            this.age = existingEnrolle.age;
            this.ctPoints = existingEnrolle.ctPoints;
            counter++;
        }


        public static void DisplayCounter()
        {
            Console.WriteLine($"Created {counter} Enrolle object(-s)");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Enrolle enrolle = obj as Enrolle;
            if (enrolle == null)
                return false;

            return enrolle.name == this.name && enrolle.age == this.age && enrolle.ctPoints == this.ctPoints;
        }

        public override int GetHashCode()
        {
            return this.age.GetHashCode() + this.ctPoints.GetHashCode();
        }

        public override string ToString()
        {
            string mark = "";
            foreach (var item in marks)
                mark += (item.ToString() + " ");
            return $"Name: {name}, Age: {age}, CTpoints: {ctPoints}, Marks: {mark}";
        }

        public int CompareTo(Enrolle obj)
        {
            return this.CTPoints - obj.CTPoints;
        }

        public void SayHello(string Name1, string Name2)
        {
            Console.WriteLine($"Hello {Name1} and {Name2}!!!");
        }
    }
}
