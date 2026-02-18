using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DuplicateTicketException : Exception
    {
        public DuplicateTicketException(string message) : base(message) { }
    }
    public class InvalidFareException : Exception
    {
        public InvalidFareException(string message) : base(message) { }
    }
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(string message) : base(message) { }
    }
}