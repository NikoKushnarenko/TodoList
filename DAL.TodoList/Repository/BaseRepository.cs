using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.TodoList.Repository
{
    public class BaseRepository: IRepository
    {
        private TodoListContext _context;

        public BaseRepository(TodoListContext context)
        {
            _context = context;
        }
        public IEnumerable<People> GetPeoples()
        {
            return _context.Peoples;
        }

        public People FindPeopleById(int id)
        {
            return _context.Peoples.SingleOrDefault(people => people.Id == id);
        }
        public async Task<People> FindPeopleByIdAsync(int id)
        {
            return await _context.Peoples.SingleOrDefaultAsync(people => people.Id == id);
        }

        public IEnumerable<TodoTask> GetTasks(int id)
        {
            return _context.Tasks.Include(task => task.People)
                 .Where(task => task.PeopleId == id).ToList();
        }

        public void AddPeople(People peole)
        {
            _context.Peoples.Add(peole);
            _context.SaveChanges();
        }

        public void AddTask(TodoTask todoTask)
        {
            if (todoTask.PeopleId != 0)
            {
                todoTask.People = FindPeopleById(todoTask.PeopleId);
                _context.Tasks.Add(todoTask);
                _context.SaveChanges();
            }

        }
    }
}
