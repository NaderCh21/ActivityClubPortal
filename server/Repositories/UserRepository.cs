using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ActivityClubPortal.Models;

namespace ActivityClubPortal.Models.Repositories
{
    public class UserRepository
    {
        private readonly activityclubportalContext _context;

        public UserRepository(activityclubportalContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            // Handle the case where the user is not found (optional).
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
