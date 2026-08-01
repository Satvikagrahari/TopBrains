// Given an integer array, sum only positive numbers until you reach 0.
// - If an element is 0, stop processing (break).
// - If an element is negative, ignore it (continue).

// Input: nums (int[])
// Output: sum (int)

using System;

class Program
{
    public static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        foreach (int num in nums)
        {
            if (num == 0)
                break;         
            if (num < 0)
                continue;       

            sum += num;         
        }

        return sum;
    }

    public static void Main()
    {
        int[] nums = { 5, -2, 8, 3, -1, 0, 10, 20 };

        Console.WriteLine(SumPositiveUntilZero(nums));
    }
}