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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Articles = new HashSet<Articles>();
            this.Marks = new HashSet<Marks>();
        }
    
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public Nullable<System.DateTime> date_birthday { get; set; }
        public string number_phone { get; set; }
        public string educational_institution { get; set; }
        public int id_class { get; set; }
        public int id_role { get; set; }
        public byte[] user_avatar { get; set; }
        public string restore_code { get; set; }
        public bool active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Articles> Articles { get; set; }
        public virtual Classes Classes { get; set; }
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marks> Marks { get; set; }
    }
}