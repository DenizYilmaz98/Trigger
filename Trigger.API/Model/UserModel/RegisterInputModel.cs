using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trigger.API.Model.UserModel
{
    public class RegisterInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordEncrypted { get; set; }
        public string PasswordSalt { get; set; }
    }
}
