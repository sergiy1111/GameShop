using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProuctName { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
        public int SystemRequirementsId { get; set; }
    }
}