using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;

namespace Trigger.Data.Concrete
{
   public  class TriggerDbRepository<TEntity>:ITriggerDbRepository<TEntity>where TEntity: class, new()
    {
        private readonly TriggerDbContext _triggerDbContext;

        public TriggerDbRepository(TriggerDbContext triggerDbContext)
        {
            _triggerDbContext = triggerDbContext;
        }

        public TEntity GetById(Guid id)
        {

            return _triggerDbContext.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _triggerDbContext.Set<TEntity>().ToList();
            }
            else
            {
                return _triggerDbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            _triggerDbContext.Set<TEntity>().Add(entity);
            _triggerDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _triggerDbContext.Set<TEntity>().Update(entity);
            _triggerDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _triggerDbContext.Set<TEntity>().Remove(entity);
            _triggerDbContext.SaveChanges();
        }
       
        public void Delete(Guid id)
        {
            var entity = _triggerDbContext.Set<TEntity>().Find(id);
            _triggerDbContext.Set<TEntity>().Remove(entity);
            _triggerDbContext.SaveChanges();
        }
        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {

            var query = _triggerDbContext.Set<TEntity>().Where(filter);
            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        }

        public bool Any(Expression<Func<TEntity, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}


