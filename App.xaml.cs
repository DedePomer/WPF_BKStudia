﻿using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPF_BKStudia.Infrastructure.Interfaces;
using WPF_BKStudia.Infrastructure.Services;
using WPF_BKStudia.ViewModel.Pages;
using WPF_BKStudia.ViewModel.Windows;

namespace WPF_BKStudia
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            AddServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<IFileReaderService, FileReaderService>();
            services.AddSingleton<IFileWriterService, FileWriterService>();
            services.AddSingleton<INavigationStoreService, NavigationStoreService>();

            services.AddTransient<MenuPageViewModel>();
        }

        public void AppStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            var mainWindowViewModel = serviceProvider.GetService<MainWindowViewModel>();

            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }

    }

}
