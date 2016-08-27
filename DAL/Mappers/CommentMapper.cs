using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class CommentMapper
    {
        public static DalComment GetDalEntity(this Comment ormEntity)
        {
            return new DalComment()
            {
                Id = ormEntity.Id,
                Text = ormEntity.Text,
                PublicationDate = ormEntity.PublicationDate,
                AuthorId = ormEntity.AuthorId,
                ArticleId = ormEntity.ArticleId
            };
        }

        public static Comment GetORMEntity(this DalComment dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new Comment()
            {
                Id = dalEntity.Id,
                Text = dalEntity.Text,
                PublicationDate = dalEntity.PublicationDate,
                AuthorId = dalEntity.AuthorId,
                ArticleId = dalEntity.ArticleId
            };
        }
    }
}
