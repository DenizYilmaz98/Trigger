using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Data.Model
{
 [Table("DailyComments")]
    public class DailyComments:BaseEntity
    {
        public string Title { get; set; }

        public string DailyComment { get; set; }
    }
}
