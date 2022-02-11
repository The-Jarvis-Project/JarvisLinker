using System.ComponentModel.DataAnnotations;

namespace JarvisLinker.Models
{
    public class JarvisResponse
    {
        [Key] public long Id { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public long RequestId { get; set; }
    }
}
