using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhillReminderApp_MelanyIssac.Models
{
    public class ReminderSteps
    {
        public int ReminderStepId { get; set; }
        public string Step { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
