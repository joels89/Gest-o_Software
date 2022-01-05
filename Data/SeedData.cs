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

		private const string ROLE_ADMINISTRATOR = "admin";
		private const string ROLE_PRODUCT_MANAGER = "gestor_projeto";
		private const string ROLE_CLIENT = "cliente";
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
			EnsureUserIsCreatedAsync(userManager, ADMIN_EMAIL, ADMIN_PASS, ROLE_ADMINISTRATOR).Wait();
		}

		private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string email, string password, string role)
		{
			var user = await userManager.FindByNameAsync(email);
			if (user == null)
			{

				user = new IdentityUser
			{
				UserName = email,
				Email = email
			};

			await userManager.CreateAsync(user, password);
		}

			if (await userManager.IsInRoleAsync(user, role)) return;
			await userManager.AddToRoleAsync(user, role);
		}
		internal static void PopulateUsers(UserManager<IdentityUser> userManager)
		{
			EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret123$", ROLE_CLIENT).Wait();
			EnsureUserIsCreatedAsync(userManager, "mary@ipg.pt", "Secret123$", ROLE_PRODUCT_MANAGER).Wait();
		}
	internal static void CreateRoles(RoleManager<IdentityRole> roleManager)
	{
		EnsureRoleIsCreatedAsync(roleManager, ROLE_ADMINISTRATOR).Wait();
		EnsureRoleIsCreatedAsync(roleManager, ROLE_PRODUCT_MANAGER).Wait();
		EnsureRoleIsCreatedAsync(roleManager, ROLE_CLIENT).Wait();
	}
		private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string role)
		{
			if (await roleManager.RoleExistsAsync(role)) return;

			await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}

