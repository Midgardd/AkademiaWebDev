using Microsoft.EntityFrameworkCore;
using webdev.Models;

namespace webdev
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
    }
}
