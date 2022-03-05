using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TemplateApp.Data;
using MudBlazor.Services;
using TemplateApp;


public class Program
{
    public static int Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Run();
        return 0;
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                var environment = hostingContext.HostingEnvironment.EnvironmentName;
                config.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    //.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            })
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}