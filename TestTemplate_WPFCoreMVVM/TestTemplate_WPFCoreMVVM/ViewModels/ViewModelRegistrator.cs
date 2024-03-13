using Microsoft.Extensions.DependencyInjection;

namespace TestTemplate_WPFCoreMVVM.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViews(this IServiceCollection services) => services
           .AddSingleton<MainWindowViewModel>()
        ;
    }
}