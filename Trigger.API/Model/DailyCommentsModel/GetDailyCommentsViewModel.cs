using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.DailyCommentsModel
{
    public class GetDailyCommentsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string DailyComment { get; set; }
    
    }
}
