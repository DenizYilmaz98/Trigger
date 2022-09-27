using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.DailyCommentsModel
{
    public class DailyCommentsListViewModel
    {
        public List<DailyCommentsListModel> List { get; set; }
    }
        public class DailyCommentsListModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string DailyComment { get; set; }
        }
    
}
