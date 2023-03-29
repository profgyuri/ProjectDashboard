using Autofac;
using ProjectDashboard.Lib;

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

                builder.RegisterAssemblyModules(typeof(AutofacContainer).Assembly);

                builder.RegisterType<DataContext>().SingleInstance();

                _container = builder.Build();
            }

            return _container;
        }
    }
}