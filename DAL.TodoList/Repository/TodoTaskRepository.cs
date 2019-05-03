using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.Models;
using DAL.TodoList.Interfaces;

namespace DAL.TodoList.Repository
{
    public class TodoTaskRepository : ITodoTaskRepo
    {
        private TodoListContext _context;
        public TodoTaskRepository(TodoListContext context)
        {
            _context = context;
        }
        public void Add(TodoTask parem)
        {
            _context.Tasks.Add(parem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TodoTask task = FindByIdAsync(id).Result;
            if (task != null)
                _context.Tasks.Remove(task);
        }

        public IQueryable<TodoTask> FindAll(int peopleId)
        {
            return _context.Tasks.Include(task => task.People)
                .Where(task => task.PeopleId == peopleId);
        }

        public Task<TodoTask> FindByIdAsync(int id)
        {
            return _context.Tasks.Include(task => task.People)
                .Where(task => task.Id == id).FirstOrDefaultAsync();
        }

        public void Update(TodoTask param)
        {
            _context.Entry(param).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
