using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_shop.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
    }
}