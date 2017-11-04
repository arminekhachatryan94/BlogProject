using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace backend
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());


            services.AddCors(options => options.AddPolicy("Cors",
                                                          builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");

            app.UseMvc();

            SeeData(app.ApplicationServices.GetService<ApiContext>());
        }

        public void SeeData(ApiContext context) {
            context.messages.Add(new Models.Message
            {
                Owner = "John",
                Text = "hello"
            });
            context.messages.Add(new Models.Message
            {
                Owner = "Tim",
                Text = "Hi"
            });

            context.users.Add( new Models.User{ Email = "a", FirstName = "Tim", Password = "a" } );

            context.SaveChanges();
        }
    }
}
