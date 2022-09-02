using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.DailyCommentsModel
{
    public class DailyCommentsInputModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DailyComments { get; set; }
    }
}
