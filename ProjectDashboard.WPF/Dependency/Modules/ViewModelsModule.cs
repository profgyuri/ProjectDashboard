using Autofac;
using ProjectDashboard.Lib.ViewModels;

namespace ProjectDashboard.WPF.Dependency.Modules;

internal sealed class ViewModelsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindowViewModel>().AsSelf().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<SolutionEditWindowViewModel>().AsSelf().AsImplementedInterfaces().InstancePerDependency();
    }
}