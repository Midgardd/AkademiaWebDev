using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Repository
{
    public class LinksRepository : ILinksRepository
    {
        private List<LinkInformation> _links;
        private int lastID;

        public LinksRepository()
        {
            lastID = 0;
            _links = new List<LinkInformation>();
        }

        public void Add(LinkInformation information)
        {
            lastID++;
            information.Id = lastID;
            _links.Add(information);
        }

        public void Delete(string originalLink)
        {
            for(int i=0; i<_links.Count; i++)
            {
                if(_links.ElementAt(i).OriginalLink == originalLink)
                {
                    _links.RemoveAt(i);
                    return;
                }
            }
        }

        public List<LinkInformation> GetLinks()
        {
            return _links;
        }

        public void Update(LinkInformation information)
        {
            // nic
        }
    }
}
