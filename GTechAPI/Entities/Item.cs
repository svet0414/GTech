using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Item
    {
        public Item()
        {
            Loans = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public bool IsLoanable { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public int? ItemMetadata { get; set; }

        public virtual BaseMetadatum ItemMetadataNavigation { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
