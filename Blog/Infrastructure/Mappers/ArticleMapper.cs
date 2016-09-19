using BLL.Interface.Entities;
using Blog.Models.ArticleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Infrastructure.Mappers
{
    public static class ArticleMapper
    {
        public static ArticleEntity GetBllEntity(this ArticleViewModel model)
        {
            return new ArticleEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                PublicationDate = model.PublicationDate,
                AuthorId = model.AuthorId,
                CountLikes = model.CountLikes,

            };
        }

        public static ArticleViewModel GetMvcEntity(this ArticleEntity model)
        {
            return new ArticleViewModel()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                PublicationDate = model.PublicationDate,
                AuthorId = model.AuthorId,
                CountLikes = model.CountLikes,
            };
        }
    }
}