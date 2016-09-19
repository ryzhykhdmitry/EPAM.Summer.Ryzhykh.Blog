using BLL.Interface.Entities;
using Blog.Models.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Infrastructure.Mappers
{
    public static class UserMapper
    {
        public static UserEntity GetBllEntity(this RegisterViewModel user)
        {
            return new UserEntity()
            {
                Id = user.UserId,
                Login = user.UserName,
                Email = user.UserEmail
            };
        }

        public static RegisterViewModel GetMvcEntity(this UserEntity user)
        {
            return new RegisterViewModel()
            {
                UserId = user.Id,
                UserName = user.Login,
                UserEmail = user.Email
            };
        }
    }
}