using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trigger.API.Model.UserModel;
using Trigger.Service.Abstract;
using Trigger.Service.Model.UserModel;
using static Trigger.API.Model.UserModel.UserListIdViewModel;

namespace Trigger.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserContext _userContext;

        public UserController(IUserService userService,UserContext userContext)
        {
            _userService = userService;
            _userContext = userContext;
        }
        [HttpPost("Register")]
        public RegisterViewModel Register(RegisterInputModel registerInputModel)
        {
            var model = registerInputModel.Adapt<RegisterDto>();
            var userId = _userService.Register(model);
            return new RegisterViewModel() { UserId = userId };
        }
        [HttpPost("Login")]
        public LoginViewModel Login(LoginInputModel loginInputModel)
        {
            var model = loginInputModel.Adapt<LoginDto>();
            var response = _userService.Login(model);
            return new LoginViewModel() { Token = response.Token };
        }
        [HttpPost("Save")]
        [Authorize]

        public SaveRegisterViewModel Save(SaveRegisterInputModel saveRegisterInputModel)
        {
            var model = saveRegisterInputModel.Adapt<SaveRegisterDto>();
            model.Id = _userContext.UserId;
            var userId = _userService.Save(model);
            return new SaveRegisterViewModel() { UserId = userId };
        }
        [HttpPost("ListUsers")]
        [Authorize]
        public UserListIdViewModel ListUsers()
        {
            var user = _userService.ListUsers();
            return new UserListIdViewModel()
            {
                List = user.Select(r => r.Adapt<UserListIdRowViewModel>()).ToList()
            };
        }
        [HttpPost("Get")]
        [Authorize]

        public GetUserViewModel Get(Guid id)
        {
            var user = _userService.Get(id);
            return user.Adapt < GetUserViewModel> ();
        }
    } 
}
