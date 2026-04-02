using System;

namespace Exceptions
{
    public class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message) { }
    }

    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message)
        {
            System.Console.WriteLine(message);
        }
    }
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string message) : base(message)
        {
            System.Console.WriteLine(message);
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
            System.Console.WriteLine(message);
        }
    }
}
