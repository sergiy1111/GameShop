using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AspNetUserId { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
    }
}