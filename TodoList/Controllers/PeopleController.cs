using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.TodoList;
using DAL.TodoList.Models;
using DAL.TodoList.Repository;
using Microsoft.AspNetCore.Mvc;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private IRepository _repo;
        private IMapper _mapper;
        public PeopleController(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetPeoples());

        [HttpGet("{id}")]
        public IActionResult GetOne(int id) =>  Ok(_repo.GetPeople(id));
        [HttpPost]
        public IActionResult Add([FromBody]PeopleViewModel people)
        {
            People res = _mapper.Map<People>(people);
            _repo.AddPeople(res);
            return Ok(res);
        }
    }
}