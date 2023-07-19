using System.Windows;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        public AdminWin()
        {
            InitializeComponent();
            Manager.AdminLoadPage = LoadPageInAdminWin;
            Manager.AdminLoadPage.Navigate(new MainAdminWin());
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
