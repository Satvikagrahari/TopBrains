using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class InvalidOrderAmountException : Exception
    {
        public InvalidOrderAmountException(string message) : base(message) { }
    }
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message) : base(message) { }
    }
}