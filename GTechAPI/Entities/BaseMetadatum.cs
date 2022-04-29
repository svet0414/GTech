using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class BaseMetadatum
    {
        public BaseMetadatum()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public int? Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public int? NumberOfCopies { get; set; }

        public virtual ItemType TypeNavigation { get; set; }
        public virtual Book Book { get; set; }
        public virtual Map Map { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
