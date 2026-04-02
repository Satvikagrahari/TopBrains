using System;
class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Marks { get; set; }

    public int CompareTo(Student other)
    {
        if(this.Marks==other.Marks){
            return this.Age.CompareTo(other.Age);
        }
        return other.Marks.CompareTo(this.Marks);
    }
}
class Program
{
    public static void Main()
    {

        List<Student> student = new List<Student>();
        System.Console.WriteLine("Enter number of students: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            System.Console.WriteLine("enter valid number");
        }
        System.Console.WriteLine("Input name, age, marks for student: ");

        for (int i = 0; i < n; i++)
        {
            Student s = new Student();
            System.Console.WriteLine("name:");
            s.Name = Console.ReadLine();
            System.Console.WriteLine("age:");
            s.Age=int.Parse(Console.ReadLine());
            System.Console.WriteLine("marks:");
            s.Marks = decimal.Parse(Console.ReadLine());
            student.Add(s);
        }
        student.Sort();
        foreach (Student s in student)
        {
            System.Console.WriteLine($"{s.Name} {s.Age} {s.Marks}");
        }


    }
}
