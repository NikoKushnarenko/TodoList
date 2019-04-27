using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.TodoList.Models;

namespace DAL.TodoList.Repository
{
    public interface IRepository
    {
        People FindPeopleById(int id);
        Task<People> FindPeopleByIdAsync(int id);
        IEnumerable<People> GetPeoples();
        IEnumerable<TodoTask> GetTasks(int id);
        void AddPeople(People peole);
        void AddTask(TodoTask todoTask);

    }
}
