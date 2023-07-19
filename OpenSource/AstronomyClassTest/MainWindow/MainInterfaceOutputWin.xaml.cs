using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для MainInterfaceOutputWin.xaml
    /// </summary>
    public partial class MainInterfaceOutputWin : Window
    {
        Users user;
        public MainInterfaceOutputWin(Users user)
        {
            InitializeComponent();
            this.user = user;
            UserLoginShortInfo.ItemsSource = AstronomyClassDBEntities.GetContext().Users.Where(p => p.id == user.id).ToList();

            Manager.MainLoadPage = MainFrame;
            Manager.MainLoadPage.Navigate(new OutputArticlesPage(user));
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualWidth >= 1150)
            {
                TextLogo.FontSize = 26;
            }
            else
            {
                TextLogo.FontSize = 20;
            }
        }
        public bool activeTransition = true;
        private void UserLoginShortInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (activeTransition == true)
            {
                activeTransition = false;
                Manager.MainLoadPage.Navigate(new ProfileUser(user, this));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("На страницу авторизации?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
        }
    }
}
