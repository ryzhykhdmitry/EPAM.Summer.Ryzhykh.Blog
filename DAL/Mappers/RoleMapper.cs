using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class RoleMapper
    {
        public static DalRole GetDalEntity(this Role ormEntity)
        {
            return new DalRole()
            {
                Id = ormEntity.Id,
                Name = ormEntity.Name,                
            };
        }

        public static Role GetORMEntity(this DalRole dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new Role()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name
            };
        }
    }
}
