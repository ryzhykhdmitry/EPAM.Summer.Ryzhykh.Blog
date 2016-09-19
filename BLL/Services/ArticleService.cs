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
            throw new NotImplementedException();
        }

        public void Edit(ArticleEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleEntity> GetAllByPredicate(Expression<Func<ArticleEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleEntity> GetAllEntities()
        {
            return articleRepository.GetAll().Select(a => a.GetBllEntity());
        }

        public ArticleEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ArticleEntity GetOneByPredicate(Expression<Func<ArticleEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }
    }
}
