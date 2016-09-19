using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContext context;

        public ArticleRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("entitiesContex");
            }
            this.context = dbContext;
        }

        public void Create(DalArticle e)
        {
            context.Set<Article>().Add(e.GetORMEntity());
        }

        public void Delete(DalArticle e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalArticle> GetAll()
        {
            var article = context.Set<Article>().Include(u => u.Comments).Include(u => u.Tags).ToList();
            return article.Select(u => u.GetDalEntity());
        }

        public IEnumerable<DalArticle> GetAllByPredicate(Expression<Func<DalArticle, bool>> f)
        {
            throw new NotImplementedException();
        }

        public DalArticle GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalArticle GetOneByPredicate(Expression<Func<DalArticle, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalArticle entity)
        {
            throw new NotImplementedException();
        }
    }
}
