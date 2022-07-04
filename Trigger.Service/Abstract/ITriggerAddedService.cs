using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Service.Model.TriggerAddedModel;

namespace Trigger.Service.Abstract
{
    public interface ITriggerAddedService
    {
        public Guid Save(TriggerAddModelDto triggerAddModelDto);
        GetTriggerAddedResponseDto Guid Get(Guid id);
        void Delete(Guid userId);
    }
}
