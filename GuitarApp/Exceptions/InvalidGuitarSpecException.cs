using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Exceptions
{
    public class InvalidGuitarSpecException : Exception
    {
        public InvalidGuitarSpecException(string message) : base (message) { }
    }
}
