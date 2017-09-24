using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPPools.Models
{
    public class UserPool
    {
      
        public User User { get; }
        public UserPool(User user, Pool pool)
        {
            User = user;
            Pool = pool;

        }
        public Pool Pool { get;  }
    }
}