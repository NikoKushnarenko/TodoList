using DAL.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.ViewModels;
using AutoMapper; 
namespace TodoList.MappingProfiles
{
    public class TodoTaskViewModelToDomainModel : Profile
    {
        public TodoTaskViewModelToDomainModel()
        {
            CreateMap<TodoTask, TodoTaskViewModel>();
        }
    }
}
