using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Software.Models
{
    public class SoftwareRequirement
    {
        public int SoftwareRequirementId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
