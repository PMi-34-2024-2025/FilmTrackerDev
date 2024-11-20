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

namespace FilmTrackerDev2
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : UserControl
    {
        public event Action RegistrationEvent; 
        public event Action GoToLoginEvent;

        public RegisterPage()
        {
            InitializeComponent();
        }

        public void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            GoToLoginEvent?.Invoke();
        }
    }
}
