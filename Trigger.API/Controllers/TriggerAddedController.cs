using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trigger.API.Model.TriggerAddedModel;
using Trigger.Service.Abstract;

namespace Trigger.API.Controllers
{
    public class TriggerAddedController : ControllerBase
    {
        private readonly ITriggerAddedService _triggerAddedService;

        public TriggerAddedController(ITriggerAddedService triggerAddedService)
        {
            _triggerAddedService = triggerAddedService;
        }
        //public TriggerAddedViewModel Add(TriggerAddedInputModel triggerAddedInputModel)
        //{
        //    var model = _triggerAddedService.Adapt<>();

        //}
      
    }
}
