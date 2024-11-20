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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
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
    }
}
