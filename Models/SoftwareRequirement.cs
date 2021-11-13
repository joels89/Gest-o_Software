using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestão_Software.Models
{
    public class SoftwareRequirement
    {
        public int SoftwareReqId { get; set; }

        [Required]
        [StringLength(256)]
        public string SoftwareReqTitle { get; set; }

        public string SoftwareReqDescription { get; set; }

        public Project Project { get; set; }

    }
}
