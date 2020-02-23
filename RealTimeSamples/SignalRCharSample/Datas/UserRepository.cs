using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRCharSample.Datas
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User { ID = 1, UserName = "admin1@xcode.me", Password = "www.xcode.me" });
            users.Add(new User { ID = 1, UserName = "admin2@xcode.me", Password = "www.xcode.me" });
            return users;
        }
    }
}
