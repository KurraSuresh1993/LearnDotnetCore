
using AutoMapper;
using LearnAPI.Container;
using LearnAPI.Helper;
using LearnAPI.Repos;
using LearnAPI.Services;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LearnAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<LearnDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("apiconn")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<ICustomerService, CustomerService>();

            //auto mapper
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = automapper.CreateMapper();
            builder.Services.AddSingleton(mapper);

            //Enable CORS
            //default one
            builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            //builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            //{
            //    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            //}));

            //RateLimiter
            builder.Services.AddRateLimiter(r => r.AddFixedWindowLimiter(policyName: "fixedwindow", options =>
            {
                options.Window = TimeSpan.FromSeconds(10);
                options.PermitLimit = 1;
                options.QueueLimit = 0;
                options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
            }).RejectionStatusCode=401);

            //Logger
            var logPath = builder.Configuration.GetSection("Logging:Logpath").Value;
            var _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(logPath)
                .CreateLogger();
            builder.Logging.AddSerilog(_logger);

            var app = builder.Build();

            //RateLimiter
            app.UseRateLimiter();

            //Enable CORS default
            app.UseCors();
            //  app.UseCors("corspolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}