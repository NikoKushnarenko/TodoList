using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.DTO;

namespace TodoList.BLL.Interfaces
{
    public interface ITodoTaskService : IService<TodoTaskDTO>
    {
        Task<IEnumerable<TodoTaskDTO>> GetTasks(int peopleId);
    }
}
