using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для RestoreUserWin.xaml
    /// </summary>
    public partial class RestoreUserWin : Window
    {
        public RestoreUserWin()
        {
            InitializeComponent();
        }
        Users userReset;
        private void LoginInputForRestore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var login = AstronomyClassDBEntities.GetContext().Users.FirstOrDefault(p => p.login == LoginInputForRestore.Text);
                if (login == null)
                {
                    MessageBox.Show("Такого пользователя не существует.");
                    return;
                }
                userReset = login;
                LoginInputForRestore.IsEnabled = false;
                CodeInputForRestore.IsEnabled = true;
                CodeInputForRestore.Focus();
            }
        }

        private void CodeInputForRestore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CodeInputForRestore.Text != userReset.restore_code)
                {
                    MessageBox.Show("Неверный код восстановления.");
                    return;
                }
                CodeInputForRestore.IsEnabled = false;
                NewPassInputForRestore.IsEnabled = true;
                NewPassInputForRestore.Focus();
            }
        }
        string forbiddenSymbols = @"[а-яА-Я]";
        string specialSymbols = @"[!@#$%^&*()_]";
        private void EndRestorePassBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userReset != null)
            {
                if (userReset.restore_code == CodeInputForRestore.Text && NewPassInputForRestore.IsEnabled == true)
                {
                    StringBuilder errors = new StringBuilder();
                    if (NewPassInputForRestore.Password == null)
                        errors.AppendLine("Пароль не может быть пустым.");
                    if (NewPassInputForRestore.Password.Length < 4)
                        errors.AppendLine("Пароль не может быть короче 4-х символов.");
                    if (Regex.IsMatch(NewPassInputForRestore.Password, forbiddenSymbols) == true)
                        errors.AppendLine("Используйте латиницу для пароля.");
                    if (Regex.IsMatch(NewPassInputForRestore.Password, specialSymbols) == false)
                        errors.AppendLine("Используйте специальные символы.");

                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }
                    userReset.password = NewPassInputForRestore.Password;
                    try
                    {
                        AstronomyClassDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Пароль успешно изменён.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
