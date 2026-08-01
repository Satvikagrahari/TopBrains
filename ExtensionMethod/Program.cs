// Implement a custom DistinctBy extension method (do NOT use LINQ's DistinctBy).
// Input items are strings formatted as "id:name".
// Return the names for the first occurrence of each distinct id (preserve input order).

// Input: items (string[])
// Output: distinctNames (string[])

// Constraints:
// 0 <= items.Length <= 2*10^5
class Program
{
    public static string[] DistinctBy(string[] items)
    {
        HashSet<string> seenIds = new HashSet<string>();
        List<string> distinctNames = new List<string>();

        foreach (string item in items)
        {
            string[] parts = item.Split(':');
            string id = parts[0];
            string name = parts[1];

            if (!seenIds.Contains(id))
            {
                seenIds.Add(id);
                distinctNames.Add(name);
            }
        }

        return distinctNames.ToArray();
    }

    public static void Main()
    {
        string[] items = { "1:Alice", "2:Bob", "1:Charlie", "3:David", "2:Eve" };

        string[] result = DistinctBy(items);

        Console.WriteLine(string.Join(", ", result));
    }
}