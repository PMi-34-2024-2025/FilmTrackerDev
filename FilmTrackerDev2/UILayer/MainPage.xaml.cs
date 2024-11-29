using FilmTrackerDev2.ClassLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilmTrackerDev2.UILayer
{
    public partial class MainPage : Page
    {
        public event Action MenuEvent;
        private bool IsMenuOpen = false;
        public event Action SearchEvent;

        public MainPage()
        {
            InitializeComponent();
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            // Імітація отримання даних з бази
            var films = GetRecordsFromDatabase();

            // Додаємо дані в ItemsControl
            foreach (var film in films)
            {
                var filmButton = new FilmButton(film.Name,film.year, film);

                // Подія кліку для кнопки (наприклад, показ інформації про запис)
                filmButton.MainButton.Click += (s, e) =>
                {
                    this.NavigationService.Navigate(new FilmPage( film.FilmId,film.Name,film.Description,film.IsWatched, film.IsFavorite,
                        film.IsPlanned));
                };

                // Додаємо кнопку до ItemsControl
                ItemsGrid.Items.Add(filmButton);
            }
        }

        private List<FilmObject> GetRecordsFromDatabase()
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
            return dbFuncs.GetFilmObjects(App.CurrentUserId);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Анімація для розкриття/приховування меню
            if (IsMenuOpen)
            {
                MenuColumn.Width = new GridLength(0);
                MenuButton1.Visibility = Visibility.Visible;
                MenuButton2.Visibility = Visibility.Collapsed;
            }
            else
            {
                MenuColumn.Width = new GridLength(200);
                MenuButton1.Visibility = Visibility.Collapsed;
                MenuButton2.Visibility = Visibility.Visible;
            }

            IsMenuOpen = !IsMenuOpen;
        }

        private void SearchButton_Click(Object sender, RoutedEventArgs e)
        {

        }

        // Метод для переходу на сторінку WatchedPage
        private void NavigateToWatchedPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new WatchListPage());
        }

        public void NavigateToPlanedPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PlanerPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
