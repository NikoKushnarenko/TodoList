using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.TodoList.Interfaces;
using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.TodoList.Repository
{
    public class UserRepository : IUserRepo
    {
        private TodoListContext _context;
        public UserRepository(TodoListContext context)
        {
            _context = context;
        }
        public void Add(AppUser parem)
        {
            _context.Users.Add(parem);
        }

        public void Delete(string userId)
        {
            AppUser user = FindByIdAsync(userId).Result;
            if(user != null)
                _context.Users.Remove(user);
        }

        public IQueryable<AppUser> FindAll()
        {
            return _context.Users;
        }

        public  Task<AppUser> FindByIdAsync(string id)
        {
            return _context.Users.SingleOrDefaultAsync(user => user.Id == id);
        }

        public void Update(AppUser param)
        {
            _context.Entry(param).State = EntityState.Modified;
        }
    }
}
