//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCentre
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sotrudniki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudniki()
        {
            this.Arenda = new HashSet<Arenda>();
        }
    
        public int ID_Sotrudnik { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string fathername { get; set; }
        public string Gender { get; set; }
        public string Telephone_Number { get; set; }
        public string Role { get; set; }
        public string Login_Employee { get; set; }
        public string Password_Employee { get; set; }
        public byte[] Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arenda> Arenda { get; set; }
    }
}
