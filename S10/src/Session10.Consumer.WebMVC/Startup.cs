using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Session10.Consumer.WebMVC.Infrastructures;
using Session10.Consumer.WebMVC.Middleware;
using Session10.Consumer.WebMVC.Services;
using System;
using System.Threading.Tasks;

namespace Session10.Consumer.WebMVC
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly DurationAction durationAction;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            

            services.AddRouting(options =>
            {
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
                options.ConstraintMap.Add("PersonIdentity", typeof(PersonIdentityConstraint));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("person", "/{controller}/{action}/{identityt:PersonIdentity}");
            });
        }

    }
}
