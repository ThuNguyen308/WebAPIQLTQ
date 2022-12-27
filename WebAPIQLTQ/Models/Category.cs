using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIQLTQ.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int colorId { get; set; }
        public int iconId { get; set; }
        public int userId { get; set; }
        public string colorCode { get; set; }
        public string iconImage { get; set; }
    }
}