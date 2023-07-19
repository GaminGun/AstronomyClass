using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWin.xaml
    /// </summary>
    public partial class RegistrationWin : Window
    {
        Users newUser = new Users();
        public RegistrationWin()
        {
            InitializeComponent();
            ClassSelect.ItemsSource = AstronomyClassDBEntities.GetContext().Classes.ToList();
            EducationalInput.Text = "Название и город";
        }
        string forbiddenSymbols = @"[а-яА-Я]";
        string specialSymbols = @"[!@#$%^&*()_]";
        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (LoginInput.Text == null)
                errors.AppendLine("Логин не может быть пустым.");
            if (LoginInput.Text.Length < 4)
                errors.AppendLine("Логин не может быть короче 4-х символов.");
            if (Regex.IsMatch(LoginInput.Text, forbiddenSymbols) == true)
                errors.AppendLine("Используйте латиницу для логина.");
            if (AstronomyClassDBEntities.GetContext().Users.FirstOrDefault(p => p.login == LoginInput.Text) != null)
                errors.AppendLine("Такой пользователь уже существует.");


            if (PasswordInput.Password == null)
                errors.AppendLine("Пароль не может быть пустым.");
            if (PasswordInput.Password.Length < 4)
                errors.AppendLine("Пароль не может быть короче 4-х символов.");
            if (Regex.IsMatch(PasswordInput.Password, forbiddenSymbols) == true)
                errors.AppendLine("Используйте латиницу для пароля.");
            if (Regex.IsMatch(PasswordInput.Password, specialSymbols) == false)
                errors.AppendLine("Используйте специальные символы.");

            if (NumberPhone.Text == null || NumberPhone.Text == "X XXX XXX-XX-XX")
                errors.AppendLine("Номер телефона не может быть пустым.");
            if (Regex.IsMatch(NumberPhone.Text, @"[a-zA-Zа-яА-Я]") == true)
                errors.AppendLine("Используйте только цифры, а также разделитель -");
            if (!Regex.IsMatch(NumberPhone.Text, @"\d{1} \d{3} \d{3}-\d{2}-\d{2}"))
                errors.AppendLine("Используйте указанный формат. X XXX XXX-XX-XX");
            if (AstronomyClassDBEntities.GetContext().Users.FirstOrDefault(p => p.number_phone == NumberPhone.Text) != null)
                errors.AppendLine("Такой номер телефона уже используется.");


            if (FullNameInput.Text == null)
                errors.AppendLine("Поле ФИО не может быть пустым.");
            {
                if (Regex.IsMatch(FullNameInput.Text, @"[a-zA-Z0-9]") == true)
                    errors.AppendLine("Используйте кириллицу для поля ФИО.");
                string[] splitUserName = FullNameInput.Text.Split(' ');
                if (splitUserName.Length == 1)
                    errors.AppendLine("Заполните поле ФИО полностью.");
                else if (splitUserName.Length <= 2)
                {
                    if (splitUserName[1].Length == 0)
                        errors.AppendLine("Напишите имя.");
                    newUser.last_name = splitUserName[0];
                    newUser.first_name = splitUserName[1];
                    if (splitUserName.Length == 3)
                        newUser.surname = splitUserName[2];
                }
            }


            if (EducationalInput.Text == null || EducationalInput.Text == "Название и город")
                errors.AppendLine("Поле 'учебное учреждение' не может быть пустым.");
            if (EducationalInput.Text.Length < 3)
                errors.AppendLine("Название учебного учреждения не может быть короче 3-х символов.");


            if (ClassSelect.SelectedItem == null)
                errors.AppendLine("Выберите класс.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (newUser.id == 0)
            {
                newUser.login = LoginInput.Text;
                newUser.password = PasswordInput.Password;
                newUser.number_phone = NumberPhone.Text;
                newUser.educational_institution = EducationalInput.Text;
                newUser.id_class = ClassSelect.SelectedIndex + 1;
                newUser.id_role = 1;
                newUser.active = true;

                GenerateRestoreCodeWin generateCodeWin = new GenerateRestoreCodeWin(newUser);
                this.Close();
                generateCodeWin.Show();
            }
        }

        private void EducationalInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EducationalInput.Text == "Название и город")
                EducationalInput.Text = "";
        }

        private void EducationalInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EducationalInput.Text == "")
                EducationalInput.Text = "Название и город";
        }

        private void NumberPhone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(NumberPhone.Text, @"[0-9]");
            string text = (sender as TextBox).Text;
            if (NumberPhone.Text.Length == 0)
                text = "+7 (";
            if (NumberPhone.Text.Length == 7)
                text += ") ";
            if (NumberPhone.Text.Length == 12)
                text += "-";
            if (NumberPhone.Text.Length == 15)
                text += "-";
            if (NumberPhone.Text.Length == 18)
                e.Handled = true;
            (sender as TextBox).Text = text;
            (sender as TextBox).CaretIndex = text.Length;
        }
    }
}
