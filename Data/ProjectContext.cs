using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestao_Software.Models;

namespace Gestao_Software.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Gestao_Software.Models.Project> Project { get; set; }

        public DbSet<Gestao_Software.Models.SoftwareRequirement> SoftwareRequirement { get; set; }

        public DbSet<Gestao_Software.Models.Client> Client { get; set; }

        public DbSet<Gestao_Software.Models.Collaborator> Collaborator { get; set; }
    }
}
