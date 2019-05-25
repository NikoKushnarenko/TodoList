using DAL.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TodoList.Interfaces
{
    public interface IUserRepo : IRepository<AppUser>
    {
        Task<AppUser> FindByIdAsync(string userId);
        IQueryable<AppUser> FindAll();
        void Delete(string userId);
    }
}
