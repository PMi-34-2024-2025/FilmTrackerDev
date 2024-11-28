using FilmTrackerDev2.ClassLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FilmTrackerDev2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string Username { get; set; }
        private int userId { get; set; }

        public List<FilmObject> FilmObjects { get; set; } = new List<FilmObject>();
        public List<ActorObject> ActorObjects { get; set; } = new List<ActorObject>();

        static void ConfigureServices(IServiceCollection services)
        {
            // Додати DbContext з підключенням до PostgreSQL
            services.AddDbContext<TrackerDbContext>(options =>
                options.UseNpgsql("Host=localhost;Database=FilmTrackerTest;Username=postgres;Password=mi20051409"));
        }
    }
}
