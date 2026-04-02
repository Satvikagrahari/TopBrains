using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class DuplicateInvestmentException : Exception
    {
        public DuplicateInvestmentException(string message) : base(message) { }
    }
    public class InvalidRiskRatingException : Exception
    {
        public InvalidRiskRatingException(string message) : base(message) { }
    }
}