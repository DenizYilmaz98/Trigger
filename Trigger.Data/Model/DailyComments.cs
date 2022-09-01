using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Data.Model
{
  public class DailyComments:BaseEntity
    {
        public Guid UserId { get; set; }
        public string DailyComment { get; set; }
        public Guid UserId { get; set; }
    }
}
