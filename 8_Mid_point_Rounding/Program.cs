
// Write a method that returns the area of a circle for a given radius.
// Round the result to 2 decimal places (MidpointRounding.AwayFromZero).

// Input: radius (double)
// Output: area (double)

// Constraints:
// 0 <= radius <= 1e6

using System;

class Program
{
    public static void Main()
    {
        System.Console.Write("Enter Radius = ");
        double r;
        while (!double.TryParse(Console.ReadLine(), out r) && r<=0)
        {
            System.Console.WriteLine("Enter valid number");
        } 
        double area = Math.Round(r*r*3.14,2,MidpointRounding.AwayFromZero);
        System.Console.WriteLine("Area = "+area);       
    }
}