using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webdev.Helpers;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Controllers
{
    public class LinkController : Controller
    {
        private ILinksRepository _repository;
        private IHashAlgorithm _hashAlgorithm;


        public LinkController(ILinksRepository linksRepository, IHashAlgorithm hashAlgorithm)
        {
            _repository = linksRepository;
            _hashAlgorithm = hashAlgorithm;
        }

        [HttpGet("/api/links")]
        public IActionResult Get([FromQuery]LinkRequest request)
        {
            int requestedPage = request.Page ?? 1;
            int requestedPageSize = request.PageSize ?? 10;
            string search = request.Search ?? "";

            IEnumerable<Link> links = _repository.GetLinks(search,requestedPage,requestedPageSize);

            int linksCountMatchedSearch = _repository.LinksCount(search);
            int maxPage = (linksCountMatchedSearch / requestedPageSize);
            maxPage += linksCountMatchedSearch % requestedPageSize == 0 ? 0 : 1;

            IEnumerable<LinkGetResult.SendedLinkToClient> linkInformations = links.Select(x => new LinkGetResult.SendedLinkToClient(x));
            LinkGetResult result = new LinkGetResult(linkInformations, new LinkGetResult.PageInfo(requestedPage, maxPage));

            return Ok(result);
        }

        [HttpDelete("/api/links")]
        public IActionResult Delete([FromBody]string hash)
        {
            _repository.Delete(hash);
            return Ok();
        }

        [HttpPost("/api/links")]
        public IActionResult Create([FromBody]string link)
        {
            if(!(link.IsValidHttpLink() || link.IsValidHttpsLink()))
            {
                return BadRequest();
            }
        
            Link linkInformation = new Link { OriginalLink = link , Visitors=0};
            _repository.Add(linkInformation);

            linkInformation.Hash = _hashAlgorithm.Hash(linkInformation.Id);
            _repository.Update(linkInformation);

            return Ok();
        }
    }
}
