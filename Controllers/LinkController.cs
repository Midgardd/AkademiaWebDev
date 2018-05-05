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

        [HttpGet("/api/links/{hash}")]
        public IActionResult Get(string hash)
        {
            Link link = _repository.GetLink(hash);
            if (link == null)
                return BadRequest();

            return Ok(new LinkGetResult.SendedLinkToClient(link));
        }


        [HttpDelete("/api/links")]
        public IActionResult Delete([FromQuery]string hash)
        {
            _repository.Delete(hash);
            return Ok(new { message = "Deleted" });
        }

        [HttpPost("/api/links")]
        public IActionResult Create([FromBody]CreateLink command)
        {
            if(!(command.Link.IsValidHttpLink() || command.Link.IsValidHttpsLink()))
            {
                return BadRequest();
            }
        
            Link linkInformation = new Link { OriginalLink = command.Link , Visitors=0};
            _repository.Add(linkInformation);

            linkInformation.Hash = _hashAlgorithm.Hash(linkInformation.Id);
            _repository.Update(linkInformation);

            return Ok(new { message = "Created" });
        }

        [HttpPut("/api/links")]
        public IActionResult Update([FromBody]LinkUpdate update)
        {
            if (!(update.Link.IsValidHttpLink() || update.Link.IsValidHttpsLink()))
            {
                return BadRequest(new { message = "Not valid link" });
            }

            
            Link linkInformation = _repository.GetLinkByHash(update.Hash);

            if (linkInformation == null)
                return BadRequest(new { message = "Link does not exists" });

            linkInformation.OriginalLink = update.Link;
            _repository.Update(linkInformation);

            return Ok(new { message="Updated" });
        }

    }
}
