using System;
using System.Data;
class InvalidExpression : SystemException
{
    public InvalidExpression(string message) : base(message)
    {   
    }

}
class UnknownOperator : SystemException
{
    public UnknownOperator(string message) : base(message)
    {
    }
}


class Program
{
    public int Add(int a, int b)
    {
        return a+b;
    }
    public int Subtract(int a, int b)
    {
        return a-b;
    }
    public int Multiply(int a, int b)
    {
        return a*b;
    }
    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a/b;
    }
    public static void Main(string[] arg)
    {
        try{
        Program program = new Program();
        System.Console.WriteLine("enter expression to evaluate in format a op b where op is +,-,/,* .");
        string input = Console.ReadLine();
        string[] inputarr = input.Split(" "); 
        if(inputarr.Length != 3)
            {
                throw new InvalidExpression("Error: InvalidExpression");
            }
        int a;
        if(!int.TryParse(inputarr[0], out a))
            {
                throw new InvalidExpression("Error: InvalidExpression");
            }
        string op = inputarr[1];
        int b;
        if(!int.TryParse(inputarr[2], out b))
            {
                throw new InvalidExpression("Error: InvalidExpression");
            }
        if (op == "+")
        {
            System.Console.WriteLine(program.Add(a,b));
        }  
        else if (op == "-")
        {
            System.Console.WriteLine(program.Subtract(a,b));
        }
        else if (op == "*")
        {
            System.Console.WriteLine(program.Multiply(a,b));
        }
        else if (op == "/")
        {
            System.Console.WriteLine(program.Divide(a,b));
        }
        else
        {
            throw new UnknownOperator("Error:UnknownOperator");
        }
        }
        catch(DivideByZeroException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch(UnknownOperator ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch(InvalidExpression ex)
        {
            System.Console.WriteLine(ex.Message);
        }

    }
}