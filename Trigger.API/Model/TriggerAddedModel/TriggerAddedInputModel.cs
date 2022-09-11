using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.TriggerAddedModel
{
    public class TriggerAddedInputModel
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
