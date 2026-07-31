// Given strings formatted as "Name:Score", build a list of Student objects.
// Filter students with Score >= minScore, sort by Score descending then Name ascending,
// and serialize the result to a JSON array using System.Text.Json.

// Use a C# record for Student.

// Input: items (string[]), minScore (int)
// Output: json (string)
class Program
{
    public record Student(string Name, int Score);

    public static string FilterAndSerializeStudents(string[] items, int minScore)
    {
        var students = items
            .Select(item => item.Split(':'))
            .Select(parts => new Student(parts[0], int.Parse(parts[1])))
            .Where(student => student.Score >= minScore)
            .OrderByDescending(student => student.Score)
            .ThenBy(student => student.Name)
            .ToList();

        return System.Text.Json.JsonSerializer.Serialize(students);
    }

    public static void Main(string[] args)
    {
        string[] items = { "Ram:60", "", "Champ:75", "Dad:90" };
        int minScore = 80;
        string json = FilterAndSerializeStudents(items, minScore);
        Console.WriteLine(json);
    }
}

