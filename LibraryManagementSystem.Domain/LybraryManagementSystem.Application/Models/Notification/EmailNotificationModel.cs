using LibraryManagementSystem.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models.Notification
{
    public class EmailNotificationModel 
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EmailStatus EmailStatus { get; set; }
    }
}
