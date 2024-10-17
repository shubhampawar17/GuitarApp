using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Exceptions
{
    public class GuitarNotFoundException : Exception
    {
        public GuitarNotFoundException(string message) :base(message)  { }
    }
}
