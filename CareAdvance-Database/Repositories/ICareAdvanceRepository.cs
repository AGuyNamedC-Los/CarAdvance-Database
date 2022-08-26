using CareAdvance_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareAdvance_Database.Repositories
{
    internal interface ICareAdvanceRepository
    {
        public Task AddUsers(List<User> user);
        public Task<List<User>> GetAllUsers();
    }
}
