using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trigger.UI.Models;

namespace Trigger.UI.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IOptions<AppSettings> _options;


        public AdminController(IOptions<AppSettings>options)
        {
            _options = options;
        }
        [HttpGet("Home")]
        public IActionResult Home()
        {
            return View("~/Views/Admin/Home/Index.cshtml");
        }
        [HttpGet("User")]
        public IActionResult User()
        {
            return View("~/Views/Admin/User/List.cshtml");
        }
        [HttpGet("User/Detail")]
        public IActionResult UserDetail(Guid id)
        {
            return View("~/Views/Admin/User/Detail.cshtml",id);
        }
        [HttpGet("TriggerAdded")]
        public IActionResult TriggerAdded()
        {
            return View("~/Views/Admin/TriggerAdded/List.cshtml");
        }
        [HttpGet("TriggerAdded/Detail")]
        public IActionResult TriggerAddedDetail(Guid id)
        {
            return View("~/Views/Admin/TriggerAdded/Detail.cshtml",id);
        }
        [HttpGet("TriggerAdded/Add")]
        public IActionResult TriggerAddeddAdd()
        {
            return View("~/Views/Admin/TriggerAdded/Detail.cshtml");
        }
        [HttpGet("DailyComments")]
        public IActionResult DailyComments()
        {
            return View("~/Views/Admin/DailyComments/Dc.cshtml");
        }
        [HttpGet("DailyComments/Add")]
        public IActionResult DailyCommentsAdd(Guid id)
        {
            return View("~/Views/Admin/DailyComments/Dc.cshtml",id);
        }
    }
}
