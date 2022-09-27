using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Trigger.API.Attributes;
using Trigger.API.Model.TriggerAddedModel;
using Trigger.API.Model.UserModel;
using Trigger.Service.Abstract;
using Trigger.Service.Model.TriggerAddedModel;

namespace Trigger.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var triggerAddedId = _triggerAddedService.Save(model);
            return new TriggerAddedViewModel { TriggerAddedId = triggerAddedId };
        }
        [HttpPost("Get")]
        [Authorize]
        public GetTriggerAddedViewModel Get(Guid id)
        {
            var trAdded = _triggerAddedService.Get(id);
            return trAdded.Adapt<GetTriggerAddedViewModel>();
        }
        [HttpPost("List")]
        [Authorize]
        public TriggerAddedViewListModel List()
        {
            var triggermodel = _triggerAddedService.List();
            return new TriggerAddedViewListModel()
            {
                List = triggermodel.Select(m => m.Adapt<TriggerAddedListModel>()).ToList()

            };

        }
        
        [HttpPost("Delete")]
        [Authorize]
        public void Delete(Guid id)
        {
            _triggerAddedService.Delete(id);
        }
        
    }
}
