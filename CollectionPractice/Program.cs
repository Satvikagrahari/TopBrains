// Student Marks Analyzer
// You are given a system that stores marks of students in multiple subjects.
// Each student has a name and a list of marks.

// Requirements
// Create a class Student with:

// Name : string

// Marks : List<int>

// Create a class Manager with the following methods:

// RegisterStudent(List<Student> students, Student s)

// Adds a student to the list.

// GetTopStudents(List<Student> students, int threshold)

// Return Dictionary<string, int>

// Key → student name

// Value → highest mark obtained by the student

// Include only students whose highest mark is greater than the given threshold.

// CalculateAverageMarks(List<Student> students)

// Return Dictionary<string, double>

// Key → student name

// Value → average marks of that student.

// In Main():

// Create a List<Student>

// Add at least 3 students with marks

// Print:

// Students whose highest marks are above the threshold

// Average marks of all students

// Constraints

// Use LINQ functions like
// Where()
// Max()
// Average()
// ToDictionary()

// Do not use loops inside Manager methods.

// Example Input Data

// Rahul → 70, 80, 90, 60
// Priya → 85, 95, 88, 92
// Aman → 50, 60, 55, 65

// Threshold = 90

// Expected Output

// Top Students:
// Priya - 95

// Average Marks:
// Rahul - 75
// Priya - 90
// Aman - 57.5



// using System;
// using System.Collections.Generic;
// using System.ComponentModel.Design;
// using System.Linq;
// public class InvalidMarksException : Exception
// {
//     public InvalidMarksException(string message) : base(message)
//     {

//     }
// }

// public class NoStudentFoundException : Exception
// {
//     public NoStudentFoundException(string message) : base(message)
//     {

//     }
// }
// public class Student
// {
//     public string Name { get; set; }
//     public List<int> Marks { get; set; }

//     public Student(string name, List<int> marks)
//     {
//         Name = name;
//         Marks = marks;
//     }
// }

// public class Manager
// {
//     public void RegisterStudent(List<Student> students, Student s)
//     {
//         if (students.Any(x => x.Name == s.Name))
//         {
//             return;
//         }
//         if (s.Marks.Any(x => x < 0)) throw new InvalidMarksException("Marks is less than 0");
//         students.Add(s);

//     }

//     public Dictionary<string, int> GetTopStudents(List<Student> students, int threshold)
//     {
//         var s = students.Where(x => x.Marks.Max() > threshold).ToDictionary(x => x.Name, x => x.Marks.Max());
//         if (s.Count==0)
//         {
//             throw new NoStudentFoundException("No Student found");
//         }
//         return s;

//     }

//     public Dictionary<string, double> CalculateAverageMarks(List<Student> students)
//     {
//         if (students.Count==0)
//         {
//             throw new NoStudentFoundException("No Student found");
//         }
//         var s = students.ToDictionary(x => x.Name, x => x.Marks.Average());
//         return s;
//     }
// }
// public class Program
// {
//     public static void Main()
//     {
//         try
//         {
//             List<Student> students = new List<Student>();
//             Manager manager = new Manager();
//             manager.RegisterStudent(students, new Student("Ravi", new List<int> { 70, 80, 0 }));
//             manager.RegisterStudent(students, new Student("Arun", new List<int> { 50, 100, 40 }));
//             manager.RegisterStudent(students, new Student("Jiya", new List<int> { 90, 100, 40 }));
//             var topstudent = manager.GetTopStudents(students, 80);
//             System.Console.WriteLine("topstudents: ");
//             foreach (var x in topstudent)
//             {
//                 System.Console.WriteLine(x.Key + " " + x.Value);
//             }
//             var averages = manager.CalculateAverageMarks(students);
//             Console.WriteLine("Average Marks:");
//             foreach (var item in averages)
//                 Console.WriteLine(item.Key + " " + $"{item.Value:F2}");
//         }
//         catch (InvalidMarksException ex)
//         {
//             System.Console.WriteLine(ex.Message);
//         }
//         catch (NoStudentFoundException ex)
//         {
//             System.Console.WriteLine(ex.Message);
//         }

//     }
// }


// Product Price Analyzer

// Classes

// Product

// Name : string

// Prices : List<int>

// Manager methods

// AddProduct(Product p, List<Product> products)

// GetExpensiveProducts(List<Product> products, int priceLimit)

// Return Dictionary<string,int>

// Key → product name

