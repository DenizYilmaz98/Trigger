using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;
using Trigger.Service.Abstract;
using Trigger.Service.Model.DailyCommentsModel;

namespace Trigger.Service.Concrete
{
    public class DailyCommentsService:IDailyCommentsService
    {
        private readonly IDailyCommentsRepository _dailyCommentsRepository;

        public DailyCommentsService(IDailyCommentsRepository dailyCommentsRepository)
        {
            _dailyCommentsRepository = dailyCommentsRepository;
        }
        public void Delete(Guid id)
        {
            _dailyCommentsRepository.Delete(id);
        }
        public GetDailyCommentsResponseDto Get(Guid id)
        {
            var dailycommentsresponse = _dailyCommentsRepository.Get(id);
            return dailycommentsresponse.Adapt<GetDailyCommentsResponseDto>();
   
        }

        public List<GetListbyModelDto> List()
        {
            List<DailyComments> dailyComments = _dailyCommentsRepository.List();
            return dailyComments.Select(m => m.Adapt<GetListbyModelDto>()).ToList(); 
        }

        public Guid Save(DailyCommentsModelDto dailyCommentsModelDto)
        {
            var dailyComments = new DailyComments();
            dailyComments.Title = dailyCommentsModelDto.Title;
            dailyComments.DailyComment = dailyCommentsModelDto.DailyComment;

            if (dailyCommentsModelDto.Id==Guid.Empty)
            {
                dailyComments.Id = Guid.NewGuid();
                _dailyCommentsRepository.Insert(dailyComments);
            }
            else
            {
                dailyComments.Id = dailyCommentsModelDto.Id;
                _dailyCommentsRepository.Update(dailyComments);
            }
            return dailyComments.Id;

        }

    }
}
