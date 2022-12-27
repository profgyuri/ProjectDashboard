using Autofac;
using ProjectDashboard.WPF.Dependency.Modules;

namespace ProjectDashboard.WPF.Dependency;

public static class AutofacContainer
{
    private static IContainer? _container;
    
    internal static IContainer Container
    {
        get
        {
            if (_container is null)
            {
                var builder = new ContainerBuilder();
                
                builder.RegisterModule<ViewsModule>();
                builder.RegisterModule<ViewModelsModule>();
                
                _container = builder.Build();
            }
            
            return _container;
        }
    }
}