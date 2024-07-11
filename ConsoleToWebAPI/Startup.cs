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
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddSwaggerGen();
            //auto mapper
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);

            //RateLimiter
            //services.AddRateLimiter(r => r.AddFixedWindowLimiter(policyName: "fixedwindow", options =>
            //{
            //    options.Window = TimeSpan.FromSeconds(10);
            //    options.PermitLimit = 1;
            //    options.QueueLimit = 0;
            //    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
            //}));

            ////logger
            //var logPath = configuration.GetSection("Logging:Logpath");


            //Enable default CORS
            services.AddCors(p => p.AddDefaultPolicy(build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            //with plociy name
            //services.AddCors(p => p.AddPolicy("corspolicy", build =>
            //{
            //    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            //}));



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
            //Enable CORS
            app.UseCors();
            //app.UseCors("corspolicy");

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