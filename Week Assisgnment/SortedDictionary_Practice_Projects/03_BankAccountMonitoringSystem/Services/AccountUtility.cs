using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class AccountUtility
    {
        private SortedDictionary<decimal, List<Account>> _data
            = new SortedDictionary<decimal, List<Account>>();

        public void AddAccount(Account account)
        {
            // TODO: Validate account
            // TODO: Handle duplicate entries
            // TODO: Add account to SortedDictionary
            
            if (account.Balance < 0)
            {
                throw new NegativeBalanceException("Negative Balance");
            }
            
            if (_data.ContainsKey(account.Balance))
                _data[account.Balance].Add(account);
            else
                _data[account.Balance] = new List<Account> { account };
        
        }
        public void Deposit(int acNo, decimal balance)
        {

            bool check = false;
            foreach (var values in _data.Keys)
            {
                var list = _data[values];
                foreach (var x in list)
                {
                    if(x.AccountNumber == acNo)
                    {
                        check = true;
                    }
                    
                }
            }
            if (check == false)
            {
                throw new AccountNotFoundException("Account with a/c no. is not present");
            }

            foreach (var values in _data.Keys)
            {
                var list = _data[values];
                foreach (var x in list)
                {
                    if(x.AccountNumber == acNo)
                    {
                        x.Balance += balance;
                    }
                }
            }
            {
                
            }
        }

        public void Withdraw(int acNo, decimal amt)
        {
            
            bool check = false;
            foreach (var values in _data.Keys)
            {
                var list = _data[values];
                foreach (var x in list){
                    if(x.AccountNumber == acNo)
                    {
                        check = true;

                    }
                }
            }
            if (check == false)
            {
                throw new AccountNotFoundException("Account with a/c no. is not present");
            }

            
            foreach (var values in _data.Keys)
            {
                var list = _data[values];
                foreach (var x in list){
                    if (x.AccountNumber == acNo)
                    {
                        if (x.Balance < 0)
                        {
                            throw new NegativeBalanceException("Negative Balance");
                        }
                        if(x.Balance < amt)
                        {
                           
                            throw new InsufficientFundsException("Insufficient Balance");
                        }
                        else
                        {
                            x.Balance -= amt;
                        }
                    }
                }
            }

        }

       public void DisplayAccounts()
        {
            foreach(var values in _data.Keys)
            {
                var list = _data[values];
                foreach (var x in list)
                {
                    System.Console.WriteLine($"Details: AccNo: {x.AccountNumber} HolderName: {x.HolderName} Balance: {x.Balance}");
                }
            }
        }

        // public IEnumerable<Account> GetAll()
        // {
        //     // TODO: Return sorted entities
        //     return new List<Account>();
        // }
    }
}
