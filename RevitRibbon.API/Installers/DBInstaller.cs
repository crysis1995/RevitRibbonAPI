using RevitRibbon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RevitRibbon.API.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddPooledDbContextFactory<RevitRibbonContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("RevitRibbonCS")));
        }
    }
}