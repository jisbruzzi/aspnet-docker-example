using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace aspnet_docker_example
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context,next)=>{
                await context.Response.WriteAsync("->");
                await next.Invoke();
                await context.Response.WriteAsync("!!!!!!!!! use it!");
            });


            app.Map("/bye",(insideApp)=>{
                insideApp.Run( async (context)=>{
                    await context.Response.WriteAsync("Bye bye World");
                });
            });

            app.Map("/hi",(insideApp)=>{
                insideApp.Run( async (context)=>{
                    await context.Response.WriteAsync("Hello World");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("?????????????");
            });

            app.Use(async (context,next)=>{
                await context.Response.WriteAsync("last use");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(":(");
            });
        }
    }
}
