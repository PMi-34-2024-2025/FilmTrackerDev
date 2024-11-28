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
    /// Interaction logic for PlanerPage.xaml
    /// </summary>
    public partial class PlanerPage : Page
    {
        public PlanerPage()
        {
            InitializeComponent();

            var records = GetRecordsFromDatabase();

            var watchedBlock = new PlanerBlock(GetRecordsFromDatabase());

            // Додаємо кнопку до ItemsControl
            PlanerGrid.Items.Add(watchedBlock);

        }

        private bool IsMenuOpen = false;

        private FilmObject GetRecordsFromDatabase()
        {
            List<ActorObject> testList = new List<ActorObject>();
            List<string> testList2 = new List<string>() {"b", "a"};
            ActorObject actorObject = null;
            testList.Add(actorObject);
            // Повертаємо список записів з бази даних
            return new FilmObject(1,"test",4,"test description",testList,testList2);
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

        public void GoToMainPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void SearchButton_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NavigateToWatchedPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new WatchListPage());
        }
    }
}
