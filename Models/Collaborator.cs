using Gestao_Software.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Software.Models
{
    public class Collaborator : Controller
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Funcao { get; set; }

        public byte[] Photo { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
