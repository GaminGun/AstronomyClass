using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AstronomyClassTest
{
    /// <summary>
    /// Логика взаимодействия для PassingTest.xaml
    /// </summary>
    public partial class PassingTest : Page
    {
        Users user;
        Tests test;
        public PassingTest(Users user, Tests test)
        {
            InitializeComponent();
            this.user = user;
            this.test = test;
            min = test.time;
            TimerStart();

            Manager.OutputQuestions = OutputQuestion;
            Manager.OutputQuestions.Navigate(new OutputQuestionOnPage(user, test));

        }

        DispatcherTimer timer = null;
        int min = 0, sec = 1;
        public void TimerStart()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }
        void TimerTick(object sender, EventArgs e)
        {
            sec--;
            if (sec == 0)
            {
                sec = 59;
                min--;
            }

            if (Time.Text == "00:01")
            {
                Time.Text = "00:00";
                timer.Stop();

                for (int i = 0; i < Manager.ListQuestions.Count; i++)
                    if (Manager.UserAnswer.Count != Manager.ListQuestions.Count)
                        Manager.UserAnswer.Add(0);
                for (int index = 0; index < Manager.UserAnswer.Count; index++)
                    if (Manager.ListQuestions[index].true_answer == Manager.UserAnswer[index])
                        Manager.TrueAnswer++;
                Marks newMark = new Marks();
                int percent = (Manager.TrueAnswer * 100) / Manager.CountQuestions;
                if (percent >= 85)
                    newMark.mark = 5;
                else if (percent >= 70)
                    newMark.mark = 4;
                else if (percent >= 50)
                    newMark.mark = 3;
                else
                    newMark.mark = 2;

                newMark.id_test = test.id;
                newMark.id_student = user.id;
                newMark.finish_date = DateTime.Now;
                try
                {
                    MessageBox.Show($"Время закончилось.\nТест завершён.\nВаша оценка: {newMark.mark}\nПроцент правильных ответов: {percent}%");
                    AstronomyClassDBEntities.GetContext().Marks.Add(newMark);
                    AstronomyClassDBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                Manager.TrueAnswer = 0;
                Manager.NumberQuestion = 0;
                Manager.ListQuestions = null;
                Manager.UserAnswer = null;
                Manager.MainLoadPage.RemoveBackEntry();
                Manager.MainLoadPage.Navigate(new OutputArticlesPage(user));
            }

            TimeOutput(min, sec);
        }
        void TimeOutput(int min, int sec)
        {
            string _min, _sec;
            if (sec < 10)
                _sec = $"0{sec}";
            else
                _sec = $"{sec}";

            if (min < 10)
                _min = $"0{min}";
            else
                _min = $"{min}";

            Time.Text = $"{_min}:{_sec}";
        }
    }
}
