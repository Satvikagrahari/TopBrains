using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class StudentUtility
    {
        private SortedDictionary<double, List<Student>> _data
            = new SortedDictionary<double, List<Student>>();

        public void AddStudent(Student student)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary

            if (_data.ContainsKey(student.GPA))
            {
                _data[student.GPA].Add(student);
            }
            else
            {
                _data[student.GPA] = new List<Student>{student};
            }
        }

        public void UpdateGPA(string id, double GPA)
        {
            // TODO: Update entity logic
            foreach (var value in _data.Values)
            {
                foreach (var Student in value)
                {
                    if(Student.Id == id)
                    {
                        Student.GPA = GPA;
                        // Student = GPA;
                        return;
                    }
                }
            }

        }

        public void DisplayRanking()
        {
            foreach (var value in _data.Values)
            {
                foreach (var Student in value)
                {
                    System.Console.WriteLine($"Details: {Student.Id} {Student.Name} {Student.GPA}");
                }
                System.Console.WriteLine();
            }
        }

        
    }
}
