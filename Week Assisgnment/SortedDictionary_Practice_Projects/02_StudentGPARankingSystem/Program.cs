using System;
using Services;
using Domain;
using System.ComponentModel;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentUtility utility = new StudentUtility();
            

            while (true)
            {
                Console.WriteLine("1. Display Ranking");
                Console.WriteLine("2. Update GPA");
                Console.WriteLine("3. AddStudent");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO


                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        utility.DisplayRanking();                     
                        break;

                    case 2:
                        System.Console.WriteLine("enter gpa");
                        double gpa = double.Parse(Console.ReadLine());
                        System.Console.WriteLine("enter student id");
                        string id = Console.ReadLine();
                        utility.UpdateGPA(id,gpa);
                        break;                       
                        
                    case 3:
                        System.Console.WriteLine("enter studentid name GPA (space seprated)");
                        string[] input = Console.ReadLine().Split(' ');
                        Student student = new Student
                        {
                            Id = input[0],
                            Name = input[1],
                            GPA = double.Parse(input[2])
                        };
                        utility.AddStudent(student);
                        break;
                    case 4:

                        Console.WriteLine("Thank You");
                        return;
    
                        
                    default:
                        // TODO: Handle invalid choice
                        System.Console.WriteLine("invalid choice");
                        break;
                }
            }
        }
    }
}
