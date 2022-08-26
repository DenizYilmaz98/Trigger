using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Service.Model.TriggerAddedModel
{
    public class TriggerAddModelDto
    {
        public  Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string comment { get; set; }
        public string image { get; set; }
    }
}
