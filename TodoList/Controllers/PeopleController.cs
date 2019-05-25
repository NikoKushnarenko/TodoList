using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DAL.TodoList.Models;
using DAL.TodoList.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoList.ViewModels;
using DAL.TodoList.Interfaces;
using System.Threading.Tasks;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private IUserRepo _repo;
        private IMapper _mapper;
        public PeopleController(IUserRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resFromDb = _repo.FindAll().ToList();
            var result = resFromDb.Select(People => _mapper.Map<PeopleViewModel>(People));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([Required]string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid id param");
            }
            AppUser personGet = await _repo.FindByIdAsync(userId);
            PeopleViewModel res = _mapper.Map<PeopleViewModel>(personGet);
            return Ok(res);
        } 
        [HttpPost]
        public IActionResult Add([FromBody]PeopleViewModel people)
        {
            AppUser res = _mapper.Map<AppUser>(people);
            _repo.Add(res);
            return Ok(res);
        }
    }
}