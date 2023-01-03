using Autofac;

namespace ProjectDashboard.WPF.Dependency.Modules;

internal sealed class ViewsModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindow>().SingleInstance();
        builder.RegisterType<SolutionEditWindow>().InstancePerDependency();
    }
}