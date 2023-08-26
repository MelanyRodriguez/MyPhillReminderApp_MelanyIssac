using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhillReminderApp_MelanyIssac.Models
{
    public class ReminderCategory
    {
        public int ReminderCategory1 { get; set; }
        public string Description { get; set; } = null!;
        public int UserId { get; set; }
    }
}
