using System;
using System.Collections.Generic;
using System.Linq;
using ActivityClubPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivityClubPortal.Repositories
{
    public class AdminRepository
    {
        private readonly activityclubportalContext _context;

        public AdminRepository(activityclubportalContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }

        public Admin GetAdminById(int adminId)
        {
            return _context.Admins.Find(adminId);
        }

        public Admin GetAdminByUsername(string username)
        {
            return _context.Admins.FirstOrDefault(a => a.Username == username);
        }


        public void AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void UpdateAdmin(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAdmin(int adminId)
        {
            var admin = _context.Admins.Find(adminId);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
        }
    }
}
