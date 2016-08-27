using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class ArticleEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        public int CountLikes { get; set; }

        public virtual List<CommentEntity> Comments { get; set; }

        public virtual List<TagEntity> Tags { get; set; }
    }
}
