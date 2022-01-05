//#define TEST_PAGINATION_PROJECTS

using Gestao_Software.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Software.Data
{
    public class SeedData
    {
		private const string ADMIN_EMAIL = "admin@ipg.pt";
		private const string ADMIN_PASS = "Secret123$";

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
		internal static void CreateDefaultAdmin(UserManager<IdentityUser> userManager)
		{
			EnsureUserIsCreatedAsync(userManager, ADMIN_EMAIL, ADMIN_PASS).Wait();
		}

		private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string email, string password)
		{
			var user = await userManager.FindByNameAsync(email);
			if (user != null) return;

			user = new IdentityUser
			{
				UserName = email,
				Email = email
			};

			await userManager.CreateAsync(user, password);
		}

		internal static void PopulateUsers(UserManager<IdentityUser> userManager)
		{

		}
	}
}

