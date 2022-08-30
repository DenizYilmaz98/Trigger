using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;

namespace Trigger.Data.Concrete
{
    public class TriggerAddedRepository :TriggerDbRepository<TriggerAdded>, ITriggerAddedRepository
    {
        private readonly TriggerDbContext _triggerDbContext;

        public TriggerAddedRepository(TriggerDbContext triggerDbContext):base(triggerDbContext)
        {
            _triggerDbContext = triggerDbContext;
        }
        public void Add(TriggerAdded triggerAdded)
        {
             _triggerDbContext.Add(triggerAdded);
            _triggerDbContext.SaveChanges();

        }
        public void Delete(Guid triggeraddedId)
        {
            var triggerAddedEntity = _triggerDbContext.triggerAddeds.Where(m => m.Id == triggeraddedId).FirstOrDefault();
            _triggerDbContext.triggerAddeds.Remove(triggerAddedEntity);
            _triggerDbContext.SaveChanges();
        }

        public TriggerAdded Get(Guid userId)
        {
            return _triggerDbContext.triggerAddeds.Where(m => m.UserId == userId).FirstOrDefault();
        }

        public List<TriggerAdded> List(Guid userId)
        {
            return _triggerDbContext.triggerAddeds.Where(m => m.UserId == userId).ToList();
        }
    }
}
