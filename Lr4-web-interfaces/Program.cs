using System.Reflection;

namespace Lr4
{
    // 1. Створення класу Student з мінімум 5 полями та 3 методами
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int Age;
        protected double GPA;
        internal string Specialization;

        // Конструктор
        public Student(string firstName, string lastName, int age, double gpa, string specialization)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            GPA = gpa;
            Specialization = specialization;
        }

        public int GetAge() => Age;

        public void SetGPA(double newGPA)
        {
            GPA = newGPA;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Student: {FirstName} {LastName}, Age: {Age}, GPA: {GPA:F2}, Specialization: {Specialization}");
        }
    }

    class Program
    {
        static void Main()
        {
            Student student = new Student("Alice", "Johnson", 20, 87.5, "Computer Science");

            // 2. Робота з Type та TypeInfo
            Type type = typeof(Student);
            TypeInfo typeInfo = type.GetTypeInfo();

            Console.WriteLine("Type and TypeInfo:");
            Console.WriteLine($"Class Name: {type.Name}");
            Console.WriteLine($"Namespace: {type.Namespace}");
            Console.WriteLine($"Is Class: {typeInfo.IsClass}\n");

            // 3. Робота з MemberInfo
            Console.WriteLine("MemberInfo:");
            MemberInfo[] members = type.GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine($"{member.MemberType}: {member.Name}");
            }
            Console.WriteLine();

            // 4. Робота з FieldInfo
            Console.WriteLine("FieldInfo:");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                Console.WriteLine($"Field Name: {field.Name}, Field Type: {field.FieldType}");
            }
            Console.WriteLine();

            // 5. Робота з MethodInfo. Виклик методу через рефлексію
            Console.WriteLine("MethodInfo:");
            MethodInfo printInfoMethod = type.GetMethod("PrintInfo");
            printInfoMethod.Invoke(student, null); // Виклик методу через рефлексію

            Console.WriteLine();

            // Виклик SetGPA через рефлексію та повторний виклик PrintInfo
            MethodInfo setGpaMethod = type.GetMethod("SetGPA");
            setGpaMethod.Invoke(student, new object[] { 91 });
            printInfoMethod.Invoke(student, null); // Повторний виклик методу через рефлексію
        }
    }
}
