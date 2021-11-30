using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestão_Software.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
