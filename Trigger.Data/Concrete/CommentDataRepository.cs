using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Model;

namespace Trigger.Data.Concrete
{
    public class CommentDataRepository : TriggerDbRepository<CommentData>
    {
        public CommentDataRepository(TriggerDbContext triggerDbContext) : base(triggerDbContext)
        { 
        }
    }
}
