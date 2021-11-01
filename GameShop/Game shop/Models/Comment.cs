using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_shop.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int AspNetUserId { get; set; }
        public int ProductId { get; set; }
    }
}