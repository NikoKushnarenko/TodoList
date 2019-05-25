using DAL.TodoList.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.TodoList.Interfaces
{
    public interface ITodoTaskRepo : IRepository<TodoTask>
    {
        Task<TodoTask> FindByIdAsync(int id);
        IQueryable<TodoTask> FindAll(string userId);
        void Delete(int id);
    }
}
