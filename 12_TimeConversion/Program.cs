// Question
// 12
// Time Conversion
// Description
// Convert a number of seconds into a string formatted as m:ss.
// Seconds must be 2 digits (leading zero if needed).

// Input: totalSeconds (int)
// Output: formatted (string)

// Examples:
// 125 -> "2:05"
// 60  -> "1:00"

// Constraints:
// 0 <= totalSeconds <= 1e9

using System;

class Program
{
    public static void Main()
    {
        System.Console.Write("enter totalsec to convert m:ss = ");
        int totalsec = int.Parse(Console.ReadLine());
        int min = totalsec/60;
        int sec = totalsec%60;
        if (totalsec < 60)
        {
            System.Console.WriteLine($"{0}:{sec}");
        }
        else if (sec < 10)
        {
            System.Console.WriteLine($"{min}:0{sec}");
        }
        else{
        System.Console.WriteLine($"{min}:{sec}");
        }
    }
}