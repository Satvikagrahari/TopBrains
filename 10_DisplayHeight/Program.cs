// Given a person's height in centimeters, return the height category:
// - "Short"  : height < 150
// - "Average": 150 <= height < 180
// - "Tall"   : height >= 180

// Input: heightCm (int)
// Output: category (string)

// Constraints:
// 0 <= heightCm <= 300
using System;

class Program
{
    public static void Main()
    {
        System.Console.Write("enter height in cm = ");
        int cm = int.Parse(Console.ReadLine());
        if (cm < 150)
        {
            System.Console.WriteLine("Short");
        } 
        else if(cm>=150 && cm < 180)
        {
            System.Console.WriteLine("Average");
        }
        else if (cm >= 180)
        {
            System.Console.WriteLine("Tall");
        }
        else
        {
            System.Console.WriteLine("Out of range ");
        }
        
    }
}