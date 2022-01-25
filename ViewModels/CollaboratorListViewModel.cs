using Gestao_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Software.ViewModels
{
    public class CollaboratorListViewModel
    {
        public IEnumerable<Collaborator> Collaborators { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public string NameSearched { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
