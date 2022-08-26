using CareAdvance_Database.Data;
using CareAdvance_Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareAdvance_Database.Repositories
{
    internal class CareAdvanceRepository : ICareAdvanceRepository
    {
        private CareAdvanceContext _careAdvanceContext;
        public CareAdvanceRepository(CareAdvanceContext careAdvanceContext)
        {
            _careAdvanceContext = careAdvanceContext;
        }

        public async Task AddUsers(List<User> users)
        {
            foreach (User user in users)
            {
                await _careAdvanceContext.User.AddAsync(user);
            }

            await _careAdvanceContext.SaveChangesAsync();
            
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _careAdvanceContext.User.ToListAsync();
        }
    }
}
