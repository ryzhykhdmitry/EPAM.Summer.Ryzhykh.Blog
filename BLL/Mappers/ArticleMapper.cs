using DAL.Interface.DTO;
using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class ArticleMapper
    {
        public static ArticleEntity GetBllEntity(this DalArticle dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new ArticleEntity()
            {
                Id = dalEntity.Id,
                Title = dalEntity.Title,
                Text = dalEntity.Text,
                PublicationDate = dalEntity.PublicationDate,
                AuthorId = dalEntity.AuthorId,
                CountLikes = dalEntity.CountLikes,
                Comments =
                    dalEntity.Comments != null
                        ? dalEntity.Comments.Select(r => r.GetBllEntity()).ToList()
                        : null,
                Tags =
                    dalEntity.Tags != null
                        ? dalEntity.Tags.Select(r => r.GetBllEntity()).ToList()
                        : null
            };
        }

        public static DalArticle GetDalEntity(this ArticleEntity bllEntity)
        {
            return new DalArticle()
            {
                Id = bllEntity.Id,
                Title = bllEntity.Title,
                Text = bllEntity.Text,
                PublicationDate = bllEntity.PublicationDate,
                AuthorId = bllEntity.AuthorId,
                CountLikes = bllEntity.CountLikes,
                //Comments = bllEntity.Comments.Select(r => r.GetDalEntity()).ToList(),
                //Tags = bllEntity.Tags.Select(r => r.GetDalEntity()).ToList()
            };
        }
    }
}
