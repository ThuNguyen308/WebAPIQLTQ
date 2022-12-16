using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIQLTQ.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userImage { get; set; }
    }
}