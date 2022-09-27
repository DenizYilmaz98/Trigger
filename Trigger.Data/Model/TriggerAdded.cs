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
