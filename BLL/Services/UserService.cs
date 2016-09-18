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
using System.IO;
using Helpers;
using System.Web.Helpers;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.uow = unitOfWork;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public void Create(UserEntity user)
        {
            user.Password = Crypto.HashPassword(user.Password);
            user.Roles = new List<RoleEntity> { roleRepository.GetById(2).GetBllEntity() };
            userRepository.Create(user.GetDalEntity());
            if (!(Directory.Exists(user.Login)))
            {
                try
                {
                    Directory.CreateDirectory(user.Login);
                }
                catch (Exception error)
                {

                }
            }
            //if (ReferenceEquals(user, null))
            //    throw new ArgumentNullException();

            //userRepository.Create(user.GetDalEntity());
            uow.Commit();
        }

        public void Delete(UserEntity entity)
        {
            userRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }

        public void Edit(UserEntity entity)
        {
            userRepository.Update(entity.GetDalEntity());
            uow.Commit();
        }

        public IEnumerable<UserEntity> GetAllByPredicate(Expression<Func<UserEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<UserEntity, DalUser>(Expression.Parameter(typeof(DalUser), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalUser, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList()
            return userRepository.GetAllByPredicate(exp2).Select(user => user.GetBllEntity()).ToList();
        }

        public IEnumerable<UserEntity> GetAllEntities()
        {
            return userRepository.GetAll().Select(u => u.GetBllEntity()).ToList();
        }

        public UserEntity GetById(int id)
        {
            return userRepository.GetById(id).GetBllEntity();
        }

        public UserEntity GetOneByPredicate(Expression<Func<UserEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<UserEntity, DalUser>(Expression.Parameter(typeof(DalUser), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalUser, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return userRepository.GetOneByPredicate(exp2).GetBllEntity();
        }
    }
}
