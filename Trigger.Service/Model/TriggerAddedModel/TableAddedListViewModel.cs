using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Service.Model.TriggerAddedModel
{
    public class TableAddedListViewModel
    {
        public List<TableAddedListViewRowModel> List { get; set; }
        public class TableAddedListViewRowModel
        {
            public Guid Id { get; set; }
            public string comment { get; set; }

        }

    }
}
