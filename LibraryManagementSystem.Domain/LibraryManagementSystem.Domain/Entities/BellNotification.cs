using LibraryManagementSystem.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class BellNotification
    {
        //public string FromEmail { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public BellType BellType { get; set; }

    }
}
