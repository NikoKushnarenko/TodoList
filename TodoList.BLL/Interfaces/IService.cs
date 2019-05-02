using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        void Make(T paramDto);
        Task<T> GetAsync(int id);
        void Dispose();
    }
}
