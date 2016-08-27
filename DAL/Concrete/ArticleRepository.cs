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

namespace DAL.Concrete
{
    public class ArticleRepository : IArticleRepository
    {
        public void Create(DalArticle e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalArticle e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalArticle> GetAll()
        {
            throw new NotImplementedException();
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
