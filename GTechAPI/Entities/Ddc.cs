using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Ddc
    {
        public Ddc()
        {
            Books = new HashSet<Book>();
        }

        public int DdcsCode { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
