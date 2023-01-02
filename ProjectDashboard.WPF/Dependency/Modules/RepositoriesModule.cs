using Autofac;
using ProjectDashboard.Lib.Repositories;

namespace ProjectDashboard.WPF.Dependency.Modules;

public class RepositoriesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<SolutionRepository>()
            .As<ISolutionRepository>()
            .SingleInstance();
    }
}