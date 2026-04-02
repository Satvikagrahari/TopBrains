using System;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string str = Console.ReadLine();
        // bool isValid = Regex.IsMatch(str,@"^[6-9]{1}\d{9}$");
        // bool isValid = Regex.IsMatch(str,@"^([a-fA-F0-9]{1,4}:){7}[a-fA-F0-9]{1,4}::([0-9A-F]{2}[:-]){5}[0-9A-F]{2}$");
        // bool isValid = Regex.IsMatch(str,@"^[a-zA-Z0-9.%_+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        if (isValid)
        {
            System.Console.WriteLine("valid");
        }
        else
        {
            System.Console.WriteLine("invalid");
        }
    }

}