using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Data.Model
{
    [Table("CommentData")]

    public class CommentData:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Comments { get; set; }
        public User UserData { get; set; }
    }
}
