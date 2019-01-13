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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
 using Swashbuckle.AspNetCore.Swagger;

namespace TodoApi
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
            //Register the database context
            services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Register the Swagger generator
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new Info 
                { 
                    Version = "v1",
                    Title = "Todo App API",
                    Description = "A simple ToDo Application built with ASP.NET Core Web Api",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Nke Sebastien Yapo - CSC 496",
                        Email = "contact@nkeyapo.com",
                        Url = "https://nkeyapo.com"
                    },
                    License =new License
                    {
                        Name = "Use under GPLv3",
                        Url = "https://www.gnu.org/licenses/gpl-3.0.html"
                    }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo App Api V1");
                c.RoutePrefix = string.Empty;
            }
            );
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
