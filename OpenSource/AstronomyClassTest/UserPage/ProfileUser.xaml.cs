using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Page
    {
        MainInterfaceOutputWin main;
        Users userEdit = new Users();
        public ProfileUser(Users user, MainInterfaceOutputWin main)
        {
            InitializeComponent();
            userEdit = user;

            this.main = main;
            UserInfoOutput.ItemsSource = AstronomyClassDBEntities.GetContext().Users.Where(p => p.id == user.id).ToList();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            main.activeTransition = true;
            Manager.MainLoadPage.GoBack();
        }

        private void EditUserProfile_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainLoadPage.Navigate(new EditUser((sender as Button).DataContext as Users, main));
            UserInfoOutput.ItemsSource = AstronomyClassDBEntities.GetContext().Users.Where(p => p.id == userEdit.id).ToList();
        }
    }
}
