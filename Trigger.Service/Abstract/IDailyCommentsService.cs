using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Service.Model.DailyComments;

namespace Trigger.Service.Abstract
{
   public interface IDailyCommentsService
    {
        public Guid Save(DailyCommentsModelDto dailyCommentsModelDto);
    }
}
