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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilmTrackerDev2.UILayer
{
    /// <summary>
    /// Interaction logic for FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        public bool IsPlanned;
        public bool IsFavorite;
        public bool IsWatched;
        public int filmId;
        public bool IsMenuOpen = false;
        //List<string> coments = null
        public FilmPage(int filmId = -1, string name = "Test", string description = "Test", bool isWatched = false,bool isFavorite = false,
            bool isPlaned = false)
        {
            InitializeComponent();
            this.filmId = filmId;
            FilmNameBox.Text = name;
            FilmDescriptionBox.Text = description;
            if (isWatched) 
            {
                this.IsWatched = true;
                WhatchButton.Content = "Уже Переглянуте";
            }

            if (isPlaned)
            {
                this.IsPlanned = true;
                PlanButton.Content = "Заплановано";
            }

            if (isFavorite) 
            {
                this.IsFavorite = true;
                FavoriteButton.Content = "Вподобане";
            }
        }

        public FilmPage(FilmObject filmObject)
        {
            InitializeComponent();
            this.filmId = filmObject.FilmId;
            FilmNameBox.Text = filmObject.Name;
            FilmDescriptionBox.Text = filmObject.Description;
            if (filmObject.IsWatched)
            {
                this.IsWatched = true;
                WhatchButton.Content = "Уже Переглянуте";
            }

            if (filmObject.IsPlanned)
            {
                this.IsPlanned = true;
                PlanButton.Content = "Заплановано";
            }

            if (filmObject.IsFavorite)
            {
                this.IsFavorite = true;
                FavoriteButton.Content = "Вподобане";
            }
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

        public void GoToMainPageClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        public void GoToWatchListPageClick(object sender, RoutedEventArgs e) 
        {
            this.NavigationService.Navigate(new WatchListPage());
        }

        public void GoToPlannerPageClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PlanerPage());
        }

        public void PlanFilmClick(object sender, RoutedEventArgs e)
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
            IsPlanned = !IsPlanned;
            if (IsPlanned) 
            {
                PlanButton.Content = "Заплановано";
            }
            else
            {
                PlanButton.Content = "Запланувати";
            }
            dbFuncs.ChangePlannedCheckbox(App.CurrentUserId, this.filmId, IsPlanned);
        }
        public void FavoriteFilmClick(object sender, RoutedEventArgs e)
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
            IsFavorite = !IsFavorite;
            if (IsFavorite)
            {
                FavoriteButton.Content = "Вподобане";
            }
            else
            {
                FavoriteButton.Content = "Уподобати";
            }
            dbFuncs.ChangeFavoriteCheckbox(App.CurrentUserId, this.filmId, IsFavorite);
        }

        public void WatchedFilmClick(object sender, RoutedEventArgs e)
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
            IsWatched = !IsWatched;
            if (IsWatched)
            {
                WhatchButton.Content = "Уже Переглянуте";
            }
            else
            {
                WhatchButton.Content = "Переглянути";
            }
            dbFuncs.ChangeWatchedCheckbox(App.CurrentUserId,this.filmId,IsWatched);
        }
    }
}
