using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class MemberType
    {
        public MemberType()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string NameOfMemberType { get; set; }
        public int? MaximumLoans { get; set; }
        public int? LoanPeriod { get; set; }
        public int? GracePeriod { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
