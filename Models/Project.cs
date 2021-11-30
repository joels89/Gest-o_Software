using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestão_Software.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public ICollection<SoftwareRequirement> SoftwareRequirements { get; set; }

        public string BeginDate { get; set; }

        public string EndDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
