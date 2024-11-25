using System.Text;
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
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            LoginPage loginPage = new LoginPage();
            loginPage.LoginEvent += loginVerify;
            loginPage.ChangeToregistrationEvent += changeToRegister;
            MainGrid.Children.Add(loginPage);
        }

        public void changeToRegister()
        {
            MainGrid.Children.Clear();
            RegisterPage registrationPage = new RegisterPage();
            registrationPage.RegistrationEvent += registrationVerify;
            registrationPage.GoToLoginEvent += changeToLogin;
            MainGrid.Children.Add(registrationPage);
        }

        public void changeToLogin()
        {
            MainGrid.Children.Clear();
            LoginPage loginPage = new LoginPage();
            loginPage.LoginEvent += loginVerify;
            loginPage.ChangeToregistrationEvent += changeToRegister;
            MainGrid.Children.Add(loginPage);
        }

        public void loginVerify()
        {

        }
        public void registrationVerify()
        {

        }
    }
}