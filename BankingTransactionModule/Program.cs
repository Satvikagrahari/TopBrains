using System;
using System.Runtime.Intrinsics.X86;
class ArgumentException : SystemException
{
    public ArgumentException(string str)
    {
        System.Console.WriteLine(str);
    }
}
class InvalidOperationException : SystemException
{
    public InvalidOperationException(string str)
    {
        System.Console.WriteLine(str);
    }
}
class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public decimal Deposit(decimal amount)
    {
        try{
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        else
        {
            Balance += amount;
        }
        }
        catch(ArgumentException)
        {
            
        }
        return Balance;


    }
    public decimal Withdraw(decimal amount)
    {
        try{
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
        }
        else if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive");
        }
        else if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        }
        catch(ArgumentException)
        {
            
        }
        catch (InvalidOperationException)
        {
            
        }
        return Balance;
    }
}
class Program
{

    public static void Main()
    {
        Account account = new Account();

            System.Console.WriteLine("enter 1 for deposit \nenter 2 for withdraw \nenter 3 for exit");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                System.Console.WriteLine("invalid choice pls enter 1 or 2");
                return;
            }
            System.Console.WriteLine("Account Number = ");
            account.AccountNumber = Console.ReadLine();

            System.Console.WriteLine("Intial Balance");
            account.Balance = decimal.Parse(Console.ReadLine());

            if (choice == 1)
            {
                System.Console.WriteLine("enter amount to deposit");
                decimal amt = decimal.Parse(Console.ReadLine());
                System.Console.WriteLine("Balance Amount = " + account.Deposit(amt));
            }
            else if (choice == 2)
            {
                System.Console.WriteLine("enter amount to withdraw");
                decimal amt = decimal.Parse(Console.ReadLine());
                System.Console.WriteLine("Balance Amount = " + account.Withdraw(amt));
            }
            else if (choice == 3)
            {
                System.Console.WriteLine("invalid choice try again");
                return;
            }
}   
}