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
    public class CommentRepository : ICommentRepository
    {
        public void Create(DalComment e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalComment e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetAllByPredicate(Expression<Func<DalComment, bool>> f)
        {
            throw new NotImplementedException();
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
