﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trigger.API.Attributes;
using Trigger.API.Model.TriggerAddedModel;
using Trigger.API.Model.UserModel;
using Trigger.Service.Abstract;
using Trigger.Service.Model.TriggerAddedModel;

namespace Trigger.API.Controllers
{
    public class TriggerAddedController : ControllerBase
    {
        private readonly ITriggerAddedService _triggerAddedService;
        private readonly UserContext _userContext;

        public TriggerAddedController(ITriggerAddedService triggerAddedService,UserContext userContext)
        {
            _triggerAddedService = triggerAddedService;
            _userContext = userContext;
        }
        [HttpPost("Save")]
        [Authorize]
        public TriggerAddedViewModel Save(TriggerAddedInputModel triggerAddedInputModel)
        {
            var model = triggerAddedInputModel.Adapt<TriggerAddModelDto>();
             model.userId = _userContext.UserId;
            var triggerAddedId = _triggerAddedService.Save(model);
            return new TriggerAddedViewModel { TriggerAddedId = triggerAddedId };
        }
        [HttpGet("Get")]
        [Authorize]
        public GetTriggerAddedViewModel Get(Guid id)
        {
            var trAdded = _triggerAddedService.Get(id);
            return trAdded.Adapt<GetTriggerAddedViewModel>();
        }
        [HttpDelete]
        public void Delete(Guid userId)
        {
            _triggerAddedService.Delete(userId);
        }

    }
}
