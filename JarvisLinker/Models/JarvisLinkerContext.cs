using Microsoft.EntityFrameworkCore;

namespace JarvisLinker.Models
{
    public class JarvisLinkerContext : DbContext
    {
        public JarvisLinkerContext(DbContextOptions<JarvisLinkerContext> options) : base(options) { }

        public DbSet<JarvisRequest> Requests { get; set; }
        public DbSet<JarvisResponse> Responses { get; set; }
    }
}
