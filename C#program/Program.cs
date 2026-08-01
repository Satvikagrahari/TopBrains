// Mahirl and Alphabets and Vowels
// Mahirl's uncle Sam has just taught her about vowels.
// To test her understanding, he gave her the following assignment.

// He gave her two words.
// Mahirl needs to:

// Task 1: Remove Common Consonants
// Remove all consonants from the first word that also appear in the second word.

// While comparing characters, case should not be considered.
// (Example: 'A' and 'a' are considered the same.)

// Task 2: Remove Consecutive Duplicate Characters
// After deleting the common consonants:
// If there are two or more consecutive identical characters, only the first occurrence must be kept and all others deleted.

// Your job is to help Mahirl complete this assignment.

//  Input Format
// Input consists of two strings:
// The first word and the second word.

// Maximum string length: 50 characters.

// Strings contain only uppercase and lowercase English letters.

// Comparisons are case-insensitive.

//  Output Format
// Output the final processed string after applying both rules.


class Program
{
    public static string RemoveCommonConsonants(string word1, string word2)
    {
        HashSet<char> consonantsToRemove = new HashSet<char>();

        foreach (char c in word2.ToLower())
        {
            if (!IsVowel(c))
            {
                consonantsToRemove.Add(c);
            }
        }

        string result = "";
        foreach (char c in word1)
        {
            if (!consonantsToRemove.Contains(char.ToLower(c)))
            {
                result += c;
            }
        }

        return result;
    }

    public static bool IsVowel(char c)
    {
        return "aeiouAEIOU".IndexOf(c) >= 0;
    }

    public static string RemoveConsecutiveDuplicates(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        char[] result = new char[input.Length];
        int index = 0;

        result[index++] = input[0];

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                result[index++] = input[i];
            }
        }

        return new string(result, 0, index);
    }

    public static void Main()
    {
        Console.WriteLine("Enter the first word:");
        string word1 = Console.ReadLine();

        Console.WriteLine("Enter the second word:");
        string word2 = Console.ReadLine();

        string processedWord = RemoveCommonConsonants(word1, word2);
        processedWord = RemoveConsecutiveDuplicates(processedWord);

        Console.WriteLine("Processed String: " + processedWord);
    }
}