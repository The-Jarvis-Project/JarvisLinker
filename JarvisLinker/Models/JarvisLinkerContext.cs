using Microsoft.EntityFrameworkCore;

namespace JarvisLinker.Models
{
    public class JarvisLinkerContext : DbContext
    {
        public JarvisLinkerContext(DbContextOptions<JarvisLinkerContext> options) : base(options) { }

        public DbSet<JarvisRequest> JarvisRequests { get; set; }
        public DbSet<JarvisResponse> JarvisResponses { get; set; }

        public DbSet<BladeMsgCmd> BladeCommands { get; set; }
        public DbSet<BladeMsgResponse> BladeResponses { get; set; }
    }
}
