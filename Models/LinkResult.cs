using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdev.Models
{
    public class LinkGetResult
    {
        public IEnumerable<SendedLinkToClient> Links { get; }
        public PageInfo PageInformation { get; }

        public LinkGetResult(IEnumerable<SendedLinkToClient> links, PageInfo pageInfo)
        {
            PageInformation = pageInfo;
            Links = links;
        }

        public class PageInfo
        {
            public int CurrentPage { get; }
            public int MaxPage { get; }

            public PageInfo(int curentPage, int maxPage)
            {
                CurrentPage = curentPage;
                MaxPage = maxPage;
            }
        }

        public class SendedLinkToClient
        {
            public string OriginalLink { get; }
            public string Hash { get; }
            public int Visitors { get; set; }
            public SendedLinkToClient(Link link)
            {
                OriginalLink = link.OriginalLink;
                Hash = link.Hash;
                Visitors = link.Visitors;
            }
        }
    }
}
