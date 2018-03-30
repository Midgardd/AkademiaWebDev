using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Interfaces;

namespace webdev.Algorithms
{
    public class HashIdAlgorithm : IHashAlgorithm
    {
        public string Hash(int number)
        {
            var hashids = new Hashids("salt");
            string hash = hashids.Encode(number);
            return hash;
        }
    }
}
