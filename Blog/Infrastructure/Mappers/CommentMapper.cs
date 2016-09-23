using BLL.Interface.Entities;
using Blog.Models.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Infrastructure.Mappers
{
    public static class CommentMapper
    {
        public static CommentEntity GetBllEntity(this CommentViewModel model)
        {
            return new CommentEntity()
            {
                Id = model.Id,
                Text = model.Text,        
                PublicationDate = model.PublicationDate,
                AuthorId = model.AuthorId,        
                ArticleId = model.ArticleId
            };
        }

        public static CommentViewModel GetMvcEntity(this CommentEntity model)
        {
            return new CommentViewModel()
            {
                Id = model.Id,
                Text = model.Text,
                PublicationDate = model.PublicationDate,
                AuthorId = model.AuthorId,
                ArticleId = model.ArticleId
            };
        }
    }
}