using DAL.TodoList;
using DAL.TodoList.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Extentions;

namespace TodoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoListContext>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<TodoListContext>().AddDefaultTokenProviders();
            services.InitMapper();
            services.AddDefaulDependency();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            TodoListContext.CreateAdminUser(app.ApplicationServices).Wait();
        }
    }
}
