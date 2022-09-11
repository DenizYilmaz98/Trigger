using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trigger.API.Middlewares;
using Trigger.API.Model.UserModel;
using Trigger.Data.Abstract;
using Trigger.Data.Concrete;
using Trigger.Service.Abstract;
using Trigger.Service.Concrete;
using TriggerCore;

namespace Trigger.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddCors();
            services.AddDbContext<TriggerDbContext>(option =>
            {
                var provider = services.BuildServiceProvider();
                var config = provider.GetService<IOptions<AppSettings>>();
                option.UseSqlServer(config.Value.ConnectionString);
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<UserContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITriggerAddedService, TriggerAddedService>();
            services.AddScoped<IDailyCommentsService, DailyCommentsService>();
            

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITriggerAddedRepository, TriggerAddedRepository>();
            services.AddScoped<IDailyCommentsRepository,DailyCommentsRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Trigger.API", Version = "v1" });
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });


            app.UseMiddleware<AuthorizationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Trigger.API v1"));
            }
        }
    }
}
