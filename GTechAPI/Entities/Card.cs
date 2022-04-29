using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Card
    {
        public int CardNumber { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpire { get; set; }
        public int? MemberSsn { get; set; }
        public byte[] Photo { get; set; }

        public virtual Member MemberSsnNavigation { get; set; }
    }
}
