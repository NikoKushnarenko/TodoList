using AutoMapper;
using DAL.TodoList.Interfaces;
using DAL.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.DTO;
using TodoList.BLL.Infrastructure;
using TodoList.BLL.Interfaces;
using System.Linq;
namespace TodoList.BLL.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public Exception ValidExaption { get; private set; }

        public TodoTaskService(IUnitOfWork unit, IMapper mapper)
        {
            _unitOfWork = unit;
            _mapper = mapper;
        }
        public async Task<TodoTaskDTO> GetAsync(int id)
        {
            
            if(id > 0)
            {
                TodoTask task = await _unitOfWork.TodoTaskRepository.FindByIdAsync(id);
                TodoTaskDTO res = _mapper.Map<TodoTaskDTO>(task);
                return res;
            }
            throw new ValidationException("Not found task", "");
        }

        public async Task<IEnumerable<TodoTaskDTO>> GetTasks(int peopleId)
        {
            IEnumerable<TodoTaskDTO> res;
            if(peopleId > 0)
            {
                People person = await _unitOfWork.PeopleRepository.FindByIdAsync(peopleId);
                if (person != null)
                {
                    res = _unitOfWork.TodoTaskRepository.FindAll(peopleId).Select(men => _mapper.Map<TodoTaskDTO>(men)).ToList();
                    return res;
                }
            }
            throw new ValidationException("Not found task by id","");
        }

        public void Make(TodoTaskDTO paramDto)
        {
            if(paramDto != null)
            {
                TodoTask newTask = _mapper.Map<TodoTask>(paramDto);
                _unitOfWork.TodoTaskRepository.Add(newTask);
                _unitOfWork.Save();
            }
            throw new ValidationException("Not right data", "");
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
