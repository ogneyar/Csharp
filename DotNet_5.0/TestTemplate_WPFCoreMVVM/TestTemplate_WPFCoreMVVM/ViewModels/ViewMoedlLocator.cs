using Microsoft.Extensions.DependencyInjection;

namespace TestTemplate_WPFCoreMVVM.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
