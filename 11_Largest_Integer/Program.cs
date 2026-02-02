// Write a method that returns the largest of three integers using conditional logic.

// Input: a (int), b (int), c (int)
// Output: largest (int)

// Constraints:
// -1e9 <= a,b,c <= 1e9
using System;

class Program
{
    public static void Main()
    {
        System.Console.WriteLine("enter three numb one  by one");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        if(a>b && a>c)System.Console.WriteLine(a);
        else if(b>a && b>c) System.Console.WriteLine(b);
        else System.Console.WriteLine(c);
        
    }
}