using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.TriggerAddedModel
{
    public class TriggerAddedInputModel
    {
        public Guid Id { get; set; }
        public string comment { get; set; }
        public string image { get; set; }
    }
}
