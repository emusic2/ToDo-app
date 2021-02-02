using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using Microsoft.AspNetCore.Identity;
using ToDoAPI.Settings;
using MyMusic.Api.Extensions;
using ToDoAPI.Data;

namespace ToDoAPI
{
    public class Startup
    {
        private JwtSettings jwtSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddDbContext<TaskContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ToDoDB")));

            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<TaskContext>()
                    .AddDefaultTokenProviders();

            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddAuth(jwtSettings);

            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
