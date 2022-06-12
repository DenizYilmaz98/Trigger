
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Data.Model
{
    [Table("User")]

    public class User:BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email { get; set; }
        public string PasswordEncrypted { get; set; }
        public string PasswordSalt { get; set; }
    }
}
