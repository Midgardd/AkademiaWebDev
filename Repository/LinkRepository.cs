using System.Collections.Generic;
using System.Linq;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Repository
{
    public class LinkRepository : ILinksRepository
    {
        private LinkDbContext DbContext { get; }

        public LinkRepository(LinkDbContext linkDbContext)
        {
            DbContext = linkDbContext;
        }

        public void Add(Link information)
        {
            DbContext.Links.Add(information);
            DbContext.SaveChanges();
        }

        public void Delete(string hash)
        {
            Link deletedLink = DbContext.Links.FirstOrDefault(x => x.Hash.Equals(hash));
            DbContext.Links.Remove(deletedLink);
            DbContext.SaveChanges();
        }

        public IEnumerable<Link> GetLinks(string search,int pageNumber,int pageSize)
        {
            search = search.ToLower();
            return DbContext.Links
                .Where(x => x.OriginalLink.ToLower().Contains(search))
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public int LinksCount(string search)
        {
            search = search.ToLower();
            return DbContext.Links
                .Where(x => x.OriginalLink.ToLower().Contains(search))
                .Count();
        }

        public void Update(Link link)
        {
            DbContext.Links.Attach(link);
            DbContext.Entry(link).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public Link GetLinkByHash(string hash)
        {
            return DbContext.Links.First(x => x.Hash.Equals(hash));
        }
    }
}
