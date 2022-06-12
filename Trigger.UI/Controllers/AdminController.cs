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
        public IActionResult Index()
        {
            return View();
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
      

    }
}
