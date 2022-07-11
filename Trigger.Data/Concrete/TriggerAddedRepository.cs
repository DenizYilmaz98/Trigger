using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;

namespace Trigger.Data.Concrete
{
    public class TriggerAddedRepository : ITriggerAddedRepository
    {
        private readonly TriggerDbContext _triggerDbContext;

        public TriggerAddedRepository(TriggerDbContext triggerDbContext)
        {
            _triggerDbContext = triggerDbContext;
        }
        public void Add(TriggerAdded triggerAdded)
        {
             _triggerDbContext.Add(triggerAdded);
            _triggerDbContext.SaveChanges();

        }

        public void Delete(Guid userId)
        {
            _triggerDbContext.Remove(userId);
            _triggerDbContext.SaveChanges();
        }

        public TriggerAdded Get(Guid triggerAddedId)
        {
            return _triggerDbContext.triggerAddeds.Where(m=>m.Id== triggerAddedId).FirstOrDefault();
            _triggerDbContext.SaveChanges();
        }

        public List<TriggerAdded> List(Guid triggerAddedId)
        {
            return _triggerDbContext.triggerAddeds.Where(m => m.Id == triggerAddedId).ToList();
            _triggerDbContext.SaveChanges();
        }
    }
}
