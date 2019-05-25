using System.Threading.Tasks;

namespace DAL.TodoList.Interfaces
{
    public interface IRepository<T> where T: class
    {

        void Add(T parem);
        void Update(T param);
    }
}
