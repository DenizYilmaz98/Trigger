using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;

namespace Trigger.Data.Abstract
{
    public interface ITriggerAddedRepository
    {
        void Add(TriggerAdded triggerAdded);
        void Delete(Guid userId);
    }
}
