namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public virtual User User { get; set; }
    }
}
