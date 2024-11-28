using FilmTrackerDev2.ClassLayer;
using FilmTrackerDev2.UILayer;
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
using Microsoft.Extensions.DependencyInjection;


namespace FilmTrackerDev2
{
    public partial class MainWindow : Window
    {
        public LoginPage loginPage;
        public RegisterPage registrationPage;

        public MainWindow()
        {
            InitializeComponent();

            loginPage = new LoginPage();
            loginPage.LoginEvent += loginVerify;
            loginPage.ChangeToregistrationEvent += changeToRegister;
            MainFrame.Navigate(loginPage);
        }

        public void changeToRegister()
        {
            registrationPage = new RegisterPage();
            registrationPage.RegistrationEvent += registrationVerify;
            registrationPage.GoToLoginEvent += changeToLogin;
            MainFrame.Navigate(registrationPage);
        }

        public void changeToLogin()
        {
            loginPage = new LoginPage();
            loginPage.LoginEvent += loginVerify;
            loginPage.ChangeToregistrationEvent += changeToRegister;
            MainFrame.Navigate(loginPage);
        }

        public void loginVerify()
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();

            string username = loginPage.LoginUsername.Text;
            string password = loginPage.LoginPassword.Text;
            if (dbFuncs.LoginCheck(username,password))
            {
                
                MainFrame.Navigate(new MainPage());
            }
        }

        public void registrationVerify()
        {
            var dbFuncs = App._serviceProvider.GetRequiredService<DbFuncs>();
            string username = registrationPage.RegistrationUsername.Text;
            string password = registrationPage.RegistrationPassword.Text;
            if (dbFuncs.RegistrationCheck(username, password))
            {
                MainFrame.Navigate(new MainPage());
            }
        }
    }
}