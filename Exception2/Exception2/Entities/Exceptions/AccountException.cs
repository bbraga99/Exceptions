using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception2.Entities.Exceptions
{
    internal class AccountException : ApplicationException
    {
        public AccountException(string message) : base(message) 
        {
        }
    }
}
