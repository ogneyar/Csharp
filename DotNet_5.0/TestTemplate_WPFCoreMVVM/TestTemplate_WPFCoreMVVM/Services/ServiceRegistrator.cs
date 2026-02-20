using Microsoft.Extensions.DependencyInjection;
using TestTemplate_WPFCoreMVVM.Services.Interfaces;

namespace TestTemplate_WPFCoreMVVM.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
           .AddTransient<IDataService, DataService>()
           .AddTransient<IUserDialog, UserDialog>()
        ;
    }
}
