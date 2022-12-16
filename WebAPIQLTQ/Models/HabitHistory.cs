using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIQLTQ.Models
{
    public class HabitHistory
    {
        public int habitHistoryId { get; set; }
        public int habitId { get; set; }
        public DateTime checkinDate { get; set; }
    }
}