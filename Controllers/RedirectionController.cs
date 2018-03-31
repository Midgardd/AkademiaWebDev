using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Controllers
{
    public class RedirectionController : Controller
    {
        private ILinksRepository _repository;

        public RedirectionController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet("/api/{hash}")]
        public IActionResult RedirectLink(string hash)
        {
            var links = _repository.GetLinks();
            foreach (LinkInformation x in links)
            {
                if(x.Hash == hash)
                {
                    return Ok(x.OriginalLink);
                }
            }

            throw new Exception();
        }
    }
}