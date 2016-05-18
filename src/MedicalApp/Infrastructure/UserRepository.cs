using MedicalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Infrastructure
{
    public class UserRepository
    {
        ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<ApplicationUser> List()
        {
            return _db.Users;
        }
    }
}
