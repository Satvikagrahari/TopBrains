using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public int S(int n)
    {
        int temp = 0;
        while (n > 0)
        {
            temp+=n%10;
            n = n/10;
        }
        return temp;
    }
    public bool LuckyNumber(int n)
    {
        bool islucky = false;
        if(S(n*n) == S(n) * S(n))
        {
            islucky=true;
        }
        return islucky;
    }
    public static void Main()
    {
        Program program = new Program();
        int a;
        int b;
        if(!int.TryParse(Console.ReadLine(), out a) || !int.TryParse(Console.ReadLine(), out b) )
        {
            System.Console.WriteLine("Invalid Number");
            return;
        }
        int count = 0; 
        for (int i = a; i <= b; i++)
        {
            if (program.LuckyNumber(i))
            {
                count++;
            }
        }
        System.Console.WriteLine(count);      
    }
}