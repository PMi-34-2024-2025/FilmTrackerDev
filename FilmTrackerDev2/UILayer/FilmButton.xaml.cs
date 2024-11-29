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
    public partial class FilmButton : UserControl
    {
        FilmObject localFilm;

        public FilmButton(string filmName, int filmYear, FilmObject film)
        {
            InitializeComponent();
            this.FilmName.Text = filmName;
            this.Year.Text = filmYear.ToString();
            localFilm = film;

            if (film.IsFavorite) 
            {
                this.SubButton.Background = new SolidColorBrush(Colors.Orange);
            }
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
            dbFuncs.CreateOrCheckView(localFilm,App.CurrentUserId);

        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
