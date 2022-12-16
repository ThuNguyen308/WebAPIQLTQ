using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIQLTQ.Models
{
    public class Habit
    {
        public int habitId { get; set; }
        public string habitName { get; set; }
        public DateTime habitStartDate { get; set; }
        public DateTime habitEndDate { get; set; }
        public string habitDescription { get; set; }
        public int categoryId { get; set; }
        public int userId { get; set; }

    }
}