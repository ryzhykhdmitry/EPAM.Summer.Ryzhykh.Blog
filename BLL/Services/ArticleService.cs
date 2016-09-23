using BLL.Interface.Services;
using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Helpers;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork uow;
        private readonly IArticleRepository articleRepository;

        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
        {
            this.uow = unitOfWork;
            this.articleRepository = articleRepository;
        }

        public void Create(ArticleEntity entity)
        {
            articleRepository.Create(entity.GetDalEntity());
            uow.Commit();
        }

        public void Delete(ArticleEntity entity)
        {
            articleRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }

        public void Edit(ArticleEntity entity)
        {
            articleRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }

        public IEnumerable<ArticleEntity> GetAllByPredicate(Expression<Func<ArticleEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<ArticleEntity, DalArticle>(Expression.Parameter(typeof(DalArticle), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalArticle, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList()
            return articleRepository.GetAllByPredicate(exp2).Select(article => article.GetBllEntity()).ToList();
        }

        public IEnumerable<ArticleEntity> GetAllEntities()
        {
            return articleRepository.GetAll().Select(a => a.GetBllEntity());
        }

        public ArticleEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ArticleEntity GetOneByPredicate(Expression<Func<ArticleEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<ArticleEntity, DalArticle>(Expression.Parameter(typeof(DalArticle), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalArticle, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return articleRepository.GetOneByPredicate(exp2).GetBllEntity();
        }
    }
}
