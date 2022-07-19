using System.ComponentModel.DataAnnotations;

namespace JarvisLinker.Models
{
    public class BladeResponse
    {
        [Key] public long Id { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public long CmdId { get; set; }
    }
}
