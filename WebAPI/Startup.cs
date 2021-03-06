using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using AutoMapper;
using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using FluentValidation;
using CBC.TaskManagement.WebApi.Models;
using CBC.TaskManagement.WebApi.TodoTasksApi.Data;
using CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using CBC.TaskManagement.WebApi.TodoTasksApi.Service.Command;
using CBC.TaskManagement.WebApi.TodoTasksApi.Service.Query;
using CBC.TaskManagement.WebApi.Validators;
using FluentValidation.AspNetCore;

namespace CBC.TaskManagement.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure ASP.NET Core to work with proxy servers and load balancers
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddDbContext<TodoTaskContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TaskManagementDatabase")));

            services.AddControllersWithViews().AddFluentValidation();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen( s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TodoTask Api",
                    Description = "A simple API to manage todo / task",
                    Contact = new OpenApiContact
                    {
                        Name = "Yaser Shadmehr",
                        Email = "y.shadmehr@gmail.com",
                    }
                });
            });


            // Handling Invalud Model State
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as ActionExecutingContext;

                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });

            // Register automapper to map POCO (DTO <--> Model)
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();

            // Apply Business Validation
            services.AddTransient<IValidator<TodoTaskModel>, TodoTaskModelValidator>();

            // Register All Queries
            services.AddTransient<IRequestHandler<GetTodoTaskQuery, List<TodoTask>>, GetTodoTaskQueryHandler>();
            services.AddTransient<IRequestHandler<GetTodoTaskByIdQuery, TodoTask>, GetTodoTaskByIdQueryHandler>();

            // Register All Commands
            services.AddTransient<IRequestHandler<CreateTodoTaskCommand, TodoTask>, CreateTodoTaskCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateTodoTaskCommand, TodoTask>, UpdateTodoTaskCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTodoTaskCommand>, DeleteTodoTaskCommandHandler>();
            services.AddTransient<IRequestHandler<SetTaskStatusCommand, TodoTask>, SetTaskStatusCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management API V1");
            });

            // Forwarded Headers Middleware before other middleware to consume forwarded headers information, if applicable.
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
