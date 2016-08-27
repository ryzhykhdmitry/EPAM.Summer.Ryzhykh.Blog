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
    public class TagRepository : ITagRepository
    {
        public void Create(DalTag e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTag e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTag> GetAllByPredicate(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public DalTag GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalTag GetOneByPredicate(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTag entity)
        {
            throw new NotImplementedException();
        }
    }
}
