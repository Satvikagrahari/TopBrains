using System;
using Services;
using Domain;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
           AccountUtility accountUtility = new AccountUtility();
           try
           {         
           

            while (true)
            {
                Console.WriteLine("1 → Display Accounts");
                Console.WriteLine("2 → Deposit");
                Console.WriteLine("3 → Withdraw");
                Console.WriteLine("4 → Add Account");
                Console.WriteLine("5 → Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        accountUtility.DisplayAccounts();
                        break;
                    case 2:
                        System.Console.WriteLine("ac no : ");
                        int acNo = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("amount to deposit: ");
                        decimal amt = decimal.Parse(Console.ReadLine());

                        accountUtility.Deposit(acNo, amt);
                        break;
                    case 3:
                        System.Console.WriteLine("ac no : ");
                        int acNo1 = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("amount to withdraw: ");
                        decimal amt1 = decimal.Parse(Console.ReadLine());

                        accountUtility.Withdraw(acNo1, amt1);                        
                        break;
                    case 4:
                        
                        System.Console.WriteLine("Enter details like {a/cNo. name balance}");
                        string[] input = Console.ReadLine().Split(' ');
                        
                        Account ac = new Account
                        {
                            AccountNumber= int.Parse(input[0]),
                            HolderName = input[1],
                            Balance = decimal.Parse(input[2])
                        };
                        break;
                    case 5:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        break;
                }
            }
           }
            catch (AccountNotFoundException e)
           {
                System.Console.WriteLine(e.Message);
           }
           catch(NegativeBalanceException e)
            {
                System.Console.WriteLine(e.Message);
            }
            catch(InsufficientFundsException e)
            {
                System.Console.WriteLine(e.Message);
            }
           
        }
    }
}
