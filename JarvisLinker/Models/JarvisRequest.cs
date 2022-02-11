using System.ComponentModel.DataAnnotations;

namespace JarvisLinker.Models
{
    public class JarvisRequest
    {
        [Key] public long Id { get; set; }
        public string Request { get; set; }
    }
}
