using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Concrete;
using Trigger.Data.Model;

namespace Trigger.Data.Abstract
{
   public interface IHomeRepository:ITriggerDbRepository<Home>
    {
    }
}
