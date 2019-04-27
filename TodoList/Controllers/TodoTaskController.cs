using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.TodoList.Models;
using DAL.TodoList.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    public class TodoTaskController : ControllerBase
    {
        private IRepository _repo;
        private IMapper _mapper;
        public TodoTaskController(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(_repo.GetTasks(id));
        }
        [HttpPost]
        public async void AddTask([FromBody] TodoTaskViewModel task)
        {
            //var people = await _repo.FindPeopleById(task.PeopleId).FirstOrDefaultAsync();
            //if (people == null)
            //{
            //    return BadRequest("Cannot find people by id");
            //}
            TodoTask model = _mapper.Map<TodoTask>(task);
            _repo.AddTask(model);
        }
    }
}