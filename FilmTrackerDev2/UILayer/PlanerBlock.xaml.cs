using FilmTrackerDev2.ClassLayer;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FilmTrackerDev2.UILayer
{
    public partial class PlannerBLock : UserControl, INotifyPropertyChanged
    {
        private bool _isFavorite;
        public FilmObject filmObject;

        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (_isFavorite != value)
                {
                    _isFavorite = value;
                    OnPropertyChanged(nameof(IsFavorite)); // Повідомляємо про зміну властивості
                }
            }
        }

        public PlannerBLock(FilmObject film)
        {
            InitializeComponent();
            FilmTitle = film.Name;
            IsFavorite = film.IsFavorite;
            this.filmObject = film;
            DataContext = this; // Встановлюємо DataContext для прив'язки
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsFavorite = !IsFavorite;
            filmObject.IsFavorite = IsFavorite;// Оновлюємо властивість
        }

        private void WatchedButtonClick(object sender, RoutedEventArgs e)
        {
            if (RatingComboBox.SelectedItem is ComboBoxItem selectedRating && selectedRating.Content != null)
            {
                // Отримуємо рейтинг з ComboBox
                string ratingString = selectedRating.Content.ToString();
                this.filmObject.Rating = int.Parse(ratingString);
            }
            else
            {
                MessageBox.Show("Please select a rating before submitting.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Отримуємо коментар із текстового поля
            filmObject.comment = CommentBox.Text;

            try
            {
                // Оновлення даних у базі через DbFuncs
                var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
                dbFuncs.UpdateViewTableRecord(filmObject, App.CurrentUserId);
                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the record: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class BoolToFillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isFavorite = (bool)value;
            return isFavorite ? Brushes.Orange : Brushes.Transparent; // Заповнена зірка, якщо isFavorite = true
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public partial class PlannerBLock : UserControl, INotifyPropertyChanged
    {
        private string _filmTitle = "Назва фільму"; // Початкове значення
        private int _filmRating = 0; // Початкова оцінка

        public string FilmTitle
        {
            get => _filmTitle;
            set
            {
                if (_filmTitle != value)
                {
                    _filmTitle = value;
                    OnPropertyChanged(nameof(FilmTitle)); // Оновлюємо прив'язку
                }
            }
        }

        public int FilmRating
        {
            get => _filmRating;
            set
            {
                if (_filmRating != value)
                {
                    _filmRating = value;
                    OnPropertyChanged(nameof(FilmRating)); // Оновлюємо прив'язку
                }
            }
        }
    }

}

