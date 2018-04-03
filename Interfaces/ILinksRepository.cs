using System;
using System.Collections.Generic;
using webdev.Models;

namespace webdev.Interfaces
{
    public interface ILinksRepository
    {
        IEnumerable<Link> GetLinks(string search,int pageNumber,int pageSize);
        void Add(Link information);
        void Delete(String hash);
        void Update(Link link);
        int LinksCount(string search);
        Link GetLinkByHash(string hash);
    }
}
