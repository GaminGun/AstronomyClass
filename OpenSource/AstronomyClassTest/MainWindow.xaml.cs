using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginInput.Focus();
        }
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AstronomyClassDBEntities())
            {
                var login = db.Users.AsNoTracking().FirstOrDefault(p => p.login == LoginInput.Text);
                var user = db.Users.AsNoTracking().FirstOrDefault(p => p.login == LoginInput.Text && p.password == PasswordInput.Password);
                if (login == null)
                {
                    MessageBox.Show("Такого пользователя не существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (user == null)
                {
                    MessageBox.Show("Указан неверный пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (user.id_role == 3)
                {
                    AdminWin adminWin = new AdminWin();
                    adminWin.Show();
                } else
                {
                    if (user.active == true)
                    {
                        MainInterfaceOutputWin mainWin = new MainInterfaceOutputWin(user);
                        mainWin.Show();
                    } else
                    {
                        MessageBox.Show("Аккаунт заблокирован.");
                        return;
                    }
                }
                this.Close();
            }
        }

        private void ResisrationWinOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWin regisWin = new RegistrationWin();
            regisWin.ShowDialog();
        }

        private void RestorePasswordBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RestoreUserWin restorePassWin = new RestoreUserWin();
            restorePassWin.ShowDialog();
        }

        private void RestorePasswordBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            RestorePasswordBtn.TextDecorations = TextDecorations.Underline;
        }

        private void RestorePasswordBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            RestorePasswordBtn.TextDecorations = null;
        }
    }
}
