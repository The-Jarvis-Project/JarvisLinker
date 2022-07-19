using System.ComponentModel.DataAnnotations;

namespace JarvisLinker.Models
{
    public class BladeCmd
    {
        [Key] public long Id { get; set; }
        public string Command { get; set; }
    }
}
