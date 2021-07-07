using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RevitRibbon.API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddApplication();
            //services.AddInfrastructure();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                });
        }
    }
}