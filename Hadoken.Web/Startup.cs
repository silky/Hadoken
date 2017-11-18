#region Using References

using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hadoken.Core;

#endregion

namespace Hadoken.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            ApplicationConfiguration.HadokenConnectionString = _configuration.GetConnectionString(ApplicationConfiguration.HadokenConnectionStringKey);
        }

        private readonly IConfiguration _configuration;

        public IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment() == true)
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseBrowserLink();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/Home/Error");
            }

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Home}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvc();
        }
    }
}
