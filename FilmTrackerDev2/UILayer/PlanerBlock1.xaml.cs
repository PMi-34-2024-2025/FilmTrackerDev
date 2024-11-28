using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FilmTrackerDev2.UILayer
{
    public partial class PlanerBlock1 : UserControl, INotifyPropertyChanged
    {
        private bool _isFavorite;

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

        public PlanerBlock1(string title = "Test")
        {
            InitializeComponent();
            FilmTitle = title;
            DataContext = this; // Встановлюємо DataContext для прив'язки
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsFavorite = !IsFavorite; // Оновлюємо властивість
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

    public partial class PlanerBlock1 : UserControl, INotifyPropertyChanged
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

