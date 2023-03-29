using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Extensions.Autofac.DependencyInjection;
using ProjectDashboard.Lib.ViewModels;

namespace ProjectDashboard.WPF.Dependency.Modules;

public class MediatrModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var configuration = MediatRConfigurationBuilder
            .Create(typeof(MainWindowViewModel).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .WithRegistrationScope(RegistrationScope.Scoped)
            .Build();

        builder.RegisterMediatR(configuration);
    }
}