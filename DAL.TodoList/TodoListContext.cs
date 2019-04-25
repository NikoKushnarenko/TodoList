using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.TodoList
{
    public class TodoListContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
        public TodoListContext(DbContextOptions<TodoListContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
