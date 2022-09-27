using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;

namespace Trigger.Data.Concrete
{
    public class DailyCommentsRepository : TriggerDbRepository<DailyComments>, IDailyCommentsRepository
    {
        private readonly TriggerDbContext _triggerDbContext;

        public DailyCommentsRepository(TriggerDbContext triggerDbContext) : base(triggerDbContext)
        {
            _triggerDbContext = triggerDbContext;
        }

        public DailyComments Get(Guid userId)
        {
        return  _triggerDbContext.dailyComments.FirstOrDefault();
                }

        public List<DailyComments> List()
        {
         return _triggerDbContext.dailyComments.ToList();

        }

        public void Save(DailyComments dailyComments)
        {
            _triggerDbContext.dailyComments.Add(dailyComments);
            _triggerDbContext.SaveChanges();
        }
       public void Delete(Guid id)
        {
            var entity = _triggerDbContext.dailyComments.Where(m => m.Id == id).FirstOrDefault();
            _triggerDbContext.dailyComments.Remove(entity);
            _triggerDbContext.SaveChanges();

        }
    }
}
