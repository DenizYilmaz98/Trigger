﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Service.Model.DailyCommentsModel 
{ 
   public class GetDailyCommentsResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DailyComment { get; set; }
    }
}
