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
using Helpers;

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
            var visitor = new HelperExpressionVisitor<DalArticle, Article>(Expression.Parameter(typeof(Article), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<Article, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var x = context.Set<Article>().Where(exp2).ToList();
            return x.Select(u => u.GetDalEntity());
        }

        public DalArticle GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalArticle GetOneByPredicate(Expression<Func<DalArticle, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public void Update(DalArticle entity)
        {
            throw new NotImplementedException();
        }
    }
}
