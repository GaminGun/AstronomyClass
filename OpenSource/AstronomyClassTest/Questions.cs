//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AstronomyClassTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questions
    {
        public int id { get; set; }
        public int id_test { get; set; }
        public string question { get; set; }
        public string answer_1 { get; set; }
        public string answer_2 { get; set; }
        public string answer_3 { get; set; }
        public string answer_4 { get; set; }
        public int true_answer { get; set; }
    
        public virtual Tests Tests { get; set; }
    }
}
