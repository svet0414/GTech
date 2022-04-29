using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class ItemType
    {
        public ItemType()
        {
            BaseMetadata = new HashSet<BaseMetadatum>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BaseMetadatum> BaseMetadata { get; set; }
    }
}
