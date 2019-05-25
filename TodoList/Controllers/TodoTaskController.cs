using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.TodoList.Interfaces;
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
        private ITodoTaskRepo _repo;
        private IMapper _mapper;
        public TodoTaskController(ITodoTaskRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            TodoTask task = await _repo.FindByIdAsync(id);
            if (task == null)
                return BadRequest("Not found task");
            TodoTaskViewModel result = _mapper.Map<TodoTaskViewModel>(task);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetAll(string id)
        {
            IEnumerable<TodoTask> alltask = _repo.FindAll(id);
            List<TodoTaskViewModel> res = alltask.Select(task => _mapper.Map<TodoTaskViewModel>(task)).ToList();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddTask([FromBody] TodoTaskViewModel task)
        {
            TodoTask model = _mapper.Map<TodoTask>(task);
            _repo.Add(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] TodoTaskViewModel task)
        {
            TodoTask model = _mapper.Map<TodoTask>(task);
            _repo.Update(model);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}