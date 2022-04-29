using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using GTechAPI.Helpers;
using GTechAPI.Interfaces;
using GTechAPI.Data;
using GTechAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GTechAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApplicationServices(_config);
            services.AddControllers();
            //services.AddIdentityServices(_config);
            services.AddHealthChecks();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });

            services.AddDbContextFactory<psu0221_1074251Context>(
        options =>
            options.UseSqlServer("Server=hildur.ucn.dk;Database=psu0221_1074251;User Id=psu0221_1074251;Password=Password1!;"));

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IMemberRepository,MemberRepository>();
            services.AddScoped<IItemRepository,ItemRepository>();
            services.AddScoped<ILoanRepository,LoanRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHealthChecks("/api/healthcheck");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
