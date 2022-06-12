using System;
using System.Collections.Generic;
using System.Linq;
using Trigger.Data.Abstract;
using Trigger.Data.Concrete;
using Trigger.Data.Model;

namespace Trigger.Data.Abstract
{
    public class UserRepository : TriggerDbRepository<User>, IUserRepository
    {
        private readonly TriggerDbContext _triggerDbContext;

        public UserRepository(TriggerDbContext triggerDbContext) : base(triggerDbContext)
        {
            _triggerDbContext = triggerDbContext;
        }

        public User Get(Guid id)
        {
            return _triggerDbContext.Users.Where(m => m.Id == m.Id).FirstOrDefault();
                
        }

        public List<User> ListUsers()
        {
            return _triggerDbContext.Users.Where(m=>m.Id==m.Id).ToList();
        }
    }
}
