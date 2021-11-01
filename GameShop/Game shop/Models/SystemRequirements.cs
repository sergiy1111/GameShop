using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_shop.Models
{
    public class SystemRequirements
    {
        public int Id { get; set; }
        public string OS { get; set; }
        public string Procesor { get; set; }
        public string RAM { get; set; }
        public string VideoCard { get; set; }
        public string DriveSpace { get; set; }
        public string SoundCard { get; set; }
    }
}