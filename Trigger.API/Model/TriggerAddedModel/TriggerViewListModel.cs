using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trigger.API.Model.TriggerAddedModel
{
    public class TriggerViewListModel
    {
       public List<TriggerAddedListViewModel> List { get; set; }
    }
    public class TriggerAddedListViewModel
        {
            public Guid Id { get; set; }
            public string Comment { get; set; }
        }
    
}
