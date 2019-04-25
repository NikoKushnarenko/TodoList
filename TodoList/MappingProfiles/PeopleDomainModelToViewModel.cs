using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.MappingProfiles
{
    public class PeopleDomainModelToViewModel : Profile
    {
        public PeopleDomainModelToViewModel()
        {
            CreateMap<PeopleViewModel, People>();
        }
    }
}
