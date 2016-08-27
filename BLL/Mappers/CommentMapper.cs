using DAL.Interface.DTO;
using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class CommentMapper
    {
        public static CommentEntity GetBllEntity(this DalComment dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new CommentEntity()
            {
                Id = dalEntity.Id,
                Text = dalEntity.Text,
                PublicationDate = dalEntity.PublicationDate,
                AuthorId = dalEntity.AuthorId,
                ArticleId = dalEntity.ArticleId
            };
        }

        public static DalComment GetDalEntity(this CommentEntity bllEntity)
        {
            return new DalComment()
            {
                Id = bllEntity.Id,
                Text = bllEntity.Text,
                PublicationDate = bllEntity.PublicationDate,
                AuthorId = bllEntity.AuthorId,
                ArticleId = bllEntity.ArticleId
            };
        }
    }
}
