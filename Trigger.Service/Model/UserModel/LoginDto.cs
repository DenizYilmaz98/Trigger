using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Service.Model.UserModel
{
   public class LoginDto
    {
        public string Email { get; set; }
        public string PasswordEncrypted { get; set; }
    }
}
