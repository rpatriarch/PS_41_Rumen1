using DataLayer.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Създаване на контейнер за внедряване на зависимости
            var serviceProvider = new ServiceCollection()
                .AddTransient<DatabaseContext>() // Регистриране на DatabaseContext като transient зависимост
                .BuildServiceProvider();

            // Създаване на главното прозорец
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = serviceProvider.GetService<DatabaseContext>();

            // Показване на главното прозорец
            mainWindow.Show();
        }
    }
}
