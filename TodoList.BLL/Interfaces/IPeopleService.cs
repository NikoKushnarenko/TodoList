using System;
using System.Collections.Generic;
using System.Text;
using TodoList.BLL.DTO;

namespace TodoList.BLL.Interfaces
{
    public interface IPeopleService : IService<PeopleDTO>
    {
        IEnumerable<PeopleDTO> GetPeoples();
    }
}
