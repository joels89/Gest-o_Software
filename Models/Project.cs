using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Software.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [DisplayName("Client")]
      
        public int ClientId { get; set; }
      
        public Client Client { get; set; }

        public ICollection<Collaborator> Collaborators { get; set; }
    }
}
