using Autofac;
using ProjectDashboard.Lib.Services;

namespace ProjectDashboard.WPF.Dependency.Modules;

public class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<StarterService>()
            .As<IStarterService>()
            .SingleInstance();
    }
}