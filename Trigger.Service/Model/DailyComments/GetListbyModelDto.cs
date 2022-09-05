using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Service.Model.DailyComments
{
    public class GetListbyModelDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DailyComments { get; set; }

    }
}
