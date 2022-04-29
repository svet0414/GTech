using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.DTO.ItemDTO
{
    public class BaseMetadatumDTO
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public int? NumberOfCopies { get; set; }

    }
}
