using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;
using Trigger.Service.Model.DailyCommentsModel;

namespace Trigger.Service.Abstract
{
   public interface IDailyCommentsService
    {
        public Guid Save(DailyCommentsModelDto dailyCommentsModelDto);
        GetDailyCommentsResponseDto Get(Guid DailyCommentsId);
      
         List<GetListbyModelDto> List();
        void Delete(Guid id);

    }
}
