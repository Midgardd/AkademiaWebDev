using System.ComponentModel.DataAnnotations;

namespace webdev.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string Hash { get; set; }
        public int Visitors { get; set; }
    }
}
