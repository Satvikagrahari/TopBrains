// Simulate a bank account.
// - Start with an initial balance.
// - For each transaction:
//   - if transaction >= 0: deposit
//   - if transaction < 0 : withdraw (only if enough balance; otherwise ignore)

// Return the final balance.

// Input: initialBalance (int), transactions (int[])
// Output: finalBalance (int)

// Constraints:
// 0 <= transactions.Length <= 1e5
// -1e9 <= transactions[i] <= 1e9

using System;
class Program
{
    public static void Main()
    {
        System.Console.WriteLine("initial balance:");
        int initialBalance = int.Parse(Console.ReadLine());
        System.Console.WriteLine("enter number transaction:");
        int n = int.Parse(Console.ReadLine());
        int[] transaction = new int[n];
        for (int i = 0; i < n; i++)
        {
            transaction[i] = int.Parse(Console.ReadLine());
            if (transaction[i] >= 0)
            {
                initialBalance += transaction[i];
            }
            else 
            {
                if(initialBalance + transaction[i] > 0){
                    initialBalance+=transaction[i];
                }
            }
        }
        System.Console.WriteLine(initialBalance);


    }
}
