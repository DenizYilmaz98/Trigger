using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;
using Trigger.Service.Model.TriggerAddedModel;

namespace Trigger.Service.Abstract
{
    public interface ITriggerAddedService
    {
        public Guid Save(TriggerAddModelDto triggerAddModelDto);
        GetTriggerAddedResponseDto Get(Guid tableAddedId);
        void Delete(Guid userId);
        List<ListTriggerAddedModelDto> List(Guid userId);
            
    }
}
