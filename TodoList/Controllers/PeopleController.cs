using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DAL.TodoList.Models;
using DAL.TodoList.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private IRepository _repo;
        private IMapper _mapper;
        public PeopleController(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resFromDb = _repo.GetPeoples().ToList();
            var result = resFromDb.Select(People => _mapper.Map<PeopleViewModel>(People));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([Required]int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id param");
            }
            return Ok(id);
        } 
        [HttpPost]
        public IActionResult Add([FromBody]PeopleViewModel people)
        {
            People res = _mapper.Map<People>(people);
            _repo.AddPeople(res);
            return Ok(res);
        }
    }
}