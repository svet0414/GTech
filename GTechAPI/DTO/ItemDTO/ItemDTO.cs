using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.DTO.ItemDTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public bool IsLoanable { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public int? ItemMetadata { get; set; }
    }
}
