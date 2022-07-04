using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;
using Trigger.Service.Abstract;
using Trigger.Service.Model.TriggerAddedModel;

namespace Trigger.Service.Concrete
{
   public class TriggerAddedService:ITriggerAddedService
    {
        private readonly ITriggerAddedRepository _triggerAddedRepository;

        public TriggerAddedService(ITriggerAddedRepository triggerAddedRepository)
        {
            _triggerAddedRepository = triggerAddedRepository;
        }

        public void Delete(Guid userId)
        {
            _triggerAddedRepository.Delete(userId);
        }

        

        public Guid Save(TriggerAddModelDto triggerAddModelDto)
        {
            var triggerAdded = new TriggerAdded();
            triggerAdded.Id = triggerAddModelDto.userId;
            triggerAdded.Comment = triggerAddModelDto.comment;
            if (triggerAddModelDto.userId==Guid.Empty)
            {
                triggerAdded.Id = Guid.NewGuid();
                
            }
            return triggerAdded.Id;
        }
    }
}
