using AutoMapper;
using DAL.TodoList.Interfaces;
using DAL.TodoList.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.MappingProfiles;

namespace TodoList.Extentions
{
    static public class ServiceConfiguration
    {
        static public void InitMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainModelToViewModel());
                config.AddProfile(new ViewModelToDomainModel());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        static public void AddDefaulDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepository>();
            services.AddScoped<ITodoTaskRepo, TodoTaskRepository>();
        }
    }
}
