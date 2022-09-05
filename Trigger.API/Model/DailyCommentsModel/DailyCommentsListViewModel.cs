using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.DailyCommentsModel
{
    public class DailyCommentsListViewModel
    {
        public List<DailyCommentsAddedViewModel>List{get;set;}
  
        public class DailyCommentsAddedViewModel
        {
            public Guid Id { get; set; }
            public string DailyComment { get; set; }
        }
    }
}
