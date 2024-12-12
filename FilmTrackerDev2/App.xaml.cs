using FilmTrackerDev2.ClassLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FilmTrackerDev2
{
    public partial class App : Application
    {
        public static IServiceProvider _serviceProvider;

        public static int CurrentUserId;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Конфігурація DI
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            // Відкриття головного вікна
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Додати DbContext з підключенням до PostgreSQL
            services.AddDbContext<TrackerDbContext>(options =>
                options.UseNpgsql("Host=localhost;Database=FilmTrackerTest;Username=postgres;Password=1234"));

            // Реєстрація інших класів для DI
            services.AddTransient<DbFuncs>();  // Додаємо DbFuncs для DI
            services.AddTransient<MainWindow>();
        }
    }
}
