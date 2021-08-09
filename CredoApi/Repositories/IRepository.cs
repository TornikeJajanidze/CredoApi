using CredoApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredoApi.Repositories
{
    public interface IRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(User user);
        bool SaveChanges();
    }
}
