using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestao_Software.Models;

namespace Gestao_Software.ViewModels
{
    public class ProjectsListViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
      
        public PagingInfo PagingInfo { get; set; }

        public IEnumerable<Client>Clients { get; set; }
        
        public string NameSearched { get; set; }

    }
}
