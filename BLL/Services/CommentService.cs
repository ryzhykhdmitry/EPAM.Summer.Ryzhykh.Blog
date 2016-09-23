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
using Helpers;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;

        public CommentService(IUnitOfWork unitOfWork, ICommentRepository commentRepository)
        {
            this.uow = unitOfWork;
            this.commentRepository = commentRepository;
        }

        public void Create(CommentEntity entity)
        {
            commentRepository.Create(entity.GetDalEntity());
            uow.Commit();
        }

        public void Delete(CommentEntity entity)
        {
            commentRepository.Delete(entity.GetDalEntity());
            uow.Commit();
        }

        public void Edit(CommentEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentEntity> GetAllByPredicate(Expression<Func<CommentEntity, bool>> f)
        {
            var visitor = new HelperExpressionVisitor<CommentEntity, DalComment>(Expression.Parameter(typeof(DalComment), f.Parameters[0].Name));
            var exp2 = Expression.Lambda<Func<DalComment, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            //ToList()
            return commentRepository.GetAllByPredicate(exp2).Select(comment => comment.GetBllEntity()).ToList();
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
