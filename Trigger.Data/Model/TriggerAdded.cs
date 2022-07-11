using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Data.Model
{
    [Table("TriggerAdded")]
    public class TriggerAdded:BaseEntity
    {

        public string Comment { get; set; }

    }
}
