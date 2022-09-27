using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Trigger.API.Attributes;
using Trigger.API.Model.DailyCommentsModel;
using Trigger.API.Model.UserModel;
using Trigger.Service.Abstract;
using Trigger.Service.Model.DailyCommentsModel;

namespace Trigger.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DailyCommentsController : ControllerBase
    {
        private readonly IDailyCommentsService _dailyCommentsService;
        private readonly UserContext _userContext;

        public DailyCommentsController(IDailyCommentsService dailyCommentsService,UserContext userContext)
        {
            _dailyCommentsService = dailyCommentsService;
            _userContext = userContext;
        }
        [HttpPost("Save")]
        [Authorize]
        public DailyCommentsViewModel Save(DailyCommentsInputModel dailyCommentsInputModel)
        {
            var data = dailyCommentsInputModel.Adapt<DailyCommentsModelDto>();
            var dailyCommentsId = _dailyCommentsService.Save(data);
            return new DailyCommentsViewModel { DailyCommentsId = dailyCommentsId };            
        }
        [HttpPost("List")]
        [Authorize]
        public DailyCommentsListViewModel List()
        {
            var DcListResponseModel = _dailyCommentsService.List();
            return new DailyCommentsListViewModel()
            {
                List = DcListResponseModel.Select(m => m.Adapt<DailyCommentsListModel>()).ToList()
            
            };
        }
        [HttpPost("Get")]
        [Authorize]
        public GetDailyCommentsViewModel Get(Guid id)
        {
            var DcGetModel = _dailyCommentsService.Get(id);
            return DcGetModel.Adapt<GetDailyCommentsViewModel>();

        }
        [HttpPost("Delete")]
        [Authorize]

        public void Delete(Guid id)
        {
            _dailyCommentsService.Delete(id);
        }

    }
}
