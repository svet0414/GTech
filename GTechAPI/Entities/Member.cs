using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Member
    {
        public Member()
        {
            Cards = new HashSet<Card>();
            Loans = new HashSet<Loan>();
        }

        public int Ssn { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CampusAddress { get; set; }
        public string HomeAddress { get; set; }
        public int? MemberType { get; set; }
        [NotMapped]
        public virtual MemberType MemberTypeNavigation { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
