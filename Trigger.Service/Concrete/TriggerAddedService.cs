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

        public void Delete(Guid tableAddedId)
        {
            _triggerAddedRepository.Delete(tableAddedId);
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
            triggerAdded.FirstName = triggerAddModelDto.FirstName;
            triggerAdded.LastName = triggerAddModelDto.LastName;
            triggerAdded.BirthDate = triggerAddModelDto.BirthDate;
            triggerAdded.SchoolName= triggerAddModelDto.SchoolName;
            triggerAdded.SchoolStartTime = triggerAddModelDto.SchoolStartTime;
            triggerAdded.SchoolFinishTime = triggerAddModelDto.SchoolFinishTime;
            triggerAdded.Abilities = triggerAddModelDto.Abilities;

            if (triggerAddModelDto.Id==Guid.Empty)
            {
                triggerAdded.Id = Guid.NewGuid();
                triggerAdded.FirstName = triggerAddModelDto.FirstName;
                triggerAdded.LastName = triggerAddModelDto.LastName;
                triggerAdded.BirthDate = triggerAddModelDto.BirthDate;
                triggerAdded.SchoolName = triggerAddModelDto.SchoolName;
                triggerAdded.SchoolStartTime = triggerAddModelDto.SchoolStartTime;
                triggerAdded.SchoolFinishTime = triggerAddModelDto.SchoolFinishTime;
                triggerAdded.Abilities = triggerAddModelDto.Abilities;
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
