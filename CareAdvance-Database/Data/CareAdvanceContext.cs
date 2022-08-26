using CareAdvance_Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareAdvance_Database.Data
{
    public class CareAdvanceContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LTUS75589\SQLEXPRESS;Database=CareAdvance;Trusted_Connection=True;");
        }
    }
}
