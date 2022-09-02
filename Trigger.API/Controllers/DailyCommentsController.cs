using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trigger.API.Model.DailyCommentsModel;
using Trigger.API.Model.UserModel;
using Trigger.Service.Abstract;
using Trigger.Service.Model.DailyComments;

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
        
        public DailyCommentsViewModel Save(DailyCommentsInputModel dailyCommentsInputModel)
        {
            var data = dailyCommentsInputModel.Adapt<DailyCommentsModelDto>();
            data.Id = _userContext.UserId;
            var dailyCommentsId = _dailyCommentsService.Save(data);
            return new DailyCommentsViewModel { DailyCommentsId = dailyCommentsId };



            
        }
    }
}
