using CredoApi.Context;
using CredoApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredoApi.Repositories
{
    public class UserRepository : IRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;

        }
        public User CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _context.Users.Add(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            _context.Users.Remove(user);
            return user;


        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public User UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
                return null;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.PhoneNumber = user.PhoneNumber;
            return existingUser;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }
    }
}
