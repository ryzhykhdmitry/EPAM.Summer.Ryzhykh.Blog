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
    public class TagService : ITagService
    {
        public void Create(TagEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TagEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TagEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagEntity> GetAllByPredicate(Expression<Func<TagEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public TagEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TagEntity GetOneByPredicate(Expression<Func<TagEntity, bool>> predicates)
        {
            throw new NotImplementedException();
        }
    }
}
