using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Service.Model.TriggerAddedModel
{
    public class ListTriggerAddedModelDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string SchoolName { get; set; }
        public string SchoolStudyName { get; set; }
        public DateTime SchoolStartTime { get; set; }
        public DateTime SchoolFinishTime { get; set; }
        public string Abilities { get; set; }
    }
}
