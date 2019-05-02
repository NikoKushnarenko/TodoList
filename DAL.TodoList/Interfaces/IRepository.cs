using System.Threading.Tasks;

namespace DAL.TodoList.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<T> FindByIdAsync(int id);
        void Add(T parem);
        void Delete(int id);
        void Update(T param);
    }
}
