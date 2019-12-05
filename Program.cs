using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiScool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration(
                (env, config) =>
                {
                    //aqui colocamos al configuracion de proveedores.
                    var ambiente = env.HostingEnvironment.EnvironmentName;
                    config.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{ambiente}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                }
                )
                .UseStartup<Startup>();
    }
}
