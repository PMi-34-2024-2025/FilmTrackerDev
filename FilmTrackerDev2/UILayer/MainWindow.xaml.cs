using FilmTrackerDev2.UILevel;
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
            MainFrame.Navigate(loginPage);
        }

        public void changeToRegister()
        {
            RegisterPage registrationPage = new RegisterPage();
            registrationPage.RegistrationEvent += registrationVerify;
            registrationPage.GoToLoginEvent += changeToLogin;
            MainFrame.Navigate(registrationPage);
        }

        public void changeToLogin()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginEvent += loginVerify;
            loginPage.ChangeToregistrationEvent += changeToRegister;
            MainFrame.Navigate(loginPage);
        }

        public void loginVerify()
        {            
            MainFrame.Navigate( new MainPage() );
        }
        public void registrationVerify()
        {

        }
    }
}