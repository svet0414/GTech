using System;
using System.Collections.Generic;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Author
    {
        public Author()
        {
            AuthorBookRelations = new HashSet<AuthorBookRelation>();
        }

        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public virtual ICollection<AuthorBookRelation> AuthorBookRelations { get; set; }
    }
}
