using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdev.Interfaces
{
    public interface IHashAlgorithm
    {
        string Hash(int number);
    }
}
