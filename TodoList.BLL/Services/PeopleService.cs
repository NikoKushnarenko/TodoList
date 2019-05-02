using AutoMapper;
using DAL.TodoList.Interfaces;
using DAL.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BLL.DTO;
using TodoList.BLL.Infrastructure;
using TodoList.BLL.Interfaces;
using System.Linq;

namespace TodoList.BLL.Services
{
    public class PeopleService : IPeopleService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PeopleService(IUnitOfWork unit, IMapper mapper)
        {
            _unitOfWork = unit;
            _mapper = mapper;
        }
        public async Task<PeopleDTO> GetAsync(int id)
        {
            People res;
            if (id < 0)
            {
                res = await _unitOfWork.PeopleRepository.FindByIdAsync(id);
                if (res != null)
                    return _mapper.Map<PeopleDTO>(res);
                   
            }
            throw new ValidationException("Invalid id param", ""); ;
        }

        public IEnumerable<PeopleDTO> GetPeoples()
        {
            List<People> people = _unitOfWork.PeopleRepository.FindAll().ToList();
            IEnumerable<PeopleDTO> res = people.Select(person => _mapper.Map<PeopleDTO>(person));
            return res;
        }

        public void Make(PeopleDTO paramDto)
        {
            if(paramDto != null)
            {
                People person = _mapper.Map<People>(paramDto);
                _unitOfWork.PeopleRepository.Add(person);
            }
            _unitOfWork.Save();
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
