#define POPULATE_PROJECTS

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
		private const string ROLE_PROJECT_MANAGER = "gestor_projecto";
		private const string ROLE_CLIENT = "cliente";

		internal static void Populate(ProjectContext projectContext)
		{

#if POPULATE_PROJECTS
			Client client = projectContext.Client.FirstOrDefault();

			if (client == null)
			{
				client = new Client { Nome = "Anonimo", Endereco= "Nao introduzido", Email="Nao introduzido", Telefone="Nao introduzido"};
				projectContext.Add(client);
			}

			if (projectContext.Client.Any())
			{
				return;
			}

			projectContext.Client.Add(
                new Client
				{
					Nome= "Bosch Braga",
					Endereco= "Rua Max Grundig, 35, Lomar 4705 - 820 Braga Portugal",
					Email= "bosch.braga@pt.bosch.com",
					Telefone= "808 100 202",
				}
			);
			projectContext.SaveChanges();

			projectContext.Client.Add(
				new Client
				{
					Nome = "Capgemini Gaia",
					Endereco = "R. de Serpa Pinto 44, 4400-012 Vila Nova de Gaia",
					Email = "capgemini_gaia@capgemini.com",
					Telefone = "210 331 600",
				}
			);
			projectContext.SaveChanges();

			if (projectContext.Project.Any())
			{
				return;
			}

			projectContext.Project.Add(
					new Project
					{
						Name = "Project Bosch",
						BeginDate = new DateTime(2008, 5, 1, 8, 30, 52),
						EndDate = new DateTime(2009, 5, 1, 8, 30, 52),
						ClientId = 1
					}
				);		
			projectContext.SaveChanges();

			projectContext.Project.Add(
				new Project
				{
					Name = "Project Capgemini",
					BeginDate = new DateTime(2009, 3, 1, 8, 30, 52),
					EndDate = new DateTime(2009, 5, 1, 8, 30, 52),
					ClientId = 2
				}
			);
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
			EnsureUserIsCreatedAsync(userManager, "cliente@ipg.pt", "Secret123$", ROLE_CLIENT).Wait();
			EnsureUserIsCreatedAsync(userManager, "gestor@ipg.pt", "Secret123$", ROLE_PROJECT_MANAGER).Wait();
		}
	internal static void CreateRoles(RoleManager<IdentityRole> roleManager)
	{
		EnsureRoleIsCreatedAsync(roleManager, ROLE_ADMINISTRATOR).Wait();
		EnsureRoleIsCreatedAsync(roleManager, ROLE_PROJECT_MANAGER).Wait();
		EnsureRoleIsCreatedAsync(roleManager, ROLE_CLIENT).Wait();
	}
		private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string role)
		{
			if (await roleManager.RoleExistsAsync(role)) return;

			await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}

// Drop-Database -Context ProjectContext
//Update - Database - Context ProjectContext
