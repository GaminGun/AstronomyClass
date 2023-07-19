using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        Users editUser = new Users();
        MainInterfaceOutputWin main;
        public EditUser(Users user, MainInterfaceOutputWin main)
        {
            InitializeComponent();
            editUser = user;

            this.main = main;

            DataContext = editUser;
            SelectedClassForUser.ItemsSource = AstronomyClassDBEntities.GetContext().Classes.ToList();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainLoadPage.GoBack();
        }
        string forbiddenSymbolsRus = @"[а-яА-Я]";
        string forbiddenSymbolsEng = @"[a-zA-Z]";
        string specialSymbols = @"[!@#$%^&*()_]";
        private void SaveUserProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (OldPasswordInput.Password != "" && NewPasswordInput.Password != "")
            {
                if (OldPasswordInput.Password == editUser.password)
                {
                    if (NewPasswordInput.Password == null)
                        errors.AppendLine("Пароль не может быть пустым.");
                    if (NewPasswordInput.Password.Length < 4)
                        errors.AppendLine("Пароль не может быть короче 4-х символов.");
                    if (Regex.IsMatch(NewPasswordInput.Password, forbiddenSymbolsRus) == true)
                        errors.AppendLine("Используйте латиницу.");
                    if (Regex.IsMatch(NewPasswordInput.Password, specialSymbols) == false)
                        errors.AppendLine("Используйте специальные символы.");
                }
                else
                {
                    MessageBox.Show("Текущий пароль введён не верно.");
                    errors.AppendLine("Неверный пароль.");
                }
            }
            

            if (LastNameInput.Text == "")
                errors.AppendLine("Фамилия не может быть пустой.");
            if (LastNameInput.Text.Length < 3)
                errors.AppendLine("Фамилия не может быть короче 3-х символов.");
            if (Regex.IsMatch(LastNameInput.Text, forbiddenSymbolsEng) == true)
                errors.AppendLine("Используйте кириллицу");

            if (FirstNameInput.Text == "")
                errors.AppendLine("Имя не может быть пустой.");
            if (FirstNameInput.Text.Length < 2)
                errors.AppendLine("Имя не может быть короче 2-х символов.");
            if (Regex.IsMatch(FirstNameInput.Text, forbiddenSymbolsEng) == true)
                errors.AppendLine("Используйте кириллицу");

            if (SurnameInput.Text != "")
            {
                if (SurnameInput.Text.Length < 3)
                    errors.AppendLine("Отчество не может быть короче 3-х символов.");
                if (Regex.IsMatch(SurnameInput.Text, forbiddenSymbolsEng) == true)
                    errors.AppendLine("Используйте кириллицу");
            }
            

            if (NumberPhone.Text == "")
                errors.AppendLine("Номер телефона не может быть пустым.");
            if (Regex.IsMatch(NumberPhone.Text, @"[a-zA-Zа-яА-Я]") == true)
                errors.AppendLine("Используйте только цифры, а также разделитель -");
            if (!Regex.IsMatch(NumberPhone.Text, @"\d{1} \d{3} \d{3}-\d{2}-\d{2}"))
                errors.AppendLine("Используйте указанный формат. X XXX XXX-XX-XX");
            if (NumberPhone.Text != editUser.number_phone)
                if (AstronomyClassDBEntities.GetContext().Users.FirstOrDefault(p => p.number_phone == NumberPhone.Text) != null)
                    errors.AppendLine("Такой номер телефона уже используется.");

            if (EducationalInput.Text == null)
                errors.AppendLine("Поле 'учебное учреждение' не может быть пустым.");
            if (EducationalInput.Text.Length < 3)
                errors.AppendLine("Название учебного учреждения не может быть короче 3-х символов.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if (NewPasswordInput.Password != "")
                    editUser.password = NewPasswordInput.Password;
                AstronomyClassDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены.");
                main.UserLoginShortInfo.ItemsSource = AstronomyClassDBEntities.GetContext().Users.Where(p => p.id == editUser.id).ToList();
                Manager.MainLoadPage.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void UploadAvatarUser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.bmp)|*.bmp|(All Files)|*.*";
            if (openImage.ShowDialog() == true)
            {
                if (openImage.FileName.Contains(".png") || openImage.FileName.Contains(".jpg") || openImage.FileName.Contains(".bmp"))
                    editUser.user_avatar = File.ReadAllBytes(openImage.FileName);
                else MessageBox.Show("Загрузите изображение.");
            }
        }
    }
}
