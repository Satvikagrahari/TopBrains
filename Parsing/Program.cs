
// Given an array of strings, sum only the values that can be parsed as 32-bit integers.
// Use int.TryParse (ignore invalid and overflow values).

// Input: tokens (string[])
// Output: sum (int)

// Constraints:
// 0 <= tokens.Length <= 1e5

class Program
{
    public static int SumValidIntegers(string[] tokens)
    {
        int sum = 0;

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int value))
            {
                sum += value;
            }
        }

        return sum;
    }

    public static void Main()
    {
        string[] tokens = { "10", "20", "abc", "30", "2147483648", "-5" };

        Console.WriteLine(SumValidIntegers(tokens));
    }
}