using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AstronomyClassTest
{
    internal class Manager
    {
        public static Frame MainLoadPage { get; set; }
        public static Frame AdminLoadPage { get; set; }
        public static Frame OutputQuestions { get; set; }

        public static int NumberQuestion = 0;
        public static int TrueAnswer = 0;
        public static int CountQuestions = 0;
        public static List<Questions> ListQuestions { get; set; }
        public static List<int> UserAnswer { get; set; }
    }
}
