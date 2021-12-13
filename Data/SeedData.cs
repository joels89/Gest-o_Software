#define TEST_PAGINATION_PROJECTS

using Gestao_Software.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Software.Data
{
    public class SeedData
    {
        internal static void Populate(ProjectContext projectContext){
#if TEST_PAGINATION_PROJECTS
			Client client = projectContext.Client.FirstOrDefault();

			if (client == null) {
				client = new Client { Name = "Anonymous" };
				projectContext.Add(client);
			}

			for (int i = 1; i <= 1000; i++) {
				projectContext.Project.Add(
					new Project{
						Name = "Project " + i,
						BeginDate = new DateTime(),
						EndDate = new DateTime(),
						Client = client
					}
				);
			}

            projectContext.SaveChanges();
#endif
		}
	}
}

