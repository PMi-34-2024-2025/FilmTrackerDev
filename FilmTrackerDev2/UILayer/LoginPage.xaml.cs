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
    public partial class LoginPage : Page
    {
        public event Action LoginEvent;
        public event Action ChangeToregistrationEvent;

        public LoginPage()
        {
            InitializeComponent();
        }

        public void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            ChangeToregistrationEvent?.Invoke();
        }

        public void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginEvent?.Invoke();
        }
    }
}
