using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GTechAPI.Entities
{
    public partial class Book
    {
        public Book()
        {
            AuthorBookRelations = new HashSet<AuthorBookRelation>();
        }

        public int Id { get; set; }
        public string Isbn13 { get; set; }
        public int? Ddcs { get; set; }
        public int? PublisherId { get; set; }
        public int? PageCount { get; set; }
        public int? Language { get; set; }
        [NotMapped]
        public virtual Ddc DdcsNavigation { get; set; }
        public virtual BaseMetadatum IdNavigation { get; set; }
        public virtual Language LanguageNavigation { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<AuthorBookRelation> AuthorBookRelations { get; set; }
    }
}
