// Return the multiplication table row for a number n from 1..upto.
// Example: n=3, upto=5 -> [3,6,9,12,15]

// Input: n (int), upto (int)
// Output: row (int[])

class Program
{
    public static int[] GetMultiplicationTableRow(int n, int upto) 
{
    int[] row = new int[upto];
    for (int i = 1; i <= upto; i++)
    {
        row[i - 1] = n * i;
    }
    return row;
}
    public static void Main(string[] args)
    {
        int n = 3;
        int upto = 5;
        int[] row = GetMultiplicationTableRow(n, upto);
        Console.WriteLine(string.Join(", ", row)); 
    }
}