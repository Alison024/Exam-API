using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Solution.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.SqlServer;
using Solution.IRepositories;
using Solution.Domain.IServices;
using Solution.Services;
using Solution.Persistence.Repositories;
using Solution.Helpers;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace Solution
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
            services.AddControllers();

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);
            var appSettings = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x=>{
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>{
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer("Data Source=DESKTOP-VAOFU4A;Initial Catalog=ExamAPI;Integrated Security=True"));

            services.AddScoped<ICustomerRepository, CusotmerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGameService,GameService>();
            services.AddScoped<IGenreService,GenreService>();
            services.AddScoped<IGameRepository,GameRepository>();
            services.AddScoped<IGenreRepository,GenreRepository>();
            services.AddScoped<ITagRepository,TagsRepository>();
            services.AddScoped<ITagService,TagService>();
            services.AddScoped<ISaleRepository,SaleRepository>();
            services.AddScoped<ISaleService,SaleService>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IRoleService,RoleService>();

            services.AddScoped<IGameGenreRepository,GameGenreRepository>();
            services.AddScoped<IGameGenreService,GameGenreService>();

            services.AddScoped<IGameTagRepository,GameTagRepository>();
            services.AddScoped<IGameTagService,GameTagService>();

            services.AddScoped<ICustomerRoleRepository,CustomerRoleRepository>();
            services.AddScoped<ICustomerRoleService,CustomerRoleService>();
            
            services.AddScoped<AppDbContext,AppDbContext>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Game Shop Api", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Game Shop API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
