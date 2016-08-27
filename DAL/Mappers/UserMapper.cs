using DAL.Interface.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class UserMapper
    {
        public static DalUser GetDalEntity(this User ormEntity)
        {
            return new DalUser()
            {
                Id = ormEntity.Id,
                Login = ormEntity.Login,
                Email = ormEntity.Email,
                Password = ormEntity.Password,
                RegistrationDate = ormEntity.RegistrationDate,
                BirthDate = ormEntity.BirthDate,
                Blocked = ormEntity.Blocked,
                Avatar = ormEntity.Avatar,
                About = ormEntity.About,
                Roles = ormEntity.Roles.Select(r => r.GetDalEntity()).ToList()
            };
        }

        public static User GetORMEntity(this DalUser dalEntity)
        {
            if (dalEntity == null)
                return null;
            return new User()
            {
                Id = dalEntity.Id,
                Login = dalEntity.Login,
                Email = dalEntity.Email,
                Password = dalEntity.Password,
                RegistrationDate = dalEntity.RegistrationDate,
                BirthDate = dalEntity.BirthDate,
                Blocked = dalEntity.Blocked,
                Avatar = dalEntity.Avatar,
                About = dalEntity.About,
                Roles = 
                    dalEntity.Roles != null 
                        ? dalEntity.Roles.Select(r => r.GetORMEntity()).ToList() 
                        : null
            };
        }
    }
}
