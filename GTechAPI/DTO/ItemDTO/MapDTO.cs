using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.DTO.ItemDTO
{
    public class MapDTO
    {
        public int Id { get; set; }
        public string Scale { get; set; }
        public string Size { get; set; }

        public virtual BaseMetadatumDTO IdNavigation { get; set; }
    }
}
