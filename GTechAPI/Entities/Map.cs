using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Map
    {
        public int Id { get; set; }
        public string Scale { get; set; }
        public string Size { get; set; }

        public virtual BaseMetadatum IdNavigation { get; set; }
    }
}
