using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class TagMapper
    {
        public static DalTag GetDalEntity(this Tag ormEntity)
        {
            return new DalTag()
            {
                Id = ormEntity.Id,
                Name = ormEntity.Name,
            };
        }

        public static Tag GetORMEntity(this DalTag dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new Tag()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name
            };
        }
    }
}
