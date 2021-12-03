using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestão_Software.Models;

namespace Gestão_Software.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Gestão_Software.Models.Project> Project { get; set; }

        public DbSet<Gestão_Software.Models.Client> Client { get; set; }
    }
}
