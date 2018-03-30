using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webdev.Interfaces;
using webdev.Models;
using webdev.Repository;

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

        [HttpGet]
        public IActionResult Index()
        {
            var links = _repository.GetLinks();
            return View(links);
        }

        [HttpPost]
        public IActionResult Delete(string link)
        {
            _repository.Delete(link);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Create(string link)
        {
            LinkInformation linkInformation = new LinkInformation { OriginalLink = link };
            _repository.Add(linkInformation);
            //uzupełniony Id
            string hash = _hashAlgorithm.Hash(linkInformation.Id);
            linkInformation.Hash = hash;
            _repository.Update(linkInformation);
            return Redirect("Index");
        }
    }
}
