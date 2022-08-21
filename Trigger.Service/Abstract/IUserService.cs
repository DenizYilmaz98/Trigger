using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Service.Model.UserModel;

namespace Trigger.Service.Abstract
{
   public interface IUserService
    {
        UserDetailDto Detail(Guid userId); 
       public string Register(RegisterDto registerDto);
        public LoginResponseModel Login(LoginDto loginDto);
        public Guid Save(SaveRegisterDto saveRegisterDto);
        public List<UserListIdViewModelDto> ListUsers();
        GetUserResponseDto Get(Guid id);
    }
}
