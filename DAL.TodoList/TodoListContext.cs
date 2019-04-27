using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.ModelConfiguration;
using Microsoft.Extensions.Configuration;

namespace DAL.TodoList
{
    public class TodoListContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
        private IConfiguration _configuration;
        public TodoListContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new TodoTaskConfiguration());
        }
    }
}
