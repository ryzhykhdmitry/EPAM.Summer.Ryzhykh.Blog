using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int key);

        IEnumerable<TEntity> GetAllByPredicate(Expression<Func<TEntity, bool>> f);

        TEntity GetOneByPredicate(Expression<Func<TEntity, bool>> f);

        void Create(TEntity e);

        void Delete(TEntity e);

        void Update(TEntity entity);
    }
}
