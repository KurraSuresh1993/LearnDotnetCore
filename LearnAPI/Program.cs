
using AutoMapper;
using LearnAPI.Container;
using LearnAPI.Helper;
using LearnAPI.Models;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

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

            //Basic authentication
            // builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //JWT authentocation
            var authKey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
            builder.Services.AddAuthentication(item =>
            {
                item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IRefreshHandler, RefreshHandler>();

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
            }).RejectionStatusCode = 401);

            //Logger
            var logPath = builder.Configuration.GetSection("Logging:Logpath").Value;
            var _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(logPath)
                .CreateLogger();
            builder.Logging.AddSerilog(_logger);

            //JWT Authentication
            var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(_jwtsettings);

            var app = builder.Build();

            //minimal api
            app.MapGet("/minimalapi", () => "Kurra Suresh");
            app.MapGet("/GetAllCustomers", async (LearnDataContext _context) => await _context.TblCustomers.ToListAsync());
            app.MapGet("/GetCustomerById/{id}", async (LearnDataContext _context, int id) => await _context.TblCustomers.FindAsync(id));
            app.MapPost("/CreateCustomer", async (LearnDataContext _context, TblCustomer customer) =>
            {
                await _context.TblCustomers.AddAsync(customer);
                await _context.SaveChangesAsync();
            });
            app.MapPut("/UpdateCustomer/{id}", async (LearnDataContext _context, TblCustomer customer, int id) =>
            {
                var existCustomer = await _context.TblCustomers.FindAsync(id);
                if (existCustomer != null)
                {
                    existCustomer.Name = customer.Name;
                    existCustomer.Email = customer.Email;
                    existCustomer.Phone = customer.Phone;
                    existCustomer.CreditLimit = customer.CreditLimit;
                    existCustomer.Code = customer.Code;
                }

                await _context.SaveChangesAsync();
            });
            app.MapDelete("/DeleteCustomer/{id}", async (LearnDataContext _context, int id) =>
            {
                var existCustomer = await _context.TblCustomers.FindAsync(id);
                if (existCustomer != null)
                {
                    _context.TblCustomers.Remove(existCustomer);
                }
                await _context.SaveChangesAsync();
            });

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

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}