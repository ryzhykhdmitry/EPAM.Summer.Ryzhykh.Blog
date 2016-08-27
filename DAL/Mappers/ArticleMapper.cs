using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class ArticleMapper
    {
        public static DalArticle GetDalEntity(this Article ormEntity)
        {
            return new DalArticle()
            {
                Id = ormEntity.Id,
                Title = ormEntity.Title,
                Text = ormEntity.Text,
                PublicationDate = ormEntity.PublicationDate,
                AuthorId = ormEntity.AuthorId,
                CountLikes = ormEntity.CountLikes,
                Comments = ormEntity.Comments.Select(r => r.GetDalEntity()).ToList(),
                Tags = ormEntity.Tags.Select(r => r.GetDalEntity()).ToList()
            };
        }

        public static Article GetORMEntity(this DalArticle dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new Article()
            {
                Id = dalEntity.Id,
                Title = dalEntity.Title,
                Text = dalEntity.Text,
                PublicationDate = dalEntity.PublicationDate,
                AuthorId = dalEntity.AuthorId,
                CountLikes = dalEntity.CountLikes,
                Comments =
                    dalEntity.Comments != null
                        ? dalEntity.Comments.Select(r => r.GetORMEntity()).ToList()
                        : null,
                Tags =
                    dalEntity.Tags != null
                        ? dalEntity.Tags.Select(r => r.GetORMEntity()).ToList()
                        : null
            };
        }
    }
}
