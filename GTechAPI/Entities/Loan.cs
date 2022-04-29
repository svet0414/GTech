using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Loan
    {
        public Loan()
        {
            Reminders = new HashSet<Reminder>();
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? ItemId { get; set; }
        public int? MemberSnn { get; set; }
        public DateTime DateLoaned { get; set; }
        public DateTime? DateDue { get; set; }
        public DateTime? DateFinished { get; set; }

        public virtual Item Item { get; set; }
        public virtual Member MemberSnnNavigation { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
