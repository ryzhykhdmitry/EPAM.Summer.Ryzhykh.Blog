﻿using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalComment : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        public int ArticleId { get; set; }

        public virtual List<DalArticle> Articles { get; set; }

        public virtual List<DalUser> Users { get; set; }
    }
}
