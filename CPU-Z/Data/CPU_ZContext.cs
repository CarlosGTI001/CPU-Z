using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CPU_Z.Models;

namespace CPU_Z.Data
{
    public class CPU_ZContext : DbContext
    {
        public CPU_ZContext (DbContextOptions<CPU_ZContext> options)
            : base(options)
        {
        }

        public DbSet<CPU_Z.Models.CPU_Z_Intel> CPU_Z_Intel { get; set; }

        public DbSet<CPU_Z.Models.CPU_Z_AMD> CPU_Z_AMD { get; set; }
    }
}
