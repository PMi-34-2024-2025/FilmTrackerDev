﻿using FilmTrackerDev2.ClassLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for WatchedPage.xaml
    /// </summary>
    public partial class WatchedPage : Page
    {
        private bool IsMenuOpen = false;

        public ObservableCollection<Film> WatchedFilms { get; set; } = new ObservableCollection<Film>() {
            new Film { }
            
        };
        public WatchedPage()
        {
            InitializeComponent();

            var records = GetRecordsFromDatabase();

            foreach (var record in records)
            {
                var watchedBlock = new PlanerBlock1();

                // Подія кліку для кнопки (наприклад, показ інформації про запис)
                

                // Додаємо кнопку до ItemsControl
                ItemsGrid.Items.Add(watchedBlock);
            }
            
            
        }

            private List<Record> GetRecordsFromDatabase()
                 {
                    // Повертаємо список записів з бази даних
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

        public class Film
        {
            public string Title { get; set; }
            public string Rating { get; set; }
        }


    }
}