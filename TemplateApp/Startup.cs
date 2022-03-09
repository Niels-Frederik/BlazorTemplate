using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using TemplateApp.Areas.Identity;
using TemplateApp.Services;

namespace TemplateApp;

public class Startup
{
    private readonly IWebHostEnvironment _environment;

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _environment = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddTransient<IDefaultService, DefaultService>();
        services.AddMudServices();
        services.AddHttpClient();
        services.AddScoped<TokenProvider>();
        services.AddDbContextFactory<DatabaseContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddDefaultIdentity<IdentityUser>().AddDefaultUI().AddEntityFrameworkStores<DatabaseContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext dbContext)
    {
        if (env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            //endpoints.MapHub<AgentHub>("/AgentHub");
            endpoints.MapControllers();
            endpoints.MapRazorPages();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}