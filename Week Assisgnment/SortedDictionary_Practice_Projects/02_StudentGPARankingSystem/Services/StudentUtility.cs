using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class StudentUtility
    {
        private SortedDictionary<double, List<Student>> _data
            = new SortedDictionary<double, List<Student>>(Comparer<double>.Create((x,y) => y.CompareTo(x)));

        public void AddStudent(Student student)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if(student.GPA<0 || student.GPA > 10)
            {
                throw new InvalidGPAException("GPA must be 0-10");
            }
            foreach (var key in _data.Keys)
            {
                var list = _data[key];
                foreach (var s in list)
                {
                    if(s.Id == student.Id)
                    {
                        throw new DuplicateStudentException("Duplicate Student");
                    }
                }
            }

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
            if(GPA<0 || GPA > 10)
            {
                throw new InvalidGPAException("GPA must be 0-10");
            }

            
            foreach (var key in _data.Keys)
            {
                var list = _data[key];
                foreach (var value in list)
                {
                    if(value.Id == id)
                    {
                        list.Remove(value);
                    }
                    if (list.Count == 0)
                    {
                        _data.Remove(key);
                    }  
                    value.GPA = GPA;
                    AddStudent(value);  
                    return;            
                }                
            }
            throw new StudentNotFoundException("Student not found");

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
