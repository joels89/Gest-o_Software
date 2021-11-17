using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestão_Software.Models;

    public class SoftwareRequirementContext : DbContext
    {
        public SoftwareRequirementContext (DbContextOptions<SoftwareRequirementContext> options)
            : base(options)
        {
        }

        public DbSet<Gestão_Software.Models.SoftwareRequirement> SoftwareRequirement { get; set; }
    }
