// Write a method that converts feet to centimeters.
// Use: 1 foot = 30.48 cm
// Round the result to 2 decimal places (MidpointRounding.AwayFromZero).

// Input: feet (int)
// Output: centimeters (double)

// Constraints:
// 0 <= feet <= 1e6

using System;

class Program
{
    public static void Main()
    {
        System.Console.Write("enter feet to convert into cm : ");
        int foot = int.Parse(Console.ReadLine());
        double cm = Math.Round(foot * 30.48, 2, MidpointRounding.AwayFromZero);
        System.Console.WriteLine($"cm : {cm}");   
    }
}