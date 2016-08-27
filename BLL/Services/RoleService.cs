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
    public class RoleService : IRoleService
    {
        public void Create(RoleEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(RoleEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(RoleEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleEntity> GetAllByPredicate(Expression<Func<RoleEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public RoleEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RoleEntity GetOneByPredicate(Expression<Func<RoleEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }
    }
}
