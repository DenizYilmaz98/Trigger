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
        public void Save(TriggerAdded triggerAdded);
        public void Delete(Guid triggeraddedId);
        TriggerAdded Get(Guid triggerAddedId);
        List<TriggerAdded> List();
    }
}
