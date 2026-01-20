using System;

class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        input = input.Trim();
        string result = "";
        for(int i=0; i<input.Length; i++)
        {
            if(i==0 || input[i] != input[i - 1])
            {
                result += input[i];
            }
        }
        
        string upper = "";
        
        for(int i=0; i<result.Length; i++)
        {
            if(i==0 || result[i-1]==' ')
            {
                upper += char.ToUpper(result[i]);
            }
            else
            {
                upper += char.ToLower(result[i]);
            }
            
        }
        System.Console.WriteLine(upper);
    }
}