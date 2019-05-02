using DAL.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.TodoList.Interfaces
{
    public interface ITodoTaskRepo : IRepository<TodoTask>
    {
        IQueryable<TodoTask> FindAll(int peopleId);
    }
}
