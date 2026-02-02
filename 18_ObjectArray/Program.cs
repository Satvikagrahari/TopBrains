// Given an object array that may contain ints, strings, bools, nulls, etc., sum only the integer values.
// Use pattern matching (is int x).

// Input: values (object[])
// Output: sum (int)

// Constraints:
// 0 <= values.Length <= 1e5


using System;
using System.Reflection.Metadata;

class Program
{
    public static int SumIntegers(object[] values)
{
    int sum = 0;

    foreach (object item in values)
    {
        if (item is int x)
        {
            sum += x;
        }
    }

    return sum;
}
        public static void Main()
    {
        object[] values = { 10, "abc", true, null, 20, 5.5, 30 };
        Console.WriteLine(SumIntegers(values));


    }
}