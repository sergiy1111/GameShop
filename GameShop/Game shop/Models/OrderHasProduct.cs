using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_shop.Models
{
    public class OrderHasProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}