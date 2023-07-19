using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для EditUserAdmin.xaml
    /// </summary>
    public partial class EditUserAdmin : Page
    {
        Users currentUser = new Users();
        int addUser = 1;
        public EditUserAdmin(Users user)
        {
            InitializeComponent();
            if (user != null)
            {
                currentUser = user;
                if (currentUser.active == true)
                    SelectedActiveAdmin.SelectedIndex = 0;
                else
                    SelectedActiveAdmin.SelectedIndex = 1;
                addUser = 2;
            }
            ClassSelectAdmin.ItemsSource = AstronomyClassDBEntities.GetContext().Classes.ToList();
            RoleSelectAdmin.ItemsSource = AstronomyClassDBEntities.GetContext().Roles.ToList();
            DataContext = currentUser;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminLoadPage.GoBack();
        }
        string forbiddenSymbols = @"[а-яА-Я]";
        string specialSymbols = @"[!@#$%^&*()_]";
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (LoginInputAdmin.Text == null)
                errors.AppendLine("Логин не может быть пустым.");
            if (LoginInputAdmin.Text.Length < 4)
                errors.AppendLine("Логин не может быть короче 4-х символов.");
            if (Regex.IsMatch(LoginInputAdmin.Text, forbiddenSymbols) == true)
                errors.AppendLine("Используйте латиницу.");
            if (addUser == 1)
                if (AstronomyClassDBEntities.GetContext().Users.FirstOrDefault(p => p.login == LoginInputAdmin.Text) != null)
                    errors.AppendLine("Такой пользователь уже существует.");


            if (PasswordInputAdmin.Text == null)
                errors.AppendLine("Пароль не может быть пустым.");
            if (PasswordInputAdmin.Text.Length < 4)
                errors.AppendLine("Пароль не может быть короче 4-х символов.");
            if (Regex.IsMatch(PasswordInputAdmin.Text, forbiddenSymbols) == true)
                errors.AppendLine("Используйте латиницу.");
            if (Regex.IsMatch(PasswordInputAdmin.Text, specialSymbols) == false)
                errors.AppendLine("Используйте специальные символы.");

            if (LastNameInputAdmin.Text.Length == 0)
                errors.AppendLine("Заполните поле фамилия.");
            if (FirstNameInputAdmin.Text.Length == 0)
                errors.AppendLine("Заполните поле имя.");

            if (NumberPhoneAdmin.Text == null || NumberPhoneAdmin.Text == "X XXX XXX-XX-XX")
                errors.AppendLine("Номер телефона не может быть пустым.");
            if (Regex.IsMatch(NumberPhoneAdmin.Text, @"[a-zA-Zа-яА-Я]") == true)
                errors.AppendLine("Используйте только цифры, а также разделитель -");
            if (!Regex.IsMatch(NumberPhoneAdmin.Text, @"\d{1} \d{3} \d{3}-\d{2}-\d{2}"))
                errors.AppendLine("Используйте указанный формат. X XXX XXX-XX-XX");
            if (addUser == 1)
                if (AstronomyClassDBEntities.GetContext().Users.FirstOrDefault(p => p.number_phone == NumberPhoneAdmin.Text) != null)
                    errors.AppendLine("Такой номер телефона уже используется.");

            if (EducationalInputAdmin.Text == null || EducationalInputAdmin.Text == "Название и город")
                errors.AppendLine("Поле 'учебное учреждение' не может быть пустым.");
            if (EducationalInputAdmin.Text.Length < 3)
                errors.AppendLine("Название учебного учреждения не может быть короче 3-х символов.");

            if (ClassSelectAdmin.SelectedItem == null)
                errors.AppendLine("Выберите класс.");

            if (RoleSelectAdmin.SelectedItem == null)

            if (Code.Text.Length != 6)
                errors.AppendLine("Длина кода должна равняться 6.");

            if (SelectedActiveAdmin.SelectedIndex == 0)
                currentUser.active = true;
            else
                currentUser.active = false;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }    

            if (currentUser.id == 0)
                AstronomyClassDBEntities.GetContext().Users.Add(currentUser);


            try
            {
                currentUser.restore_code = Code.Text;
                AstronomyClassDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены.");
                Manager.AdminLoadPage.GoBack();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        Random rnd = new Random();
        string[] letters = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S",
                                          "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B",
                                          "N", "M", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        const int maxLenghtCode = 6;
        string code = null;
        private void GenerateCode_Click(object sender, RoutedEventArgs e)
        {
            for (int index = 0; index < maxLenghtCode; index++)
            {
                code += letters[rnd.Next(0, letters.Length)];
            }
            Code.Text = code;
        }
    }
}
