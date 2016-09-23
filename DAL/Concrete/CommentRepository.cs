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
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext context;

        public CommentRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("entitiesContex");
            }
            this.context = dbContext;
        }

        public void Create(DalComment e)
        {
            context.Set<Comment>().Add(e.GetORMEntity());
        }

        public void Delete(DalComment e)
        {
            var comment = context.Set<Comment>().Where(a => a.Id == e.Id).FirstOrDefault();
            if (comment != null)
            {
                context.Set<Comment>().Remove(comment);            
            }
            context.SaveChanges();
        }

        public IEnumerable<DalComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetAllByPredicate(Expression<Func<DalComment, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalComment, Comment>(Expression.Parameter(typeof(Comment), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<Comment, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var x = context.Set<Comment>().Where(exp2).ToList();
            return x.Select(u => u.GetDalEntity());
        }

        public DalComment GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalComment GetOneByPredicate(Expression<Func<DalComment, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalComment entity)
        {
            throw new NotImplementedException();
        }
    }
}
