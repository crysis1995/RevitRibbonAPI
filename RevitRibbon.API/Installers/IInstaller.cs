using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RevitRibbon.API.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration Configuration);
    }
}