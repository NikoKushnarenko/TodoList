using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.Models;


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

        public People GetPeople(int id)
        {
            return _context.Peoples.Where(people => people.Id == id).SingleOrDefault();
        }

        public IEnumerable<TodoTask> GetTasks(int id)
        {
            return _context.Tasks.Where(task => task.People.Id == id);
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
                todoTask.People = GetPeople(todoTask.PeopleId);
                _context.Tasks.Add(todoTask);
                _context.SaveChanges();
            }

        }
    }
}
