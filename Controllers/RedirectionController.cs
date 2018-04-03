using Microsoft.AspNetCore.Mvc;
using System;
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
            Link linkToRedirect = _repository.GetLinkByHash(hash);
            
            if (!(Request.Cookies[hash] is null))
            {
                return Redirect(linkToRedirect.OriginalLink);
            }

            linkToRedirect.Visitors += 1;
            _repository.Update(linkToRedirect);

            AddCookie(hash);

            return Redirect(linkToRedirect.OriginalLink);
        }

        private void AddCookie(string hash)
        {
            Microsoft.AspNetCore.Http.CookieOptions cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Append(hash, hash, cookieOptions);
        }
    }
}