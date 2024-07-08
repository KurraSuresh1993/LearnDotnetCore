using AutoMapper;
using ConsoleToWebAPI.Helper;
using ConsoleToWebAPI.Interfaces.Repositories;
using ConsoleToWebAPI.Interfaces.Services;
using ConsoleToWebAPI.Models;
using ConsoleToWebAPI.Repositories;
using ConsoleToWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ConsoleToWebAPI
{
    internal class Startup
    {
        private IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeDBContext>(options =>
            {
                options.UseSqlServer(this.configuration.GetConnectionString("conn"));
            });
            services.AddControllers();
            services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddSwaggerGen();
            //auto mapper
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}