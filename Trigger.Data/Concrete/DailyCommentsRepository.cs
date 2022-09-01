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
        public DailyCommentsRepository(TriggerDbContext triggerDbContext) : base(triggerDbContext)
        {
        }
        public DailyCommentsViewModel Save()
    }
}
