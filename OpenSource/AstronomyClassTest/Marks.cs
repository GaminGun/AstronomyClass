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
    
    public partial class Marks
    {
        public int id { get; set; }
        public int id_student { get; set; }
        public int id_test { get; set; }
        public short mark { get; set; }
        public System.DateTime finish_date { get; set; }
    
        public virtual Tests Tests { get; set; }
        public virtual Users Users { get; set; }
    }
}
