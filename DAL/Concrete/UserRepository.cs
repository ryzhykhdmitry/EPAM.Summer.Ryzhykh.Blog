using DAL.Interface.Repository;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using ORM;
using Helpers;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;        

        public UserRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("entitiesContex");
            }
            this.context = dbContext;
        }

        public void Create(DalUser e)
        {
            context.Set<User>().Add(e.GetORMEntity());
        }

        public void Delete(DalUser e)
        {
            var user = context.Set<User>().Single(u => u.Id == e.Id);
            var articleId = context.Set<Article>().Where(t => t.AuthorId == user.Id).ToList();
            context.Set<Article>().RemoveRange(articleId);
            context.Set<User>().Remove(e.GetORMEntity());
            context.SaveChanges();
        }

        public IEnumerable<DalUser> GetAll()
        {
            var user = context.Set<User>().Include(u => u.Roles).Include(r => r.Articles).ToList();
            return user.Select(u => u.GetDalEntity());
        }

        public IEnumerable<DalUser> GetAllByPredicate(Expression<Func<DalUser, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<DalUser, User>(Expression.Parameter(typeof(User), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<User, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            var x = context.Set<User>().Include(user => user.Roles).Where(exp2).ToList();
            return x.Select(user => user.GetDalEntity());
        }

        public DalUser GetById(int key)
        {
            var ormUser = context.Set<User>().Include(u => u.Roles).FirstOrDefault(u => u.Id == key);
            return ormUser == null ? null : ormUser.GetDalEntity();
        }

        public DalUser GetOneByPredicate(Expression<Func<DalUser, bool>> f)
        {
            return GetAllByPredicate(f).FirstOrDefault();
        }

        public void Update(DalUser entity)
        {
            context.Set<User>().AddOrUpdate(entity.GetORMEntity());
            context.SaveChanges();
        }
    }
}
