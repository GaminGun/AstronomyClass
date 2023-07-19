using System;
using System.Windows;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для GenerateRestoreCodeWin.xaml
    /// </summary>
    public partial class GenerateRestoreCodeWin : Window
    {
        Users user;
        public GenerateRestoreCodeWin(Users user)
        {
            InitializeComponent();
            this.user = user;
            GenerateCode();
        }
        Random rnd = new Random();
        string[] letters = new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S",
                                          "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B",
                                          "N", "M", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        const int maxLenghtCode = 6;
        string code = null;
        void GenerateCode()
        {
            for (int index = 0; index < maxLenghtCode; index++)
            {
                code += letters[rnd.Next(0, letters.Length)];
            }
            ViewCode.Text = code;
            user.restore_code = code;
        }

        private void SaveCodeUserBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AstronomyClassDBEntities())
            {
                db.Users.Add(user);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрированы.");
                    this.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