// Value → highest price.

// AveragePrice(List<Product> products)

// Return Dictionary<string,double>

// Key → product name

// Value → average price.

// using System;
// using System.Collections.Generic;
// using System.ComponentModel.Design;
// using System.Linq;
// public class Product
// {
//     public string Name { get; set; }
//     public List<int> Prices { get; set; }
//     public Product(string name,List<int> prices)
//     {
//         Name = name;
//         Prices = prices;
//     }
// }
// public class Manager
// {
//     public void AddProduct(Product p, List<Product> products)
//     {
//         if(products.Any(x => x.Name == p.Name))
//         {
//             return;
//         }
//         products.Add(p);
//     }
//     public Dictionary<string,int> GetExpensiveProducts(List<Product> products, int priceLimit)
//     {
//         return products.Where(x => x.Prices.Max()>priceLimit).ToDictionary(x=> x.Name, x=> x.Prices.Max()); 
//     }
//     public Dictionary<string,double> AveragePrice(List<Product> products)
//     {
//         return products.ToDictionary(x=> x.Name, x=>x.Prices.Average());
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         List<Product> products = new List<Product>();
//         Manager manager = new Manager();
//         manager.AddProduct(new Product("Laptop",new List<int>{10,30,40}),products);
//         manager.AddProduct(new Product("Mouse", new List<int>{30,40,20}),products);
//         manager.AddProduct(new Product("Keyboard",new List<int>{50,20,10}),products);

//         var exp = manager.GetExpensiveProducts(products,40);
//         foreach (var x in exp)
//         {
//             System.Console.WriteLine(x.Key+" "+x.Value);
//         }

//         var avg = manager.AveragePrice(products);
//         foreach (var x in avg)
//         {
//             System.Console.WriteLine(x.Key+" "+$"{x.Value:F2}");
//         }

//     }
// }



// Cricket Player Score Analyzer

// Classes

// Player

// Name : string

// Scores : List<int>

// Manager methods

// RegisterPlayer(Player p, List<Player> players)

// GetCenturyPlayers(List<Player> players)

// Return Dictionary<string,int>

// Include players whose highest score ≥ 100.

// AverageScore(List<Player> players)

// Return Dictionary<string,double>

// Average score per player.

using System;
using System.Runtime.ConstrainedExecution;
public class DuplicatePlayerException : Exception
{
    public DuplicatePlayerException(string message) : base(message)
    {

    }
}
public class Player
{
    public string Name { get; set; }
    public List<int> Scores { get; set; }
}
public class Manager
{
    public void RegisterPlayer(Player p, List<Player> players)
    {
        if (!players.Any(x=> x.Name==p.Name))
        {
            players.Add(p);
        }
        else
        {
            throw new DuplicatePlayerException("this player already exsisted");
        }
    }
    public Dictionary<string, int> GetCenturyPlayers(List<Player> players)
    {
        var centuryp = players.Where(s => s.Scores.Max() >= 100).ToDictionary(s => s.Name, s => s.Scores.Max());
        return centuryp;
    }

    public Dictionary<string, double> AverageScore(List<Player> players)
    {
        var avgs = players.ToDictionary(x => x.Name, x => x.Scores.Average());
        if (avgs.Count == 0)
        {
            System.Console.WriteLine("no player found");
            return new Dictionary<string, double>();
        }
        return avgs;
    }
}
class Program
{
    public static void Main()
    {
        try
        {            
        List<Player> players = new List<Player>();
        Manager manager = new Manager();

        manager.RegisterPlayer(new Player { Name = "Rohit", Scores = new List<int> { 50, 45, 100 } }, players);
        manager.RegisterPlayer(new Player { Name = "Virat", Scores = new List<int> { 40, 30, 70 } }, players);
        
        var cp = manager.GetCenturyPlayers(players);
        System.Console.WriteLine("century player");
        if (cp.Count == 0) System.Console.WriteLine("no player found");
        else
        {
            foreach (var item in cp)
            {
                System.Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        var avgs = manager.AverageScore(players);
        System.Console.WriteLine("Average Score");
        if (avgs.Count == 0) System.Console.WriteLine("no player found");

        else
        {
            foreach (var item in avgs)
            {
                System.Console.WriteLine(item.Key + " " + $"{item.Value:F2}");
            }
        }
        }
        catch (DuplicatePlayerException ex)
        {
            System.Console.WriteLine(ex.Message);
        }

    }
}