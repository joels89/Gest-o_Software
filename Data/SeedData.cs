using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//#define TEST_PAGINATION_PROJECTS;

namespace Gestao_Software.Data
{
    public class SeedData
    {
        internal static void Populate(ProjectContext projectContext){
#if TEST_PAGINATION_PROJECTS
			for (int i = 1; i <= 1000; i++) {
				ProjectContext.Project.Add(
					new Project{

					}
				);
			}

			ProjectContext.SaveChanges();
#endif
		}
	}
}

