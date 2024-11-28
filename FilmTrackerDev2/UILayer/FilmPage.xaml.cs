using FilmTrackerDev2.ClassLayer;
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
        public bool IsMenuOpen = false;
        //List<string> coments = null
        public FilmPage(string name = "Test", string description = "Test", bool isWatched = false,bool isFavorite = false,
            bool isPlaned = false)
        {
            InitializeComponent();
            FilmNameBox.Text = name;
            FilmDescriptionBox.Text = description;
            if (isWatched) 
            {
                WhatchButton.Content = "Уже Переглянуте";
            }

            if (isPlaned)
            {
                PlanButton.Content = "Заплановано";
            }

            if (isFavorite) 
            {
                FavoriteButton.Content = "Вподобане";
            }
        }

        public FilmPage(FilmObject filmObject)
        {
            InitializeComponent();
            FilmNameBox.Text = filmObject.Name;
            FilmDescriptionBox.Text = filmObject.Description;
            if (filmObject.IsWatched)
            {
                WhatchButton.Content = "Уже Переглянуте";
            }

            if (filmObject.IsPlaned)
            {
                PlanButton.Content = "Заплановано";
            }

            if (filmObject.IsFavorite)
            {
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
    }
}
