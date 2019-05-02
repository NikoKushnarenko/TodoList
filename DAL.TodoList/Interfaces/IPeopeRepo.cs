using DAL.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.TodoList.Interfaces
{
    public interface IPeopeRepo : IRepository<People>
    {
        IQueryable<People> FindAll();
        
    }
}
