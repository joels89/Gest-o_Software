using Gestao_Software.Models;
using Gestao_Software.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestão_Software.ViewModels
{
    public class ClientListViewModel
    {
        public PagingInfo PagingInfo { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        public string NameSearched { get; set; }
    }
}
