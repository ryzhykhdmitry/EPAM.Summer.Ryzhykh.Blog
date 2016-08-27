using DAL.Interface.DTO;
using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class TagMapper
    {
        public static TagEntity GetBllEntity(this DalTag dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new TagEntity()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name
            };
        }

        public static DalTag GetDalEntity(this TagEntity bllEntity)
        {
            return new DalTag()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
            };
        }
    }
}
