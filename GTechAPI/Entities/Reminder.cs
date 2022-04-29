using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Reminder
    {
        public int LoanId { get; set; }
        public DateTime DateSent { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
