using System.Threading.Tasks;

namespace TestTemplate_WPFCoreMVVM.Infrastructure
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
