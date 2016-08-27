using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        public void Create(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAllByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public DalRole GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalRole GetOneByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
