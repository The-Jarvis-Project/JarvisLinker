﻿using System.ComponentModel.DataAnnotations;

namespace JarvisLinker.Models
{
    public class BladeMsgCmd
    {
        [Key] public string Origin { get; set; }
        public string Data { get; set; }
    }
}
