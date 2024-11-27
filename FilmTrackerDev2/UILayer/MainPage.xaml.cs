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
            var records = GetRecordsFromDatabase();

            // Додаємо дані в ItemsControl
            foreach (var record in records)
            {
                var filmButton = new FilmButton();

                // Подія кліку для кнопки (наприклад, показ інформації про запис)
                filmButton.MainButton.Click += (s, e) =>
                {
                    MessageBox.Show($"Ви натиснули на елемент: {record.Title}");
                };

                // Додаємо кнопку до ItemsControl
                ItemsGrid.Items.Add(filmButton);
            }
        }

        private List<Record> GetRecordsFromDatabase()
        {
            // Приклад фейкових даних
            return new List<Record>
            {
                new Record { Id = 1, Title = "Запис 1" },
                new Record { Id = 2, Title = "Запис 2" },
                new Record { Id = 3, Title = "Запис 3" },
                new Record { Id = 4, Title = "Запис 4" },
                new Record { Id = 5, Title = "Запис 5" },
                new Record { Id = 6, Title = "Запис 6" },
                new Record { Id = 7, Title = "Запис 7" },
                new Record { Id = 8, Title = "Запис 8" },
                new Record { Id = 9, Title = "Запис 9" },
                new Record { Id = 10, Title = "Запис 10" }
            };
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
    }

    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
