using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdev.Helpers
{
    public static class StringExtensions
    {
        public static bool IsValidHttpLink(this string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

        public static bool IsValidHttpsLink(this string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
        }
    }
}
