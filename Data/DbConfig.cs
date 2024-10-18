using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_management_system_api.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend_management_system_api.Data
{
    public class DbConfig:DbContext
    {
        
           public DbConfig(DbContextOptions<DbConfig> options) : base(options) { }
            public DbSet<Ticket> Tickets { get; set; }
        
    }
}