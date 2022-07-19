using Microsoft.EntityFrameworkCore;

namespace JarvisLinker.Models
{
    public class JarvisLinkerContext : DbContext
    {
        public JarvisLinkerContext(DbContextOptions<JarvisLinkerContext> options) : base(options) { }

        public DbSet<JarvisRequest> JarvisRequests { get; set; }
        public DbSet<JarvisResponse> JarvisResponses { get; set; }

        public DbSet<BladeCmd> BladeCommands { get; set; }
        public DbSet<BladeResponse> BladeResponses { get; set; }
    }
}
