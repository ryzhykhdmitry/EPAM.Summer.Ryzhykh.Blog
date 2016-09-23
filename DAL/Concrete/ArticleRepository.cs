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
using System.Data.Entity.Migrations;

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
            var article = context.Set<Article>().Where(a => a.Id == e.Id).FirstOrDefault();
            if (article != null)
            {
                context.Set<Article>().Remove(article);            
            }
            context.SaveChanges();
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
            //context.Set<Article>().AddOrUpdate(entity.GetORMEntity());  
            var article = context.Set<Article>().Where(a => a.Id == entity.Id).FirstOrDefault();
            context.Set<Article>().Attach(article);
            //if (article != null)
            //{
            //context.Set<Article>().AddOrUpdate();
            if (entity.Title != null) article.Title = entity.Title;
            if (entity.Text != null) article.Text = entity.Text;
            if (entity.PublicationDate != null) article.PublicationDate = entity.PublicationDate;
            if (entity.CountLikes != null) article.CountLikes = entity.CountLikes;


             //article = entity.GetORMEntity();
             //   context.Entry(article).State = EntityState.Modified;
                context.SaveChanges();
            //}
            
        }
    }
}
