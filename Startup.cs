using System;
using System.IO;
using AutoMapper;
using Consul;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Interface;
using iread_story.DataAccess.Repository;
using iread_story.Web.Service;
using iread_story.Web.Profile;
using iread_story.Web.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace iread_story
{
    public class Startup
    {
        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
            });

        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "/Properties/launchSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins", builder =>
                     builder
                         .AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
            });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // for routing
            services.AddControllers();

            // for protected APIs
            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication("Bearer", options =>
            {
                options.ApiName = "api1";
                options.Authority = "http://192.168.1.118:5015";
                options.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {

                options.AddPolicy(Policies.Administrator, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireScope(Policies.Administrator);
                });
                options.AddPolicy(Policies.Teacher, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireScope(Policies.Teacher);
                });
                options.AddPolicy(Policies.Student, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireScope(Policies.Student);
                });
            });




            // for connection of DB
            services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseLoggerFactory(_myLoggerFactory).UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
                });

            // for consul
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = Configuration.GetValue<string>("ConsulConfig:Host");
                consulConfig.Address = new Uri(address);
            }));
            services.AddConsulConfig(Configuration);
            services.AddHttpClient<IConsulHttpClientService, ConsulHttpClientService>();


            // for swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iread_story", Version = "v1" });
            });

            // Inject the public repository
            services.AddScoped<IPublicRepository, PublicRepository>();

            // Inject story service
            services.AddScoped<StoryService>();

            //for page service
            services.AddScoped<PageService>();


            IMapper mapper = new MapperConfiguration(config =>
            {
                config.AddProfile<AutoMapperProfile>();
            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddHttpClient<IConsulHttpClientService, ConsulHttpClientService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iread_story v1"));
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("_myAllowSpecificOrigins");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseConsul(Configuration);
        }
    }
}
