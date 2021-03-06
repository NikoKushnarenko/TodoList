﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.MappingProfiles
{
    public class DomainModelToViewModel : Profile
    {
        public DomainModelToViewModel()
        {
            CreateMap<PeopleViewModel, People>();
            CreateMap<TodoTaskViewModel, TodoTask>();
        }
    }
}
