#region Using References

using System;
using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.Json;

#endregion

namespace Hadoken.Web
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
            IWebHost webHost = new WebHostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.Add(new JsonConfigurationSource() { Path = "appsettings.json" });
                })
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            webHost.Run();
        }
    }
}
