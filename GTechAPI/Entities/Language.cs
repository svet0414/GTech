using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Language
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Language1 { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
