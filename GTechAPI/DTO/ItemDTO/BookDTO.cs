using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTechAPI.DTO.ItemDTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Isbn13 { get; set; }
        public int? Ddcs { get; set; }
        public int? PublisherId { get; set; }
        public int? PageCount { get; set; }
        public int? Language { get; set; }
        public virtual BaseMetadatumDTO IdNavigation { get; set; }
    }
}
