using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;

namespace Trigger.Data.Abstract
{
   public interface IDailyCommentsRepository:ITriggerDbRepository<DailyComments>
    {
        DailyComments Get(Guid userId);    
        void Save(DailyComments dailyComments);
        List<DailyComments>List();
        void Delete(Guid id);
    }
}
