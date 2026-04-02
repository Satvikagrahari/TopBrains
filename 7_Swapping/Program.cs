// Question
// 7
// Swapping
// Description
// Ref / Out – Swap Without Temp
// Swap two numbers using:

// ·        Method 1: ref

// ·        Method 2: out

using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
   
    public static void SwapRef(ref int a, ref int b)
    {
        System.Console.WriteLine("using ref");
        a = a+b;
        b = a-b;
        a = a-b;
        System.Console.WriteLine("a = " + a);
        System.Console.WriteLine("b = " + b);
        
    }
    public static void SwapOut(int a, int b, out int x, out int y)
    {
        System.Console.WriteLine("using out");
        x = b;
        y = a;
        System.Console.WriteLine("a = "+x);
        System.Console.WriteLine("b = "+y);
    }
    public static void Main()
    {
        Program program = new Program();
        System.Console.WriteLine("enter number to swap using ref : ");
        System.Console.WriteLine("enter a:");
        System.Console.WriteLine("enter b:");
        int a, b;

        while (!int.TryParse(Console.ReadLine(),out a) || !int.TryParse(Console.ReadLine(), out b))
        {
            System.Console.WriteLine("enter valid number");
        }
        SwapRef(ref a, ref b);
        System.Console.WriteLine("enter number to swap using out :");
        System.Console.WriteLine("enter a:");
        System.Console.WriteLine("enter b:");
        int c, d;
        int x,y;

        while (!int.TryParse(Console.ReadLine(),out c) || !int.TryParse(Console.ReadLine(), out d))
        {
            System.Console.WriteLine("enter valid number");
        }
        
        SwapOut(c,d,out x, out y);
    }
}