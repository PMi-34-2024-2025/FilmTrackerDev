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
    public partial class WatchlistBlock : UserControl
    {
        private FilmObject LocalFilmObject;
        public bool IsFavorite;

        public WatchlistBlock(FilmObject filmObject)
        {
            InitializeComponent();
            MainButton.Content = filmObject.Name;
            this.LocalFilmObject = filmObject;

            this.IsFavorite = filmObject.IsFavorite;

            if (filmObject.IsFavorite)
            {
                FavoriteButton.Background = new SolidColorBrush(Colors.Orange);
            }
            else 
            {
                FavoriteButton.Background = new SolidColorBrush(Colors.LightGray);
            }
        }

        public void FavoriteButtonCLick(object sender, RoutedEventArgs e)
        {
            IsFavorite = !IsFavorite;
            if (IsFavorite)
            {
                FavoriteButton.Background = new SolidColorBrush(Colors.Orange);
            }
            else
            {
                FavoriteButton.Background = new SolidColorBrush(Colors.LightGray);
            }
        }
    }
}
