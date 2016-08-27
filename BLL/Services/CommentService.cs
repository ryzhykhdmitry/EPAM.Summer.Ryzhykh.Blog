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
    public class CommentService : ICommentService
    {
        public void Create(CommentEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CommentEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(CommentEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentEntity> GetAllByPredicate(Expression<Func<CommentEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public CommentEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CommentEntity GetOneByPredicate(Expression<Func<CommentEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }
    }
}
