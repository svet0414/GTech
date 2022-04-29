using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class AuthorBookRelation
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
