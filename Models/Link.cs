using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webdev.Models
{
    public class Link
    {
        [Key] //klucz glowny tabeli:
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string Hash { get; set; }
    }
}
