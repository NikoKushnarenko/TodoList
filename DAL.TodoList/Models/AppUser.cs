using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TodoList.Models
{
    public class AppUser : IdentityUser
    {
        public List<TodoTask> Tasks { get; set; }
    }
}
