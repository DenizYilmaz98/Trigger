using Mapster;
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

        public GetTriggerAddedResponseDto Get(Guid id)
        {
            var model = _triggerAddedRepository.Get(id);
            return model.Adapt<GetTriggerAddedResponseDto>();
        }

        public List<ListTriggerAddedModelDto> List(Guid userId)
        {
            List<TriggerAdded> triggerAddeds = _triggerAddedRepository.List(userId);

            return triggerAddeds.Select(m => m.Adapt<ListTriggerAddedModelDto>()).ToList();
        }

        public Guid Save(TriggerAddModelDto triggerAddModelDto)
        {
            var triggerAdded = new TriggerAdded();
            triggerAdded.UserId = triggerAddModelDto.UserId;
            triggerAdded.Comment = triggerAddModelDto.comment;
            triggerAdded.İmage = triggerAddModelDto.image;
            
            if (triggerAddModelDto.Id==Guid.Empty)
            {
                triggerAdded.Id = Guid.NewGuid();
                triggerAdded.Comment = triggerAddModelDto.comment;
                triggerAdded.İmage = triggerAddModelDto.image;
                triggerAdded.Id = triggerAddModelDto.Id;
                _triggerAddedRepository.Insert(triggerAdded);
                
            }
            else
            {
                triggerAdded.Id = triggerAddModelDto.Id;
                _triggerAddedRepository.Update(triggerAdded);
            }
            return triggerAdded.Id;
        }
    }
}
