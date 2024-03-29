﻿using System.Windows;
using Autofac;
using Microsoft.EntityFrameworkCore;
using ProjectDashboard.Lib;
using ProjectDashboard.WPF.Dependency;

namespace ProjectDashboard.WPF;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
internal sealed partial class App : Application
{
    #region Overrides of Application
    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        using var scope = AutofacContainer.Container.BeginLifetimeScope();
        
        var dataContext = scope.Resolve<DataContext>();
        dataContext.Database.Migrate();
        
        var window = scope.Resolve<MainWindow>();
        window.Show();

        ShutdownMode = ShutdownMode.OnMainWindowClose;
    }
    #endregion
}