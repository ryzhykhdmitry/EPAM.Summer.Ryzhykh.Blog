using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        public int ArticleId { get; set; }

        public virtual List<ArticleEntity> Articles { get; set; }

        public virtual List<UserEntity> Users { get; set; }
    }
}
