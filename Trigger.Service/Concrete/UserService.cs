using Mapster;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Trigger.Data.Abstract;
using Trigger.Data.Model;
using Trigger.Service.Abstract;
using Trigger.Service.Model.UserModel;
using TriggerCore;

namespace Trigger.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
        }

        public UserDetailDto Detail(Guid userId)
        {
            var detail = _userRepository.GetById(userId);
            return new UserDetailDto()
            {
                UserId = detail.Id,
                FirstName=detail.FirstName,
                LastName=detail.LastName
            };
        }

        public GetUserResponseDto Get( Guid id)
        {
           var user = _userRepository.Get( id);
            return user.Adapt<GetUserResponseDto>();
        }

        public List<UserListIdViewModelDto> ListUsers()
        {
           List<User>users = _userRepository.ListUsers();
            return users.Select(m => m.Adapt<UserListIdViewModelDto>()).ToList();
        }

        public LoginResponseModel Login(LoginDto loginDto)
        {
            
                var user = _userRepository.GetAll(x => x.Email == loginDto.Email).FirstOrDefault();
                string PasswordEncryptedEncrypted = string.Empty;
                using (MD5 md5 = MD5.Create())
                {
                    PasswordEncryptedEncrypted = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(loginDto.PasswordEncrypted + user.PasswordSalt)));
                }
                if (user.PasswordEncrypted == PasswordEncryptedEncrypted)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_options.Value.TokenKey);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim("UserId", user.Id.ToString()),
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return new LoginResponseModel() { Token = tokenHandler.WriteToken(token)};

                }
                return null;
            
        }

        public string Register(RegisterDto registerDto)
        {
            var user = new User();
            user.Id = new Guid();
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.PasswordSalt = Guid.NewGuid().ToString();
            using (MD5 md5 = MD5.Create())
            {
                var addPassword = registerDto.Password + user.PasswordSalt;
                user.PasswordEncrypted = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(addPassword)));
            }

                _userRepository.Insert(user);
            return user.Id.ToString();
        }

        public Guid Save(SaveRegisterDto saveRegisterDto)
        {
            var user = new User();
            user.FirstName = saveRegisterDto.FirstName;
            user.LastName = saveRegisterDto.LastName;
            user.PasswordEncrypted = Guid.NewGuid().ToString();
            using (MD5 md5 = MD5.Create())
            {
                var addPassword = saveRegisterDto.Password + user.PasswordSalt;
                user.PasswordEncrypted = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(addPassword)));

            }
            user.Id = saveRegisterDto.Id;

            if (saveRegisterDto.Id==Guid.Empty)
            {
                user.Id = Guid.NewGuid();
                _userRepository.Insert(user);
            }
            else
            {
                user.Id = saveRegisterDto.Id;
                _userRepository.Update(user);
            }
            return user.Id;
        }
    }
}
