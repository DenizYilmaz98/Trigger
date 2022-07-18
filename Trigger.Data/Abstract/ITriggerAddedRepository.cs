using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;

namespace Trigger.Data.Abstract
{
    public interface ITriggerAddedRepository:ITriggerDbRepository<TriggerAdded>
    {
        void Add(TriggerAdded triggerAdded);
        void Delete(Guid userId);
        //TriggerAdded Get(Guid triggerAddedId);
        List<TriggerAdded> List(Guid triggerAddedId);
    }
}
