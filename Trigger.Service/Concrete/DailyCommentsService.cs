using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;
using Trigger.Service.Abstract;
using Trigger.Service.Model.DailyComments;

namespace Trigger.Service.Concrete
{
    public class DailyCommentsService:IDailyCommentsService
    {
        private readonly IDailyCommentsRepository _dailyCommentsRepository;

        public DailyCommentsService(IDailyCommentsRepository dailyCommentsRepository)
        {
            _dailyCommentsRepository = dailyCommentsRepository;
        }

        public List<GetListbyModelDto> List(Guid userId)
        {
            List<DailyComments> dailyComments = _dailyCommentsRepository.List(userId);
            return dailyComments.Select(m => m.Adapt<GetListbyModelDto>()).ToList(); 
        }

        public Guid Save(DailyCommentsModelDto dailyCommentsModelDto)
        {
            var dailyComments = new DailyComments();
            dailyComments.Id = dailyCommentsModelDto.Id;
            dailyComments.Title = dailyCommentsModelDto.Title;
            dailyComments.DailyComment = dailyCommentsModelDto.DailyComments;
            if (dailyCommentsModelDto.Id==Guid.Empty)
            {
                dailyComments.Id = Guid.NewGuid();
                dailyComments.Title = dailyCommentsModelDto.Title;
                dailyComments.DailyComment = dailyCommentsModelDto.Title;
                _dailyCommentsRepository.Save(dailyComments);
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
