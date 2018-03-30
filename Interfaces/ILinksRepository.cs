using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Models;

namespace webdev.Interfaces
{
    public interface ILinksRepository
    {
        List<LinkInformation> GetLinks();
        void Add(LinkInformation information);
        void Update(LinkInformation information);
        void Delete(String originalLink);
    }
}
