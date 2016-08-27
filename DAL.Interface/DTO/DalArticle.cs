using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalArticle : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        public int CountLikes { get; set; }

        public virtual List<DalComment> Comments { get; set; }

        public virtual List<DalTag> Tags { get; set; }
    }
}
