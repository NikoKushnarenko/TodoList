using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.ModelConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.TodoList
{
    public class TodoListContext : IdentityDbContext<AppUser>
    {
        public DbSet<TodoTask> Tasks { get; set; }
        private IConfiguration _configuration;
        public TodoListContext(DbContextOptions<TodoListContext> options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public static async Task CreateAdminUser(IServiceProvider service)
        {
            UserManager<AppUser> userManager = service.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            string nameAdmin = "Admin";
            string password = "Secret123!";
            string role = "Admin";
            string email = "bancry@gmail.com";
            if (await userManager.FindByNameAsync(nameAdmin) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                AppUser user = new AppUser
                {
                    UserName = nameAdmin,
                    Email = email
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TodoTaskConfiguration());
        }
    }
}
