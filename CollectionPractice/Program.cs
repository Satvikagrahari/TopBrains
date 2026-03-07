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


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

public class Program
{
    class Student
    {
        public string Name { get; set; }
        public List<int> Marks { get; set; }

        public Student(string name, List<int> marks)
        {
            Name = name;
            Marks = marks;
        }
    }

    class Manager
    {
        public void RegisterStudent(List<Student> students, Student s)
        {
            if (!students.Contains(s.Name))
            {
                if(s.Marks<0) throw new InvalidMarksException("Marks is less than 0");
                students.Add(s);
            }
        }

        public Dictionary<string, int> GetTopStudents(List<Student> students, int threshold)
        {
            var s = students.Where(x => x.Marks.Max()>threshold).ToDictionary(x => x.Name, x => x.Marks);
            if (s==null)
            {
                throw new NoStudentFoundException("No Student found");
            
            return s;
            
        }

        public Dictionary<string, double> CalculateAverageMarks(List<Student> students)
        {

        }
    }

    public static void Main()
    {

    }
}