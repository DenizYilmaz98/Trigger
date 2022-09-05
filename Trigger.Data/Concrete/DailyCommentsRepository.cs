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

        public List<DailyComments> List(Guid userId)
        {
         return _triggerDbContext.dailyComments.Where(m=>m.Id==userId).ToList();

        }

        public void Save(DailyComments dailyComments)
        {
            _triggerDbContext.dailyComments.Add(dailyComments);
            _triggerDbContext.SaveChanges();
        }
    }
}
